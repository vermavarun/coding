/*
Title: 3212. Count Submatrices With Equal Frequency of X and Y
Solution: https://leetcode.com/problems/count-submatrices-with-equal-frequency-of-x-and-y/solutions/7664943/simplest-solution-c-time-omn-space-omn-p-jc6p/
Difficulty: Medium
Approach: 2D Prefix Sum / Dynamic Programming
Tags: Array, Matrix, Prefix Sum, Dynamic Programming
1) Create two 2D arrays to store prefix sums for 'X' and 'Y' counts.
2) Initialize both prefix arrays with dimensions matching the grid.
3) Iterate through each cell in the grid from top-left to bottom-right.
4) For each cell, calculate cumulative count of 'X' and 'Y' from (0,0) to current position.
5) Use inclusion-exclusion principle: current cell + top + left - top-left diagonal.
6) After computing prefix sums for current position, check if counts are equal and at least one X exists.
7) Count all valid submatrices that end at current position as bottom-right corner.

Time Complexity: O(m * n) where m = rows, n = cols
Space Complexity: O(m * n) for two prefix sum arrays
Tip: The key insight is using 2D prefix sums to efficiently count characters in any submatrix ending at position (r,c). By building prefix sums as we iterate, we count all valid submatrices starting from (0,0) in a single pass without nested loops for submatrix checking.
Similar Problems: 304. Range Sum Query 2D - Immutable, 1277. Count Square Submatrices with All Ones, 560. Subarray Sum Equals K, 1314. Matrix Block Sum
*/
public class Solution
{
    public int NumberOfSubmatrices(char[][] grid)
    {
        int rows = grid.Length;                                     // Get total number of rows in grid
        int cols = grid[0].Length;                                  // Get total number of columns in grid

        // Prefix sum for 'X' and 'Y'
        int[][] prefixX = new int[rows][];                          // 2D array to store cumulative count of 'X' characters
        int[][] prefixY = new int[rows][];                          // 2D array to store cumulative count of 'Y' characters

        for (int i = 0; i < rows; i++)                              // Initialize each row of prefix arrays
        {
            prefixX[i] = new int[cols];                             // Allocate space for columns in prefixX
            prefixY[i] = new int[cols];                             // Allocate space for columns in prefixY
        }

        int validSubmatrices = 0;                                   // Counter for submatrices with equal X and Y counts

        for (int r = 0; r < rows; r++)                              // Iterate through each row
        {
            for (int c = 0; c < cols; c++)                          // Iterate through each column
            {
                // Step 1: Current cell contribution
                prefixX[r][c] = (grid[r][c] == 'X') ? 1 : 0;        // Add 1 if current cell is 'X', else 0
                prefixY[r][c] = (grid[r][c] == 'Y') ? 1 : 0;        // Add 1 if current cell is 'Y', else 0

                // Step 2: Add top
                if (r > 0)                                          // If not in first row
                {
                    prefixX[r][c] += prefixX[r - 1][c];             // Add count from cell directly above (vertical accumulation)
                    prefixY[r][c] += prefixY[r - 1][c];             // Add count from cell directly above (vertical accumulation)
                }

                // Step 3: Add left
                if (c > 0)                                          // If not in first column
                {
                    prefixX[r][c] += prefixX[r][c - 1];             // Add count from cell to the left (horizontal accumulation)
                    prefixY[r][c] += prefixY[r][c - 1];             // Add count from cell to the left (horizontal accumulation)
                }

                // Step 4: Remove double-counted top-left
                if (r > 0 && c > 0)                                 // If not in first row or column (avoiding index out of bounds)
                {
                    prefixX[r][c] -= prefixX[r - 1][c - 1];         // Subtract diagonal to fix double-counting (inclusion-exclusion)
                    prefixY[r][c] -= prefixY[r - 1][c - 1];         // Subtract diagonal to fix double-counting (inclusion-exclusion)
                }

                // Step 5: Check condition
                // Equal number of X and Y AND at least one exists
                if (prefixX[r][c] == prefixY[r][c] && prefixX[r][c] > 0)  // If X count equals Y count and at least one X exists
                {
                    validSubmatrices++;                             // Increment count of valid submatrices
                }
            }
        }

        return validSubmatrices;                                    // Return total count of valid submatrices
    }
}