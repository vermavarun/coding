/*
Solution: https://leetcode.com/problems/maximum-69-number/solutions/7088498/simplest-solution-c-time-o1-space1-pleas-psug/
Tags: Greedy
Approach: Scan from highest digit, change first 6 to 9
Tags: Math, Greedy, Simulation
1) Start from the highest digit (thousands place for 4-digit numbers).
2) If the current digit is 6, change it to 9 and return the new number.
3) If not, move to the next lower digit.
4) If no 6 is found, return the original number.

Time Complexity: O(1) (since number of digits is constant)
Space Complexity: O(1)
*/
public class Solution {
    public int Maximum69Number (int num) {
        int pos = 4;                              // Position tracker for digits (thousands to units)
        int q = 1000;                             // Divisor to extract each digit
        int originalNum = num;                    // Store original number for calculation

        while (pos > 0) {                        // Check each digit from left to right
            if (num / q == 6)                    // If current digit is 6
                return originalNum + (3 * q);    // Change 6 to 9 (add 3 * place value) and return
            else {
                num = num % q;                   // Remove the leftmost digit
                q = q / 10;                      // Move to next lower digit
                pos--;                           // Decrement position
            }
        }
        return originalNum;                      // If no 6 found, return original number
    }
}