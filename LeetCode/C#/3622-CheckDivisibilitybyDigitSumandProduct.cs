/*
Title: 3622. Check Divisibility by Digit Sum and Product
Solution:
Difficulty: Easy
Approach: Digit extraction with sum/product aggregation
Tags: Math
1) Traverse digits of n from right to left using modulo and division.
2) Compute digit sum and digit product in one pass.
3) Check if n is divisible by (digit sum + digit product).

Time Complexity: O(d) where d = number of digits in n
Space Complexity: O(1)
Tip: Use modulo (%) to extract the last digit and integer division (/ 10) to remove it. This gives a clean one-pass digit-processing pattern.
Similar Problems: 1281. Subtract the Product and Sum of Digits of an Integer
*/
public class Solution
{
    public bool CheckDivisibility(int n)
    {
        (int digitSum, int digitProduct) = GetDigitSumProduct(n); // Compute digit sum and product together
        return n % (digitSum + digitProduct) == 0;                // Divisible if remainder is zero
    }

    private (int, int) GetDigitSumProduct(int n)
    {
        int sum = 0;       // Running sum of digits
        int product = 1;   // Running product of digits

        while (n > 0)      // Process all digits
        {
            int lastDigit = n % 10; // Extract last digit
            n = n / 10;             // Remove last digit
            sum += lastDigit;       // Add to sum
            product *= lastDigit;   // Multiply into product
        }

        return (sum, product);      // Return both aggregated values
    }
}