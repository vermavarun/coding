/*
Title: 3660. Jump Game IX
Solution: https://leetcode.com/problems/jump-game-ix/solutions/8160213/simplest-solution-c-time-on-space-on-ple-y1xa/
Difficulty: Medium
Approach: Prefix Maximum + Suffix Minimum
Tags: Array, Greedy, Dynamic Programming
1) Build a prefix maximum array where prefixMaximum[i] holds the max of nums[0..i].
2) Traverse from right to left, tracking the running suffix minimum.
3) At each index, if the prefix maximum exceeds the suffix minimum, a valid right-side jump is unavailable — inherit the result from the next index (or 0 at the last index).
4) Otherwise, record the prefix maximum as the result for this index.
5) Update the suffix minimum with the current element before moving left.

Time Complexity: O(n) — two linear passes over the array
Space Complexity: O(n) — for the prefix maximum and result arrays
Tip: The core insight is that a jump from index i is safe only when the maximum reachable value from the left does not exceed the minimum value available on the right. Splitting the problem into prefix max and suffix min allows an O(n) solution.
Similar Problems: 45. Jump Game II, 55. Jump Game, 1696. Jump Game VI, 1871. Jump Game VII
*/
public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int arrayLength = nums.Length;                                  // Total number of elements

        int[] result = new int[arrayLength];                            // Stores the final answer for each index

        int[] prefixMaximum = new int[arrayLength];                     // prefixMaximum[i] = max of nums[0..i]

        prefixMaximum[0] = nums[0];                                     // First element is its own maximum

        for (int index = 1; index < arrayLength; index++)               // Build the prefix maximum array
        {
            prefixMaximum[index] = Math.Max(
                prefixMaximum[index - 1],
                nums[index]
            );
        }

        int suffixMinimum = int.MaxValue;                               // Tracks minimum seen while traversing right to left

        for (int index = arrayLength - 1; index >= 0; index--)         // Traverse from right to left
        {
            /*
                If the maximum value on the left side
                is greater than the minimum value on the right side,
                then the current prefix maximum cannot be used safely.

                In that case:
                - Reuse the value already calculated for the next position.
                - For the last element, use 0.
            */
            if (prefixMaximum[index] > suffixMinimum)
            {
                result[index] =
                    (index + 1 < arrayLength)
                    ? result[index + 1]
                    : 0;
            }
            else
            {
                result[index] = prefixMaximum[index];                   // Current prefix maximum is valid
            }

            suffixMinimum = Math.Min(suffixMinimum, nums[index]);       // Update suffix minimum with current element
        }

        return result;
    }
}