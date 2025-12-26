/*
Solution: 
Difficulty: Easy
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public bool IsPalindrome(int x) {
        if ( x < 0) {
            return false;
        }
        
        string num = x.ToString();
        for(int index = 0 ; index <= num.Length/2 ; index++ ) {
            if(num[index] != num[num.Length - 1 - index]) {
                return false;
            }
        }
        return true;
        
    }
}