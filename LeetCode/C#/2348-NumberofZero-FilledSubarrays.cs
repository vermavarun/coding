/*
Solution: 
Difficulty: Medium
Approach: [To be documented]
Tags: Array, String, Math
1) [Step 1]
2) [Step 2]

Time Complexity: O(?)
Space Complexity: O(?)
*/

/*
Solution: https://leetcode.com/problems/number-of-zero-filled-subarrays/solutions/7099676/simplest-solution-c-time-on-space1-pleas-qfik/
Approach: Count length of each zero streak and sum up all possible subarrays
Tags: Array, Math, Counting
1) Iterate through the array, tracking the current streak of consecutive zeros.
2) For each zero, increment the streak and add its length to the sum.
3) If a non-zero is encountered, reset the streak.
4) The sum accumulates the total number of zero-filled subarrays.

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public long ZeroFilledSubarray(int[] nums) {
        long currentContinuousZeros = 0;           // Tracks current streak of consecutive zeros
        long sum = 0;                              // Accumulates total zero-filled subarrays

        for (long i = 0; i < nums.Length; i++) {   // Iterate through the array
            if (nums[i] == 0) {                    // If current element is zero
                currentContinuousZeros++;           // Increment zero streak
                sum = sum + currentContinuousZeros; // Add streak length to sum
            }
            else {
                currentContinuousZeros = 0;         // Reset streak if non-zero
            }
        }
        return sum;                                // Return total number of zero-filled subarrays
    }
}
