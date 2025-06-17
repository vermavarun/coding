/*
Solution: https://leetcode.com/problems/maximum-difference-between-increasing-elements/solutions/6852841/simplest-solution-c-time-on-space1-pleas-j7tq/
Approach: Two Pointers
1) Initialize two pointers: `minPosition` at the start and `maxPosition` at the second element.
2) Iterate through the array with `maxPosition`:
   - If the current element at `maxPosition` is greater than the element at `minPosition`, calculate the difference and update `maxDiff` if this difference is greater than the current `maxDiff`.
   - If the current element at `maxPosition` is not greater, move `minPosition` to `maxPosition`.
3) Continue until `maxPosition` reaches the end of the array.
4) Return `maxDiff`.

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution
{
    public int MaximumDifference(int[] nums)
    {
        int minPosition = 0;                                                             // Start with the first element as the minimum position
        int maxPosition = 1;                                                             // Start with the second element as the maximum position
        int maxDiff = -1;                                                                // Initialize maxDiff to -1, indicating no valid difference found yet
        while (maxPosition < nums.Length)                                                // Iterate through the array until maxPosition reaches the end
        {
            if (nums[maxPosition] > nums[minPosition])                                   // If the current element at maxPosition is greater than the element at minPosition
            {
                maxDiff = Math.Max(maxDiff, nums[maxPosition] - nums[minPosition]);      // Calculate the difference and update maxDiff if it's greater than the current maxDiff
            }
            else
            {
                minPosition = maxPosition;                                               // If the current element is not greater, move minPosition to maxPosition
            }
            maxPosition++;                                                               // Move to the next element
        }
        return maxDiff;                                                                  // Return the maximum difference found, or -1 if no valid difference was found
    }
}