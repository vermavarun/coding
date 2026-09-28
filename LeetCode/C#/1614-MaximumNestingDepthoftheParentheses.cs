/*
Title: 1614. Maximum Nesting Depth of the Parentheses
Solution: https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/solutions/8544077/simplest-solution-c-time-on-space-o1-ple-n5js/
Difficulty: Easy
Approach: Track the current depth in one pass
Tags: String, Stack
1) Initialize the current depth and maximum depth to zero.
2) Increase the current depth for each opening parenthesis.
3) Decrease the current depth for each closing parenthesis.
4) Update the maximum depth after processing each character.
5) Return the maximum depth reached.

Time Complexity: O(n) where n = s.length
Space Complexity: O(1)
Tip: The input is guaranteed to be a valid parentheses string, so a counter is enough; an explicit stack is unnecessary.
Similar Problems: 20. Valid Parentheses, 921. Minimum Add to Make Parentheses Valid, 1021. Remove Outermost Parentheses
*/
public class Solution {
    public int MaxDepth(string s) {
        int currentDepth = 0;
        int maxDepth = 0;
        foreach(char c in s) {
            if (c == '(') {
                currentDepth++; // Opening parenthesis adds one nesting level.
            }
            else if (c == ')') {
                currentDepth--; // Closing parenthesis returns to the enclosing level.
            }
            maxDepth = Math.Max(maxDepth,currentDepth); // Keep the deepest level seen so far.
        }
        return maxDepth;
    }
}