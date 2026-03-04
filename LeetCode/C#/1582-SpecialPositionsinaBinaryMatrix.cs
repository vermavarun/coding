/*
Title: 1582. Special Positions in a Binary Matrix
Solution: https://leetcode.com/problems/special-positions-in-a-binary-matrix/solutions/7624206/simplest-solution-c-time-om-n-space-om-n-z78b/
Difficulty: Easy
Approach: Row and Column Counting
Tags: Array, Matrix
1) Calculate and store the count of 1s in each row.
2) Calculate and store the count of 1s in each column.
3) Iterate through all cells in the matrix.
4) For each cell with value 1, check if its row has exactly one 1 and its column has exactly one 1.
5) If both conditions are met, increment the special position counter.
6) Return the total count of special positions.

Time Complexity: O(m * n) where m = number of rows, n = number of columns
Space Complexity: O(m + n) for the row and column count arrays
Tip: The key insight is to precompute the counts of 1s in each row and column in the first pass, then use these counts in the second pass to identify special positions. This avoids repeatedly counting 1s for each position.
Similar Problems: 36. Valid Sudoku, 73. Set Matrix Zeroes, 289. Game of Life, 766. Toeplitz Matrix
*/
public class Solution {
    public int NumSpecial(int[][] mat) {

        int rows = mat.Length;                                      // Get total number of rows in matrix
        int cols = mat[0].Length;                                   // Get total number of columns in matrix

        // Store count of 1s in each row
        int[] rowCount = new int[rows];                             // Array to track count of 1s per row

        // Store count of 1s in each column
        int[] colCount = new int[cols];                             // Array to track count of 1s per column

        // Step 1: Count number of 1s in every row and column
        for (int r = 0; r < rows; r++) {                            // Iterate through each row
            for (int c = 0; c < cols; c++) {                        // Iterate through each column
                if (mat[r][c] == 1) {                               // If current cell contains 1
                    rowCount[r]++;                                  // Increment count for current row
                    colCount[c]++;                                  // Increment count for current column
                }
            }
        }

        int result = 0;                                             // Initialize special position counter

        // Step 2: Check each cell again
        for (int r = 0; r < rows; r++) {                            // Iterate through each row
            for (int c = 0; c < cols; c++) {                        // Iterate through each column

                // A position is special if:
                // 1. Cell value is 1
                // 2. That row has exactly one 1
                // 3. That column has exactly one 1
                if (mat[r][c] == 1 && rowCount[r] == 1 && colCount[c] == 1) {  // Check all three conditions
                    result++;                                       // Increment count of special positions
                }
            }
        }

        return result;                                              // Return total count of special positions
    }
}