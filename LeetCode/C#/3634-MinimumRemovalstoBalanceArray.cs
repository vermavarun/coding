/*
Title: 3634. Minimum Removals to Balance Array
Solution: https://leetcode.com/problems/minimum-removals-to-balance-array/solutions/7556628/simplest-solution-c-time-on-log-n-space-ere7k/
Difficulty: Medium
Approach: Sliding Window with Sorting
Tags: Array, Sliding Window, Two Pointers, Sorting
1) Sort the array to group similar values together.
2) Use sliding window with two pointers (left and right).
3) Expand the window by moving right pointer.
4) For each position, check if nums[right] <= k * nums[left] (balanced condition).
5) If condition violated, shrink window by moving left pointer forward.
6) Track the maximum valid window size found.
7) Return total elements minus max window size (elements to remove).

Time Complexity: O(n log n) where n = nums.length (dominated by sorting)
Space Complexity: O(1) or O(log n) depending on sorting implementation
Tip: The key insight is that after sorting, we can use a sliding window to find the longest subarray where the largest element is at most k times the smallest element. The minimum removals is then the complement of this maximum valid window.
Similar Problems: 713. Subarray Product Less Than K, 209. Minimum Size Subarray Sum, 904. Fruit Into Baskets
*/
public class Solution {
    public int MinRemoval(int[] nums, int k) {
        Array.Sort(nums);                                       // Sort array to group similar values

        int left = 0;                                           // Left pointer of sliding window
        int maxLength = 0;                                      // Track maximum valid window size

        // Expand right pointer
        for (int right = 0; right < nums.Length; right++) {     // Iterate through array with right pointer

            // Move left pointer when condition breaks
            while (nums[right] > (long)k * nums[left]) {        // If nums[right] > k * nums[left], window invalid
                left++;                                         // Shrink window from left
            }

            // Track max valid window size
            maxLength = Math.Max(maxLength, right - left + 1);  // Update max window size if current is larger
        }

        return nums.Length - maxLength;                         // Return elements to remove (total - max valid)
    }
}
