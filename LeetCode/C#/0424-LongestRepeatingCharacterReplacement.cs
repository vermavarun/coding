/*
Solution: https://leetcode.com/problems/longest-repeating-character-replacement/solutions/6973917/simplest-solution-c-time-on-space1-pleas-ye56/
Difficulty: Medium
Approach: Sliding Window
Tags: Sliding-Window, Hash-Table
1. Initialize a dictionary to count character frequencies.
2. Use two pointers to maintain the window.
3. Expand the right pointer and update the frequency count.
4. If the window size minus the maximum frequency is greater than k, shrink the left pointer.
5. Update the maximum length of the substring found.
Space complexity: O(1) - since we only store 26 characters in the dictionary

Time Complexity: O(?)
*/
public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] freq = new int[26];                                                   // Frequency array for characters A-Z
        int left = 0;                                                               // Left pointer for the sliding window
        int maxWindowLength = 0;                                                    // Maximum length of the substring found
        int maxFreq = 0;                                                            // Maximum frequency of any character in the current window
        int currWindowLength = 0;                                                   // Current length of the sliding window

        for (int right = 0; right<s.Length; right++) {                              // Iterate through the string with the right pointer

            freq[s[right] - 65]++;                                                  // Increment the frequency of the current character
            maxFreq = Math.Max(maxFreq, freq[s[right] - 65]);                       // Update the maximum frequency in the current window
            currWindowLength = right - left + 1;                                    // Update the current window length
            if ( (currWindowLength - maxFreq) > k) {                                // If the number of characters that need to be replaced exceeds k
                freq[s[left] - 65]--;                                               // Decrease the frequency of the character at the left pointer
                left++;                                                             // Move the left pointer to shrink the window
            }
            currWindowLength = right - left + 1;                                    // Update the current window length after adjusting the left pointer
            maxWindowLength = Math.Max(maxWindowLength, currWindowLength);          // Update the maximum window length found
        }

        return maxWindowLength;                                                     // Return the maximum length of the substring found
    }
}