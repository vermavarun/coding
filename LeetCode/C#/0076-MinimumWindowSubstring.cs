/*
Solution: https://leetcode.com/problems/minimum-window-substring/solutions/7027291/simplest-solution-c-time-on-spacen-pleas-3bvj/
Difficulty: Easy
Approach: Two Pointers (Sliding Window)
Tags: String, Hash Table, Sliding Window, Two Pointers
1) Use a dictionary to count characters in target string t.
2) Use two pointers (left and right) to maintain a sliding window.
3) Expand the window by moving right pointer until all characters are included.
4) Contract the window by moving left pointer while maintaining validity.
5) Track the minimum window that contains all characters of t.
6) Return the minimum window substring or empty string if no valid window exists.

Time Complexity: O(|s| + |t|)
Space Complexity: O(|t|)
*/
public class Solution {
    public string MinWindow(string s, string t) {

        if (s.Length == 0 || t.Length==0 || t.Length > s.Length)    // Handle edge cases
            return string.Empty;

        int left = 0;                                               // Left pointer for sliding window
        int right = 0;                                              // Right pointer for sliding window
        int minLeft = 0;                                            // Starting position of minimum window
        int minWindowLength = int.MaxValue;                         // Length of minimum window found
        int need = t.Length;                                        // Count of characters still needed
        Dictionary<char,int> dict = new Dictionary<char, int>();    // Dictionary to store character counts

        // Count Chars
        foreach (char c in t) {                                     // Iterate through each character in t
            if (!dict.ContainsKey(c))                               // If character not in dictionary
                dict.Add(c,1);                                      // Add character with count 1
            else                                                    // If character already in dictionary
                dict[c]++;                                          // Increment the count
        }

        // Slide
        while (right < s.Length) {                                  // Expand the window by moving right pointer

            char rightCh = s[right];                                // Get character at right pointer

            if (dict.ContainsKey(rightCh)) {                        // If character is in target string
                dict[rightCh]--;                                    // Decrease the count needed
                if (dict[rightCh] >= 0) {                           // If we fulfilled a requirement
                    need--;                                         // Decrease total characters needed
                }
            }

            while (need == 0) {                                         // While we have a valid window
                if ((right - left + 1) < minWindowLength) {            // If current window is smaller
                    minWindowLength = right - left + 1;                // Update minimum window length
                    minLeft = left;                                     // Update minimum window start position
                }
                char leftCh = s[left];                                  // Get character at left pointer
                if (dict.ContainsKey(leftCh)) {                         // If character is in target string
                    dict[leftCh]++;                                     // Increase the count needed
                    if (dict[leftCh] > 0) {                             // If we broke a requirement
                        need++;                                         // Increase total characters needed
                    }
                }
                left++;                                                 // Move left pointer to shrink window
            }
            right++;                                                    // Move right pointer to expand window
        }

        return minWindowLength == int.MaxValue ? string.Empty : s.Substring(minLeft,minWindowLength);    // Return minimum window or empty string if no valid window found
    }
}