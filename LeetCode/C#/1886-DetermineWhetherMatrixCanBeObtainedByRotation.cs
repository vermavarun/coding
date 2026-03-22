/*
Title: 1886. Determine Whether Matrix Can Be Obtained By Rotation
Solution: https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/solutions/7679619/simplest-solution-c-time-on2-space-on2-p-io3t/
Difficulty: Easy
Approach: Matrix Rotation with Comparison
Tags: Array, Matrix
1) Get the size of the matrix (it's always n x n).
2) Try all 4 possible rotations (0°, 90°, 180°, 270°).
3) Before each rotation, check if current matrix equals target.
4) If equal at any rotation, return true.
5) Rotate the matrix 90 degrees clockwise in-place.
6) After all 4 rotations, if no match found, return false.

Time Complexity: O(n²) where n is the size of the matrix (we check equality and rotate, both O(n²))
Space Complexity: O(1) as rotation is done in-place
Tip: A matrix rotated 4 times by 90° returns to original position. Use transpose + reverse rows for efficient 90° clockwise rotation.
Similar Problems: 48. Rotate Image, 867. Transpose Matrix, 1380. Lucky Numbers in a Matrix
*/
public class Solution {
    public bool FindRotation(int[][] mat, int[][] target) {
        int n = mat.Length;                                     // Get matrix size (n x n)

        // Try all 4 rotations (0°, 90°, 180°, 270°)
        for (int r = 0; r < 4; r++) {                          // Loop through 4 possible rotations
            if (IsEqual(mat, target))                           // Check if current rotation matches target
                return true;                                    // Found a match, return true

            Rotate90(mat, n);                                   // Rotate matrix 90° clockwise for next iteration
        }

        return false;                                           // No rotation matched, return false
    }

    // Check if two matrices are equal
    private bool IsEqual(int[][] a, int[][] b) {
        int n = a.Length;                                       // Get matrix size

        for (int i = 0; i < n; i++) {                          // Iterate through rows
            for (int j = 0; j < n; j++) {                      // Iterate through columns
                if (a[i][j] != b[i][j])                         // If any element differs
                    return false;                               // Matrices are not equal
            }
        }

        return true;                                            // All elements match, matrices are equal
    }

    // Rotate matrix 90 degrees clockwise (in-place)
    private void Rotate90(int[][] mat, int n) {
        // Step 1: Transpose
        for (int i = 0; i < n; i++) {                          // Iterate through rows
            for (int j = i + 1; j < n; j++) {                  // Iterate upper triangle (avoid double swap)
                int temp = mat[i][j];                           // Store element in temporary variable
                mat[i][j] = mat[j][i];                          // Swap row and column indices
                mat[j][i] = temp;                               // Complete the transpose swap
            }
        }

        // Step 2: Reverse each row
        for (int i = 0; i < n; i++) {                          // Iterate through each row
            Array.Reverse(mat[i]);                              // Reverse the current row to complete 90° rotation
        }
    }
}