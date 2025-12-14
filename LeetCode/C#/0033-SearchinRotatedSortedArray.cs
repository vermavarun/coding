/*
Solution: https://leetcode.com/problems/search-in-rotated-sorted-array/solutions/7042000/simplest-solution-c-time-olog-n-space1-p-5knq/
Difficulty: Medium
Approach: Modified Binary Search
Tags: Array, Binary Search, Divide and Conquer
1) Use binary search with left and right pointers.
2) Check if mid element equals target, return index if found.
3) Determine which half of the array is sorted (left or right).
4) Check if target lies within the sorted half's range.
5) If target is in sorted half, search that half; otherwise search the other half.
6) Return -1 if target is not found after exhausting search space.

Time Complexity: O(log n)
Space Complexity: O(1)
*/
public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0;                                               // Left pointer for binary search
        int right = nums.Length - 1;                                // Right pointer for binary search

        while (left <= right) {                                     // Continue while search space exists
            int mid = left + (right - left) / 2;                    // Calculate mid point to avoid overflow

            if (nums[mid] == target)                                // If target found at mid
                return mid;                                         // Return the index

            // Left half is sorted
            if (nums[left] <= nums[mid]) {                          // Check if left half is sorted
                if (nums[left] <= target && target < nums[mid]) {   // If target is in left sorted half
                    right = mid - 1;                                // Search left half
                } else {                                            // Target is not in left half
                    left = mid + 1;                                 // Search right half
                }
            }
            // Right half is sorted
            else {                                                  // Right half must be sorted
                if (nums[mid] < target && target <= nums[right]) {  // If target is in right sorted half
                    left = mid + 1;                                 // Search right half
                } else {                                            // Target is not in right half
                    right = mid - 1;                                // Search left half
                }
            }
        }

        return -1;                                                  // Target not found, return -1
    }
}

 // [4,5,6,7,0,1,2] target = 0

//[6,8,9,34,45,67,1] target = 1

// [67,1,2,3,4,5,6] target = 67