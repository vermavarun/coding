/*
Title: 2553. Separate the Digits in an Array
Solution: https://leetcode.com/problems/separate-the-digits-in-an-array/solutions/8186853/simplest-solution-c-time-ond-space-ond-p-s4qz/
Difficulty: Easy
Approach: Digit Extraction with Reversal
Tags: Array, Simulation
1) Initialize a list to collect the final separated digits.
2) Iterate through each number in the input array.
3) For single-digit numbers (< 10), add directly to the result list.
4) For multi-digit numbers, extract digits right-to-left using modulo (% 10) and integer division (/ 10).
5) Reverse the extracted digits to restore left-to-right order.
6) Append the reversed digits to the result list.
7) Convert the result list to an array and return it.

Time Complexity: O(n * d) where n = numbers.length and d = max digits in a number
Space Complexity: O(n * d) for the output list
Tip: Extracting digits with % 10 and / 10 naturally produces them in reverse order — always reverse before appending to maintain original digit order.
Similar Problems: 2094. Finding 3-Digit Even Numbers, 1290. Convert Binary Number in a Linked List to Integer
*/
public class Solution
{
    // Stores the final sequence of separated digits
    private List<int> separatedDigits;

    public int[] SeparateDigits(int[] numbers)
    {
        separatedDigits = new List<int>();

        foreach (int number in numbers)
        {
            // If the number has multiple digits,
            // split it into individual digits.
            if (number >= 10)
            {
                AddDigitsToResult(number);
            }
            else
            {
                // Single-digit numbers are added directly.
                separatedDigits.Add(number);
            }
        }

        return separatedDigits.ToArray();
    }

    /// <summary>
    /// Extracts all digits from a number
    /// and appends them to the result list
    /// in the original left-to-right order.
    /// </summary>
    private void AddDigitsToResult(int number)
    {
        List<int> digits = new List<int>();

        // Extract digits from right to left.
        while (number > 0)
        {
            int lastDigit = number % 10;
            digits.Add(lastDigit);

            number /= 10;
        }

        // Digits were collected in reverse order,
        // so reverse them back.
        digits.Reverse();

        // Add all digits to the final result.
        foreach (int digit in digits)
        {
            separatedDigits.Add(digit);
        }
    }
}