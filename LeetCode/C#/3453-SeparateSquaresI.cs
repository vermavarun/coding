/*
Title: 3453. Separate Squares I
Solution: https://leetcode.com/problems/separate-squares-i/solutions/7491164/simplest-solution-c-time-on-logrange-spa-flle/
Difficulty: Medium
Approach: Binary Search on Y-coordinate
Tags: Array, Binary Search, Geometry, Math
1) Calculate total area of all squares and find the range of y-coordinates.
2) Target area for separation is total area divided by 2.
3) Use binary search on y-coordinate to find the horizontal line that divides area equally.
4) For each candidate y-line (mid), calculate the area below the line.
5) If area below is >= target, move the line down (high = mid), else move up (low = mid).
6) After 60 iterations, we achieve precision of 1e-5 for the optimal y-coordinate.

Time Complexity: O(n * log(range)) where n = number of squares, log(range) ≈ 60 iterations
Space Complexity: O(1) - only using constant extra space
Tip: The key insight is that we're finding a horizontal line (y = k) that splits the total area in half. Binary search works because as we move the line up, the area below increases monotonically. For each square, calculate its contribution to the area below the line using Min(mid, top) - y.
Similar Problems: 410. Split Array Largest Sum, 1011. Capacity To Ship Packages Within D Days, 875. Koko Eating Bananas, 1482. Minimum Number of Days to Make m Bouquets
*/
public class Solution {
    public double SeparateSquares(int[][] squares) {

        double total = 0;                                           // Total area of all squares
        double low = double.MaxValue, high = double.MinValue;       // Range of y-coordinates for binary search

        foreach (var s in squares) {                                // Iterate through each square
            int y = s[1], l = s[2];                                 // y = bottom y-coordinate, l = side length
            total += (double)l * l;                                 // Add square's area to total
            low = Math.Min(low, y);                                 // Find lowest y-coordinate
            high = Math.Max(high, y + l);                           // Find highest y-coordinate (y + length)
        }

        double target = total / 2.0;                                // Target area for equal division

        // binary search on y
        for (int i = 0; i < 60; i++) {                              // 60 iterations gives precision of 1e-5
            double mid = (low + high) / 2.0;                        // Candidate y-coordinate for horizontal line
            double area = 0;                                        // Area below the line

            foreach (var s in squares) {                            // Calculate area below mid line
                int y = s[1], l = s[2];                             // y = bottom, l = side length
                double top = y + l;                                 // Top edge of square

                if (mid > y) {                                      // If line intersects or is above square bottom
                    area += Math.Min(mid, top) - y > 0              // Calculate portion of square below line
                        ? (Math.Min(mid, top) - y) * l              // Height below line * width
                        : 0;                                        // If no intersection, area is 0
                }
            }

            if (area >= target)                                     // If area below is at least half
                high = mid;                                         // Move line down (search lower y values)
            else                                                    // If area below is less than half
                low = mid;                                          // Move line up (search higher y values)
        }

        return low;                                                 // Return the y-coordinate that splits area equally
    }
}
