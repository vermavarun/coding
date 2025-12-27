/*
Solution: https://leetcode.com/problems/decode-the-message/solutions/7443476/simplest-solution-c-time-onm-space1-plea-njli/
Difficulty: Easy
Approach: Hash Table for Character Substitution Mapping
Tags: String, Hash Table
1) Create a dictionary to map each unique character in key to its position (0-25).
2) Iterate through the key string, skipping spaces.
3) For each new unique character, map it to the current alphabet position.
4) Iterate through the message string.
5) Replace each character using the mapping (spaces remain unchanged).
6) Build and return the decoded message.

Time Complexity: O(n + m) where n = key.length, m = message.length
Space Complexity: O(1) - dictionary has at most 26 entries
*/
public class Solution {
    public string DecodeMessage(string key, string message) {
        Dictionary<char,int> map = new Dictionary<char,int>();      // Dictionary to map encrypted char -> alphabet position
        StringBuilder output = new StringBuilder();                 // StringBuilder to efficiently construct decoded message
        int currIndex = 0;                                          // Track current alphabet position (0-25)

        foreach(char c in key) {                                    // Iterate through key to build substitution table
            if (c != ' ' && !map.ContainsKey(c))                    // If character is not space and not yet mapped
                map.Add(c, currIndex++);                            // Map character to current position and increment
        }

        currIndex = 0;                                              // Reset index (not needed, but kept for clarity)

        foreach(char c in message) {                                // Iterate through message to decode

            if (c != ' '){                                          // If character is not a space
                output.Append((char)(map[c] + 'a'));                // Convert mapped position to actual letter and append
            }
            else                                                    // If character is a space
                output.Append(' ');                                 // Keep the space in decoded message
        }

        return output.ToString();                                   // Return the decoded message string

    }
}