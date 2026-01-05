/*
Solution: https://leetcode.com/problems/maximum-matrix-sum/solutions/7467833/simplest-solution-c-time-omn-space1-plea-z1oh/
Difficulty: Medium
Approach: Greedy with negative count tracking
Tags: Array, Greedy, Matrix, Math
1) Initialize sum to accumulate absolute values, count negative numbers, track minimum absolute value.
2) Iterate through entire matrix (all rows and columns).
3) For each element, update minimum absolute value across all elements.
4) Count negative numbers encountered.
5) Add absolute value of each element to sum.
6) If negative count is even, all negatives can be cancelled out - return sum.
7) If negative count is odd, one negative remains - subtract twice the smallest absolute value.

Time Complexity: O(m*n) where m = rows, n = columns
Space Complexity: O(1)
*/
public class Solution {
    public long MaxMatrixSum(int[][] matrix) {
        long sum = 0;                                               // Sum of absolute values of all elements
        long numOfNegativeNumbers = 0;                              // Count of negative numbers in matrix
        long minNumber = long.MaxValue;                             // Track smallest absolute value in matrix

        foreach (int[] arr in matrix) {                             // Iterate through each row
            foreach (int num in arr) {                              // Iterate through each element in row
                minNumber = Math.Min(minNumber,Math.Abs(num));      // Update minimum absolute value
                if (num < 0) {                                      // If element is negative
                    numOfNegativeNumbers++;                         // Increment negative count
                }
                sum+= Math.Abs(num);                                // Add absolute value to sum
            }
        }
        return numOfNegativeNumbers % 2 == 0 ? sum : (sum - 2*(Math.Abs(minNumber)));  // If even negatives: return sum, else subtract 2*min
    }
}