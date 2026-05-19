/*
Title: 2540. Minimum Common Value
Solution: https://leetcode.com/problems/minimum-common-value/solutions/8272669/simplest-solution-c-time-on-m-space-o1-p-lgg9/
Difficulty: Easy
Approach: Two Pointers on sorted arrays
Tags: Array, Hash Table, Two Pointers, Binary Search
1) Use two pointers i and j starting at the beginning of nums1 and nums2.
2) If nums1[i] == nums2[j], a common value is found — return it immediately (it's the minimum since both arrays are sorted).
3) If nums1[i] < nums2[j], advance i to look for a larger value in nums1.
4) Otherwise, advance j to look for a larger value in nums2.
5) If no common value is found, return -1.

Time Complexity: O(n + m) where n = nums1.length, m = nums2.length
Space Complexity: O(1) — only two pointers used
Tip: Since both arrays are sorted and we want the minimum common value, the two-pointer approach naturally finds the first match in O(n + m) without any extra space. A hash set approach also works but uses O(n) space.
Similar Problems: 349. Intersection of Two Arrays, 350. Intersection of Two Arrays II, 1385. Find the Distance Value Between Two Arrays
*/
public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {

        int result = -1;
        int i = 0;                                                  // Pointer for nums1
        int j = 0;                                                  // Pointer for nums2

        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] == nums2[j]) {                             // Common value found — minimum since arrays are sorted
                result = nums1[i];
                break;
            }
            else if (nums1[i] < nums2[j]) {                        // nums1 is behind, advance it
                i++;
            }
            else {                                                  // nums2 is behind, advance it
                j++;
            }
        }

        return result;                                              // -1 if no common value exists
    }
}