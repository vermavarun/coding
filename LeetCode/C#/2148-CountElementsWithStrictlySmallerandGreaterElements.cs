/*
Title: 2148. Count Elements With Strictly Smaller and Greater Elements
Solution: https://leetcode.com/problems/count-elements-with-strictly-smaller-and-greater-elements/solutions/7539801/simplest-solution-c-time-on-log-n-space-x1upu/
Difficulty: Easy
Approach: Sorting
Tags: Array, Sorting
1) Check if array has less than 3 elements - if so, return 0 (impossible to have elements strictly between min and max).
2) Sort the array to easily identify minimum and maximum values.
3) Get the minimum element (first element after sorting).
4) Get the maximum element (last element after sorting).
5) Initialize a counter to track valid elements.
6) Iterate through all elements in the array.
7) For each element, check if it's strictly greater than min AND strictly less than max.
8) If condition is met, increment the counter.
9) Return the final count.

Time Complexity: O(n log n) where n = nums.length (dominated by sorting)
Space Complexity: O(1) excluding sorting overhead (in-place sorting)
Tip: The key insight is that after sorting, the minimum and maximum are at the boundaries. We need to count elements that are strictly in between - not equal to either boundary value.
Similar Problems: 2293. Min Max Game, 1491. Average Salary Excluding the Minimum and Maximum Salary
*/
public class Solution {
    public int CountElements(int[] nums) {
        if (nums.Length < 3) return 0;                                                              // If array has less than 3 elements, return 0 (no elements can be strictly between min and max)

        Array.Sort(nums);                                                                           // Sort the array to identify min and max easily

        int min = nums[0];                                                                          // Get the minimum element (first element after sorting)
        int max = nums[nums.Length - 1];                                                            // Get the maximum element (last element after sorting)
        int count = 0;                                                                              // Initialize counter for valid elements

        foreach (int num in nums) {                                                                 // Iterate through each element in the array
            if (num > min && num < max) {                                                           // Check if element is strictly greater than min AND strictly less than max
                count++;                                                                            // Increment counter if condition is met
            }
        }

        return count;                                                                               // Return the final count of valid elements
    }
}
