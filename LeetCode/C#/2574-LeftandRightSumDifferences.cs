/*
Title: 2574. Left and Right Sum Differences
Solution: https://leetcode.com/problems/left-and-right-sum-differences/solutions/8317049/simplest-solution-c-time-on-space-on-ple-hl0n/
Difficulty: Easy
Approach: Prefix Sum with running left/right totals
Tags: Array, Prefix Sum
1) Compute total sum of the array.
2) Initialize leftSum = 0 and rightSum = total sum.
3) For each index i, left = leftSum (sum of elements before i).
4) Right = rightSum - nums[i] (sum of elements after i).
5) Store absolute difference |left - right| in result array.
6) Update leftSum and rightSum for the next iteration.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the result array
Tip: Track running left and right sums simultaneously to avoid recomputing prefix/suffix sums from scratch at each index. Start with rightSum = total and subtract as you move forward.
Similar Problems: 724. Find Pivot Index, 1991. Find the Middle Index in Array
*/
public class Solution {
    public int[] LeftRightDifference(int[] nums) {
        int sum = nums.Sum();                       // Total sum of the array
        int leftSum = 0;                            // Sum of elements to the left (initially 0)
        int rightSum = sum;                         // Sum of elements to the right (initially total)

        int[] result = new int[nums.Length];        // Result array to store differences

        for (int i=0; i<nums.Length; i++) {

            int left = leftSum;                     // Left sum excludes nums[i]
            int right = rightSum - nums[i];         // Right sum excludes nums[i]

            result[i] = Math.Abs(left - right);     // Store absolute difference
            rightSum = rightSum - nums[i];          // Shrink right window by removing nums[i]
            leftSum = leftSum + nums[i];            // Grow left window by adding nums[i]
        }

        return result;                              // Return the differences array
    }
}