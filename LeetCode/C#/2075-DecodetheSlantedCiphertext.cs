/*
Title: 2075. Decode the Slanted Ciphertext
Solution: https://leetcode.com/problems/decode-the-slanted-ciphertext/solutions/7778837/simplest-solution-c-time-on-space-on-ple-4z6h/
Difficulty: Medium
Approach: Diagonal traversal of virtual 2D matrix
Tags: String, Matrix, Simulation
1) Handle edge case: if rows is 0, return empty string.
2) Calculate the number of columns by dividing text length by rows.
3) Create a StringBuilder to efficiently build the decoded string.
4) Traverse each diagonal starting from column 0 to cols-1.
5) For each diagonal, start at row 0 and the current start column.
6) Move diagonally (down-right) by incrementing both row and column.
7) Append each character from the encoded text using the formula: row * cols + col.
8) After all diagonals are traversed, remove trailing spaces.
9) Return the decoded string without trailing spaces.

Time Complexity: O(n) where n = encodedText.length (visit each character once)
Space Complexity: O(n) for the StringBuilder to store the result
Tip: The key insight is that the encoded text represents a 2D matrix stored row-by-row in a 1D string. To decode, read diagonally (top-left to bottom-right) starting from each column in the first row. Use the index formula (row * cols + col) to access the correct character in the 1D string.
Similar Problems: 498. Diagonal Traverse, 54. Spiral Matrix, 59. Spiral Matrix II, 885. Spiral Matrix III
*/
public class Solution {
    public string DecodeCiphertext(string encodedText, int rows) {
        if (rows == 0) return "";                                   // Edge case: no rows means empty result

        int n = encodedText.Length;                                 // Total length of encoded text
        int cols = n / rows;                                        // Calculate number of columns in virtual matrix

        var sb = new System.Text.StringBuilder();                   // StringBuilder for efficient string construction

        // Traverse diagonals starting from each column in first row
        for (int startCol = 0; startCol < cols; startCol++) {       // Iterate through each starting column
            int r = 0, c = startCol;                                // Initialize row and column for diagonal traversal

            while (r < rows && c < cols) {                          // Continue while within matrix bounds
                sb.Append(encodedText[r * cols + c]);               // Append character at (r, c) using 1D index formula
                r++;                                                // Move down one row
                c++;                                                // Move right one column
            }
        }

        // Remove trailing spaces from the decoded string
        int end = sb.Length - 1;                                    // Start from the last character
        while (end >= 0 && sb[end] == ' ') {                        // Find the last non-space character
            end--;                                                  // Move backwards
        }

        return sb.ToString(0, end + 1);                             // Return substring without trailing spaces
    }
}