/*
Title: 70. Climbing Stairs
Solution: https://leetcode.com/problems/climbing-stairs/solutions/6318685/simplest-solution-c-time-on-spacen-pleas-yv1s
Difficulty: Easy
Approach: Top-Down Dynamic Programming with Memoization (Recursion)
Tags: Math, Dynamic Programming, Memoization, Recursion
1) Initialize a dp array of size n+1 with all values set to -1 (uncomputed state).
2) Handle base cases: n == 0 returns 1 (one way to stay at ground), n < 0 returns 0 (invalid).
3) Check if dp[n] has been computed (!= -1), if yes return cached result.
4) Recursively compute: ways(n) = ways(n-1) + ways(n-2).
5) Store result in dp[n] before returning to avoid recomputation.
6) The problem reduces to Fibonacci sequence: F(n) = F(n-1) + F(n-2).

Time Complexity: O(n) - each subproblem computed once
Space Complexity: O(n) - dp array + recursion call stack
Tip: This is essentially computing Fibonacci numbers! At step n, you can arrive from (n-1) with 1 step or from (n-2) with 2 steps.
*/
public class Solution {
    public int ClimbStairs(int n) {
        if (n == 0) {                                                   // Base case: reached the top (ground level)
            return 1;                                                   // One way to stay at ground level
        }
        if (n < 0) {                                                    // Base case: overshot the target
            return 0;                                                   // No valid way if we go negative
        }
        int[] dp = new int[n + 1];                                      // Memoization array for storing computed results
        for (int i = 0; i < dp.Length; i++) {                           // Initialize all positions
            dp[i] = -1;                                                 // -1 indicates uncomputed state
        }
        if (dp[n] != -1) {                                              // Check if result already cached (won't happen on first call)
            return dp[n];                                               // Return cached value to avoid recomputation
        }
        return FindClimbStairs(n - 1, dp) + FindClimbStairs(n - 2, dp); // Compute: ways from (n-1) + ways from (n-2)
    }

    public static int FindClimbStairs(int n, int[] dp) {                // Helper function: recursive memoized calculation
        if (n == 0) {                                                   // Base case: reached the top
            return 1;                                                   // One way to be at ground level
        }
        if (n < 0) {                                                    // Base case: overshot
            return 0;                                                   // Invalid path
        }
        if (dp[n] != -1) {                                              // Memoization check: already computed?
            return dp[n];                                               // Return cached result
        }
        dp[n] = FindClimbStairs(n - 1, dp) + FindClimbStairs(n - 2, dp); // Store: ways(n) = ways(n-1) + ways(n-2)
        return dp[n];                                                   // Return computed and cached value
    }
}