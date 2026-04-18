/*
Title: 3783. Mirror Distance of an Integer
Solution: https://leetcode.com/problems/mirror-distance-of-an-integer/solutions/7971780/simplest-solution-c-time-od-space-o1-ple-6frb/
Difficulty: Easy
Approach: Mathematical Digit Reversal
Tags: Math
1) Call helper function to reverse the input number.
2) Calculate absolute difference between original and reversed number.
3) Return the mirror distance.

Helper Function (Reverse):
1) Initialize reversed number to 0.
2) Loop while input number is not zero.
3) Extract last digit using modulo 10.
4) Remove last digit by integer division by 10.
5) Build reversed number by multiplying by 10 and adding extracted digit.
6) Return the fully reversed number.

Time Complexity: O(d) where d = number of digits in n
Space Complexity: O(1) - only using constant extra space
Tip: The mirror distance is simply the absolute difference between a number and its reversed form. The key is the digit extraction technique: use modulo to get the last digit and integer division to remove it, while building the reversed number by multiplying by 10 each iteration.
Similar Problems: 7. Reverse Integer, 9. Palindrome Number, 3761. Minimum Absolute Distance Between Mirror Pairs
*/
public class Solution {
    public int MirrorDistance(int n) {

        int reversedNumber = Reverse(n);                        // Reverse the input number
        int mirrorDistance = Math.Abs(n-reversedNumber);        // Calculate absolute difference

        return mirrorDistance;                                  // Return the mirror distance
    }

    private int Reverse(int n) {
        int reversedNumber = 0;                                 // Initialize reversed number to zero

        while (n != 0) {                                        // Loop until all digits are processed
            int lastDigit = n % 10;                             // Extract rightmost digit
            n = n / 10;                                         // Remove rightmost digit from number
            reversedNumber = reversedNumber*10 + lastDigit;     // Build reversed number by adding digit
        }

        return reversedNumber;                                  // Return the reversed number
    }
}