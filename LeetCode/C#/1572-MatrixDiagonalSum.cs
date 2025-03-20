/*
Solution:
Approach: Iteration
1. Initialize a variable sum to 0.
2. Iterate through the matrix mat.
3. Add the element at the index i and colIndex to sum.
4. Decrement colIndex by 1.
5. Repeat steps 3 and 4 until the end of the matrix.
6. If the length of the matrix is odd, subtract the element at the index lengthOfMatrix/2 and lengthOfMatrix/2 from sum.
7. Return sum.

Time complexity: O(n), where n is the number of elements in the matrix.
Space complexity: O(1).
*/
public class Solution {
    public int DiagonalSum(int[][] mat) {
        int lengthOfMatrix = mat.Length;                            // Get the length of the matrix.
        int colIndex = lengthOfMatrix - 1;                          // Initialize the column index to the last column.
        int sum = 0;                                                // Initialize a variable sum to 0.
        for(int i=0; i<lengthOfMatrix; i++) {                       // Iterate through the matrix.
            sum += mat[i][i];                                       // Add the element at the index i and i to sum.
            sum += mat[i][colIndex];                                // Add the element at the index i and colIndex to sum.
            colIndex--;                                             // Decrement colIndex by 1.
        }
        if (lengthOfMatrix % 2 != 0) {                              // If the length of the matrix is odd.
            sum = sum - mat[lengthOfMatrix/2][lengthOfMatrix/2];    // Subtract the element at the index lengthOfMatrix/2 and lengthOfMatrix/2 from sum.
        }
        return sum;                                                 // Return sum.
    }
}