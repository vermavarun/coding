/*
Title: 3379. Transformed Array
Solution: https://leetcode.com/problems/transformed-array/solutions/7554010/simplest-solution-c-time-on-space-on-ple-cxyr/
Difficulty: Easy
Approach: Array transformation with modular arithmetic
Tags: Array, Math, Simulation
1) Create a result array of the same length as input.
2) Iterate through each index of the input array.
3) For each element, calculate the new index using modular arithmetic: (i + nums[i]) % n.
4) Handle negative indices by adding n to wrap around to positive values.
5) Store the value from the calculated index in the result array at position i.
6) Return the transformed result array.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the result array
Tip: The key insight is using modular arithmetic to handle circular array wrapping. When dealing with negative modulo results, add n to wrap correctly. This handles both forward and backward movements in a single formula.
Similar Problems: 189. Rotate Array, 61. Rotate List, 1470. Shuffle the Array
*/
public class Solution {
    public int[] ConstructTransformedArray(int[] nums) {

        int n = nums.Length;                                        // Store array length for modulo operations
        int[] result = new int[n];                                  // Initialize result array with same length

        for (int i = 0; i < n; i++) {                              // Iterate through each index

            // handles both directions mathematically
            // Moves both forward and backward.
            int newIndex = (i + nums[i]) % n;                       // Calculate new index using modular arithmetic

            // Handle negative modulo
            if (newIndex < 0)                                       // If modulo result is negative (backward movement)
                newIndex += n;                                      // Wrap around by adding n to get positive index

            result[i] = nums[newIndex];                             // Store value from calculated index in result
        }

        return result;                                              // Return the transformed array
    }
}
