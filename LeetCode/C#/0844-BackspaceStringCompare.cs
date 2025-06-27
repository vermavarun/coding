/*
Solution: https://leetcode.com/problems/backspace-string-compare/solutions/6891192/simplest-solution-c-time-onm-space1-plea-y9ba/
Approach: Two Pointer Technique
1) Traverse both strings from the end to the beginning.
2) Use two pointers to skip characters that are followed by a backspace character '#'.
3) Compare the characters at the pointers after skipping the backspaces.
Time Complexity: O(n + m), where n and m are the lengths of the two strings.
Space Complexity: O(1), as we are not using any extra space except for a few variables.
*/
public class Solution
{
    public bool BackspaceCompare(string s, string t)
    {
        return BackSpaceString(s) == BackSpaceString(t);                        // Compare the processed strings after handling backspaces
    }

    public string BackSpaceString(string s)
    {
        int backSpace = 0;                                                      // Counter for backspaces
        StringBuilder sb = new StringBuilder();
        for (int i = s.Length - 1; i >= 0; i--)                                 // Traverse the string from the end to the beginning
        {
            if (s[i] == '#')                                                    // If the current character is a backspace
            {
                backSpace++;                                                    // Increment the backspace counter
                continue;                                                       // Skip the current character
            }
            if (backSpace > 0)                                                  // If there are backspaces to process
            {
                backSpace--;                                                    // Decrement the backspace counter
                continue;                                                       // Skip the current character
            }
            sb.Append(s[i]);                                                    // Append the current character to the StringBuilder
        }

        string result = new string(sb.ToString().Reverse().ToArray());          // Reverse the StringBuilder to get the correct order of characters
        return result;                                                          // Return the processed string
    }
}