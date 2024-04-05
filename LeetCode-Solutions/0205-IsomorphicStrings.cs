// Problem: Isomorphic Strings
// Source: https://leetcode.com/problems/isomorphic-strings/
// Approach 1: Using one dictionary
// Time complexity : O(n). We traverse the entire string s once and the entire string t once.
// Space complexity : O(n). Although we do use extra space, the space complexity is O(1) because the space used is only linear with respect to the size of the input.
// Map each character in s to the corresponding character in t.
// If the mapping is incorrect, return false.
// If the mapping is correct, continue to map the rest of the characters.
// If there is a conflict in the mapping, return false.
// If the characters in s and t could be successfully mapped, return true.


public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, char> map = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                char sChar = s[i];
                char tChar = t[i];

                if (map.ContainsKey(sChar))
                {
                    if (map[sChar] != tChar)
                    {
                        return false;
                    }
                }
                else
                {
                    if (map.ContainsValue(tChar))
                    {
                        return false;
                    }
                    map.Add(sChar, tChar);
                }
            }

            return true;

    }
}