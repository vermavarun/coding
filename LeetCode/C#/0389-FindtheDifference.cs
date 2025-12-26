/*
Solution: https://leetcode.com/problems/find-the-difference/solutions/6556260/simplest-solution-c-time-on-spacen-pleas-q11h/
Difficulty: Medium
Approach: XOR
Tags: String
1. Create a StringBuilder and append both strings to it.
2. Initialize a char result to '\0' which is a null character.
3. Iterate through the StringBuilder and XOR each character with result.
4. Return the result.

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public char FindTheDifference(string s, string t) {
        StringBuilder sb = new StringBuilder(); // Initialize a StringBuilder
        sb.Append(s);                           // Append both strings to StringBuilder
        sb.Append(t);                           // Append both strings to StringBuilder
        char result = '\0';                     // Initialize a char result to '\0' which is a null character
        for(int i=0; i<sb.Length; i++) {        // Iterate through the StringBuilder
            result ^= sb[i];                    // XOR each character with result
        }
        return result;                          // Return the result
    }
}