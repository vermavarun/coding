/*
Title: 2161. Partition Array According to Given Pivot
Solution: https://leetcode.com/problems/partition-array-according-to-given-pivot/solutions/8320912/simplest-solution-c-time-on-space-on-ple-hsbm/
Difficulty: Medium
Approach: Three-pass partitioning
Tags: Array, Two Pointers, Simulation
1) Create a result array of the same length as input.
2) First pass: fill elements less than pivot in order.
3) Second pass: fill elements equal to pivot in order.
4) Third pass: fill elements greater than pivot in order.
5) Return the partitioned array.

Time Complexity: O(n) where n = nums.length (three linear passes)
Space Complexity: O(n) for the result array
Tip: The key insight is that three separate passes naturally preserve relative order (stability) for each partition group - less than, equal to, and greater than pivot. This avoids complex in-place swapping logic.
Similar Problems: 75. Sort Colors, 86. Partition List, 905. Sort Array By Parity
*/
public class Solution {
    public int[] PivotArray(int[] nums, int pivot) {

       int i=0;                                             // Pointer to track current insertion index
       int[] ans = new int[nums.Length];                    // Result array with same size as input

       foreach (int num in nums) {                          // First pass: collect elements less than pivot
            if (num < pivot)
                ans[i++] = num;                             // Place smaller elements first, preserving order
       }

       foreach (int num in nums) {                          // Second pass: collect elements equal to pivot
            if (num == pivot)
                ans[i++] = num;                             // Place pivot elements in the middle
       }

       foreach (int num in nums) {                          // Third pass: collect elements greater than pivot
            if (num > pivot)
                ans[i++] = num;                             // Place larger elements last, preserving order
       }

        return ans;                                         // Return the partitioned array

    }
}