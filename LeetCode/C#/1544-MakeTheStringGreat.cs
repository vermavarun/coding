/*
Solution: 
Difficulty: Medium
Approach:
Tags: Stack, String
1. Create a stack to store the characters.
2. Iterate through the string.
3. If the stack is empty, push the current character to the stack.
4. If the stack is not empty, peek the top character from the stack.
5. If the current character is equal to the peeked character in uppercase, pop the peeked character from the stack.
6. If the current character is not equal to the peeked character in uppercase, push the current character to the stack.
7. After iterating through the string, pop all the characters from the stack and return the string.

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public string MakeGood(string s) {
        Stack<char> stack  = new Stack<char>();                         // To store the characters
        StringBuilder sb = new StringBuilder();                         // To store the final string
        while(true) {                                                   // Loop until the string is not modified
            for(int i = s.Length-1; i>=0; i--) {                        // Iterating through the string
                stack.Push(s[i]);                                       // Push the character to the stack
            }
            while(stack.Count() != 0) {                                 // Pop all the characters from the stack
                char popped = stack.Pop();                              // Pop the character from the stack
                if(stack.Count() != 0) {                                // If the stack is not empty
                    char peeked = stack.Peek();                         // Peek the top character from the stack
                    if(IfBad(peeked, popped)) {                         // If the current character is equal to the peeked character in uppercase and vice versa
                        popped = stack.Pop();                           // Pop the peeked character from the stack
                        continue;                                       // Continue to the next character
                    }
                }
                sb.Append(popped);                                      // Append the character to the final string
            }
            if(s.Equals(sb.ToString())) break;                          // If the string is not modified, break from the loop
            s = sb.ToString();                                          // Update the string
            stack.Clear();                                              // Clear the stack
            sb.Clear();                                                 // Clear the final string
        }
        return s;                                                       // Return the final string
    }

    static bool IfBad(char a, char b) {
        return (((int)a - '0') + 32) == ((int)b - '0') || (((int)b - '0') + 32) == ((int)a - '0') ; // Check if the characters are equal to each other in uppercase and vice versa
    }
}