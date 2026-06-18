/*
Title: 1344. Angle Between Hands of a Clock
Solution: https://leetcode.com/problems/angle-between-hands-of-a-clock/solutions/8343183/simplest-solution-c-time-o1-space-o1-ple-ay4a/
Difficulty: Medium
Approach: Math (clock hand angle calculation)
Tags: Math
1) Calculate the minute hand angle as minutes * 6.
2) Calculate the hour hand angle as (hour % 12) * 30 + minutes * 0.5.
3) Find the absolute difference between the two angles.
4) Return the smaller angle between diff and (360 - diff).

Time Complexity: O(1)
Space Complexity: O(1)
Tip: A clock has two possible angles between hands. Always return the smaller one by taking min(diff, 360 - diff).
Similar Problems: 1614. Maximum Nesting Depth of the Parentheses, 2119. A Number After a Double Reversal
*/
public class Solution {
    public double AngleClock(int hour, int minutes) {
        double minuteAngle = minutes * 6;                         // Minute hand moves 6 degrees per minute
        double hourAngle = (hour % 12) * 30 + minutes * 0.5;      // Hour hand moves 30 degrees per hour + 0.5 per minute
        double diff = Math.Abs(hourAngle - minuteAngle);          // Absolute angle difference between both hands
        return Math.Min(diff, 360 - diff);                        // Return the smaller angle
    }
}