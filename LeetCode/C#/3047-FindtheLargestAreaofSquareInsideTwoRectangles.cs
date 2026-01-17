/*
Title: 3047. Find the Largest Area of Square Inside Two Rectangles
Solution: https://leetcode.com/problems/find-the-largest-area-of-square-inside-two-rectangles/solutions/7501845/simplest-solution-c-time-on2-space-o1-pl-tfgr/
Difficulty: Medium
Approach: Brute Force - Check all pairs of rectangles for overlaps
Tags: Geometry, Math
1) Get the number of rectangles from the bottomLeft array length.
2) Initialize maxArea to 0 to track the largest square found.
3) Iterate through all unique pairs of rectangles (i, j) where i < j.
4) For each pair, calculate the overlap width by finding the minimum of right edges minus the maximum of left edges.
5) Calculate the overlap height by finding the minimum of top edges minus the maximum of bottom edges.
6) If both overlap dimensions are positive (rectangles do overlap), calculate the side length of the largest square as the minimum of width and height.
7) Update maxArea if this square is larger than previously found squares.
8) Return the maximum area found (area = side * side).

Time Complexity: O(n²) where n = number of rectangles
Space Complexity: O(1) for constant extra space
Tip: The key insight is that the largest square that can fit in the intersection of two rectangles has a side length equal to the minimum of the overlap width and height. We need to check all pairs to find the maximum such square across all possible rectangle combinations.
Similar Problems: 1239. Maximum Length of a Concatenated String with Unique Characters, 2560. House Robber IV
*/
public class Solution {
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight) {
        int n = bottomLeft.Length;                                              // Number of rectangles
        long maxArea = 0;                                                       // Track the maximum area found

        for (int i = 0; i < n; i++) {                                          // Outer loop through rectangles
            for (int j = i + 1; j < n; j++) {                                  // Inner loop for all pairs (i < j)
                int overlapWidth =                                              // Calculate horizontal overlap
                    Math.Min(topRight[i][0], topRight[j][0]) -                  // Minimum of right edges
                    Math.Max(bottomLeft[i][0], bottomLeft[j][0]);               // Minus maximum of left edges

                int overlapHeight =                                             // Calculate vertical overlap
                    Math.Min(topRight[i][1], topRight[j][1]) -                  // Minimum of top edges
                    Math.Max(bottomLeft[i][1], bottomLeft[j][1]);               // Minus maximum of bottom edges

                if (overlapWidth > 0 && overlapHeight > 0) {                    // If rectangles overlap
                    long side = Math.Min(overlapWidth, overlapHeight);          // Side of square = min(width, height)
                    maxArea = Math.Max(maxArea, side * side);                   // Update max area if this square is larger
                }
            }
        }

        return maxArea;                                                         // Return the largest square area found
    }
}
