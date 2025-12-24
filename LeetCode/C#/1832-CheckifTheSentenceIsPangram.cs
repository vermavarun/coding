/*
Solution: https://leetcode.com/problems/check-if-the-sentence-is-pangram/solutions/7435800/simplest-solution-c-time-on-space1-pleas-c7mm/
Difficulty: Easy
Approach: Array-based character frequency counting
Tags: String, Array, Hash Table
1) Create an array of size 26 to track presence of each letter.
2) Iterate through each character in the sentence.
3) For each character, calculate its position (0-25) by subtracting 'a'.
4) Increment the count at the corresponding position in the array.
5) After processing all characters, check if any position has count 0.
6) If any letter is missing (count 0), return false.
7) If all 26 letters are present, return true.

Time Complexity: O(n) where n = sentence.length
Space Complexity: O(1) as array size is constant (26)
*/
public class Solution {
    public bool CheckIfPangram(string sentence) {

        int[] chars = new int[26];                                  // Array to track each letter (a-z)

        foreach(char ch in sentence) {                              // Iterate through each character
            int chPos = ch - 'a';                                   // Calculate position: 'a'=0, 'b'=1, ..., 'z'=25
            chars[chPos]++;                                         // Increment count for this letter
        }

        foreach(int c in chars) {                                   // Check all 26 letter positions
            if (c == 0) {                                           // If any letter is missing
                return false;                                       // Not a pangram
            }
        }

        return true;                                                // All 26 letters present, is pangram
    }
}