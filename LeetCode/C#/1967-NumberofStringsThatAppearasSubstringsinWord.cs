/*
Title: 1967. Number of Strings That Appear as Substrings in Word
Solution: https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word/solutions/8364694/simplest-solution-c-time-onm-space-o1-pl-j2ih/
Difficulty: Easy
Approach: Brute Force String Matching
Tags: Array, String
1) Initialize a counter to track matching patterns.
2) Iterate through each pattern in the patterns array.
3) Check if the current pattern exists as a substring in word.
4) If it exists, increment the counter.
5) Return the final count.

Time Complexity: O(n * m) in practice where n = patterns.length and m = average substring search cost in word
Space Complexity: O(1)
Tip: Leverage built-in string matching (`Contains`) for clean and readable implementation in easy substring-check problems.
Similar Problems: 28. Find the Index of the First Occurrence in a String, 1408. String Matching in an Array
*/
public class Solution {
    public int NumOfStrings(string[] patterns, string word) {
        int result = 0;                                  // Counter for patterns that appear in word

        foreach (string pattern in patterns) {           // Check each pattern one by one
            if (word.Contains(pattern)) {                // If pattern is a substring of word
                result++;                                // Increase match count
            }
        }

        return result;                                   // Return total number of matching patterns
    }
}