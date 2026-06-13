/*
Title: 3838. Weighted Word Mapping
Solution: https://leetcode.com/problems/weighted-word-mapping/solutions/8331245/simplest-solution-c-time-onm-space-on-pl-4w7i/
Difficulty: Easy
Approach: Character weight sum with modular arithmetic
Tags: String, Array, Math
1) For each word, compute the sum of weights of its characters using weights[c - 'a'].
2) Take the sum modulo 26 to get a value in range [0, 25].
3) Map the result to a character: 'z' - sum (so 0 -> 'z', 1 -> 'y', ..., 25 -> 'a').
4) Append the mapped character to the result.
5) Return the final result string.

Time Complexity: O(n * m) where n = number of words, m = average word length
Space Complexity: O(n) for the result string
Tip: The modulo 26 wraps the weight sum into the alphabet range, and subtracting from 'z' gives the reverse mapping.
Similar Problems: 2129. Capitalize the Title, 1436. Destination City
*/
public class Solution {
    public string MapWordWeights(string[] words, int[] weights) {

        StringBuilder result = new StringBuilder();                 // Builder to accumulate mapped characters

        foreach(string word in words) {                             // Iterate through each word
            int currentWordSum = 0;                                 // Sum of weights for current word
            foreach (char c in word) {                              // Sum weights of each character
                currentWordSum += weights[c - 'a'];                 // weights index based on character offset from 'a'
            }
            currentWordSum %= 26;                                   // Wrap sum into [0, 25] range
            char mappedChar = (char)('z' - currentWordSum);         // Map to character: 0->'z', 25->'a'
            result.Append(mappedChar);                              // Append mapped character to result
        }

        return result.ToString();                                   // Return final mapped string
    }
}