/*
Title: 1855. Maximum Distance Between a Pair of Values
Solution: https://leetcode.com/problems/maximum-distance-between-a-pair-of-values/solutions/7995164/simplest-solution-c-time-on-space-o1-ple-tcc8/
Difficulty: Medium
Approach: Two Pointers
Tags: Array, Two Pointers, Greedy, Binary Search
1) Initialize two pointers i and j at the start of both arrays.
2) Initialize ans variable to track maximum distance found.
3) Traverse both arrays simultaneously using while loop.
4) If nums1[i] > nums2[j], increment i to find valid pair (constraint violated).
5) Otherwise, calculate current distance (j - i) and update maximum.
6) Increment j to explore larger distances while maintaining validity.
7) Return the maximum distance found.

Time Complexity: O(n + m) where n = nums1.length and m = nums2.length
Space Complexity: O(1) - only using constant extra space for pointers
Tip: The greedy two-pointer approach works because both arrays are sorted in non-increasing order. When nums1[i] <= nums2[j], we can safely increment j to maximize distance since larger j values will still satisfy the constraint with current i.
Similar Problems: 11. Container With Most Water, 16. 3Sum Closest, 167. Two Sum II - Input Array Is Sorted, 925. Long Pressed Name
*/
public class Solution {
    public int MaxDistance(int[] nums1, int[] nums2) {
        int ans = 0;                                                // Track maximum distance found
        int i = 0;                                                  // Pointer for nums1 array
        int j = 0;                                                  // Pointer for nums2 array

        while (i < nums1.Length && j < nums2.Length)                // Traverse both arrays
        if (nums1[i] > nums2[j])                                    // If constraint violated (nums1[i] must be <= nums2[j])
            ++i;                                                    // Move i forward to find valid pair
        else                                                        // Valid pair found (i <= j and nums1[i] <= nums2[j])
            ans = Math.Max(ans, j++ - i);                           // Update max distance and increment j to explore larger distances

        return ans;                                                 // Return maximum distance between valid pairs
    }
}