/*
Title: 63. Unique Paths II
Solution: https://leetcode.com/problems/unique-paths-ii/solutions/7489200/simplest-solution-c-time-omn-spacemn-ple-edy2/
Difficulty: Medium
Approach: Top-Down Dynamic Programming with Memoization (DFS)
Tags: Array, Dynamic Programming, Matrix, Memoization, Recursion
1) Use a 2D memoization array dp[rows,columns] to cache results for each cell.
2) Start from top-left corner (0,0) and explore paths moving only right or down.
3) Base case 1: If out of bounds or obstacle (obstacleGrid[i][j]==1), return 0 (invalid path).
4) Base case 2: If at bottom-right corner (rows-1, columns-1), return 1 (found a valid path).
5) If already computed, return cached result from dp[i,j].
6) Otherwise, compute paths as sum of moving right (j+1) and moving down (i+1).

Time Complexity: O(m * n) where m = rows, n = columns - each cell computed once
Space Complexity: O(m * n) - memoization array + O(m + n) recursion stack depth
Tip: This is Unique Paths I with obstacles! The key difference is checking obstacleGrid[i][j]==1 in the base case. An obstacle blocks all paths through that cell, making it return 0. Remember to check if start or end positions have obstacles!
Similar Problems: 62. Unique Paths, 64. Minimum Path Sum, 980. Unique Paths III, 1594. Maximum Non Negative Product in a Matrix
*/
public class Solution {
    int[,] dp;                                                      // Memoization array to cache results
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int rows = obstacleGrid.Length;                             // Number of rows in the grid
        int columns = obstacleGrid[0].Length;                       // Number of columns in the grid
        dp = new int[rows,columns];                                 // Initialize dp array with grid dimensions
        return Solve(0,0,obstacleGrid);                             // Start DFS from top-left corner (0,0)
    }

    private int Solve(int i, int j, int[][] obstacleGrid) {
        int rows = obstacleGrid.Length;                             // Number of rows in the grid
        int columns = obstacleGrid[0].Length;                       // Number of columns in the grid

        if (i>= rows || j >= columns || obstacleGrid[i][j]==1)     // If out of bounds or obstacle found
            return 0;                                               // Return 0 (invalid path)

        if (i == rows-1 && j== columns-1)                           // If reached bottom-right corner
            return 1;                                               // Return 1 (found valid path)

        if (dp[i,j]!=0)                                             // If result already computed
            return dp[i,j];                                         // Return cached result

        int right = Solve(i,j+1,obstacleGrid);                      // Calculate paths by moving right one column
        int down = Solve(i+1,j,obstacleGrid);                       // Calculate paths by moving down one row

        return dp[i,j] = right+down;                                // Store and return total unique paths from this cell
    }
}