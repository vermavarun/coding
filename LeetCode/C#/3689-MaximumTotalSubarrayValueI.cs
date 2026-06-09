/*
Title: 3689. Maximum Total Subarray Value I
Solution: https://leetcode.com/problems/maximum-total-subarray-value-i/solutions/8323579/simplest-solution-c-time-on-space-o1-ple-io1t/
Difficulty: Medium
Approach: Greedy - pick the globally best subarray k times
Tags: Array, Greedy
1) The value of any subarray is defined as (max element - min element).
2) The maximum possible subarray value is always (global max - global min).
3) Since subarrays can overlap and be reused, always pick this maximum-value subarray.
4) To maximize the total across k picks, multiply the best single value by k.

Time Complexity: O(n) for two linear scans (Max and Min)
Space Complexity: O(1) no extra space used
Tip: The key insight is that the best subarray value equals the global range (max - min), and you can always reuse it k times to maximize the total.
Similar Problems: 2090. K Radius Subarray Averages, 2104. Sum of Subarray Ranges
*/
public class Solution {
    public long MaxTotalValue(int[] nums, int k) {
        return (long)(nums.Max() - nums.Min()) * k;     // Best subarray value is global (max - min), taken k times
    }
}