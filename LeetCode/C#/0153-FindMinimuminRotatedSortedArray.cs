/*
Solution: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/solutions/7027831/simplest-solution-c-time-olog-n-space1-p-0qor/
Difficulty: Medium
Approach: Modified Binary Search
Tags: Array, Binary Search, Divide and Conquer
1) Use binary search with left and right pointers.
2) Compare mid element with right element (never compare mid with left).
3) If nums[mid] > nums[right], minimum is in the right half.
4) Otherwise, minimum is at mid or in the left half.
5) Continue until left equals right, which points to the minimum.
6) Return the element at the converged position.
Space Complexity: O(1)

Time Complexity: O(log n)
Space Complexity: O(1)
*/
public class Solution {
    public int FindMin(int[] nums) {
        int left = 0;                                               // Left pointer for binary search
        int right = nums.Length - 1;                                // Right pointer for binary search

        while (left < right) {                                      // Continue until pointers converge
            int mid = left + (right - left) / 2;                    // Calculate mid point to avoid overflow

            if (nums[mid] > nums[right]) { // Always compare mid and right and never left with mid !important
                // Minimum must be to the right of mid
                left = mid + 1;                                     // Move left pointer past mid
            } else {
                // Minimum is at mid or to the left
                right = mid;                                        // Move right pointer to mid (include mid)
            }
        }

        return nums[left];                                          // Return the minimum element found
    }
}
