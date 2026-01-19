/*
Title: 1292. Maximum Side Length of a Square with Sum Less than or Equal to Threshold
Solution: https://leetcode.com/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold/solutions/7507364/simplest-solution-c-time-omnlogminmn-spa-koxa/
Difficulty: Medium
Approach: Prefix Sum + Binary Search
Tags: Array, Binary Search, Matrix, Prefix Sum
1) Build a 2D prefix sum matrix for quick square sum calculation.
2) Use binary search on the possible side lengths (0 to min(m,n)).
3) For each candidate side length, check if any square exists with sum <= threshold.
4) Use prefix sum formula: sum = prefix[i][j] - prefix[i-len][j] - prefix[i][j-len] + prefix[i-len][j-len].
5) If square exists for mid length, search larger lengths; otherwise search smaller.
6) Return the maximum side length found.

Time Complexity: O(m*n*log(min(m,n))) where m,n are matrix dimensions
Space Complexity: O(m*n) for the prefix sum matrix
Tip: The key insight is combining prefix sum for O(1) range queries with binary search to efficiently find the maximum valid square size. The prefix sum avoids recalculating sums for each square check.
Similar Problems: 304. Range Sum Query 2D - Immutable, 1314. Matrix Block Sum, 363. Max Sum of Rectangle No Larger Than K
*/
public class Solution {
    public int MaxSideLength(int[][] mat, int threshold) {
        int m = mat.Length;                                         // Get number of rows
        int n = mat[0].Length;                                      // Get number of columns

        // Build prefix sum matrix for O(1) square sum queries
        int[,] prefix = new int[m + 1, n + 1];                      // Extra row/col for easier calculation

        for (int i = 1; i <= m; i++) {                              // Iterate through rows (1-indexed)
            for (int j = 1; j <= n; j++) {                          // Iterate through columns (1-indexed)
                prefix[i, j] = mat[i - 1][j - 1]                    // Current cell value
                               + prefix[i - 1, j]                   // Sum from row above
                               + prefix[i, j - 1]                   // Sum from column left
                               - prefix[i - 1, j - 1];              // Subtract overlap (counted twice)
            }
        }

        int left = 0, right = Math.Min(m, n);                       // Binary search bounds: 0 to max possible square size

        while (left < right) {                                      // Binary search for maximum side length
            int mid = left + (right - left + 1) / 2;                // Calculate middle (bias towards right)

            if (ExistsSquare(prefix, m, n, mid, threshold))         // If square of size mid exists
                left = mid;                                         // Search for larger squares
            else                                                    // If square of size mid doesn't exist
                right = mid - 1;                                    // Search for smaller squares
        }

        return left;                                                // Return maximum valid side length
    }

    private bool ExistsSquare(int[,] prefix, int m, int n, int len, int threshold) {
        for (int i = len; i <= m; i++) {                            // Iterate through possible bottom-right row positions
            for (int j = len; j <= n; j++) {                        // Iterate through possible bottom-right column positions
                int sum = prefix[i, j]                              // Bottom-right corner sum
                        - prefix[i - len, j]                        // Subtract top section
                        - prefix[i, j - len]                        // Subtract left section
                        + prefix[i - len, j - len];                 // Add back top-left (subtracted twice)

                if (sum <= threshold)                               // If valid square found
                    return true;                                    // Return true immediately
            }
        }
        return false;                                               // No valid square found for this size
    }
}
