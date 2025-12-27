/*
Solution:
Difficulty: Easy
Approach: Two Pointers
Tags: Two Pointers, String, Dynamic Programming
1) Initialize two pointers: one for string s and one for string t.
2) Iterate through string t with one pointer.
3) When characters match, advance pointer in string s.
4) Continue until end of either string is reached.
5) If pointer in s reaches end, all characters found in order - return true.
6) Otherwise, return false.

Time Complexity: O(n) where n = t.length
Space Complexity: O(1) - constant extra space
*/
public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        int indexS = 0;
        int indexT = 0;
        while (indexS < s.Length && indexT < t.Length)
        {

            if (s[indexS] == t[indexT])
            {
                indexS++;
            }
            indexT++;
        }

        return s.Length == indexS ? true : false;
    }
}