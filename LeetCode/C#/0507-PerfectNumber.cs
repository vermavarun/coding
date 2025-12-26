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