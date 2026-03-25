/*
Title: 3546. Equal Sum Grid Partition I
Solution: https://leetcode.com/problems/equal-sum-grid-partition-i/solutions/7691416/simplest-solution-c-time-omn-space-omn-p-w8wv/
Difficulty: Medium
Approach: Greedy partitioning with prefix sum checks
Tags: Array, Grid, Partition
1) Calculate the total sum of all grid elements.
2) If total sum is odd, no equal partition is possible.
3) The target for each partition is total sum divided by 2.
4) Try all possible horizontal cuts between rows and check if top part sum equals target.
5) Try all possible vertical cuts between columns and check if left part sum equals target.
6) Return true if any single cut creates two equal sum partitions.
7) Return false if no valid partition exists.

Time Complexity: O(m*n) where m = rows and n = columns - we traverse entire grid for sum calculation and then potentially all cut positions
Space Complexity: O(1) - only using a few variables for tracking sums
Tip: The key insight is that we only need ONE horizontal OR ONE vertical cut to partition the grid into two equal parts. We can optimize by checking running sums rather than recalculating sums for each potential cut.
Similar Problems: 1015. Smallest Integer Divisible by K, 523. Continuous Subarray Sum
*/
public class Solution {
    public bool CanPartitionGrid(int[][] grid) {
        int m = grid.Length;                                        // Number of rows in the grid
        int n = grid[0].Length;                                     // Number of columns in the grid

        long totalSum = 0;                                          // Variable to store total sum

        // Step 1: Calculate total sum of grid
        foreach (var row in grid) {                                 // Iterate through each row
            foreach (var val in row) {                              // Iterate through each value in row
                totalSum += val;                                    // Add value to total sum
            }
        }

        // Step 2: If total sum is odd → cannot split equally
        if (totalSum % 2 != 0)                                      // If sum is not divisible by 2
            return false;                                           // Return false - unequal partition

        long target = totalSum / 2;                                 // Calculate target sum for each partition

        // Try Horizontal Cuts
        long runningRowSum = 0;                                     // Variable to track running sum of rows

        for (int i = 0; i < m - 1; i++) {                          // Iterate through each possible horizontal cut position
            for (int j = 0; j < n; j++) {                          // Add all columns of current row
                runningRowSum += grid[i][j];                        // Add element to running sum
            }

            // If top part equals half → valid partition
            if (runningRowSum == target)                            // If current running sum equals target
                return true;                                        // Found valid horizontal partition
        }

        // Try Vertical Cuts
        long runningColSum = 0;                                     // Variable to track running sum of columns

        for (int j = 0; j < n - 1; j++) {                          // Iterate through each possible vertical cut position
            for (int i = 0; i < m; i++) {                          // Add all rows of current column
                runningColSum += grid[i][j];                        // Add element to running sum
            }

            // If left part equals half → valid partition
            if (runningColSum == target)                            // If current running sum equals target
                return true;                                        // Found valid vertical partition
        }

        return false;                                               // No valid partition found
    }
}