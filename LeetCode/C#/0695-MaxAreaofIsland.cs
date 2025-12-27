/*
Solution: 
Difficulty: Medium
Approach: [To be documented]
Tags: Array, Math, Recursion, Depth-First Search, Breadth-First Search
1. Start from the first cell of the grid.
2. If the cell is 1, call the DFS function.
3. In the DFS function, check if the cell is out of bounds or the cell is water.
4. If the cell is out of bounds or the cell is water, return.
5. Mark the cell as visited.
6. Call the DFS function recursively with the adjacent cells.
7. Increment the area.
8. Return the area.
Space Complexity: O(1)

Time Complexity: O(rows*columns)
Space Complexity: O(1)
*/
public class Solution {
    int rows = 0;                                                               // Variable to store the number of rows.
    int columns = 0;                                                            // Variable to store the number of columns.
    int maxArea = 0;                                                            // Variable to store the maximum area.
    public int MaxAreaOfIsland(int[][] grid) {                                  // Function to find the maximum area of the island.

        rows = grid.Length;                                                     // Get the number of rows.
        columns = grid[0].Length;                                               // Get the number of columns.

        for (int i=0; i<rows; i++) {                                            // Iterate through the grid.
            for (int j=0; j<columns; j++) {                                     // Iterate through the grid.
                if (grid[i][j]==1) {                                            // If the cell is 1, call the DFS function.
                    maxArea = Math.Max(DFS(grid, i, j), maxArea);               // Call the DFS function and get the maximum area.
                }
            }
        }
        return maxArea;                                                         // Return the maximum area.
    }

    public int DFS(int[][] grid, int i, int j) {                                // Function to perform Depth First Search.
        if (i<0 || i >=rows || j<0 || j>=columns || grid[i][j] != 1) {          // If the cell is out of bounds or the cell is water, return.
            return 0;                                                           // If the cell is out of bounds or the cell is water, return.
        }

        grid[i][j] = -1;                                                        // Mark the cell as visited.

        return 1 + DFS(grid, i+1, j) +                                          // Call the DFS function recursively with the adjacent cells.
                    DFS(grid, i-1, j) +
                    DFS(grid, i, j+1) +
                    DFS(grid, i, j-1);
    }
}
/*
Approach: BFS
TODO
*/