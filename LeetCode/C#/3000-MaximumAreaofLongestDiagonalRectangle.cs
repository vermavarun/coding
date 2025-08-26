
/*
Solution: https://leetcode.com/problems/maximum-area-of-longest-diagonal-rectangle/solutions/7123509/simplest-solution-c-time-on-space1-pleas-etb0/
Tags: Array, Math, Geometry
1) For each rectangle, calculate the squared diagonal (length^2 + breadth^2).
2) Track the maximum diagonal found so far and the corresponding area.
3) If a rectangle has a longer diagonal, update both maxDiagonal and maxArea.
4) If a rectangle has the same diagonal as the current max, update maxArea if its area is larger.
5) Return the area of the rectangle with the longest diagonal (and largest area if tie).

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int AreaOfMaxDiagonal(int[][] dimensions) {
        int maxDiagonal = int.MinValue;                  // Tracks the largest diagonal found (squared)
        int maxArea = int.MinValue;                      // Tracks the largest area for max diagonal
        foreach(int[] arr in dimensions) {               // Iterate through each rectangle
            int length = arr[0];                         // Rectangle length
            int breath = arr[1];                         // Rectangle breadth
            int diagonal = (length * length) + (breath * breath); // Squared diagonal length
            if (diagonal > maxDiagonal) {                // If this diagonal is the largest so far
               maxArea =  length * breath;               // Update max area
               maxDiagonal = diagonal;                   // Update max diagonal
            }
            else if (diagonal == maxDiagonal) {          // If diagonal ties with current max
                maxArea = Math.Max(maxArea, length * breath); // Take the larger area
            }
        }
        return maxArea;                                 // Return area of rectangle with max diagonal
    }
}