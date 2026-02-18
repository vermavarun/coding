/*
Title: 693. Binary Number with Alternating Bits
Solution: https://leetcode.com/problems/binary-number-with-alternating-bits/solutions/7588134/simplest-solution-c-time-o1-space-o1-ple-xokh/
Difficulty: Easy
Approach: XOR and Bit Manipulation to check alternating pattern
Tags: Bit Manipulation, Math
1) XOR the number with itself right-shifted by 1 bit.
2) If bits are alternating (like 1010), XOR produces all 1s (like 1111).
3) Check if result is all 1s using the property: num & (num + 1) == 0.
4) All 1s number when incremented becomes power of 2, AND gives 0.

Time Complexity: O(1) - constant time bitwise operations
Space Complexity: O(1) - only storing one integer variable
Tip: XOR of alternating bits (1010 ^ 0101) produces all 1s. A number with all 1s has the property that (n & (n+1)) equals 0.
Similar Problems: 191. Number of 1 Bits, 231. Power of Two, 342. Power of Four
*/
public class Solution {
    public bool HasAlternatingBits(int n) {

        // Step 1: XOR number with itself right-shifted by 1
        // If a number has alternating bits (like 101010),
        // shifting it right by 1 and XOR-ing with original number
        // produces a number with all bits set to 1.
        //
        // Example:
        // n = 10 (binary 1010)
        // n >> 1 = 5 (binary 0101)
        //
        // XOR:
        //   1010
        // ^ 0101
        // --------
        //   1111   => All 1s
        //
        int result = n ^ (n >> 1);                              // XOR number with right-shifted version

        // Step 2: Check if result contains all 1s
        // A number which contains all 1s has a special property:
        // number & (number + 1) == 0
        //
        // Example:
        // result = 1111 (15)
        // result + 1 = 10000 (16)
        //
        //   01111
        // & 10000
        // --------
        //   00000  => 0
        //
        // If result is NOT all 1s, this condition will fail.
        return (result & (result + 1)) == 0;                   // Check if result is all 1s
    }
}