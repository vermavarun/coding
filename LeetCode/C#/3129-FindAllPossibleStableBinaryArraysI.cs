/*
Title: 3129. Find All Possible Stable Binary Arrays I
Solution: https://leetcode.com/problems/find-all-possible-stable-binary-arrays-i/solutions/7637253/simplest-solution-c-time-omn-space-omn-p-lely/
Difficulty: Medium
Approach: Dynamic Programming with state tracking (digit count and last digit)
Tags: Dynamic Programming, Array, Combinatorics
1) Define dp[i,j,k] as count of stable arrays with i zeros, j ones, ending with digit k (0 or 1).
2) Initialize base cases: arrays with only zeros (up to limit) or only ones (up to limit).
3) For each state (i zeros, j ones), calculate dp values for ending with 0 or 1.
4) To add a zero: take all arrays with (i-1) zeros and j ones, subtract invalid cases where more than limit consecutive zeros.
5) To add a one: take all arrays with i zeros and (j-1) ones, subtract invalid cases where more than limit consecutive ones.
6) Use modulo arithmetic to handle large numbers.
7) Final answer is sum of stable arrays ending with 0 or 1.

Time Complexity: O(zero * one) - fill dp table with zero * one states
Space Complexity: O(zero * one) - 3D dp array with dimensions [zero+1][one+1][2]
Tip: The key insight is tracking what the array ends with to ensure no more than 'limit' consecutive same digits. Use prefix sum technique by subtracting invalid states where we exceed the consecutive limit.
Similar Problems: 600. Non-negative Integers without Consecutive Ones, 1621. Number of Sets of K Non-Overlapping Line Segments, 2463. Minimum Total Distance Traveled
*/
public class Solution
{
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        const int MOD = 1_000_000_007;                          // Modulo constant for large number handling

        // dp[i,j,k] -> i zeros, j ones, ending with k (0 or 1)
        long[,,] dp = new long[zero + 1, one + 1, 2];           // 3D DP array: [zeros count][ones count][last digit]

        for (int i = 0; i <= Math.Min(zero, limit); i++)        // Initialize base case: arrays with only zeros
            dp[i, 0, 0] = 1;                                    // i zeros, 0 ones, ending with 0 - valid if i <= limit

        for (int j = 0; j <= Math.Min(one, limit); j++)         // Initialize base case: arrays with only ones
            dp[0, j, 1] = 1;                                    // 0 zeros, j ones, ending with 1 - valid if j <= limit

        for (int i = 1; i <= zero; i++)                         // Iterate through all possible zero counts
        {
            for (int j = 1; j <= one; j++)                      // Iterate through all possible one counts
            {
                dp[i, j, 0] =                                   // Calculate stable arrays with i zeros, j ones, ending with 0
                    (dp[i - 1, j, 0] +                          // Add one more zero to arrays ending with 0
                     dp[i - 1, j, 1] -                          // Add first zero to arrays ending with 1
                     (i - limit < 1 ? 0 : dp[i - limit - 1, j, 1]) + // Subtract invalid: more than limit consecutive zeros
                     MOD) % MOD;                                // Apply modulo to keep result within bounds

                dp[i, j, 1] =                                   // Calculate stable arrays with i zeros, j ones, ending with 1
                    (dp[i, j - 1, 0] +                          // Add first one to arrays ending with 0
                     dp[i, j - 1, 1] -                          // Add one more one to arrays ending with 1
                     (j - limit < 1 ? 0 : dp[i, j - limit - 1, 0]) + // Subtract invalid: more than limit consecutive ones
                     MOD) % MOD;                                // Apply modulo to keep result within bounds
            }
        }

        return (int)((dp[zero, one, 0] + dp[zero, one, 1]) % MOD); // Sum of stable arrays ending with 0 or 1, return as int
    }
}