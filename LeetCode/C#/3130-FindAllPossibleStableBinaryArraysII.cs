/*
Title: 3130. Find All Possible Stable Binary Arrays II
Solution: https://leetcode.com/problems/find-all-possible-stable-binary-arrays-ii/solutions/7638897/simplest-solution-c-time-omn-space-omn-p-k2us/
Difficulty: Hard
Approach: Dynamic Programming with State Tracking and Sliding Window Optimization
Tags: Dynamic Programming, Array, Combinatorics, Math
1) Use 3D DP where dp[i,j,k] represents count of valid arrays with i zeros, j ones, ending with digit k (0 or 1).
2) Initialize base cases: arrays with only zeros (up to limit) or only ones (up to limit) have exactly 1 way.
3) For each position (i,j), calculate ways to place a zero: sum of arrays ending in 0 or 1 from position (i-1,j).
4) Apply limit constraint: subtract invalid configurations where more than 'limit' consecutive zeros would form.
5) Similarly calculate ways to place a one: sum from position (i,j-1).
6) Apply limit constraint for ones: subtract configurations exceeding 'limit' consecutive ones.
7) Use modular arithmetic (MOD = 10^9+7) to prevent overflow and ensure positive results.
8) Final answer is sum of arrays ending in 0 and arrays ending in 1 for the full (zero, one) configuration.

Time Complexity: O(zero * one) - iterate through all positions in 2D grid
Space Complexity: O(zero * one) - 3D DP array with constant third dimension
Tip: The key insight is tracking the last digit (0 or 1) as state to enforce the consecutive limit constraint. Use sliding window subtraction to remove invalid configurations exceeding the limit, similar to prefix sum techniques.
Similar Problems: 1220. Count Vowels Permutation, 2466. Count Ways To Build Good Strings, 935. Knight Dialer, 1248. Count Number of Nice Subarrays
*/
public class Solution
{
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        const int MOD = 1_000_000_007;                              // Modulo constant to prevent overflow

        long[,,] dp = new long[zero + 1, one + 1, 2];              // 3D DP: [zeros used, ones used, last digit (0 or 1)]

        // Base case: Initialize arrays with only zeros (ending in 0)
        for (int i = 0; i <= Math.Min(zero, limit); i++)           // Can't exceed limit consecutive zeros
            dp[i,0,0] = 1;                                          // Exactly 1 way to form array of i zeros

        // Base case: Initialize arrays with only ones (ending in 1)
        for (int j = 0; j <= Math.Min(one, limit); j++)            // Can't exceed limit consecutive ones
            dp[0,j,1] = 1;                                          // Exactly 1 way to form array of j ones

        // Fill DP table for all combinations of zeros and ones
        for (int i = 1; i <= zero; i++)                            // For each count of zeros
        {
            for (int j = 1; j <= one; j++)                          // For each count of ones
            {
                // Calculate ways to end with 0: add 0 to arrays ending in 0 or 1
                long val0 = dp[i-1,j,0] + dp[i-1,j,1];              // Sum of both previous states (ending in 0 or 1)

                // Subtract invalid cases: more than 'limit' consecutive zeros
                if (i - limit - 1 >= 0)                             // If we have enough zeros to violate limit
                    val0 -= dp[i-limit-1,j,1];                      // Remove configurations with (limit+1) consecutive zeros

                dp[i,j,0] = (val0 % MOD + MOD) % MOD;               // Apply modulo and ensure positive result

                // Calculate ways to end with 1: add 1 to arrays ending in 0 or 1
                long val1 = dp[i,j-1,0] + dp[i,j-1,1];              // Sum of both previous states (ending in 0 or 1)

                // Subtract invalid cases: more than 'limit' consecutive ones
                if (j - limit - 1 >= 0)                             // If we have enough ones to violate limit
                    val1 -= dp[i,j-limit-1,0];                      // Remove configurations with (limit+1) consecutive ones

                dp[i,j,1] = (val1 % MOD + MOD) % MOD;               // Apply modulo and ensure positive result
            }
        }

        // Return sum of all valid arrays ending in 0 or 1
        return (int)((dp[zero,one,0] + dp[zero,one,1]) % MOD);      // Final count of all stable binary arrays
    }
}