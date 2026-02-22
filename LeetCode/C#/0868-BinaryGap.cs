/*
Title: 868. Binary Gap
Solution: https://leetcode.com/problems/binary-gap/solutions/7598571/simplest-solution-c-time-olog-n-space-o1-mzbs/
Difficulty: Easy
Approach: Bit Manipulation with position tracking
Tags: Bit Manipulation
1) Traverse bits of n from least significant to most significant.
2) Track current bit position with curr.
3) Track the position of the last seen 1 bit with prev.
4) Whenever a new 1 is found and prev exists, compute curr - prev.
5) Update result with the maximum such distance.
6) Return result after all bits are processed.

Time Complexity: O(log n) where n is the input number
Space Complexity: O(1)
Tip: Track only positions of 1-bits instead of building a binary string. This keeps the solution constant-space and efficient.
Similar Problems: 191. Number of 1 Bits, 338. Counting Bits, 231. Power of Two
*/
public class Solution {
    public int BinaryGap(int n) {
        int result = 0;   // Maximum distance between consecutive 1 bits
        int curr = 0;     // Current bit position (LSB starts at 0)
        int prev = -1;    // Previous 1-bit position (-1 means none seen yet)

        while (n > 0) {
            if ((n & 1) > 0) {                                  // Current bit is 1
                result = (prev != -1) ? Math.Max(curr - prev, result) : result;
                prev = curr;                                     // Move previous 1 position to current
            }

            curr++;                                              // Advance bit position
            n = n >> 1;                                          // Shift right to inspect next bit
        }

        return result;                                           // Return largest binary gap found
    }
}