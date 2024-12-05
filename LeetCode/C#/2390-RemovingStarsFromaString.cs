/*

Approach:
1. Create a stack to store the characters.
2. Iterate through the string.
3. If the current character is a star and the stack is not empty, pop the last character from the stack.
4. If the current character is not a star, push it to the stack.
5. After iterating through the string, pop all the characters from the stack (also remove the last character from the string when you encounter * by decreasing the length) and return the string.

Time complexity: O(n)
Space complexity: O(n)
*/
public class Solution {
    public string RemoveStars(string s) {
        Stack<char> stack = new Stack<char>();      // To store the characters
        StringBuilder sb = new StringBuilder();     // To store the final string
        for(int i = s.Length-1;i >=0;i--) {         // Iterating through the string
            stack.Push(s[i]);                       // Push the character to the stack
        }
        while(stack.Count() != 0) {                 // Pop all the characters from the stack
            char ch = stack.Pop();                  // Pop the character from the stack
            if(ch == '*' && sb.Length > 0) {        // If the current character is a star and the stack is not empty
                sb.Length = sb.Length-1;            // Remove the last character from the string
            }
            else {
                sb.Append(ch);                      // Append the character to the final string
            }
        }
        return sb.ToString();                       // Return the final string
    }
}