/*
Title: 48. Rotate Image
Solution: https://leetcode.com/problems/rotate-image/solutions/8135495/simplest-solution-c-time-on2-space-o1-pl-szzb/
Difficulty: Medium
Approach: Transpose + Reverse Rows (In-Place)
Tags: Array, Math, Matrix
1) Transpose the matrix in-place: swap matrix[i][j] with matrix[j][i] for all j > i.
2) Reverse each row in-place using two pointers (left and right).
3) These two steps together produce a 90-degree clockwise rotation.

Time Complexity: O(n^2) where n = matrix side length (every cell is visited a constant number of times)
Space Complexity: O(1) — rotation is done entirely in-place with only a temp variable
Tip: A 90-degree clockwise rotation equals transpose followed by horizontal flip (reverse each row). A counter-clockwise rotation would be reverse each row first, then transpose.
Similar Problems: 54. Spiral Matrix, 73. Set Matrix Zeroes, 289. Game of Life
*/
public class Solution {
    public void Rotate(int[][] matrix) {

        int rows = matrix.Length;                       // Number of rows (equals columns for a square matrix)
        int columns = matrix[0].Length;                 // Number of columns

        // Flip transpose
        for (int i=0; i<rows; i++) {                    // Iterate over each row
            for (int j=i; j<columns; j++) {             // Start j at i to avoid swapping twice
                int temp = matrix[i][j];                // Save current cell value
                matrix[i][j] = matrix[j][i];            // Replace with the mirrored cell
                matrix[j][i] = temp;                    // Place saved value in mirrored position
            }
        }

        // Reverse rows
        for(int i=0; i<rows; i++) {                     // Iterate over each row
            int left = 0;                               // Left pointer starts at beginning of row
            int right = columns - 1;                    // Right pointer starts at end of row
            while(left<right) {                         // Swap until pointers meet in the middle
                int temp = matrix[i][left];             // Save left element
                matrix[i][left] = matrix[i][right];     // Move right element to left
                matrix[i][right] = temp;                // Place saved element on the right
                left++;                                 // Advance left pointer inward
                right--;                                // Advance right pointer inward
            }
        }
    }
}