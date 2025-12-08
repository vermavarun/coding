/*
Solution: https://leetcode.com/problems/to-lower-case/solutions/7400197/simplest-solution-c-time-on-spacen-pleas-4wea/
Approach: Character Manipulation with ASCII Values
Tags: String, Character Manipulation, ASCII
1) Use StringBuilder for efficient string construction.
2) Iterate through each character in the input string.
3) Check if the character is an uppercase letter (A-Z).
4) If uppercase, convert to lowercase by adding 32 to ASCII value.
5) Append the (potentially converted) character to StringBuilder.
6) Return the resulting lowercase string.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public string ToLowerCase(string s) {
        StringBuilder sb = new StringBuilder();                 // StringBuilder for efficient string building
        foreach(char c in s) {                                  // Iterate through each character
            char newChar = c;                                   // Initialize with original character
            if (c >= 'A' && c <= 'Z') {                         // Check if character is uppercase
                newChar = (char)(c + 32);                       // Convert to lowercase (ASCII difference is 32)
            }
            sb.Append(newChar);                                 // Append character to result
        }
        return sb.ToString();                                   // Return the lowercase string
    }
}
