/*
Title: 3643. Flip Square Submatrix Vertically
Solution: https://leetcode.com/problems/flip-square-submatrix-vertically/solutions/7677435/simplest-solution-c-time-ok2-space-o1-pl-5ewo/
Difficulty: Easy
Approach: Two-pointer row swapping within submatrix
Tags: Array, Matrix, Two Pointers
1) Initialize two pointers - top at starting row (x) and bottom at ending row (x + k - 1).
2) While top pointer is less than bottom pointer, swap rows.
3) For each pair of rows to swap, iterate through all columns in the k x k submatrix.
4) Swap elements at positions grid[top][col] and grid[bottom][col] for each column.
5) Move top pointer down and bottom pointer up after each complete row swap.
6) Continue until pointers meet in the middle (all rows are flipped).

Time Complexity: O(k²) where k is the size of the square submatrix - we process k/2 pairs of rows, each with k elements
Space Complexity: O(1) - only uses a single temp variable for swapping, modifies grid in-place
Tip: This is a classic two-pointer approach for reversing. Start from both ends (top and bottom rows) and work towards the middle, swapping entire rows element by element within the specified submatrix boundaries.
Similar Problems: 48. Rotate Image, 73. Set Matrix Zeroes, 867. Transpose Matrix, 2022. Convert 1D Array Into 2D Array
*/
public class Solution {
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k) {

        int top = x;                                            // Initialize top pointer at starting row
        int bottom = x + k - 1;                                 // Initialize bottom pointer at ending row

        // Flip rows within the k x k submatrix
        while (top < bottom) {                                  // Continue while pointers haven't crossed

            for (int col = y; col < y + k; col++) {             // Iterate through all columns in the submatrix
                int temp = grid[top][col];                      // Store top row element temporarily
                grid[top][col] = grid[bottom][col];             // Copy bottom row element to top row
                grid[bottom][col] = temp;                       // Copy temp (original top) to bottom row
            }

            top++;                                              // Move top pointer down one row
            bottom--;                                           // Move bottom pointer up one row
        }

        return grid;                                            // Return modified grid with flipped submatrix
    }
}