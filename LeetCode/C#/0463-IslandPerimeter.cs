/*
Approach: DFS
1. Start from the first cell of the grid.
2. If the cell is 1, call the DFS function.
3. In the DFS function, check if the cell is out of bounds or the cell is water.
4. If the cell is out of bounds or the cell is water, increment the perimeter.
5. If the cell is already visited, return.
6. Mark the cell as visited.
7. Call the DFS function recursively with the adjacent cells.
8. Return the perimeter.
Time Complexity: O(rows*columns)
Space Complexity: O(1)
*/
public class Solution {
    int perimiter = 0;                                                                  // Variable to store the perimeter.
    int rows = 0;                                                                       // Variable to store the number of rows.
    int columns = 0;                                                                    // Variable to store the number of columns.
    public int IslandPerimeter(int[][] grid) {                                          // Function to find the perimeter of the island.
        rows = grid.Length;                                                             // Get the number of rows.
        columns = grid[0].Length;                                                       // Get the number of columns.

        for(int i=0; i<rows; i++) {                                                     // Iterate through the grid.
            for(int j=0; j<columns; j++) {                                              // Iterate through the grid.
                if(grid[i][j] == 1) {                                                   // If the cell is 1, call the DFS function.
                    DFS(grid, i, j);                                                    // Call the DFS function.
                    return perimiter;                                                   // Return the perimeter.
                }
            }
        }
        return 0;                                                                       // Return 0 if the island is not found.
    }

    public void DFS(int[][] grid, int i, int j) {

        if(i >=rows || i < 0 || j >= columns || j < 0 || grid[i][j] == 0) {             // If the cell is out of bounds or the cell is water, increment the perimeter.
            perimiter++;                                                                // Increment the perimeter.
            return;                                                                     // Return.
        }

        if(grid[i][j] == -1) {                                                          // If the cell is already visited, return.
            return;                                                                     // Return.
        }

        grid[i][j] = -1;                                                                // Mark the cell as visited.

        DFS(grid,i+1,j);                                                                // Call the DFS function recursively with the adjacent cells.
        DFS(grid,i-1,j);                                                                // Call the DFS function recursively with the adjacent cells.
        DFS(grid,i,j+1);                                                                // Call the DFS function recursively with the adjacent cells.
        DFS(grid,i,j-1);                                                                // Call the DFS function recursively with the adjacent cells.
    }
 }
 /*
 Approach: BFS
 TODO
 */