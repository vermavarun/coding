/*
Title: 3713. Longest Balanced Substring I
Solution: https://leetcode.com/problems/longest-balanced-substring-i/solutions/7572766/simplest-solution-c-time-on2-space-o1-pl-7kxm/
Difficulty: Medium
Approach: Brute Force with Frequency Counting
Tags: String, Hash Table, Sliding Window
1) Use nested loops to check all possible substrings.
2) For each starting position i, create a fresh frequency map.
3) Extend substring by incrementing ending position j.
4) Track character frequency in the map for current substring.
5) After each extension, check if all non-zero frequencies are equal (balanced).
6) If balanced, update result with maximum substring length.
7) Continue until all substrings are checked.

Time Complexity: O(n² * 26) = O(n²) where n = s.length (two nested loops * constant alphabet check)
Space Complexity: O(1) for the fixed-size 26-element frequency array
Tip: A balanced substring means all characters that appear must have the same frequency. The key is resetting the frequency map for each new starting position and checking balance condition after each character addition.
Similar Problems: 1156. Swap For Longest Repeated Character Substring, 3234. Count Subarrays Where Max Element Appears at Least K Times, 2781. Length of the Longest Valid Substring
*/
public class Solution {
    public int LongestBalanced(string s) {
        int[] map = new int[26];                                    // Frequency array for 26 lowercase letters
        int result = 0;                                             // Store maximum balanced substring length
        for(int i=0; i<s.Length; i++) {                             // Outer loop: iterate through each starting position
            map = new int[26];                                      // Reset frequency map for each starting position
            for(int j=i; j<s.Length; j++) {                         // Inner loop: extend substring from position i to j
                map[s[j] - 'a']++;                                  // Increment frequency of current character
                if (IsBalanced(map)) {                              // Check if current substring has balanced frequencies
                    result = Math.Max(result,j-i+1);                // Update result with max length if balanced
                }
            }
        }
        return result;                                              // Return the longest balanced substring length
    }
    private bool IsBalanced(int[] map) {
        int common = 0;                                             // Variable to store the common frequency count
        foreach(int num in map) {                                   // Iterate through all character frequencies
            if (num == 0)                                           // Skip characters that don't appear in substring
                continue;
            if (common == 0)                                        // First non-zero frequency becomes the baseline
                common = num;
            else if (num != common)                                 // If any frequency differs from baseline, not balanced
                return false;
        }
        return true;                                                // All non-zero frequencies match, substring is balanced
    }
}