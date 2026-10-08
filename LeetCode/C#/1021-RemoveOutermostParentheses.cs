/*
Title: 1021. Remove Outermost Parentheses
Solution: https://leetcode.com/problems/remove-outermost-parentheses/solutions/8562470/simplest-solution-c-time-on-spacen-pleas-26nw/
Difficulty: Easy
Approach: Track Parenthesis Depth
Tags: String, Stack
1) Initialize a depth counter to zero.
2) Iterate through each parenthesis in the string.
3) For an opening parenthesis, append it only when already inside a primitive, then increase the depth.
4) For a closing parenthesis, decrease the depth, then append it only when still inside a primitive.
5) Return the string without the outermost parentheses of each primitive.

Time Complexity: O(n) where n = s.length
Space Complexity: O(n) for the result string
Tip: The depth counter identifies the outermost parentheses of each primitive without needing a separate stack.
Similar Problems: 856. Score of Parentheses, 1614. Maximum Nesting Depth of the Parentheses
*/
public class Solution
{
    public string RemoveOuterParentheses(string s)
    {
        StringBuilder sb = new StringBuilder(); // Store the result without outermost parentheses
        int count = 0; // Track the current parenthesis depth

        foreach (char c in s) // Iterate through each parenthesis
        {
            if (c == '(')
            {
                if (count > 0)
                    sb.Append(c); // Keep opening parentheses inside a primitive
                count++; // Enter a deeper nesting level
            }
            else
            {
                count--; // Leave the current nesting level
                if (count > 0)
                    sb.Append(c); // Keep closing parentheses inside a primitive
            }
        }

        return sb.ToString(); // Return the concatenated primitive interiors
    }
}