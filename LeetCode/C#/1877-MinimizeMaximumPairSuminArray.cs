/*
Title: 1877. Minimize Maximum Pair Sum in Array
Solution: https://leetcode.com/problems/minimize-maximum-pair-sum-in-array/solutions/7520559/simplest-solution-c-time-on-log-n-space-ur40p/
Difficulty: Medium
Approach: Greedy with sorting and two-pointer pairing
Tags: Array, Greedy, Sorting, Two Pointers
1) Sort the array in ascending order.
2) Use two pointers: one at the start and one at the end.
3) Pair the smallest element with the largest element.
4) Calculate the sum of each pair and track the maximum sum.
5) Move both pointers inward and repeat until all elements are paired.
6) Return the maximum pair sum found.

Time Complexity: O(n log n) where n = nums.length (dominated by sorting)
Space Complexity: O(1) or O(n) depending on sorting implementation
Tip: The key insight is that pairing smallest with largest minimizes the maximum pair sum. After sorting, pair nums[i] with nums[n-1-i]. This greedy approach works because it prevents any large number from pairing with another large number, which would create a very large sum.
Similar Problems: 561. Array Partition, 881. Boats to Save People, 2576. Find the Maximum Number of Marked Indices
*/
public class Solution {
    public int MinPairSum(int[] nums) {
        Array.Sort(nums);                                       // Sort array in ascending order
        int maxPairSum = 0;                                     // Track maximum pair sum found
        int left = 0;                                           // Left pointer starting at beginning
        int right = nums.Length - 1;                            // Right pointer starting at end

        while (left < right) {                                  // Continue until pointers meet
            int currentSum = nums[left] + nums[right];          // Calculate sum of smallest and largest unpaired elements
            maxPairSum = Math.Max(maxPairSum, currentSum);      // Update maximum if current sum is larger
            left++;                                             // Move left pointer forward
            right--;                                            // Move right pointer backward
        }

        return maxPairSum;                                      // Return the maximum pair sum
    }
}