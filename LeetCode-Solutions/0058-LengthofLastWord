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
