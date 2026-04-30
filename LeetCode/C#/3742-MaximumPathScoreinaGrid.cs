/*
Title: 3742. Maximum Path Score in a Grid
Solution: https://leetcode.com/problems/maximum-path-score-in-a-grid/solutions/8119354/simplest-solution-c-time-omnk-space-omnk-akst/
Difficulty: Medium
Approach: 3D Dynamic Programming (bottom-up) with positive-cell budget as a state dimension
Tags: Array, Dynamic Programming, Matrix
1) Define dp[row, col, usedPositive] = max path score starting at (row, col) given how many positive cells were already consumed before arriving here.
2) Initialize the entire dp table to -1 to mark unreachable states.
3) Iterate cells from bottom-right to top-left so future cells (down/right) are computed before the current one.
4) For each cell, compute the updated positive-cell count if the current cell is positive; skip the state if it exceeds the budget.
5) Base case: at the bottom-right cell, the score is just grid[row][col].
6) Otherwise take the max of moving Down and moving Right (using the updated count for the next state) and add grid[row][col] when at least one direction is valid.
7) Answer is dp[0, 0, 0] - start at top-left with zero positives used.

Time Complexity: O(rows * cols * maxPositiveCellsAllowed)
Space Complexity: O(rows * cols * maxPositiveCellsAllowed) for the 3D dp table
Tip: Tracking 'positives used so far' as a DP dimension converts the budget constraint into a clean state. Iterating in reverse lets us reuse already-computed sub-problems for the Down and Right transitions without recursion.
Similar Problems: 64. Minimum Path Sum, 174. Dungeon Game, 931. Minimum Falling Path Sum, 1289. Minimum Falling Path Sum II
*/
public class Solution
{
    public int MaxPathScore(int[][] grid, int maxPositiveCellsAllowed)
    {
        int totalRows = grid.Length;                                        // Number of rows in the grid
        int totalCols = grid[0].Length;                                     // Number of columns in the grid

        // dp[row][col][usedPositiveCount] =
        // maximum score we can achieve starting from (row, col)
        // when we have already used 'usedPositiveCount' positive cells
        int[,,] dp = new int[totalRows + 1, totalCols + 1, maxPositiveCellsAllowed + 1]; // 3D DP table with extra row/col padding

        // Initialize all states as -1 (invalid/unreachable)
        for (int row = 0; row <= totalRows; row++)                          // Iterate over every row index
        {
            for (int col = 0; col <= totalCols; col++)                      // Iterate over every column index
            {
                for (int used = 0; used <= maxPositiveCellsAllowed; used++) // Iterate over every positive-budget value
                {
                    dp[row, col, used] = -1;                                // Mark state as unreachable initially
                }
            }
        }

        // Traverse from bottom-right to top-left
        for (int row = totalRows - 1; row >= 0; row--)                      // Process rows in reverse order
        {
            for (int col = totalCols - 1; col >= 0; col--)                  // Process cols in reverse order
            {
                for (int usedPositive = maxPositiveCellsAllowed; usedPositive >= 0; usedPositive--) // Try every possible used-count
                {
                    // If current cell is positive, it consumes 1 count
                    int updatedUsedPositive = usedPositive + (grid[row][col] > 0 ? 1 : 0); // Increment if current cell is positive

                    // If we exceed allowed positive cells, skip this state
                    if (updatedUsedPositive > maxPositiveCellsAllowed)      // Budget exceeded; this state isn't valid
                        continue;                                           // Skip and try next

                    // Base case: bottom-right cell
                    if (row == totalRows - 1 && col == totalCols - 1)       // Reached destination cell
                    {
                        dp[row, col, usedPositive] = grid[row][col];        // Score is just the cell's value
                        continue;                                           // No transitions needed from here
                    }

                    int scoreFromDown = -1;                                 // Best score if we move down (-1 = unreachable)
                    int scoreFromRight = -1;                                // Best score if we move right (-1 = unreachable)

                    // Move Down
                    if (row + 1 < totalRows)                                // Down move is in-bounds
                    {
                        scoreFromDown = dp[row + 1, col, updatedUsedPositive]; // Look up precomputed sub-problem below
                    }

                    // Move Right
                    if (col + 1 < totalCols)                                // Right move is in-bounds
                    {
                        scoreFromRight = dp[row, col + 1, updatedUsedPositive]; // Look up precomputed sub-problem to the right
                    }

                    // Choose the best possible next move
                    int bestNextScore = Math.Max(scoreFromDown, scoreFromRight); // Pick whichever transition scores higher

                    // If at least one path is valid
                    if (bestNextScore != -1)                                // -1 means neither neighbour was reachable
                    {
                        dp[row, col, usedPositive] = grid[row][col] + bestNextScore; // Add current cell to best onward score
                    }
                }
            }
        }

        // Start from (0,0) with 0 positive cells used
        return dp[0, 0, 0];                                                 // Final answer: best score from origin with empty budget
    }
}