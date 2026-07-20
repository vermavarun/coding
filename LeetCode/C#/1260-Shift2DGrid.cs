/*
Title: 1260. Shift 2D Grid
Solution: https://leetcode.com/problems/shift-2d-grid/solutions/8409563/simplest-solution-c-time-omn-space-omn-p-zkbh/
Difficulty: Easy
Approach: Flatten to 1D, shift, rebuild 2D
Tags: Array, Simulation, Matrix
1) Calculate total cells and reduce k by modulo to skip full rotations.
2) Flatten the 2D grid into a 1D array row by row.
3) Shift each element forward by k positions using modulo arithmetic.
4) Rebuild the 2D result list from the shifted 1D array.

Time Complexity: O(m * n) where m = rows, n = cols
Space Complexity: O(m * n) for the flattened and shifted arrays
Tip: The key insight is that a 2D shift is equivalent to a 1D circular shift on the flattened array. Map each cell to a linear index, shift it by k, then map back to 2D coordinates.
Similar Problems: 189. Rotate Array, 48. Rotate Image
*/
public class Solution
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        int rows = grid.Length;                         // Number of rows in the grid
        int cols = grid[0].Length;                      // Number of columns in the grid
        int totalCells = rows * cols;                   // Total number of cells

        // Reduce unnecessary full rotations.
        k %= totalCells;

        // Flatten the grid into a 1D array.
        int[] flattened = new int[totalCells];
        int index = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                flattened[index++] = grid[row][col];   // Store each cell in row-major order
            }
        }

        // Shift the flattened array.
        int[] shifted = new int[totalCells];

        for (int i = 0; i < totalCells; i++)
        {
            shifted[(i + k) % totalCells] = flattened[i];  // Place element at its new shifted position
        }

        // Convert back to a 2D list.
        IList<IList<int>> result = new List<IList<int>>();
        index = 0;

        for (int row = 0; row < rows; row++)
        {
            List<int> currentRow = new List<int>();

            for (int col = 0; col < cols; col++)
            {
                currentRow.Add(shifted[index++]);       // Fill each row from the shifted array
            }

            result.Add(currentRow);                     // Add completed row to result
        }

        return result;                                  // Return the shifted 2D grid
    }
}