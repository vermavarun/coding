/*
Title: 66. Plus One
Solution: https://leetcode.com/problems/plus-one/solutions/7454824/simplest-solution-c-time-on-space1-pleas-zwe8/
Difficulty: Easy
Approach: Reverse iteration with carry handling
Tags: Array, Math
1) Start from the rightmost digit (least significant).
2) If digit is not 9, simply increment it and return (no carry needed).
3) If digit is 9, set it to 0 and continue to next position (carry forward).
4) Repeat step 2-3 until either we increment a non-9 digit or reach the start.
5) If all digits were 9, create a new array with length+1, set first digit to 1.
6) Return the result array.

Time Complexity: O(n) where n = digits.length
Space Complexity: O(1) or O(n) only when all digits are 9
*/
public class Solution {
    public int[] PlusOne(int[] digits) {
        int i = digits.Length - 1;                                  // Start from the last digit (rightmost)

        while (i>=0) {                                              // Iterate from right to left
            if (digits[i] != 9) {                                   // If digit is not 9
                digits[i]++;                                        // Simply increment it
                return digits;                                      // Return as no carry is needed
            }
            else {                                                  // If digit is 9
                digits[i] = 0;                                      // Set it to 0 (carry forward)
                i--;                                                // Move to the next digit on the left
            }
        }

        // Case when all digits were 9 (e.g., 999 becomes 1000)
        int[] result = new int[digits.Length + 1];                  // Create new array with extra space
        result[0] = 1;                                              // Set first digit to 1, rest are 0 by default
        return result;                                              // Return the new array

    }
}