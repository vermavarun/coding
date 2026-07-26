/*
Title: 628. Maximum Product of Three Numbers
Solution: https://leetcode.com/problems/maximum-product-of-three-numbers/submissions/2081627940/?envType=daily-question&envId=2026-07-26
Difficulty: Easy
Approach: Sorting with negative number optimization
Tags: Array, Math, Sorting
1) Sort the array in ascending order.
2) Calculate two possible maximum products:
   a) Product of three largest numbers (last three elements)
   b) Product of two smallest numbers (could be negative) × largest number
3) Return the maximum of these two products.
4) Key insight: Two large negative numbers multiplied give a large positive number,
   which when multiplied by the largest positive number may exceed the product of three largest numbers.

Time Complexity: O(n log n) due to sorting where n = nums.length
Space Complexity: O(1) if sorting is in-place (may be O(log n) or O(n) depending on sort implementation)
Tip: A better O(n) approach tracks the three largest and two smallest values in a single pass without full sorting.
Similar Problems: 152. Maximum Product Subarray, 238. Product of Array Except Self, 268. Missing Number
*/
public class Solution {
    public int MaximumProduct(int[] nums) {
        Array.Sort(nums);                                           // Sort array in ascending order O(n log n)
        int n = nums.Length - 1;                                    // Store last valid index

        // Two scenarios for maximum product:
        int product1 = nums[n] * nums[n-1] * nums[n-2];            // Three largest numbers
        int product2 = nums[0] * nums[1] * nums[n];                // Two smallest (possibly negative) × largest

        return Math.Max(product1, product2);                        // Return the maximum product
    }
}