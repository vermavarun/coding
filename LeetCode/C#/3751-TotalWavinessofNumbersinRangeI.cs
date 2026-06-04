/*
Title: 3751. Total Waviness of Numbers in Range I
Solution: https://leetcode.com/problems/total-waviness-of-numbers-in-range-i/solutions/8313387/simplest-solution-c-time-onum2-num1-dspa-9bae/
Difficulty: Medium
Approach: Brute Force - Iterate each number and count peaks/valleys in its digits
Tags: Math, String, Enumeration
1) Iterate through every integer from num1 to num2 inclusive.
2) Convert each integer to a string to access individual digits.
3) For each middle digit (index 1 to length-2), check if it is a peak or valley.
4) A peak is when the digit is strictly greater than both its neighbours.
5) A valley is when the digit is strictly less than both its neighbours.
6) Accumulate the waviness count across all numbers and return.

Time Complexity: O((num2 - num1) * d) where d = number of digits in each number
Space Complexity: O(d) for the string conversion of each number
Tip: Waviness only applies to middle digits — first and last digits can never be peaks or valleys since they have only one neighbour. Iterate only indices 1 to length-2.
Similar Problems: 2269. Find the K-Beauty of a Number, 1837. Sum of Digits in Base K
*/
public class Solution {
    public int TotalWaviness(int num1, int num2) {

        int count = 0;

        for (int i = num1; i <= num2; i++) {                    // Iterate through every number in the range
            count += CalculateWaviness(i.ToString());           // Add waviness of current number to total
        }

        return count;                                           // Return total waviness across all numbers
    }

    private int CalculateWaviness(string num) {

        int waviness = 0;

        for (int i = 1; i < num.Length - 1; i++) {             // Only middle digits can be peaks or valleys

            // Peak: digit is strictly greater than both neighbours
            if (num[i] > num[i - 1] && num[i] > num[i + 1]) {
                waviness++;
            }
            // Valley: digit is strictly less than both neighbours
            else if (num[i] < num[i - 1] && num[i] < num[i + 1]) {
                waviness++;
            }
        }

        return waviness;                                        // Return waviness count for this number
    }
}