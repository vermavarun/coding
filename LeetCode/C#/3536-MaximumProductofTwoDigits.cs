/*
Title: 3536. Maximum Product of Two Digits
Solution: https://leetcode.com/problems/maximum-product-of-two-digits/solutions/8420845/simplest-solution-c-time-on-logn-space-o-rec8/
Difficulty: Easy
Approach: Sorting digits with negative number handling
Tags: Math, String, Sorting
1) Handle negative numbers by taking absolute value (digits are always 0-9).
2) Convert the number to a character array to access individual digits.
3) Sort the digit array in ascending order.
4) Extract the two largest digits (last two positions after sorting).
5) Convert characters back to integers and return their product.

Time Complexity: O(d log d) where d = number of digits (typically small, max 10 for int32)
Space Complexity: O(d) for the character array
Tip: Since we only need the two largest digits, an O(d) approach could track max and second max in a single pass without sorting.
Similar Problems: 628. Maximum Product of Three Numbers, 1464. Maximum Product of Two Elements in an Array
*/
public class Solution
{
    public int MaxProduct(int n)
    {
        // Handle negative numbers by working with absolute value
        // since digits themselves are always non-negative (0-9)
        n = Math.Abs(n);

        // Convert the number into a character array
        // so that we can work with individual digits.
        char[] digits = n.ToString().ToCharArray();

        // Sort the digits in ascending order.
        // After sorting, the two largest digits
        // will be at the last two positions.
        Array.Sort(digits);

        int length = digits.Length;

        // Convert the two largest characters to integers
        // by subtracting the ASCII value of '0'.
        int largestDigit = digits[length - 1] - '0';
        int secondLargestDigit = digits[length - 2] - '0';

        // Return the product of the two largest digits.
        return largestDigit * secondLargestDigit;
    }
}