/*
Title: 3754. Concatenate Non-Zero Digits and Multiply by Sum I
Solution: https://leetcode.com/problems/concatenate-non-zero-digits-and-multiply-by-sum-i/solutions/8382264/simplest-solution-c-time-olog-n-space-o1-laex/
Difficulty: Easy
Approach: Single-pass digit extraction with reversal
Tags: Math
1) Extract digits one by one from n using modulo and division.
2) Accumulate the sum of all digits (including zeros).
3) Build a number using only non-zero digits (appended in extraction order).
4) Reverse the non-zero digit number to restore correct digit order.
5) Return sum * reversed as a long to handle large values.

Time Complexity: O(log n) where log n = number of digits in n
Space Complexity: O(1) only a few integer variables used
Tip: Digits extracted via n % 10 come out in reverse (LSD first), so the concatenated non-zero number must be reversed at the end to match the original left-to-right order.
Similar Problems: 2520. Count the Digits That Divide a Number, 1295. Find Numbers with Even Number of Digits
*/
public class Solution {
    public long SumAndMultiply(int n) {
        int sum = 0;                                                // Accumulates sum of all digits
        int number = 0;                                             // Builds concatenation of non-zero digits (reversed)

        while (n > 0) {                                             // Process each digit of n
            int digit = n % 10;                                     // Extract the least significant digit
            sum += digit;                                           // Add digit to total sum (including zeros)

            if (digit != 0)                                         // Skip zero digits for concatenation
                number = number * 10 + digit;                       // Append non-zero digit to number

            n /= 10;                                                // Remove processed digit from n
        }

        // Reverse the number to restore correct left-to-right digit order
        int reversed = 0;
        while (number > 0) {                                        // Reverse the non-zero digit number
            reversed = reversed * 10 + number % 10;                 // Append last digit of number to reversed
            number /= 10;                                           // Remove processed digit from number
        }

        return (long)sum * reversed;                                // Return product of digit sum and concatenated non-zero digits
    }
}