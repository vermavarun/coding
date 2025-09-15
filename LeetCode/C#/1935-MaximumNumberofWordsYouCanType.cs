/*
Solution: Count Words That Can Be Typed
Approach: Track broken letters and check each word
Tags: String, Array, Simulation
1) Mark all broken letters in a boolean array.
2) Iterate through each character in the text.
3) For each word, check if it contains any broken letter.
4) If a word can be typed (no broken letter), increment the result.
5) Return the total count of typeable words.

Time Complexity: O(n + m) where n = text.Length, m = brokenLetters.Length
Space Complexity: O(1) - fixed size array for 26 letters
*/
public class Solution {
    public int CanBeTypedWords(string text, string brokenLetters) {
        bool[] brokenChars = new bool[26];                // Tracks which letters are broken
        int result = 0;                                   // Counts typeable words
        bool canType = true;                              // Flag for current word typeability

        foreach (char c in brokenLetters) {               // Mark broken letters
            brokenChars[c - 'a'] = true;
        }

        for (int i = 0; i < text.Length; i++) {           // Iterate through text
            char currentChar = text[i];
            if (currentChar == ' ') {                     // End of a word
                if (canType) result++;                    // If word can be typed, increment result
                canType = true;                           // Reset for next word
            }
            else {
                if (brokenChars[currentChar - 'a'])       // If current char is broken
                    canType = false;                      // Mark word as untypeable
            }
        }
        if (canType) result++;                            // Check last word
        return result;                                    // Return total typeable words
    }
}