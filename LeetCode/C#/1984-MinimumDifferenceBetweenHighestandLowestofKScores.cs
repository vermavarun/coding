/*
Title: 1984. Minimum Difference Between Highest and Lowest of K Scores
Solution: https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/solutions/7522112/simplest-solution-c-time-on-log-n-space-ivf6z/
Difficulty: Easy
Approach: Sorting and Sliding Window
Tags: Array, Sorting, Sliding Window
1) Sort the array in ascending order.
2) Initialize result to maximum integer value.
3) Use a sliding window of size k.
4) Iterate through the array from index 0 to (length - k).
5) For each window, calculate difference between highest (i+k-1) and lowest (i).
6) Keep track of minimum difference found.
7) Return the minimum difference.

Time Complexity: O(n log n) where n = nums.length (due to sorting)
Space Complexity: O(1) or O(log n) depending on sorting algorithm
Tip: After sorting, the minimum difference will always be found in a consecutive subarray of size k. The key insight is that sorting arranges numbers so adjacent k elements give the smallest possible range.
Similar Problems: 253. Meeting Rooms II, 632. Smallest Range Covering Elements from K Lists, 910. Smallest Range II
*/
public class Solution {
    public int MinimumDifference(int[] nums, int k) {

        Array.Sort(nums);                                           // Sort array to group similar values together

        int result = int.MaxValue;                                  // Initialize result to maximum possible value

        for (int i=0; i<=nums.Length - k;i++) {                     // Iterate through valid window positions
            result = Math.Min(result,nums[i+k-1] - nums[i]);        // Update minimum difference (highest - lowest in window)
        }

        return result;                                              // Return the minimum difference found
    }
}