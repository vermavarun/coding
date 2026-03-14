/*
Title: 485. Max Consecutive Ones
Solution: https://leetcode.com/problems/max-consecutive-ones/solutions/7608410/simplest-solution-c-time-on-space-o1-ple-z40w/
Difficulty: Easy
Approach: Single pass with running streak counter
Tags: Array
1) Initialize two counters: one for current streak and one for maximum streak.
2) Traverse each number in the array once.
3) If value is 1, increase current streak.
4) If value is 0, update maximum streak and reset current streak.
5) Return maximum between stored max streak and final current streak.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(1)
Tip: Update max streak when hitting 0, then do a final max check at return to handle arrays ending with 1.
Similar Problems: 1004. Max Consecutive Ones III, 1493. Longest Subarray of 1's After Deleting One Element
*/
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int maxStreak = 0;                      // Stores the maximum consecutive 1s seen so far
        int currentStreak = 0;                  // Tracks the current consecutive 1s streak
        foreach(int num in nums) {              // Iterate through each number in the array
            if (num == 1) {                     // If current value is 1, extend current streak
                currentStreak++;
            }
            else {                              // If current value is 0, streak breaks here
                maxStreak = Math.Max(maxStreak,currentStreak);  // Update max streak if needed
                currentStreak=0;                // Reset current streak
            }
        }
        return Math.Max(maxStreak,currentStreak); // Final check in case array ends with 1s
    }
}