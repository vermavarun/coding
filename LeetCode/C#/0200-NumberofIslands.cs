/*
Approach: DFS
1. Start from the first cell of the grid.
2. If the cell is 1, call the DFS function.
3. In the DFS function, check if the cell is out of bounds or the cell is water.
4. If the cell is out of bounds or the cell is water, return.
5. Mark the cell as visited.
6. Call the DFS function recursively with the adjacent cells.
7. Increment the number of islands.
8. Return the number of islands.
Time Complexity: O(rows*columns)
Space Complexity: O(1)
*/
public class Solution {
    int numOfIslands = 0;                                               // Variable to store the number of islands.
    int rows = 0;                                                       // Variable to store the number of rows.
    int columns = 0;                                                    // Variable to store the number of columns.
    public int NumIslands(char[][] grid) {                              // Function to find the number of islands.
        rows = grid.Length;                                             // Get the number of rows.
        columns = grid[0].Length;                                       // Get the number of columns.
        for (int i=0; i<rows; i++) {                                    // Iterate through the grid.
            for (int j=0; j<columns; j++) {                             // Iterate through the grid.
                if (grid[i][j] == '1') {                                // If the cell is 1, call the DFS function.
                    DFS(grid, i, j);                                    // Call the DFS function.
                    numOfIslands++;                                     // Increment the number of islands.
                }
            }
        }
        return numOfIslands;                                            // Return the number of islands.
    }

    public void DFS(char[][] grid, int i, int j) {                      // Function to perform Depth First Search.
        if(i>=rows || i<0 || j>=columns || j<0 || grid[i][j]!='1') {    // If the cell is out of bounds or the cell is water, return.
            return;                                                     // Return.
        }

        grid[i][j] = '$';                                               // Mark the cell as visited.
        DFS(grid, i+1, j);                                              // Call the DFS function recursively with the adjacent cells.
        DFS(grid, i-1, j);                                              // Call the DFS function recursively with the adjacent cells.
        DFS(grid, i, j+1);                                              // Call the DFS function recursively with the adjacent cells.
        DFS(grid, i, j-1);                                              // Call the DFS function recursively with the adjacent cells.
    }
}

/*
Approach: BFS
TODO
*/