/*
Solution: https://leetcode.com/problems/find-most-frequent-vowel-and-consonant/solutions/7185563/simplest-solution-c-time-on-space1-pleas-0nnb/
Approach: Frequency Counting with Character Classification
Tags: String, Hash Table, Frequency Count
1) Initialize counters for maximum vowel and consonant frequencies.
2) Create a list of vowels for classification and an array to track character frequencies.
3) Iterate through each character in the string.
4) Update character frequency and track maximum frequencies for vowels and consonants separately.
5) Return the sum of maximum vowel frequency and maximum consonant frequency.

Time Complexity: O(n)
Space Complexity: O(1) - fixed size arrays and vowel list
*/
public class Solution {
    public int MaxFreqSum(string s) {
        int maxVowelFreq = 0;                                           // Maximum frequency among vowels
        int maxConsonantFreq = 0;                                       // Maximum frequency among consonants
        List<char> vowels = new List<char>(){'a','e','i','o','u'};      // List of vowel characters
        int[] charFreq = new int[27];                                   // Frequency array for each character (a-z)

        foreach(char ch in s) {                                         // Iterate through each character in string
            int chatAt = (int)ch - 'a';                                 // Convert character to array index (0-25)

            charFreq[chatAt]++;                                         // Increment frequency of current character

            if (vowels.Contains(ch)) {                                  // If character is a vowel
                maxVowelFreq = Math.Max(maxVowelFreq, charFreq[chatAt]); // Update maximum vowel frequency
            }
            else {                                                      // If character is a consonant
                maxConsonantFreq = Math.Max(maxConsonantFreq, charFreq[chatAt]); // Update maximum consonant frequency
            }
        }

        return maxConsonantFreq + maxVowelFreq;                         // Return sum of max frequencies
    }
}