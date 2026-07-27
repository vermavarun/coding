/*
Title: 1464. Maximum Product of Two Elements in an Array
Solution: https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array/solutions/8423831/simplest-solution-c-time-on-space-o1-ple-4qzr/
Difficulty: Easy
Approach: Track the two largest numbers in one pass
Tags: Array
1) Keep track of the largest and second largest values seen so far.
2) Iterate through the array once.
3) If the current number is larger than the largest, shift the largest into second largest.
4) Otherwise, update the second largest when needed.
5) Return (max1 - 1) * (max2 - 1).

Time Complexity: O(n) where n = nums.length
Space Complexity: O(1)
Tip: This avoids sorting the array. A single pass is enough because only the top two values matter for the final product.
Similar Problems: 628. Maximum Product of Three Numbers
*/
public class Solution {
    public int MaxProduct(int[] nums) {
        int max1 = 0; // Largest number seen so far
        int max2 = 0; // Second largest number seen so far

        foreach (int num in nums) { // Scan each number once
            if (num > max1) {
                max2 = max1; // Previous largest becomes second largest
                max1 = num; // Update the largest value
            }
            else if (num > max2) {
                max2 = num; // Update second largest when appropriate
            }
        }

        return (max1 - 1) * (max2 - 1); // Compute the required product
    }
}