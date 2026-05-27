/*
Title: 3121. Count the Number of Special Characters II
Solution: https://leetcode.com/problems/count-the-number-of-special-characters-ii/solutions/8296858/simplest-solution-c-time-on-space-o1-ple-na3s/
Difficulty: Medium
Approach: Track last occurrence of lowercase and first occurrence of uppercase for each letter
Tags: String, Array, Character Mapping
1) Use two arrays of size 26:
   - lastOccurrenceSmall: stores last index of each lowercase letter
   - firstOccurrenceCapital: stores first index of each uppercase letter
2) Fill both arrays with -1 initially.
3) Iterate through the string:
   - If char is lowercase, update lastOccurrenceSmall
   - If char is uppercase, update firstOccurrenceCapital (only if not set yet)
4) For each letter, if it appears as lowercase and its last occurrence is before its first uppercase occurrence, count as special.

Time Complexity: O(n) where n = word.Length
Space Complexity: O(1) (arrays of fixed size 26)
Tip: The key is to map each letter to its lowercase and uppercase positions efficiently, then check the special condition for each letter.
Similar Problems: 1371. Find the Longest Substring Containing Vowels in Even Counts, 2027. Minimum Moves to Convert String
*/
public class Solution {
    public int NumberOfSpecialChars(string word) {
        int[] lastOccurrenceSmall = new int[26]; // Last index of each lowercase letter
        int[] firstOccurrenceCapital = new int[26]; // First index of each uppercase letter
        int result = 0; // Count of special characters

        Array.Fill(lastOccurrenceSmall, -1); // Initialize to -1 (not found)
        Array.Fill(firstOccurrenceCapital, -1); // Initialize to -1 (not found)

        // Record last occurrence of lowercase and first occurrence of uppercase
        for (int i = 0; i < word.Length; i++) {
            if (char.IsLower(word[i])) {
                lastOccurrenceSmall[word[i] - 'a'] = i;
            }
            else if (char.IsUpper(word[i]) && firstOccurrenceCapital[word[i] - 'A'] == -1) {
                firstOccurrenceCapital[word[i] - 'A'] = i;
            }
        }

        // For each letter, check if it is special
        for (int i = 0; i < 26; i++) {
            if (lastOccurrenceSmall[i] != -1 && firstOccurrenceCapital[i] != -1 && lastOccurrenceSmall[i] < firstOccurrenceCapital[i]) {
                result++;
            }
        }

        return result;
    }
}