/*
Solution:
Difficulty: Easy
Approach: Reverse iteration
Tags: String
1) Start from the end of the string.
2) Skip any trailing spaces.
3) Count characters until a space or beginning is reached.
4) Return the count.

Time Complexity: O(n) where n = s.length
Space Complexity: O(1)
*/
public class Solution {
    public int LengthOfLastWord(string s) {
        int result = 0;
        int fspace = 0;
        int index = s.Length - 1;
        while (s[index] == ' ') {
            index--;
        }
        while (index >= 0 && s[index] != ' ' ) {
            index--;
            result++;
        }
        return result;
    }
}
