/*
Title: 3640. Trionic Array II
Solution: https://leetcode.com/problems/trionic-array-ii/solutions/7550905/simplest-solution-c-time-on-space-on-ple-9e6r/
Difficulty: Hard
Approach: Dynamic Programming with Memoization and State Tracking
Tags: Array, Dynamic Programming, Recursion, Memoization
1) Initialize memoization table to track subproblems with dimensions [n, 4].
2) Use state variable 'trend' to track trionic sequence progress (0=not started, 1=increasing, 2=decreasing, 3=complete).
3) For each position, decide whether to take or skip the current element.
4) Validate transitions based on current trend and relationship with next element.
5) If trend == 0: Can skip or start increasing sequence if next > current.
6) If trend == 1 (increasing): Continue increasing or switch to decreasing if next < current.
7) If trend == 2 (decreasing): Continue decreasing or complete trionic if next > current.
8) If trend == 3 (complete): Can take any remaining increasing elements.
9) Return maximum sum possible, or NEG_INF if trionic sequence cannot be formed.

Time Complexity: O(n) where n = nums.length, with each state visited once
Space Complexity: O(n) for the memoization table
Tip: The key insight is tracking the trionic state machine with 4 states. Use NEG_INF as sentinel for impossible states and distinguish it from UNVISITED for memoization. This prevents taking incomplete sequences.
Similar Problems: 300. Longest Increasing Subsequence, 376. Wiggle Subsequence, 152. Maximum Product Subarray
*/
public class Solution {
    int n;                                                          // Length of input array
    long[,] memo;                                                   // Memoization table: [position, trend]

    const long NEG_INF = -(1L << 60);                               // Safe negative infinity (avoid long.MinValue crash)
    const long UNVISITED = long.MinValue;                           // Sentinel value for unvisited states

    public long MaxSumTrionic(int[] nums) {
        n = nums.Length;                                            // Store array length
        memo = new long[n, 4];                                      // Create memo table for n positions and 4 trends

        for (int i = 0; i < n; i++) {                               // Initialize memoization table
            for (int j = 0; j < 4; j++)                             // For each trend state
                memo[i, j] = UNVISITED;                             // Mark as unvisited
        }

        return Solve(0, 0, nums);                                   // Start recursion from position 0, trend 0
    }

    long Solve(int i, int trend, int[] nums) {
        if (i == n) {                                               // Base case: reached end of array
            return (trend == 3) ? 0 : NEG_INF;                      // Valid only if trionic sequence complete
        }

        if (memo[i, trend] != UNVISITED)                            // If already computed
            return memo[i, trend];                                  // Return memoized result

        long take = NEG_INF;                                        // Initialize take option as impossible
        long skip = NEG_INF;                                        // Initialize skip option as impossible

        if (trend == 0) {                                           // If sequence not started yet
            skip = Solve(i + 1, 0, nums);                           // Can skip current element
        }

        if (trend == 3) {                                           // If trionic sequence already complete
            take = nums[i];                                         // Can take any remaining element
        }

        if (i + 1 < n) {                                            // If there's a next element to compare
            int curr = nums[i];                                     // Current element value
            int next = nums[i + 1];                                 // Next element value

            if (trend == 0 && next > curr) {                        // Start increasing phase
                take = Math.Max(take, curr + Solve(i + 1, 1, nums));  // Take current and move to increasing
            }
            else if (trend == 1) {                                  // In increasing phase
                if (next > curr)                                    // Continue increasing
                    take = Math.Max(take, curr + Solve(i + 1, 1, nums));
                else if (next < curr)                               // Switch to decreasing
                    take = Math.Max(take, curr + Solve(i + 1, 2, nums));
            }
            else if (trend == 2) {                                  // In decreasing phase
                if (next < curr)                                    // Continue decreasing
                    take = Math.Max(take, curr + Solve(i + 1, 2, nums));
                else if (next > curr)                               // Complete trionic and start new increasing
                    take = Math.Max(take, curr + Solve(i + 1, 3, nums));
            }
            else if (trend == 3 && next > curr) {                   // After trionic complete, continue increasing
                take = Math.Max(take, curr + Solve(i + 1, 3, nums));
            }
        }

        memo[i, trend] = Math.Max(take, skip);                      // Store maximum of take or skip
        return memo[i, trend];                                      // Return memoized result
    }
}
