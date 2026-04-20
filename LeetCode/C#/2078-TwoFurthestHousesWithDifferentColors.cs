/*
Title: 2078. Two Furthest Houses With Different Colors
Solution: https://leetcode.com/problems/two-furthest-houses-with-different-colors/solutions/8012210/simplest-solution-c-time-on-space-o1-ple-0srq/
Difficulty: Easy
Approach: Two Pointer with Greedy Search
Tags: Array, Greedy
1) Get the length of the colors array.
2) Initialize two pointers: i at start (0) and j at end (n-1).
3) Move i forward from start while color at i matches color at end.
4) Move j backward from end while color at j matches color at start.
5) The maximum distance is either from colors[0] to colors[j] (distance j) or from colors[i] to colors[n-1] (distance n-1-i).
6) Return the maximum of these two distances.

Time Complexity: O(n) where n is the length of colors array (single pass with two pointers)
Space Complexity: O(1) - only using constant extra space
Tip: The optimal solution leverages the fact that the maximum distance must involve either the first house or the last house. By checking both directions (from start and from end), we find the furthest house with a different color efficiently.
Similar Problems: 121. Best Time to Buy and Sell Stock, 11. Container With Most Water, 42. Trapping Rain Water
*/
public class Solution {
    public int MaxDistance(int[] colors) {
        int n = colors.Length;                                      // Get total number of houses
        int i = 0;                                                  // Initialize left pointer at start
        int j = n - 1;                                              // Initialize right pointer at end

        while (colors[i] == colors[n - 1])                          // Move i forward while same color as last house
            ++i;

        while (colors[j] == colors[0])                              // Move j backward while same color as first house
            --j;

        return Math.Max(n - 1 - i, j);                              // Return max distance from either end
    }
}