/*
Title: 1358. Number of Substrings Containing All Three Characters
Solution: https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/solutions/8367017/simplest-solution-c-time-on-space-o1-ple-1918/
Difficulty: Medium
Approach: Sliding Window + Frequency Count
Tags: String, Sliding Window
1) Use two pointers to maintain a window [i..j].
2) Expand the window by moving j and updating frequency counts for 'a', 'b', and 'c'.
3) When the window contains at least one of each character, all substrings ending at j and starting from i to valid positions are counted.
4) Add (n - j) to the result for each valid left boundary because extending to the right keeps the window valid.
5) Shrink from the left by moving i while the window remains valid.
6) Continue until j reaches the end of the string.

Time Complexity: O(n), each pointer moves at most n times
Space Complexity: O(1), fixed-size frequency array of length 3
Tip: Once a window is valid, every longer substring starting at the same left boundary is also valid.
Similar Problems: 76. Minimum Window Substring, 930. Binary Subarrays With Sum, 1248. Count Number of Nice Subarrays
*/
public class Solution {
    public int NumberOfSubstrings(string s) {
        int result = 0;               // Stores total number of valid substrings
        int n = s.Length;             // Length of input string
        int[] mp = new int[3];        // Frequency map for 'a', 'b', 'c'

        int i = 0;                    // Left pointer of sliding window
        int j = 0;                    // Right pointer of sliding window

        while (j<n) {                 // Expand window by moving right pointer
            char ch = s[j];
            mp[ch - 'a']++;           // Include current character in the window

            while (mp[0] > 0 && mp[1] > 0 && mp[2] > 0) { // Window has all 3 chars
                result+= (n-j);        // Count all substrings ending from j to n-1
                mp[s[i] - 'a']--;      // Remove left char to shrink window
                i++;                   // Move left pointer forward
            }
            j++;                       // Move right pointer forward
        }
        return result;                 // Return total valid substring count
    }
}