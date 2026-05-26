/*
Title: 3120. Count the Number of Special Characters I
Solution: https://leetcode.com/problems/count-the-number-of-special-characters-i/solutions/8293803/simplest-solution-c-time-on-space-o1-ple-jc1s/
Difficulty: Easy
Approach: Track lowercase and uppercase occurrences for each letter
Tags: String, Array
1) Use two boolean arrays to track which lowercase and uppercase letters appear in the string.
2) Iterate through the string, marking presence in the respective arrays.
3) For each letter, if both lowercase and uppercase forms are present, count it as special.

Time Complexity: O(n) where n = word.Length
Space Complexity: O(1) (constant, since arrays are fixed size 26)
Tip: Use character arithmetic to map 'a'-'z' and 'A'-'Z' to array indices efficiently.
Similar Problems: 771. Jewels and Stones, 242. Valid Anagram
*/
public class Solution {
    public int NumberOfSpecialChars(string word) {

        bool[] lower = new bool[26]; // Track presence of lowercase letters
        bool[] upper = new bool[26]; // Track presence of uppercase letters

        foreach (char c in word) { // Iterate through each character in the string
            if (char.IsLower(c)) {
                lower[c - 'a'] = true; // Mark lowercase letter as present
            } else {
                upper[c - 'A'] = true; // Mark uppercase letter as present
            }
        }

        int result = 0; // Count of special characters

        for (int i = 0; i < 26; i++) { // Check each letter from 'a' to 'z'
            if (lower[i] && upper[i]) { // Both lowercase and uppercase present
                result++;
            }
        }

        return result; // Return the count of special characters
    }
}