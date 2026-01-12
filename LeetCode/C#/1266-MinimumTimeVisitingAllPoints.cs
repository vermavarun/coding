/*
Title: 1266. Minimum Time Visiting All Points
Solution: https://leetcode.com/problems/minimum-time-visiting-all-points/solutions/7488116/simplest-solution-c-time-on-space1-pleas-zlgv/
Difficulty: Easy
Approach: Chebyshev Distance (Maximum of horizontal and vertical distance)
Tags: Array, Math, Geometry
1) Calculate the distance between consecutive points.
2) For each pair of points, compute horizontal distance (xDiff) and vertical distance (yDiff).
3) The minimum time is the maximum of xDiff and yDiff (Chebyshev distance).
4) You can move diagonally, so diagonal moves cover both x and y simultaneously.
5) Sum up all the distances between consecutive points.
6) Return the total time required.

Time Complexity: O(n) where n = number of points
Space Complexity: O(1) - only using constant extra space
Tip: The key insight is that you can move diagonally! Moving diagonally (dx=1, dy=1) takes 1 second, not 2. So the minimum time between two points is max(|x2-x1|, |y2-y1|), not their sum. You move diagonally until one coordinate aligns, then move straight.
Similar Problems: 2152. Minimum Number of Lines to Cover Points, 2613. Beautiful Pairs, 1037. Valid Boomerang
*/
public class Solution {
    public int MinTimeToVisitAllPoints(int[][] points) {

        int ans = 0;                                                // Total time to visit all points

        for (int i=0; i< points.Length - 1; i++) {                  // Iterate through consecutive point pairs
            int xDiff = Math.Abs(points[i][0] - points[i+1][0]);   // Horizontal distance between points
            int yDiff = Math.Abs(points[i][1] - points[i+1][1]);   // Vertical distance between points
            ans+= Math.Max(xDiff,yDiff);                            // Add Chebyshev distance (max of x and y diff)
        }

        return ans;                                                 // Return total minimum time
    }
}