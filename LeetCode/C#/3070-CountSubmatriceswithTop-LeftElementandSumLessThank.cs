/*
Title: 3070. Count Submatrices with Top-Left Element and Sum Less Than k
Solution: https://leetcode.com/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/solutions/7658430/simplest-solution-c-time-omn-space-o1-pl-53r0/
Difficulty: Medium
Approach: 2D Prefix Sum with Early Break Optimization
Tags: Array, Matrix, Prefix Sum
1) Initialize counter for valid submatrices.
2) Traverse each cell as potential bottom-right corner of submatrix starting from (0,0).
3) Build 2D prefix sum in-place by adding top neighbor, left neighbor, and subtracting top-left diagonal.
4) After prefix sum computation, each cell contains sum of rectangle from (0,0) to (i,j).
5) If prefix sum at current cell <= k, increment counter.
6) If prefix sum > k, break inner loop (optimization: values increase moving right).
7) Return total count of valid submatrices.

Time Complexity: O(m * n) where m = rows, n = columns (worst case, but early breaks improve average)
Space Complexity: O(1) - in-place modification, no extra space
Tip: The key insight is building prefix sums in-place while traversing. The optimization comes from breaking early when sum exceeds k, since values only increase moving right in a row due to cumulative summing.
Similar Problems: 304. Range Sum Query 2D - Immutable, 1074. Number of Submatrices That Sum to Target, 363. Max Sum of Rectangle No Larger Than K, 1314. Matrix Block Sum
*/
public class Solution
{
    public int CountSubmatrices(int[][] weirdGrid, int limitK)
    {
        int rowsMagic = weirdGrid.Length;                           // Get number of rows in matrix
        int colsMagic = weirdGrid[0].Length;                        // Get number of columns in matrix

        int answerBucket = 0;                                       // Counter for valid submatrices with sum <= k

        // Traverse each cell as bottom-right of submatrix (0,0) → (i,j)
        for (int rChaos = 0; rChaos < rowsMagic; rChaos++)         // Iterate through each row
        {
            for (int cChaos = 0; cChaos < colsMagic; cChaos++)     // Iterate through each column
            {
                // Build 2D prefix sum in-place

                // Add top contribution
                if (rChaos > 0)                                     // If not in first row
                    weirdGrid[rChaos][cChaos] += weirdGrid[rChaos - 1][cChaos];    // Add sum from cell above

                // Add left contribution
                if (cChaos > 0)                                     // If not in first column
                    weirdGrid[rChaos][cChaos] += weirdGrid[rChaos][cChaos - 1];    // Add sum from cell to left

                // Remove double-counted top-left area
                if (rChaos > 0 && cChaos > 0)                       // If not in first row or column
                    weirdGrid[rChaos][cChaos] -= weirdGrid[rChaos - 1][cChaos - 1];    // Subtract top-left diagonal (counted twice)

                // Now weirdGrid[r][c] = sum of submatrix (0,0) → (r,c)

                /*
                 Example:

                 Input:
                 grid = [
                   [1, 2],
                   [3, 4]
                 ], k = 5

                 Prefix sum transformation:

                 (0,0) = 1
                 (0,1) = 1 + 2 = 3
                 (1,0) = 1 + 3 = 4
                 (1,1) = 1+2+3+4 = 10

                 So grid becomes:
                 [
                   [1, 3],
                   [4, 10]
                 ]

                 Now check each:
                 1  <= 5 → count
                 3  <= 5 → count
                 4  <= 5 → count
                 10 > 5 → stop row early (break)
                */

                if (weirdGrid[rChaos][cChaos] <= limitK)            // If prefix sum at current cell <= k
                {
                    answerBucket++;                                 // Increment count (valid submatrix found)
                }
                else                                                // If prefix sum > k
                {
                    // Important optimization:
                    // Since values increase as we move right,
                    // no need to check further in this row
                    break;                                          // Exit inner loop early (optimization)
                }
            }
        }

        return answerBucket;                                        // Return total count of valid submatrices
    }
}