/*
Solution: 
Difficulty: Medium
Approach:
Tags: String, Math
1. We will start from 0 and 1 and will check how many changes are required to make string alternative.
2. We will take minimum of two strings as alternative string can start from 0 or 1.
3. We will keep track of next expected character and will check if current character is same as next expected character.
4. If not, we will increment result and will update current character to next expected character.
5. We will update next expected character to opposite of current character.
6. We will return minimum of two strings.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int MinOperations(string s) {
        char nextExpectedChar = '1';
            char currentChar = '\0';
            int index = 1;
            int result = 0;

            if (s[0] != '0') {
                nextExpectedChar = '0';
            }

            while(index < s.Length) {

                currentChar = s[index];

                if(currentChar != nextExpectedChar) {
                    result++;
                    currentChar = nextExpectedChar;
                }

                nextExpectedChar = currentChar == '0' ? '1' : '0';
                index++;
            }

            // As alternative string can start from 0 or 1, we will take minimum of two strings
            // if result is for 0. s.Length - result will be for 1.
            return Math.Min(s.Length - result ,result);
    }
}