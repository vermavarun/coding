/*
Solution: https://leetcode.com/problems/power-of-four/solutions/7087932/simplest-solution-c-time-olog4-n-space1-x6b5f/
Approach: Divide by 4 until n becomes 1 or not divisible
Tags: Math, Iteration
1) If n is less than or equal to 0, it cannot be a power of four.
2) While n is greater than 1, check if n is divisible by 4.
3) If divisible, divide n by 4; otherwise, return false.
4) If n is reduced to 1, it is a power of four.

Time Complexity: O(log₄ n)
Space Complexity: O(1)
*/
public class Solution {
    public bool IsPowerOfFour(int n) {
        if (n <= 0)                         // Negative numbers and zero are not powers of four
            return false;
        while (n > 1) {                     // While n is greater than 1
            if (n % 4 == 0) {               // If n is divisible by 4
                n = n / 4;                  // Divide n by 4
            }
            else {
                return false;                // If not divisible by 4, not a power of four
            }
        }
        return true;                        // If n is reduced to 1, it's a power of four
    }
}