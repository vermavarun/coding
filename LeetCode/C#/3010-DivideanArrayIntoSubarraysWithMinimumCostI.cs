/*
Title: 3010. Divide an Array Into Subarrays With Minimum Cost I
Solution: https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/solutions/7541838/simplest-solution-c-time-on-space-o1-ple-6fhs/
Difficulty: Easy
Approach: Greedy - Find Two Smallest Elements
Tags: Array, Greedy, Sorting
1) The first element must be included in the first subarray (given constraint).
2) To minimize cost, we need to find the two smallest elements from the remaining array (index 1 onwards).
3) Initialize two variables to track the smallest and second smallest values.
4) Iterate through the array starting from index 1.
5) If current element is smaller than min, update min2 to current min, then update min to current element.
6) Else if current element is smaller than min2, update min2 to current element.
7) Return the sum of first element, smallest, and second smallest.

Time Complexity: O(n) where n = nums.length (single pass through array)
Space Complexity: O(1) (only using constant extra space)
Tip: The key insight is that the first element is fixed (must be in first subarray), so we just need to find the two smallest elements from the rest of the array. This greedy approach works because we want to minimize the sum.
Similar Problems: 2587. Rearrange Array to Maximize Prefix Score, 3011. Find if Array Can Be Sorted
*/
public class Solution {
    public int MinimumCost(int[] nums) {
        int first = nums[0];                                        // First element must be included (fixed constraint)
        int min = int.MaxValue;                                     // Track the smallest element from index 1 onwards
        int min2 = int.MaxValue;                                    // Track the second smallest element from index 1 onwards

        for (int i = 1; i < nums.Length; i++) {                     // Iterate through array starting from index 1
            if (nums[i] < min) {                                    // If current element is smaller than current minimum
                min2 = min;                                         // Move current min to second smallest
                min = nums[i];                                      // Update min to current element
            }
            else if (nums[i] < min2) {                              // Else if current element is smaller than second smallest
                min2 = nums[i];                                     // Update second smallest to current element
            }
        }

        return first + min + min2;                                  // Return sum of first element and two smallest elements
    }
}
