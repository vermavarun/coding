/*
Title: 999. Available Captures for Rook
Solution: https://leetcode.com/problems/available-captures-for-rook/solutions/7634821/simplest-solution-c-time-o1-space-o1-ple-uda9/
Difficulty: Easy
Approach: Simulation - Directional search from rook position
Tags: Array, Matrix, Simulation
1) Find the position of the rook ('R') on the 8x8 board.
2) Define four directional vectors: up, down, left, right.
3) For each direction, move step by step from the rook's position.
4) Stop when hitting a bishop ('B'), a pawn ('p'), or board boundary.
5) If a pawn is found before a bishop or boundary, increment capture count.
6) Return total number of pawns that can be captured.

Time Complexity: O(1) - board is fixed at 8x8, max 32 cells checked
Space Complexity: O(1) - only constant variables used
Tip: The rook can only capture pawns in straight lines (4 cardinal directions) until blocked by a bishop or boundary. Use directional vectors to simulate movement in each direction.
Similar Problems: 1222. Queens That Can Attack the King, 874. Walking Robot Simulation, 1275. Find Winner on a Tic Tac Toe Game
*/
public class Solution {
    public int NumRookCaptures(char[][] board) {
        int rookRow = -1;                                       // Row position of the rook
        int rookColumn = -1;                                    // Column position of the rook
        int result = 0;                                         // Count of pawns that can be captured

        // Find the rook on the board
        for (int i=0; i<8; i++) {                               // Iterate through rows
            for (int j=0; j<8 ;j++) {                           // Iterate through columns
                if (board[i][j] == 'R') {                       // If rook found
                    rookRow = i;                                // Store rook's row position
                    rookColumn = j;                             // Store rook's column position
                }
            }
        }

        // Directions: up, down, left, right
        int[][] directions = new int[][] {
            [-1,0], // up    - decrease row
            [1,0],  // down  - increase row
            [0,-1], // left  - decrease column
            [0,1],  // right - increase column
        };

        int rPosRow = 0;                                        // Current row position during direction search
        int rPosColumn = 0;                                     // Current column position during direction search

        foreach (int[] dir in directions) {                     // Check each of the 4 directions

            rPosRow = rookRow + dir[0];                         // Start one step from rook in current direction (row)
            rPosColumn = rookColumn + dir[1];                   // Start one step from rook in current direction (column)

            while (rPosRow >= 0 && rPosRow < 8 && rPosColumn>=0 && rPosColumn <8) { // While within board boundaries

                // bishop blocks
                if (board[rPosRow][rPosColumn] == 'B') break;   // Bishop blocks - stop searching this direction

                // pawn captured
                if (board[rPosRow][rPosColumn] == 'p') {        // Pawn found - can be captured
                    result++;                                   // Increment capture count
                    break;                                      // Stop searching this direction
                }

                rPosRow = rPosRow + dir[0];                     // Move one more step in current direction (row)
                rPosColumn = rPosColumn + dir[1];               // Move one more step in current direction (column)
            }

            rPosRow = 0;                                        // Reset row position for next direction
            rPosColumn = 0;                                     // Reset column position for next direction

        }

        return result;                                          // Return total number of capturable pawns
    }
}