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