/*
Title: 3655. XOR After Range Multiplication Queries II
Solution: https://leetcode.com/problems/xor-after-range-multiplication-queries-ii/solutions/7844669/simplest-solution-c-time-oq-n-sqrtn-spac-75c1
Difficulty: Hard
Approach: Sqrt Decomposition with Difference Array optimization for range multiplication queries
Tags: Array, Bit Manipulation, Math, Sqrt Decomposition, Difference Array, Binary Exponentiation
1) Sqrt Decomposition Strategy:
   - Divide queries into two categories: large step (K >= sqrt(N)) and small step (K < sqrt(N))
   - Large step queries: Process directly (few elements affected, so O(N/K) is fast)
   - Small step queries: Batch process using difference array (many elements affected, needs optimization)
2) For large step queries (K >= sqrt(N)):
   - Iterate through range [left, right] with step K
   - Multiply each affected element by multiplier (with modulo)
3) For small step queries (K < sqrt(N)):
   - Group queries by step size
   - Use difference array technique with multiplicative identity (1 instead of 0)
   - Apply range updates using difference array
   - Propagate multipliers by jumping backward by step size
   - Apply computed multipliers to original array
4) Modular Inverse: Use Fermat's Little Theorem (a^(p-1) ≡ 1 mod p) to compute inverse
5) Final XOR: XOR all modified array elements
6) Return XOR result

Time Complexity: O((Q + N) * sqrt(N)) where Q = queries, N = array length
Space Complexity: O(N) for difference arrays
Tip: Sqrt decomposition splits queries by step size. Large steps affect few elements (process directly), small steps affect many (batch with difference array). The difference array tracks cumulative multipliers efficiently. Use modular inverse (via Fermat's theorem with binary exponentiation) to "undo" multiplication effects at range boundaries. This gives ~1000x speedup over naive O(Q*N) approach for large inputs.
Similar Problems: 3653. XOR After Range Multiplication Queries I, 1310. XOR Queries of a Subarray, 307. Range Sum Query - Mutable, 2906. Construct Product Matrix
*/
public class Solution
{
    // Mod value (prime)
    private const int MOD = 1_000_000_007;                          // Prime modulo for preventing overflow (10^9 + 7)

    /// <summary>
    /// Fast exponentiation (Binary Exponentiation)
    /// Computes (baseValue ^ exponent) % MOD
    /// </summary>
    private long ModPower(long baseValue, long exponent)
    {
        long result = 1;                                            // Initialize result to multiplicative identity
        baseValue %= MOD;                                           // Reduce base to prevent overflow

        while (exponent > 0)                                        // Process all bits of exponent
        {
            // If exponent is odd → multiply result
            if ((exponent & 1) == 1)                                // Check if least significant bit is 1
                result = (result * baseValue) % MOD;                // Multiply result by current base

            // Square the base
            baseValue = (baseValue * baseValue) % MOD;              // Square base for next iteration

            // Divide exponent by 2
            exponent >>= 1;                                         // Right shift to divide by 2 (process next bit)
        }

        return result;                                              // Return (baseValue ^ original_exponent) % MOD
    }

    public int XorAfterQueries(int[] numbers, int[][] queries)
    {
        int length = numbers.Length;                                // Store array length

        // Block size ~ sqrt(N)
        int sqrtBlockSize = (int)Math.Ceiling(Math.Sqrt(length));   // Calculate sqrt(N) for decomposition threshold

        // Group queries where step < sqrt(N)
        Dictionary<int, List<int[]>> groupedByStep = new Dictionary<int, List<int[]>>();  // Map step -> list of queries with that step

        // ------------------------------------------------------------
        // STEP 1: Handle large step (K >= sqrt(N)) directly
        // ------------------------------------------------------------
        foreach (var query in queries)                              // Process each query
        {
            int left = query[0];                                    // Left boundary of range
            int right = query[1];                                   // Right boundary of range
            int step = query[2];                                    // Step size for iteration
            int multiplier = query[3];                              // Multiplier value

            // Large step → fewer updates → process directly
            if (step >= sqrtBlockSize)                              // If step is large (>= sqrt(N))
            {
                for (int index = left; index <= right; index += step)  // Iterate through range with step
                {
                    numbers[index] = (int)((1L * numbers[index] * multiplier) % MOD);  // Multiply element (use long to prevent overflow)
                }
            }
            else                                                    // Step is small (< sqrt(N))
            {
                // Store small step queries for batch processing
                if (!groupedByStep.ContainsKey(step))               // If step not seen before
                    groupedByStep[step] = new List<int[]>();        // Create new list for this step

                groupedByStep[step].Add(query);                     // Add query to list for this step
            }
        }

        // ------------------------------------------------------------
        // STEP 2: Process small step queries using difference array
        // ------------------------------------------------------------
        foreach (var entry in groupedByStep)                        // Process each group of queries with same step
        {
            int step = entry.Key;                                   // Current step size being processed
            List<int[]> stepQueries = entry.Value;                  // All queries with this step size

            // Diff array initialized with multiplicative identity = 1
            long[] diffMultiplier = new long[length];               // Difference array for tracking multipliers
            for (int i = 0; i < length; i++)                        // Initialize all positions
                diffMultiplier[i] = 1;                              // Use 1 as identity for multiplication

            // Apply range updates
            foreach (var query in stepQueries)                      // Process each query in this group
            {
                int left = query[0];                                // Left boundary
                int right = query[1];                               // Right boundary
                int multiplier = query[3];                          // Multiplier value

                // Start multiplying from index = left
                diffMultiplier[left] = (diffMultiplier[left] * multiplier) % MOD;  // Mark start of range effect

                // Compute where effect should stop
                int totalSteps = (right - left) / step;             // Calculate number of steps in range
                int nextIndex = left + (totalSteps + 1) * step;     // Calculate first index after range

                // Apply modular inverse at stopping point
                if (nextIndex < length)                             // If stopping point is within array bounds
                {
                    long inverse = ModPower(multiplier, MOD - 2);   // Compute modular inverse using Fermat's theorem
                    diffMultiplier[nextIndex] = (diffMultiplier[nextIndex] * inverse) % MOD;  // Mark end of range effect
                }
            }

            // --------------------------------------------------------
            // Propagate values using "jump by step"
            // --------------------------------------------------------
            for (int i = 0; i < length; i++)                        // Propagate multipliers through array
            {
                if (i - step >= 0)                                  // If there's a predecessor at distance 'step'
                {
                    diffMultiplier[i] = (diffMultiplier[i] * diffMultiplier[i - step]) % MOD;  // Accumulate multiplier from predecessor
                }
            }

            // --------------------------------------------------------
            // Apply computed multipliers to original array
            // --------------------------------------------------------
            for (int i = 0; i < length; i++)                        // Apply all multipliers to original array
            {
                numbers[i] = (int)((1L * numbers[i] * diffMultiplier[i]) % MOD);  // Multiply element by accumulated multiplier
            }
        }

        // ------------------------------------------------------------
        // STEP 3: Compute final XOR of array
        // ------------------------------------------------------------
        int finalXor = 0;                                           // Initialize XOR result to 0 (identity)
        foreach (int value in numbers)                              // Iterate through all modified elements
        {
            finalXor ^= value;                                      // XOR current element with accumulated result
        }

        return finalXor;                                            // Return final XOR of all elements
    }
}