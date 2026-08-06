/*
Title: 3345. Smallest Divisible Digit Product I
Solution: https://leetcode.com/problems/smallest-divisible-digit-product-i/solutions/8445113/simplest-solution-c-time-okd-space-o1-pl-y6hp/
Difficulty: Easy
Approach: Brute Force with digit product calculation
Tags: Math, Digit Manipulation
1) Start from the given number n.
2) Calculate the product of all digits in the current number.
3) Check if the digit product is divisible by t.
4) If divisible, return the number; otherwise, increment and repeat.
5) Continue until a number with digit product divisible by t is found.

Time Complexity: O(k * d) where k = distance to answer, d = number of digits
Space Complexity: O(1) constant space
Tip: Extract digits using modulo 10 and division. Since the answer is guaranteed to be close to n, brute force checking each number sequentially is efficient.
Similar Problems: 1672. Richest Customer Wealth, 2520. Count the Digits That Divide a Number
*/
public class Solution
{
    public int SmallestNumber(int n, int t)
    {
        while (true)
        {
            int digitProduct = GetDigitProduct(n);                 // Calculate product of all digits

            if (digitProduct % t == 0)                             // Check if product is divisible by t
                return n;

            n++;
        }
    }

    private int GetDigitProduct(int n)
    {
        int product = 1;

        while (n > 0)
        {
            int lastDigit = n % 10;                                // Extract last digit
            product *= lastDigit;
            n /= 10;
        }

        return product;
    }
}