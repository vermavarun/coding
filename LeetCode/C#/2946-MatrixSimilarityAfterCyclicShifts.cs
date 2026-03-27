/*
Title: 2946. Matrix Similarity After Cyclic Shifts
Solution: https://leetcode.com/problems/matrix-similarity-after-cyclic-shifts/solutions/7703355/simplest-solution-c-time-omn-space-o1-pl-zsdu/
Difficulty: Easy
Approach: Simulate cyclic shifts and check if matrix is similar to itself
Tags: Array, Matrix, Simulation
1) Get dimensions of the matrix (m rows, n columns).
2) Optimize k by taking modulo n (since n shifts return to original position).
3) If k is 0 after optimization, matrix is similar to itself (return true).
4) For each row in the matrix:
   - Even-indexed rows shift left
   - Odd-indexed rows shift right
5) For each element, calculate where it would be after k shifts.
6) Compare element at current position with element at shifted position.
7) If any pair doesn't match, matrix is not similar (return false).
8) If all pairs match, matrix is similar (return true).

Time Complexity: O(m * n) where m = number of rows, n = number of columns
Space Complexity: O(1) - only using constant extra space
Tip: The key optimization is using modulo (k % n) to avoid unnecessary full rotations. After n shifts, any row returns to its original state. Also notice that we don't need to create a new matrix - we can check similarity by comparing elements at their original and shifted positions.
Similar Problems: 48. Rotate Image, 189. Rotate Array, 1260. Shift 2D Grid, 1886. Determine Whether Matrix Can Be Obtained By Rotation
*/
public class Solution {
    public bool AreSimilar(int[][] mat, int k) {
        int m = mat.Length;                                         // Get number of rows in matrix
        int n = mat[0].Length;                                      // Get number of columns in matrix

        k = k % n;                                                  // Optimize k: n shifts = original position
        if (k == 0) return true;                                    // If no effective shift, matrix is similar to itself

        for (int i = 0; i < m; i++) {                               // Iterate through each row
            for (int j = 0; j < n; j++) {                           // Iterate through each column

                int currentIndex = j;                               // Store current column index
                int shiftedIndex;                                   // Variable to store shifted position

                if (i % 2 == 0) {                                   // Check if row index is even
                    // Even row → left shift
                    shiftedIndex = (j + k) % n;                     // Calculate left shift position with wrap-around
                } else {                                            // Row index is odd
                    // Odd row → right shift
                    shiftedIndex = (j - k + n) % n;                 // Calculate right shift position with wrap-around
                }

                if (mat[i][currentIndex] != mat[i][shiftedIndex]) { // Compare element at current position with shifted position
                    return false;                                   // If elements don't match, matrix is not similar
                }
            }
        }

        return true;                                                // All elements match their shifted positions - matrix is similar
    }
}