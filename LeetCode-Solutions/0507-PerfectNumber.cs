public class Solution {
    public bool CheckPerfectNumber(int num) {
        if(num%2!=0)
            return false;
        int sum = 0;
        for( int i=1 ; i<=num/2; i++ ) {
            if(num%i==0)
                sum=sum+i;
        }
        return sum==num ? true: false; 
    }
}