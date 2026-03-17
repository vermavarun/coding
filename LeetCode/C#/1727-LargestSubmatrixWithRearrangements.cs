/*
Title: 1727. Largest Submatrix With Rearrangements
Solution: https://leetcode.com/problems/largest-submatrix-with-rearrangements/solutions/7654547/simplest-solution-c-time-om-n-logn-space-igym/
Difficulty: Medium
Approach: Histogram Heights + Greedy Sorting
Tags: Array, Matrix, Sorting, Greedy, Dynamic Programming
1) Initialize heights array to track consecutive 1's in each column.
2) Iterate through each row of the matrix.
3) For each row, build histogram heights - if cell is 0, reset height to 0, else increment.
4) Clone the heights array and sort it in descending order.
5) For each position in sorted array, calculate area = height * width (position + 1).
6) Track maximum area across all rows and positions.
7) Return the maximum submatrix area found.

Time Complexity: O(m * n * log(n)) where m = rows, n = columns (n*log(n) for sorting each row)
Space Complexity: O(n) for heights and sorted arrays
Tip: The key insight is that we can rearrange columns freely, so sorting heights gives us the optimal arrangement. Each row becomes a histogram problem where we greedily pair tallest heights with widest possible widths.
Similar Problems: 84. Largest Rectangle in Histogram, 85. Maximal Rectangle, 221. Maximal Square, 1277. Count Square Submatrices with All Ones
*/
public class Solution {
    public int LargestSubmatrix(int[][] matrix) {
        int m = matrix.Length;                                      // Get number of rows in matrix
        int n = matrix[0].Length;                                   // Get number of columns in matrix

        int[] heights = new int[n];                                 // Array to store histogram heights for each column
        int result = 0;                                             // Variable to track maximum submatrix area

        for (int i = 0; i < m; i++) {                               // Iterate through each row
            // Step 1: Build heights (like histogram)
            for (int j = 0; j < n; j++) {                           // Iterate through each column
                if (matrix[i][j] == 0)                              // If current cell is 0
                    heights[j] = 0;                                 // Reset height to 0 (break consecutive 1's)
                else                                                // If current cell is 1
                    heights[j] += 1;                                // Increment height (consecutive 1's)
            }

            // Step 2: Copy and sort in descending order
            int[] sorted = (int[])heights.Clone();                  // Clone heights array to avoid modifying original
            Array.Sort(sorted);                                     // Sort in ascending order
            Array.Reverse(sorted);                                  // Reverse to get descending order

            // Step 3: Try all possible widths
            for (int k = 0; k < n; k++) {                           // Iterate through sorted heights
                int height = sorted[k];                             // Get height at current position
                int width = k + 1;                                  // Width is position + 1 (greedily use tallest heights)
                result = Math.Max(result, height * width);         // Update result with maximum area
            }
        }

        return result;                                              // Return maximum submatrix area found
    }
}