/*
Title: 3550. Smallest Index With Digit Sum Equal to Index
Solution: https://leetcode.com/problems/smallest-index-with-digit-sum-equal-to-index/solutions/8538196/simplest-solution-c-time-on-space-on-ple-3xxh/
Difficulty: Easy
Approach: Iterate through the array and calculate each number's digit sum
Tags: Array, Math
1) Iterate through the array while tracking each element's index.
2) Calculate the digit sum of the current number.
3) If the digit sum equals the current index, return that index.
4) If no index satisfies the condition, return -1.

Time Complexity: O(n * d) where n = nums.length and d is the maximum number of digits
Space Complexity: O(1)
Tip: Check indices from left to right so the first matching index is automatically the smallest one. Repeatedly taking the remainder by 10 extracts each digit for the digit sum.
Similar Problems: 258. Add Digits, 1295. Find Numbers with Even Number of Digits
*/
public class Solution {
    public int SmallestIndex(int[] nums) {
        for (int i=0; i<nums.Length; i++) {       // Check each number from left to right
            int sum = GetDigitSum(nums[i]);        // Calculate the digit sum of the current number
            if (sum == i)                           // Check whether the digit sum equals the index
                return i;                           // Return the first matching index
        }
        return -1;                                  // Return -1 when no index satisfies the condition
    }

    private int GetDigitSum(int num) {
        int sum = 0;                                // Store the running digit sum
        while (num > 0) {                           // Process every digit in the number
            int lastDigit = num % 10;               // Extract the last digit
            num = num / 10;                         // Remove the last digit
            sum = sum + lastDigit;                  // Add the digit to the running sum
        }
        return sum;                                 // Return the calculated digit sum
    }
}