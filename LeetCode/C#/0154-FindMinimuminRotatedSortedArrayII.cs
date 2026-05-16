/*
Title: 154. Find Minimum in Rotated Sorted Array II
Solution: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/solutions/8245878/simplest-solution-c-time-olog-n-space-o1-xp74/
Difficulty: Hard
Approach: Binary Search with duplicate handling
Tags: Array, Binary Search
1) Initialize left and right pointers at the start and end of the array.
2) Use binary search: compute mid = left + (right - left) / 2.
3) If nums[mid] == nums[right], we can't determine which side the minimum is on, so shrink right by 1.
4) If nums[mid] > nums[right], the minimum is in the right half, so move left to mid + 1.
5) If nums[mid] < nums[right], the minimum is in the left half (including mid), so move right to mid.
6) When left == right, we've found the minimum at nums[left].

Time Complexity: O(log n) average, O(n) worst case (all duplicates)
Space Complexity: O(1) — constant extra space
Tip: The key difference from problem 153 is handling duplicates. When nums[mid] == nums[right], we can't safely discard either half, so we shrink the search space by one (right--) rather than halving it.
Similar Problems: 33. Search in Rotated Sorted Array, 81. Search in Rotated Sorted Array II, 153. Find Minimum in Rotated Sorted Array
*/
public class Solution {
    public int FindMin(int[] nums) {

        int left = 0;
        int right = nums.Length - 1;                                // Pointers for binary search bounds

        while (left < right) {                                      // Continue until pointers converge

            int mid = left + (right - left) / 2;                   // Avoid integer overflow

            if (nums[mid] == nums[right]) {
                right--;                                            // Can't tell which half has min; shrink right
            }
            else if (nums[mid] > nums[right]) {
                left = mid + 1;                                     // Min must be in right half
            }
            else {
                right = mid;                                        // Min is in left half (including mid)
            }

        }

        return nums[left];                                          // left == right, pointing at the minimum

    }
}