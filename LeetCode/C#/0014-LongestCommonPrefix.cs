/*
Solution:
Difficulty: Easy
Approach: Vertical Scanning
Tags: String, Trie
1) Take the first string as reference.
2) For each character position in the first string, compare with all other strings.
3) If any string is shorter or character doesn't match, return accumulated prefix.
4) If character matches in all strings, add it to the result.
5) Continue until end of first string or mismatch found.
6) Return the longest common prefix.

Time Complexity: O(S) where S is the sum of all characters in all strings
Space Complexity: O(1) excluding output
*/
// Check all strings char by char.
public class Solution {
    public string LongestCommonPrefix(string[] strs) {

        StringBuilder result = new StringBuilder();

        for (int i=0; i<strs[0].Length; i++) { // randomly first string taken, any string can be taken best would be smallest.

            foreach(string s in strs) {

                if(i == s.Length || strs[0][i] != s[i]) { //  First condition will check if any other string is less than first string.
                    return result.ToString();
                }
            }
            result.Append(strs[0][i]);
        }

        return result.ToString();
    }
}
