/*
Solution: https://leetcode.com/problems/smallest-number-with-all-set-bits/solutions/7310831/simplest-solution-c-time-on-space1-pleas-p9i9/
Difficulty: Medium
Approach: Bit Manipulation - Check for Numbers of Form (2^k - 1)
Tags: Bit Manipulation, Math, Brute Force
Approach: Bit Manipulation - Check for Numbers of Form (2^k - 1)
1) Start from the given number n and iterate upwards.
2) For each number, check if it has all bits set (form 2^k - 1).
3) Use bit trick: n & (n+1) == 0 to check if all bits are set.
4) Return the first number that satisfies this condition.
5) Numbers with all set bits: 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023...
Space Complexity: O(1)

Time Complexity: O(m) where m is the difference between n and result
Space Complexity: O(1)
*/
public class Solution {
    public int SmallestNumber(int n) {
        int result = n;                                         // Store original n (unused variable)
        while(true) {                                           // Iterate indefinitely until solution found
            if ((n & (n + 1)) == 0) {                            // Check if n has all bits set (2^k - 1 form) ex 7 & 8 == 0. 111 & 1000 == 0000
                return n;                                       // Return first number with all set bits
            }
            n++;                                                // Move to next number
        }
        return -1;                                              // This line is unreachable since solution always exists
    }
}