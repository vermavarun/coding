/*
Title: 1914. Cyclically Rotating a Grid
Solution: https://leetcode.com/problems/cyclically-rotating-a-grid/solutions/8184033/simplest-solution-c-time-omn-space-omn-p-y2uv/
Difficulty: Medium
Approach: Layer-by-layer extraction and rotation
Tags: Array, Matrix, Simulation
1) Calculate the number of concentric layers (rings) in the grid.
2) For each layer, determine its four boundary edges (top, bottom, left, right).
3) Extract all elements of the layer in clockwise order into a list.
4) Compute effective rotations using k % layerLength to skip full cycles.
5) Rotate the list left by effectiveRotations using the three-reverse trick.
6) Write the rotated elements back into the grid in the same clockwise order.

Time Complexity: O(m*n) where m and n are the grid dimensions
Space Complexity: O(m+n) for the temporary list holding each layer's elements
Tip: Treat each concentric ring as a 1D list. The three-reverse trick (reverse prefix, reverse suffix, reverse all) efficiently rotates in-place without extra space.
Similar Problems: 48. Rotate Image, 54. Spiral Matrix, 59. Spiral Matrix II
*/
public class Solution
{
    public int[][] RotateGrid(int[][] grid, int k)
    {
        int totalRows = grid.Length;                                        // Number of rows in the grid
        int totalColumns = grid[0].Length;                                  // Number of columns in the grid

        // A layer (ring) needs at least 2 rows and 2 columns.
        // Example:
        // -------------
        // |           |
        // |   inner   |
        // |           |
        // -------------
        int totalLayers = Math.Min(totalRows, totalColumns) / 2;            // Total number of concentric rings

        // Process each layer independently
        for (int layerIndex = 0; layerIndex < totalLayers; layerIndex++)
        {
            List<int> layerElements = new List<int>();                      // Holds elements of the current ring

            // Current layer boundaries
            int topRow = layerIndex;                                        // Top boundary row of this layer
            int bottomRow = totalRows - layerIndex - 1;                     // Bottom boundary row of this layer

            int leftColumn = layerIndex;                                    // Left boundary column of this layer
            int rightColumn = totalColumns - layerIndex - 1;               // Right boundary column of this layer

            // -------------------------------------------------
            // Extract all elements of the current layer
            // in clockwise traversal order
            // -------------------------------------------------

            // Top row (left -> right)
            for (int column = leftColumn; column <= rightColumn; column++)
            {
                layerElements.Add(grid[topRow][column]);                    // Add top-row elements left to right
            }

            // Right column (top -> bottom)
            // Skip corners because they are already included
            for (int row = topRow + 1; row <= bottomRow - 1; row++)
            {
                layerElements.Add(grid[row][rightColumn]);                  // Add right-column elements top to bottom
            }

            // Bottom row (right -> left)
            for (int column = rightColumn; column >= leftColumn; column--)
            {
                layerElements.Add(grid[bottomRow][column]);                 // Add bottom-row elements right to left
            }

            // Left column (bottom -> top)
            // Skip corners because they are already included
            for (int row = bottomRow - 1; row >= topRow + 1; row--)
            {
                layerElements.Add(grid[row][leftColumn]);                   // Add left-column elements bottom to top
            }

            int layerLength = layerElements.Count;                         // Total elements in this ring

            // Avoid unnecessary full rotations
            int effectiveRotations = k % layerLength;                      // Skip complete cycles

            // Rotate left by effectiveRotations
            RotateLeft(layerElements, effectiveRotations);                  // In-place left rotation

            int elementIndex = 0;                                          // Index to read from the rotated list

            // -------------------------------------------------
            // Put rotated elements back into the grid
            // using the same traversal order
            // -------------------------------------------------

            // Top row
            for (int column = leftColumn; column <= rightColumn; column++)
            {
                grid[topRow][column] = layerElements[elementIndex++];       // Restore top-row elements
            }

            // Right column
            for (int row = topRow + 1; row <= bottomRow - 1; row++)
            {
                grid[row][rightColumn] = layerElements[elementIndex++];     // Restore right-column elements
            }

            // Bottom row
            for (int column = rightColumn; column >= leftColumn; column--)
            {
                grid[bottomRow][column] = layerElements[elementIndex++];    // Restore bottom-row elements
            }

            // Left column
            for (int row = bottomRow - 1; row >= topRow + 1; row--)
            {
                grid[row][leftColumn] = layerElements[elementIndex++];      // Restore left-column elements
            }
        }

        return grid;                                                        // Return the modified grid
    }

    /// <summary>
    /// Rotates the list to the left by k positions.
    /// Example:
    /// [1,2,3,4], k=1 -> [2,3,4,1]
    /// </summary>
    private void RotateLeft(List<int> numbers, int k)
    {
        numbers.Reverse(0, k);                          // Reverse the first k elements
        numbers.Reverse(k, numbers.Count - k);          // Reverse the remaining elements
        numbers.Reverse();                              // Reverse the entire list to complete rotation
    }
}