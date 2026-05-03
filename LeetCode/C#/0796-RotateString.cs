/*
Title: 796. Rotate String
Solution: https://leetcode.com/problems/rotate-string/solutions/8132311/simplest-solution-c-time-on2-space-on-pl-x32w/
Difficulty: Easy
Approach: String Concatenation (Substring Check)
Tags: String, String Matching
1) If lengths differ, a rotation is impossible — return false immediately.
2) Concatenate s with itself to produce all possible rotations as substrings.
3) Check whether goal appears anywhere in the doubled string.
4) If it does, goal is a valid rotation of s; otherwise it is not.

Time Complexity: O(n^2) where n = s.Length (Contains performs O(n) search on a 2n-length string)
Space Complexity: O(n) for the concatenated string s + s
Tip: Every rotation of s is a contiguous substring of s + s. So a single Contains check replaces the need to manually try all n rotations.
Similar Problems: 459. Repeated Substring Pattern, 1768. Merge Strings Alternately
*/
public class Solution {
    public bool RotateString(string s, string goal) {
        return s.Length == goal.Length      // Lengths must match for any rotation to be equal
            && (s + s).Contains(goal);      // All rotations of s appear as substrings of s+s
    }
}