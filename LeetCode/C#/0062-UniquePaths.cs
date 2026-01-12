/*
Title: 62. Unique Paths
Solution: https://leetcode.com/problems/unique-paths/solutions/7488732/simplest-solution-c-time-omn-spacemn-ple-gln6/
Difficulty: Medium
Approach: Top-Down Dynamic Programming with Memoization (DFS)
Tags: Math, Dynamic Programming, Combinatorics, Memoization, Recursion
1) Use a 2D memoization array dp[m,n] to cache results for each cell.
2) Start from top-left corner (0,0) and explore paths moving only right or down.
3) Base case 1: If out of bounds (row >= m or col >= n), return 0 (invalid path).
4) Base case 2: If at bottom-right corner (m-1, n-1), return 1 (found a valid path).
5) If already computed, return cached result from dp[row,col].
6) Otherwise, compute paths as sum of moving down (row+1) and moving right (col+1).

Time Complexity: O(m * n) - each cell computed once
Space Complexity: O(m * n) - memoization array + O(m + n) recursion stack depth
Tip: The robot can only move right or down, so paths to any cell = paths from cell above + paths from cell to the left. This is also a combinatorics problem: choosing m-1 downs from m+n-2 total moves = C(m+n-2, m-1).
Similar Problems: 63. Unique Paths II, 64. Minimum Path Sum, 980. Unique Paths III, 1573. Number of Ways to Split a String
*/
public class Solution {

    int[,] dp;                                                      // Memoization array to cache results

    public int UniquePaths(int m, int n) {
        dp = new int[m, n];                                         // Initialize dp array with m rows and n columns
        return Solve(0, 0, m, n);                                   // Start DFS from top-left corner (0,0)
    }

    private int Solve(int row, int col, int m, int n) {

        if (row >= m || col >= n)                                   // If out of grid bounds
            return 0;                                               // Return 0 (invalid path)

        if (row == m - 1 && col == n - 1)                           // If reached bottom-right corner
            return 1;                                               // Return 1 (found valid path)

        if (dp[row, col] != 0)                                      // If result already computed
            return dp[row, col];                                    // Return cached result

        dp[row, col] =                                              // Store sum of paths from both directions
            Solve(row + 1, col, m, n) +                             // Paths by moving down one row
            Solve(row, col + 1, m, n);                              // Paths by moving right one column

        return dp[row, col];                                        // Return total unique paths from this cell
    }
}