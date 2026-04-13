/*
Title: 1848. Minimum Distance to the Target Element
Solution: https://leetcode.com/problems/minimum-distance-to-the-target-element/solutions/7885611/simplest-solution-c-time-on-space-o1-ple-oqfy/
Difficulty: Easy
Approach: Linear Scan with Distance Calculation
Tags: Array
1) Initialize result variable to maximum integer value.
2) Iterate through the entire array with index tracking.
3) For each element that matches the target value, calculate absolute distance from start index.
4) Keep track of the minimum distance found so far using Math.Min.
5) Return the minimum distance after checking all matching elements.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(1) - only using constant extra space
Tip: The key is to scan the entire array once and calculate the absolute distance for every occurrence of the target. Using Math.Abs ensures we handle indices both before and after the start position correctly.
Similar Problems: 121. Best Time to Buy and Sell Stock, 283. Move Zeroes, 485. Max Consecutive Ones
*/
public class Solution {
    public int GetMinDistance(int[] nums, int target, int start) {

        int result = int.MaxValue;                                  // Initialize result to maximum possible value

        for(int i=0; i<nums.Length; i++) {                          // Iterate through entire array
            if (nums[i] == target) {                                // Check if current element matches target
                result = Math.Min(result, Math.Abs(i - start));     // Update minimum distance if current is smaller
            }
        }

        return result;                                              // Return minimum distance found
    }
}