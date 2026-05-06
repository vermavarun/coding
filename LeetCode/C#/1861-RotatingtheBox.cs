/*
Title: 1861. Rotating the Box
Solution: https://leetcode.com/problems/rotating-the-box/solutions/8153119/simplest-solution-c-time-omn-space-omn-p-frfi/
Difficulty: Medium
Approach: Gravity Simulation + 90° Clockwise Matrix Rotation
Tags: Array, Matrix, Two Pointers
1) Iterate each row right-to-left, tracking a write position for falling stones.
2) When an obstacle '*' is found, reset write position to just before it.
3) When a stone '#' is found, move it to the current write position and decrement it.
4) After gravity is applied to all rows, rotate the matrix 90° clockwise.
5) For clockwise rotation: element at (row, col) maps to (col, rows-1-row) in the new matrix.

Time Complexity: O(m * n) where m = rows and n = cols
Space Complexity: O(m * n) for the rotated output matrix
Tip: Decouple the two steps — first apply gravity in the original orientation (rows are horizontal), then rotate. Trying to do both at once is error-prone. The write-pointer technique keeps gravity simulation at O(n) per row without extra space.
Similar Problems: 48. Rotate Image, 1260. Shift 2D Grid, 2996. Smallest Missing Integer Greater Than Sequential Prefix Sum
*/
public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        int rows = box.Length;                                          // Number of rows in the box
        int cols = box[0].Length;                                       // Number of columns in the box

        // Step 1: Apply gravity — stones fall to the right within each row
        for (int row = 0; row < rows; row++) {
            int writePosition = cols - 1;                               // Rightmost open position for the next falling stone

            for (int col = cols - 1; col >= 0; col--) {
                if (box[row][col] == '*') {                             // Obstacle found — stones cannot pass through
                    writePosition = col - 1;                            // Reset write position to just left of obstacle
                }
                else if (box[row][col] == '#') {                       // Stone found — let it fall right
                    box[row][col] = '.';                                // Clear the stone's current position
                    box[row][writePosition] = '#';                      // Place stone at the rightmost open position
                    writePosition--;                                    // Move write position left for next stone
                }
            }
        }

        // Step 2: Rotate the matrix 90° clockwise
        char[][] rotated = new char[cols][];                            // New matrix has dimensions cols × rows
        for (int i = 0; i < cols; i++) {
            rotated[i] = new char[rows];                                // Initialise each row of the rotated matrix
        }

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                rotated[col][rows - 1 - row] = box[row][col];          // Clockwise rotation mapping: (row, col) → (col, rows-1-row)
            }
        }

        return rotated;                                                 // Return the gravity-applied, rotated box
    }
}