/*
Solution: https://leetcode.com/problems/ransom-note/solutions/7404079/simplest-solution-c-time-om-n-spacek-ple-tbes/
Difficulty: Medium
Approach: Character Frequency Count with Hash Table
Tags: Hash Table, String, Counting
1) Create a dictionary to count character frequencies in magazine.
2) Iterate through magazine and populate the frequency map.
3) Iterate through ransomNote and check if each character is available.
4) For each character in ransomNote, decrement its count in the dictionary.
5) If any character is missing or count becomes 0, return false.
6) If all characters are found with sufficient counts, return true.

Time Complexity: O(m + n) where m = magazine.length, n = ransomNote.length
Space Complexity: O(k) where k = number of unique characters in magazine
*/
public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        Dictionary<char,int> dict = new Dictionary<char,int>();     // Dictionary to store character frequencies
        foreach (char c in magazine) {                              // Count characters in magazine
            if (!dict.ContainsKey(c)) {                             // If character not in dictionary
                dict.Add(c,1);                                      // Add character with count 1
            }
            else {                                                  // If character already exists
                dict[c]++;                                          // Increment its count
            }

        }
        foreach (char c in ransomNote) {                            // Check each character in ransomNote
            if (!dict.ContainsKey(c) || dict[c] == 0) {             // If character unavailable or count is 0
                return false;                                       // Cannot construct ransom note
            }
            else {                                                  // If character is available
                dict[c]--;                                          // Use the character (decrement count)
            }
        }
        return true;                                                // All characters found, can construct ransom note
    }
}