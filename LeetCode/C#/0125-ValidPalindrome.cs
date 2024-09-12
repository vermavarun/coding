// Minimal Use of Built in Functions.
// Two Pointer
public class Solution {
    public bool IsPalindrome(string s) {
        
        s = s.ToLower();
        
        int i=0;
        int j= s.Length - 1;

        while(i<j) {

            if( s[i] < 48 || s[i] > 57 && s[i] < 97 || s[i] > 122) { // 48 to 57 is for numbers. 97 to 122 is for letters
                i++;
                continue;
            }

            if( s[j] < 48 || s[j] > 57 && s[j] < 97 || s[j] > 122) {
                j--;
                continue;
            }

            if(s[i] != s[j]) return false;          

            i++;
            j--;
        }
        return true;
    }
}
