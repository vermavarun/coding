/*
Solution: https://leetcode.com/problems/set-matrix-zeroes/solutions/6768863/simplest-solution-c-time-omn-space1-plea-wpzy/
Approach: Iterative
1. Check if the first row and first column need to be set to zero.
2. Use the first row and first column to mark which rows and columns need to be set to zero.
3. Set the elements in the marked rows and columns to zero.
4. Finally, set the first row and first column to zero if they were marked.

Time Complexity: O(m*n)
Space Complexity: O(1)
*/
public class Solution {
    public void SetZeroes(int[][] matrix) {
        bool firstColumnImpacted = false;                               // declare a boolean variable to check if the first column is impacted
        bool firstRowImpacted = false;                                  // declare a boolean variable to check if the first row is impacted

        int rows = matrix.Length;                                       // get the number of rows
        int columns = matrix[0].Length;                                 // get the number of columns

        for(int i=0; i<rows; i++) {                                     // check if the first column is impacted
            if (matrix[i][0] == 0) {                                    // if the first column is impacted
                firstColumnImpacted = true;                             // if the first column is impacted, set the boolean variable to true
                break;                                                  // break the loop
            }
        }

        for(int i=0; i<columns; i++) {                                  // check if the first row is impacted
            if (matrix[0][i] == 0) {                                    // if the first row is impacted
                firstRowImpacted = true;                                // if the first row is impacted, set the boolean variable to true
                break;                                                  // break the loop
            }
        }

        for(int i=1; i<rows; i++) {                                     // check if the first row and first column need to be set to zero
            for(int j=1; j<columns; j++) {                              // check if the first row and first column need to be set to zero

                if(matrix[i][j] == 0) {                                 // if the element is zero
                    matrix[i][0] = 0;                                   // set the first column to zero
                    matrix[0][j] = 0;                                   // set the first row to zero
                }
            }
        }

        for(int i=1; i<rows; i++) {                                     // set the elements in the marked rows and columns to zero
            for(int j=1; j<columns; j++) {                              // set the elements in the marked rows and columns to zero

                if(matrix[i][0] == 0 || matrix[0][j] == 0) {            // if the first column or first row is zero
                    matrix[i][j] = 0;                                   // set the element to zero
                }
            }
        }

        if(firstRowImpacted) {                                          // check if the first row is impacted
            for(int i=0; i<columns; i++) {                              // set the first row to zero
                matrix[0][i] = 0;                                       // set the first row to zero
            }
        }

        if(firstColumnImpacted) {                                       // check if the first column is impacted
            for(int i=0; i<rows; i++) {                                 // set the first column to zero
                matrix[i][0] = 0;                                       // set the first column to zero
            }
        }
    }
}