/*
Title: 7. Reverse Integer
Solution: https://leetcode.com/problems/reverse-integer/solutions/7961660/simplest-solution-c-time-on-space-on-ple-e5at/
Difficulty: Medium
Approach: Mathematical Digit Extraction with Overflow Check
Tags: Math
1) Initialize reversedNumber to 0 to build the result.
2) Loop while the input number is not zero.
3) Extract the last digit using modulo 10 operation.
4) Remove the last digit from number by dividing by 10.
5) Before multiplying reversedNumber by 10, check for potential overflow.
6) If reversedNumber would overflow when multiplied by 10, return 0.
7) Otherwise, multiply reversedNumber by 10 and add the extracted digit.
8) Continue until all digits are processed.
9) Return the reversed number.

Time Complexity: O(log(n)) where n is the input number (number of digits)
Space Complexity: O(1) - only using constant extra space
Tip: The key challenge is detecting overflow BEFORE it happens. Check if reversedNumber > int.MaxValue / 10 or < int.MinValue / 10 before multiplying by 10. This prevents overflow from occurring rather than catching it after the fact.
Similar Problems: 9. Palindrome Number, 8. String to Integer (atoi), 190. Reverse Bits
*/
public class Solution {
    public int Reverse(int number) {
        int reversedNumber = 0;                                     // Initialize result to zero

        while (number != 0) {                                       // Loop until all digits are processed
            int lastDigit = number % 10;                            // Extract rightmost digit
            number /= 10;                                           // Remove rightmost digit from number

            // Check for overflow before multiplying
            if (reversedNumber > int.MaxValue / 10 || reversedNumber < int.MinValue / 10) {  // Check if multiplication would overflow
                return 0;                                           // Return 0 if overflow detected
            }

            reversedNumber = reversedNumber * 10 + lastDigit;       // Build reversed number by adding digit
        }

        return reversedNumber;                                      // Return final reversed number
    }
}