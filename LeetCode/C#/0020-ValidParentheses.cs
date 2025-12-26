/*
Solution:
Difficulty: Easy
Approach: Stack
Tags: String, Stack
1) Create a stack to store the opening brackets.
2) Iterate through the string.
3) If the character is an opening bracket, push it to the stack.
4) If the character is a closing bracket, check if the stack is empty. If it is, return false.
5) If the stack is not empty, check if the top of the stack is the corresponding opening bracket. If it is not, return false.
6) If the top of the stack is the corresponding opening bracket, pop it from the stack.
7) If the stack is empty after the iteration, return true. Otherwise, return false.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public bool IsValid(string s) {
        Stack<char> pstack = new Stack<char>();
        foreach(var c in s) {
            switch(c) {
                case '(':
                case '[':
                case '{':
                    pstack.Push(c);
                    break;
                case ')':
                    if (pstack.Count() == 0) return false;
                    if (pstack.Peek() != '(') return false;
                    pstack.Pop();
                    break;
                case ']':
                    if (pstack.Count() == 0) return false;
                    if (pstack.Peek() != '[') return false;
                    pstack.Pop();
                    break;
                case '}':
                    if (pstack.Count() == 0) return false;
                    if (pstack.Peek() != '{') return false;
                    pstack.Pop();
                    break;
            }
        }
        return pstack.Count() == 0 ? true : false;
    }
}
