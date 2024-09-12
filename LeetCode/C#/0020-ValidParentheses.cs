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
