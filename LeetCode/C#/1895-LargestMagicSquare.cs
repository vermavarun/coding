/*
Title: 1895. Largest Magic Square
Solution: https://leetcode.com/problems/largest-magic-square/solutions/7505121/simplest-solution-c-time-om-n-minm-n-spa-bdab/
Difficulty: Medium
Approach: Prefix Sum with Greedy Size Check
Tags: Array, Matrix, Prefix Sum
1) Create prefix sum arrays for rows, columns, and both diagonals.
2) Build prefix sums by iterating through the grid once.
3) Try all possible square sizes from largest to smallest (greedy approach).
4) For each size and position, check if it forms a magic square.
5) A magic square has equal sums for all rows, columns, and diagonals.
6) Use prefix sums to calculate range sums in O(1) time.
7) Return the first (largest) valid magic square size found.

Time Complexity: O(m · n · min(m, n)) where m = rows, n = columns
Space Complexity: O(m · n) for prefix sum arrays
Tip: The key insight is using prefix sums to quickly compute row, column, and diagonal sums in O(1) time, combined with a greedy approach (checking largest sizes first) to find the answer efficiently. Magic squares require all rows, columns, and both diagonals to have equal sums.
Similar Problems: 840. Magic Squares In Grid, 661. Image Smoother, 304. Range Sum Query 2D - Immutable
*/
public class Solution {
    public int LargestMagicSquare(int[][] grid) {
        int m = grid.Length;                                    // Number of rows in grid
        int n = grid[0].Length;                                 // Number of columns in grid

        int[,] row = new int[m, n + 1];                         // Prefix sums for rows (extra column for easier calculation)
        int[,] col = new int[m + 1, n];                         // Prefix sums for columns (extra row for easier calculation)
        int[,] diag1 = new int[m + 1, n + 1];                   // Prefix sums for top-left to bottom-right diagonal
        int[,] diag2 = new int[m + 1, n + 1];                   // Prefix sums for top-right to bottom-left diagonal

        // Build prefix sums
        for (int i = 0; i < m; i++) {                           // Iterate through each row
            for (int j = 0; j < n; j++) {                       // Iterate through each column
                row[i, j + 1] = row[i, j] + grid[i][j];         // Calculate row prefix sum
                col[i + 1, j] = col[i, j] + grid[i][j];         // Calculate column prefix sum
                diag1[i + 1, j + 1] = diag1[i, j] + grid[i][j]; // Calculate main diagonal prefix sum
                diag2[i + 1, j] = diag2[i, j + 1] + grid[i][j]; // Calculate anti-diagonal prefix sum
            }
        }

        int maxSize = Math.Min(m, n);                           // Maximum possible square size

        // Try sizes from largest to smallest
        for (int size = maxSize; size >= 2; size--) {           // Greedy: check largest sizes first (magic square needs size >= 2)
            for (int i = 0; i + size <= m; i++) {               // Try all valid row positions for this size
                for (int j = 0; j + size <= n; j++) {           // Try all valid column positions for this size

                    int target = row[i, j + size] - row[i, j];  // Calculate expected sum using first row
                    bool valid = true;                          // Flag to track if current square is valid

                    // Check rows
                    for (int r = i; r < i + size; r++) {        // Check each row in the square
                        if (row[r, j + size] - row[r, j] != target) { // Calculate row sum using prefix sum
                            valid = false;                      // Row sum doesn't match target
                            break;                              // No need to check further
                        }
                    }

                    // Check columns
                    for (int c = j; c < j + size && valid; c++) { // Check each column (only if still valid)
                        if (col[i + size, c] - col[i, c] != target) { // Calculate column sum using prefix sum
                            valid = false;                      // Column sum doesn't match target
                            break;                              // No need to check further
                        }
                    }

                    // Check diagonals
                    int d1 = diag1[i + size, j + size] - diag1[i, j];     // Main diagonal sum (top-left to bottom-right)
                    int d2 = diag2[i + size, j] - diag2[i, j + size];     // Anti-diagonal sum (top-right to bottom-left)

                    if (valid && d1 == target && d2 == target) { // If all checks passed and both diagonals match
                        return size;                            // Found largest magic square, return its size
                    }
                }
            }
        }

        return 1;                                               // If no magic square found, return 1 (minimum size)
    }
}
