/*
Solution:
Difficulty: Easy
Approach: Find all divisors up to num/2 and check if sum equals num
Tags: Math
1) Check if number is odd (quick optimization - perfect numbers > 1 are even).
2) Initialize sum to track the total of all proper divisors.
3) Iterate from 1 to num/2 to find all divisors.
4) For each divisor found, add it to the sum.
5) Check if sum of all proper divisors equals the original number.
6) Return true if perfect number, false otherwise.

Time Complexity: O(n) where n = num
Space Complexity: O(1)
*/
public class Solution {
    public bool CheckPerfectNumber(int num) {
        if(num%2!=0)                                                // If number is odd
            return false;                                           // Return false (perfect numbers > 1 are even)
        int sum = 0;                                                // Initialize sum of divisors
        for( int i=1 ; i<=num/2; i++ ) {                            // Iterate through potential divisors
            if(num%i==0)                                            // If i is a divisor of num
                sum=sum+i;                                          // Add it to sum
        }
        return sum==num ? true: false;                              // Return true if sum equals num (perfect number)
    }
}