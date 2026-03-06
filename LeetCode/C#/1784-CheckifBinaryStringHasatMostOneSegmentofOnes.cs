/*
Title: 1784. Check if Binary String Has at Most One Segment of Ones
Solution: https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones/solutions/7628629/simplest-solution-c-time-on-space-o1-ple-ypsc/
Difficulty: Easy
Approach: Pattern Detection
Tags: String
1) If a binary string has at most one segment of ones, all ones must be contiguous.
2) If there's a "0" followed by a "1" (pattern "01"), it means ones are separated into segments.
3) Simply check if the string does NOT contain the pattern "01".
4) If "01" is not present, all ones are grouped together (or there are no ones at all).

Time Complexity: O(n) where n = s.length, for Contains() method
Space Complexity: O(1) as we only check for a pattern
Tip: The key insight is recognizing that multiple segments of ones are only possible when we encounter a "01" pattern. If there's no "01" pattern, all ones must be consecutive (or the string is all zeros).
Similar Problems: 2609. Find the Longest Balanced Substring of a Binary String, 696. Count Binary Substrings
*/
public class Solution {
    public bool CheckOnesSegment(string s) {
        return !s.Contains("01");                                   // Return true if "01" pattern is NOT found (at most one segment of ones)
    }
}