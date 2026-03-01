/*
Title: 1689. Partitioning Into Minimum Number Of Deci-Binary Numbers
Solution: https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers/solutions/7617414/simplest-solution-c-time-on-space-on-ple-3d68/
Difficulty: Medium
Approach: Find Maximum Digit (Greedy)
Tags: String, Greedy, Math
1) Initialize maxDigit to track the largest digit seen.
2) Iterate through each character in the string.
3) Convert each character to its numeric value.
4) Update maxDigit with the maximum value found so far.
5) Return maxDigit as the answer.
6) Key insight: A deci-binary number contains only 0s and 1s. To form any digit d, we need at least d deci-binary numbers (each contributing 1 to that position).

Time Complexity: O(n) where n = length of string
Space Complexity: O(1) constant space
Tip: The minimum number of deci-binary numbers needed equals the maximum digit in the string. Think of it as stacking: if the largest digit is 7, you need at least 7 deci-binary numbers where each contributes a 1 to build that 7.
Similar Problems: 2139. Minimum Moves to Reach Target Score, 991. Broken Calculator, 1558. Minimum Numbers of Function Calls to Make Target Array
*/
public class Solution {
    public int MinPartitions(string n) {
        int maxDigit = 0;                                       // Initialize maximum digit tracker

        foreach(char c in n) {                                  // Iterate through each character in the string
            int num = c - '0';                                  // Convert character to its numeric value
            maxDigit = Math.Max(num, maxDigit);                 // Update maxDigit with the larger value
        }

        return maxDigit;                                        // Return the maximum digit found
    }
}