/*
Title: 509. Fibonacci Number
Solution: https://leetcode.com/problems/fibonacci-number/solutions/6318613/simplest-solution-c-time-on-spacen-pleas-w094
Difficulty: Easy
Approach: Multiple Solutions - Iterative DP, Pure Recursion, Recursion with Memoization
Tags: Dynamic Programming, Math, Recursion, Memoization
1) Approach 1 (Iterative DP): Use bottom-up dynamic programming with array.
2) Approach 2 (Pure Recursion): Use simple recursion without optimization.
3) Approach 3 (Memoized Recursion): Use top-down recursion with memoization.

Time Complexity: O(n) for Approach 1 & 3, O(2^n) for Approach 2
Space Complexity: O(n) for array storage (Approach 1 & 3), O(n) recursion stack (Approach 2 & 3)
*/

//////////////////////////////////////////////////////////////////////////////////////////////////////
/// Approach 1: Iterative Dynamic Programming (Bottom-Up)
//////////////////////////////////////////////////////////////////////////////////////////////////////
public class Solution {
    int[] fib = new int[31];                                        // Array to store Fibonacci numbers (max n = 30)
    public int Fib(int n) {

        fib[0] = 0;                                                 // Base case: F(0) = 0
        fib[1] = 1;                                                 // Base case: F(1) = 1
        int i = 0;                                                  // Loop counter

        for (i = 2; i <= n; i++) {                                  // Iterate from 2 to n
            fib[i] = fib[i - 1] + fib[i - 2];                       // F(n) = F(n-1) + F(n-2)
        }
        return fib[n];                                              // Return the nth Fibonacci number
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////
/// Approach 2: Pure Recursion without Memoization (Exponential Time)
//////////////////////////////////////////////////////////////////////////////////////////////////////
public class Solution {
    public int Fib(int n) {
        if (n == 0)                                                 // Base case: F(0) = 0
            return 0;                                               // Return 0 for n = 0
        if (n == 1)                                                 // Base case: F(1) = 1
            return 1;                                               // Return 1 for n = 1
        return Fib(n - 1) + Fib(n - 2);                            // Recursive call: F(n) = F(n-1) + F(n-2)
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////
/// Approach 3: Recursion with Memoization (Top-Down DP)
/*
1) Initialize an array dp of size 31 to store computed Fibonacci numbers.
2) Use -1 as sentinel value to mark uncomputed states.
3) Check memo array before computing to avoid redundant calculations.
4) Store computed values in dp array for future reuse.
5) Recursively compute F(n-1) + F(n-2) with memoization.

Time Complexity: O(n) - each number computed once
Space Complexity: O(n) - dp array + recursion stack
*/
//////////////////////////////////////////////////////////////////////////////////////////////////////
public class Solution {

    public int Fib(int n) {
        if (n == 0)                                                 // Base case: F(0) = 0
            return 0;                                               // Return 0 for n = 0
        if (n == 1)                                                 // Base case: F(1) = 1
            return 1;                                               // Return 1 for n = 1
        int[] dp = new int[31];                                     // Memoization array (max n = 30)
        for (int i = 0; i < dp.Length; i++) {                       // Initialize dp array
            dp[i] = -1;                                             // Mark all positions as uncomputed using -1
        }
        return Solve(n - 1, dp) + Solve(n - 2, dp);                // Compute F(n-1) + F(n-2) with memoization
    }

    public int Solve(int n, int[] dp) {                             // Helper function for memoized recursion
        if (n == 0)                                                 // Base case: F(0) = 0
            return 0;                                               // Return 0 for n = 0
        if (n == 1)                                                 // Base case: F(1) = 1
            return 1;                                               // Return 1 for n = 1
        if (dp[n] != -1) {                                          // If value already computed (memoization check)
            return dp[n];                                           // Return cached value from dp array
        }
        dp[n] = Solve(n - 1, dp) + Solve(n - 2, dp);               // Compute and store F(n) = F(n-1) + F(n-2)
        return dp[n];                                               // Return computed and cached value
    }
}