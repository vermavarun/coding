/*
Title: 3548. Equal Sum Grid Partition II
Solution: https://leetcode.com/problems/equal-sum-grid-partition-ii/solutions/7698463/simplest-solution-c-time-omnm-space-omn-5fms8/
Difficulty: Hard
Approach: Grid Partition with Transformations and Optimization
Tags: Array, Matrix, Hash Table, Greedy
1) Calculate the total sum of all elements in the grid.
2) Try all horizontal cuts to partition the grid into two parts.
3) For each cut, check if sums can be equal by removing at most one element.
4) If no horizontal cut works, reverse the grid rows and try again.
5) Transpose the grid to convert vertical cuts into horizontal cuts.
6) Try horizontal cuts on the transposed grid.
7) Reverse the transposed grid and try once more.
8) Use hash set to track seen values for efficient element removal checks.

Time Complexity: O(m × n × m) where m = rows, n = columns (checking all cuts)
Space Complexity: O(m × n) for transpose grid and hash set
Tip: The key insight is to convert all partition cases into horizontal cuts by using transformations (reverse and transpose). By checking edge elements and using a hash set for seen values, we can efficiently determine if removing one element makes the partition equal.
Similar Problems: 416. Partition Equal Subset Sum, 698. Partition to K Equal Sum Subsets, 1012. Partition Array Into Three Parts With Equal Sum
*/


public class Solution
{
    private long total = 0;                                         // Store total sum of all grid elements

    public bool CanPartitionGrid(int[][] grid)
    {
        int m = grid.Length;                                        // Number of rows in the grid
        int n = grid[0].Length;                                     // Number of columns in the grid

        // Step 1: Calculate total sum
        total = 0;                                                  // Initialize total sum to 0
        for (int i = 0; i < m; i++)                                 // Iterate through each row
        {
            for (int j = 0; j < n; j++)                             // Iterate through each column
            {
                total += grid[i][j];                                // Add current element to total sum
            }
        }

        // Step 2: Try horizontal cuts
        if (CheckHorizontalCuts(grid)) return true;                 // If valid partition found with horizontal cuts, return true

        // Step 3: Reverse rows and try again
        ReverseRows(grid);                                          // Reverse rows to check cuts from bottom
        if (CheckHorizontalCuts(grid)) return true;                 // If valid partition found after reversing, return true

        // Restore grid
        ReverseRows(grid);                                          // Restore original grid order

        // Step 4: Transpose grid (convert vertical → horizontal)
        int[][] transpose = new int[n][];                           // Create transposed grid with swapped dimensions
        for (int i = 0; i < n; i++)                                 // Initialize rows of transposed grid
            transpose[i] = new int[m];                              // Allocate space for each row

        for (int i = 0; i < m; i++)                                 // Iterate through original rows
        {
            for (int j = 0; j < n; j++)                             // Iterate through original columns
            {
                transpose[j][i] = grid[i][j];                       // Swap rows and columns for transpose
            }
        }

        // Step 5: Try on transposed grid
        if (CheckHorizontalCuts(transpose)) return true;            // Check horizontal cuts on transposed grid (vertical cuts on original)

        // Step 6: Reverse transposed and try again
        ReverseRows(transpose);                                     // Reverse transposed rows for remaining cases
        return CheckHorizontalCuts(transpose);                      // Final check after all transformations
    }

    // 🔹 Core logic for horizontal partition
    private bool CheckHorizontalCuts(int[][] grid)
    {
        int m = grid.Length;                                        // Get number of rows in grid
        int n = grid[0].Length;                                     // Get number of columns in grid

        HashSet<long> seenValues = new HashSet<long>();             // Track all elements seen in top partition
        long topSum = 0;                                            // Running sum of top partition

        // Try cutting after each row
        for (int i = 0; i < m - 1; i++)                             // Try cut after each row (exclude last row)
        {
            for (int j = 0; j < n; j++)                             // Add all elements from current row
            {
                seenValues.Add(grid[i][j]);                         // Store element value in hash set
                topSum += grid[i][j];                               // Add element to top partition sum
            }

            long bottomSum = total - topSum;                        // Calculate bottom partition sum
            long diff = topSum - bottomSum;                         // Calculate difference between partitions

            // Perfect split
            if (diff == 0) return true;                             // If sums are equal, partition is valid

            // Edge removals (corner cases)
            if (diff == grid[0][0]) return true;                    // If removing top-left corner balances, valid
            if (diff == grid[0][n - 1]) return true;                // If removing top-right corner balances, valid
            if (diff == grid[i][0]) return true;                    // If removing left element of current row balances, valid

            // Remove one element from top half
            if (i > 0 && n > 1 && seenValues.Contains(diff))        // If difference matches a seen value in top partition
            {
                return true;                                        // Removing that element will balance partitions
            }
        }

        return false;                                               // No valid partition found
    }

    // 🔹 Reverse rows (top ↔ bottom)
    private void ReverseRows(int[][] grid)
    {
        int top = 0;                                                // Pointer to the top row
        int bottom = grid.Length - 1;                               // Pointer to the bottom row

        while (top < bottom)                                        // Continue until pointers meet in middle
        {
            var temp = grid[top];                                   // Store top row temporarily
            grid[top] = grid[bottom];                               // Move bottom row to top position
            grid[bottom] = temp;                                    // Move stored top row to bottom position

            top++;                                                  // Move top pointer down
            bottom--;                                               // Move bottom pointer up
        }
    }
}