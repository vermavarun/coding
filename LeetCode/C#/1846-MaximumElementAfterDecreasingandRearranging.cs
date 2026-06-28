/*
Title: 1846. Maximum Element After Decreasing and Rearranging
Solution: https://leetcode.com/problems/maximum-element-after-decreasing-and-rearranging/solutions/8363120/simplest-solution-c-time-on-log-n-space-uz4sk/
Difficulty: Medium
Approach: Sort + Greedy normalization
Tags: Array, Greedy, Sorting
1) Sort the array so values are processed in non-decreasing order.
2) Force the first element to 1 (minimum valid start).
3) Traverse from left to right and ensure adjacent difference is at most 1.
4) If current value is too large, reduce it to previous + 1.
5) The last element is then the maximum achievable value.

Time Complexity: O(n log n) due to sorting
Space Complexity: O(1) extra space (ignoring sort implementation details)
Tip: After sorting, the optimal strategy is to keep values as large as possible while only enforcing the adjacent-difference rule.
Similar Problems: 945. Minimum Increment to Make Array Unique, 330. Patching Array
*/
public class Solution {
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr) {

        Array.Sort(arr);                                      // Sort to process elements in increasing order
        arr[0] = 1;                                           // First element must be 1 in any valid arrangement
        for(int i=1; i<arr.Length; i++) {                     // Validate each element against previous normalized value
            int diff = Math.Abs(arr[i]-arr[i-1]);             // Compute gap between current and previous element
            if (diff>1) {                                     // If gap is too large, reduce current to previous + 1
                arr[i] = arr[i-1] + 1;                        // Greedily keep current as large as allowed
            }
        }

        return arr[arr.Length-1];                             // Last element is the maximum achievable value
    }
}