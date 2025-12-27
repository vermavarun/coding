/*
Solution: 
Difficulty: Medium
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public bool ValidPalindrome(string s) {
       
        int chance = 0; // try to remove this variable
        int i=0;
        int j= s.Length - 1;

        while(i<=j) {

            if(s[i] != s[j] && chance == 1) {
                return false;
            }
            else if(s[i] != s[j] && chance == 0) {
                chance++;
                return IsPalendrome(s,i+1,j) || IsPalendrome(s,i,j-1) ;
            }      
            i++;
            j--;
        }
        return true;
    }

    private bool IsPalendrome(string s, int i, int j) {
        while(i<=j) {
            if(s[i]!=s[j]) return false;
            i++;
            j--;
        }
        return true;
    }
}
