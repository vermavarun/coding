/*
Title: 3567. Minimum Absolute Difference in Sliding Submatrix
Solution: https://leetcode.com/problems/minimum-absolute-difference-in-sliding-submatrix/solutions/7675092/simplest-solution-c-time-om-k1-n-k1-k2-l-vu80/
Difficulty: Medium
Approach: Sliding Window with SortedSet for Unique Sorted Values
Tags: Array, Matrix, Sliding Window, Sorting, Hash Table
1) Calculate result matrix dimensions as (rows-k+1) x (cols-k+1) for all valid k x k submatrices.
2) Initialize result matrix to store minimum absolute differences.
3) Iterate through all possible top-left positions of k x k submatrices.
4) For each submatrix, use SortedSet to collect unique sorted elements (eliminates duplicates automatically).
5) If all elements are identical (SortedSet size = 1), minimum difference is 0.
6) Iterate through the sorted unique values and track previous value for comparison.
7) Calculate difference between consecutive sorted values and update minimum.
8) Store the minimum difference in result matrix at corresponding position.

Time Complexity: O((m-k+1) * (n-k+1) * k² * log(k²)) where m = rows, n = cols
Space Complexity: O(k²) for storing unique elements of each submatrix
Tip: Using SortedSet instead of List provides two benefits: automatic sorting and duplicate removal. This is crucial because duplicates have zero difference, and the minimum absolute difference must occur between consecutive distinct values in sorted order.
Similar Problems: 530. Minimum Absolute Difference in BST, 1200. Minimum Absolute Difference, 1984. Minimum Difference Between Highest and Lowest of K Scores, 1852. Distinct Numbers in Each Subarray
*/
using System;
using System.Collections.Generic;

public class Solution
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        int totalRows = grid.Length;                                // Get total number of rows in grid
        int totalCols = grid[0].Length;                             // Get total number of columns in grid

        // Result matrix size
        int[][] answer = new int[totalRows - k + 1][];              // Create result array for valid submatrix positions
        for (int r = 0; r <= totalRows - k; r++)                    // Initialize each row of result array
        {
            answer[r] = new int[totalCols - k + 1];                 // Allocate columns for each valid submatrix position
        }

        // Traverse every k x k submatrix
        for (int startRow = 0; startRow <= totalRows - k; startRow++) // Iterate through valid row positions for top-left corner
        {
            for (int startCol = 0; startCol <= totalCols - k; startCol++) // Iterate through valid column positions for top-left corner
            {
                // SortedSet keeps elements:
                // 1. Sorted
                // 2. Unique (duplicates removed)
                SortedSet<int> uniqueSortedValues = new SortedSet<int>(); // Data structure for automatic sorting and deduplication

                // Collect elements of current k x k window
                for (int r = startRow; r < startRow + k; r++)       // Iterate through k rows of current submatrix
                {
                    for (int c = startCol; c < startCol + k; c++)   // Iterate through k columns of current submatrix
                    {
                        uniqueSortedValues.Add(grid[r][c]);         // Add element to set (auto-sorted, duplicates ignored)
                    }
                }

                // If all elements are same → min diff = 0
                if (uniqueSortedValues.Count == 1)                  // If only one unique value exists in submatrix
                {
                    answer[startRow][startCol] = 0;                 // Minimum difference is 0 (all elements identical)
                    continue;                                       // Skip to next submatrix
                }

                int minDifference = int.MaxValue;                   // Initialize minimum difference to maximum possible value

                int? previousValue = null;                          // Track previous value for consecutive comparison (nullable for first iteration)

                // Iterate sorted unique values
                foreach (int currentValue in uniqueSortedValues)    // Iterate through set in sorted order
                {
                    if (previousValue != null)                      // If not the first element
                    {
                        int diff = currentValue - previousValue.Value; // Calculate difference between consecutive sorted values
                        if (diff < minDifference)                   // If current difference is smaller than minimum found so far
                            minDifference = diff;                   // Update minimum difference
                    }

                    previousValue = currentValue;                   // Update previous value for next iteration
                }

                answer[startRow][startCol] = minDifference;         // Store minimum difference for this submatrix position
            }
        }

        return answer;                                              // Return result matrix with all minimum differences
    }
}