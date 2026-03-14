/*
Title: 3666. Minimum Operations to Equalize Binary String
Solution: https://leetcode.com/problems/minimum-operations-to-equalize-binary-string/solutions/7612962/simplest-solution-c-time-on2-space-on-pl-0sfb/
Difficulty: Hard
Approach: BFS with State Space Reduction using Parity Optimization
Tags: String, BFS, Bit Manipulation, State Space Search
1) Initialize two sorted sets to track possible zero counts by parity (even/odd).
2) Count initial zeros in the string and remove from visited set.
3) Use BFS starting from initial zero count.
4) For each state, compute range of reachable zero counts after flipping k bits.
5) Only explore states with matching parity (key optimization).
6) Return number of operations when zero count reaches 0.

Time Complexity: O(n²) where n = s.length (in worst case, BFS explores O(n) states, each processing O(n) potential next states)
Space Complexity: O(n) for storing all possible zero counts in sorted sets and BFS queue
Tip: The key insight is that flipping k bits changes the zero count by an even number (from -2k to +k), so we only need to track states by parity. This cuts the state space in half and enables efficient range queries using SortedSet.GetViewBetween().
Similar Problems: 995. Minimum Number of K Consecutive Bit Flips, 1284. Minimum Number of Flips to Convert Binary Matrix to Zero Matrix, 1347. Minimum Number of Steps to Make Two Strings Anagram
*/
public class Solution
{
    public int MinOperations(string s, int k)
    {
        int n = s.Length;                                           // Length of the binary string

        // -------------------------------
        // Step 1: Store all possible zero counts (0..n)
        // separated by parity (even / odd)
        // -------------------------------
        var zeroCountsByParity = new SortedSet<int>[2];              // Array of 2 sorted sets for even/odd parities
        zeroCountsByParity[0] = new SortedSet<int>();                // Set for even parity zero counts
        zeroCountsByParity[1] = new SortedSet<int>();                // Set for odd parity zero counts

        for (int i = 0; i <= n; i++)                                 // Iterate through all possible zero counts (0 to n)
        {
            zeroCountsByParity[i % 2].Add(i);                        // Add to appropriate parity set (even or odd)
        }

        // -------------------------------
        // Step 2: Count initial number of zeros
        // -------------------------------
        int initialZeroCount = 0;                                    // Counter for zeros in initial string
        foreach (char c in s)                                        // Iterate through each character in the string
        {
            if (c == '0')                                            // If character is '0'
                initialZeroCount++;                                  // Increment zero counter
        }

        // Remove initial state so we don't revisit it
        zeroCountsByParity[initialZeroCount % 2].Remove(initialZeroCount);  // Mark initial state as visited by removing it

        // -------------------------------
        // Step 3: BFS Setup
        // -------------------------------
        var queue = new Queue<int>();                                // Queue for BFS to store zero counts
        queue.Enqueue(initialZeroCount);                             // Start BFS from initial zero count

        int operations = 0;                                          // Track number of operations (BFS levels)

        // -------------------------------
        // Step 4: BFS traversal
        // -------------------------------
        while (queue.Count > 0)                                      // Continue while there are states to explore
        {
            int levelSize = queue.Count;                             // Number of states at current BFS level

            for (int i = 0; i < levelSize; i++)                      // Process all states at current level
            {
                int currentZeros = queue.Dequeue();                  // Get next state to process

                // If no zeros remain, we're done
                if (currentZeros == 0)                               // If we've converted all zeros to ones
                    return operations;                               // Return number of operations taken

                // ------------------------------------------
                // Step 5: Compute possible next zero range
                // ------------------------------------------

                // Minimum possible zero count after flip
                int left = currentZeros + k - 2 * Math.Min(currentZeros, k);  // Min zeros after flipping k bits (best case: flip all zeros)

                // Maximum possible zero count after flip
                int right = currentZeros + k - 2 * Math.Max(k - n + currentZeros, 0);  // Max zeros after flipping k bits (worst case: flip all ones)

                // We only look at zero counts with correct parity
                var validSet = zeroCountsByParity[left % 2];         // Get set matching the parity of left (and right, since parity preserved)

                // Collect values to remove after iteration
                var visitedThisRound = new List<int>();              // Temporarily store states visited in this iteration

                // Efficiently get values in range [left, right]
                foreach (int nextZeros in validSet.GetViewBetween(left, right))  // Query sorted set for range in O(log n + m)
                {
                    queue.Enqueue(nextZeros);                        // Add reachable state to BFS queue
                    visitedThisRound.Add(nextZeros);                 // Mark for removal from available states
                }

                // Remove visited states (avoid revisiting)
                foreach (int value in visitedThisRound)              // Iterate through newly visited states
                {
                    validSet.Remove(value);                          // Remove from available states to prevent revisiting
                }
            }

            operations++;                                            // Increment operation count (move to next BFS level)
        }

        return -1;                                                   // Return -1 if target state not reachable (shouldn't happen for valid inputs)
    }
}