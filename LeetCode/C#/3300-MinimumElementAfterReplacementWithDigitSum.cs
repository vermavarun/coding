/*
Title: 3300. Minimum Element After Replacement With Digit Sum
Solution: https://leetcode.com/problems/minimum-element-after-replacement-with-digit-sum/solutions/8300099/simplest-solution-c-time-ond-space-o1-pl-mp6m/
Difficulty: Easy
Approach: For each number, replace it with the sum of its digits and find the minimum among all such replacements.
Tags: Array, Math, Digit Sum
1) Iterate through each number in the array.
2) For each number, calculate the sum of its digits.
3) Track the minimum digit sum found.
4) Return the minimum digit sum as the answer.

Time Complexity: O(n * d) where n = nums.length and d = number of digits per number
Space Complexity: O(1) (no extra space except variables)
Tip: The key is to realize that the minimum possible value after replacement is the minimum digit sum among all numbers.
Similar Problems: 258. Add Digits, 66. Plus One
*/
public class Solution {
    public int MinElement(int[] nums) {
        int result = int.MaxValue; // Initialize result to maximum integer value
        foreach(int num in nums) { // Iterate through each number in the array
            int sum = GetSumOfDigits(num); // Calculate sum of digits for current number
            result = Math.Min(result, sum); // Update result if current sum is smaller
        }
        return result; // Return the minimum digit sum found
    }

    // Helper method to calculate the sum of digits of a number
    private int GetSumOfDigits(int num) {
        int sum = 0; // Initialize sum to 0
        while (num > 0) { // Loop until all digits are processed
            int digit = num % 10; // Extract the last digit
            sum = sum + digit; // Add digit to sum
            num = num / 10; // Remove the last digit
        }
        return sum; // Return the sum of digits
    }
}