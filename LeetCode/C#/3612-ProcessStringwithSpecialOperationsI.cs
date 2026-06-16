/*
Title: 3612. Process String with Special Operations I
Solution: https://leetcode.com/problems/process-string-with-special-operations-i/solutions/8337086/simplest-solution-c-time-onm-space-on-pl-b3z1/
Difficulty: Medium
Approach: Linear scan with string mutation
Tags: String, Simulation
1) Initialize an empty result string.
2) Iterate through each character in the input string.
3) If '*', remove the last character from result (if non-empty).
4) If '#', duplicate the result string by concatenating it with itself.
5) If '%', reverse the result string.
6) Otherwise, append the character to result.
7) Return the final result string.

Time Complexity: O(n * m) where n = s.length and m = max result length (due to string concatenation/reversal)
Space Complexity: O(m) for the result string
Tip: Simulate each operation in order. The '*' operation removes the last character, '#' doubles the string, and '%' reverses it. Using StringBuilder would improve performance for large inputs.
Similar Problems: 1047. Remove All Adjacent Duplicates In String, 1544. Make The String Great
*/
public class Solution {
    public string ProcessStr(string s) {
        string result = "";                                         // Initialize empty result string

        foreach (char c in s) {                                     // Iterate through each character
            switch (c) {
                case '*':
                    // Remove the last character if present
                    if (result.Length > 0)
                        result = result.Remove(result.Length - 1, 1);   // Delete last character
                    break;

                case '#':
                    // Duplicate the current string
                    result = result + result;                       // Concatenate string with itself
                    break;

                case '%':
                    // Reverse the current string
                    result = new string(result.Reverse().ToArray());    // Reverse and reconstruct string
                    break;

                default:
                    // Append normal characters
                    result += c;                                    // Add character to result
                    break;
            }
        }

        return result;                                              // Return the processed string
    }
}