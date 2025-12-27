/*
Solution: https://leetcode.com/problems/rearrange-characters-to-make-target-string/solutions/7443174/simplest-solution-c-time-onm-space1-plea-hbym/
Difficulty: Easy
Approach: Character Frequency Count
Tags: String, Hash Table, Counting
1) Create two frequency arrays (26 letters) for target and source strings.
2) Count frequency of each character in the target string.
3) Count frequency of each character in the source string.
4) For each character in target, calculate how many times target can be formed.
5) Take minimum of all possible copies based on each character's availability.
6) Return the maximum number of copies that can be formed.

Time Complexity: O(n + m) where n = s.length, m = target.length
Space Complexity: O(1) - fixed size arrays (26 characters)
*/
public class Solution {
    public int RearrangeCharacters(string s, string target) {
       int[] targetCount = new int[26];                     // Array to store frequency of characters in target
       int[] sCount = new int[26];                          // Array to store frequency of characters in source string
       int ans = s.Length;                                  // Initialize answer to max possible value

       foreach(char c in target) {                          // Count frequency of each character in target
            targetCount[c - 'a']++;                         // Increment count for character (convert to 0-25 index)
       }

       foreach(char c in s) {                               // Count frequency of each character in source string
            sCount[c - 'a']++;                              // Increment count for character (convert to 0-25 index)
       }

       foreach(char c in target) {                          // Check each character needed in target
            ans = Math.Min(sCount[c - 'a']/targetCount[c - 'a'],ans);  // Calculate copies possible with this char, take minimum
       }
       return ans;                                          // Return maximum number of complete copies possible
    }
}