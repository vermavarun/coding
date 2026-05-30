/*
Title: 476. Number Complement
Solution: https://leetcode.com/problems/number-complement/solutions/8302292/simplest-solution-c-time-olog-n-space-o1-9pmw/
Difficulty: Easy
Approach: Bit Manipulation (XOR with mask)
Tags: Bit Manipulation
1) Use a mask to flip each bit of the number up to its most significant bit (MSB).
2) Start with mask = 1 and left-shift until mask exceeds num.
3) For each bit position, XOR num with mask to flip the bit.
4) Continue until all bits up to the MSB are flipped.

Time Complexity: O(log n) where n = num (number of bits in num)
Space Complexity: O(1)
Tip: The key insight is to only flip bits up to the highest set bit. Flipping higher bits would incorrectly add leading 1s.
Similar Problems: 1009. Complement of Base 10 Integer, 191. Number of 1 Bits
*/
public class Solution {
    /// <summary>
    /// Returns the complement of a positive integer by flipping all bits up to the most significant set bit.
    /// Example: num = 5 (101) => complement = 2 (010)
    /// </summary>
    public int FindComplement(int num) {
        int mask = 1; // Mask to flip each bit, starting from the least significant bit

        // Iterate through all bit positions up to the highest set bit in 'num'
        // Example: if num = 5 (101), we iterate for mask = 1, 2, 4
        // Stop if mask becomes non-positive (overflow case)
        while (mask > 0 && mask <= num) {
            // XOR operation flips the bit at the current position:
            // 1 ^ 1 = 0  (bit becomes 0)
            // 0 ^ 1 = 1  (bit becomes 1)
            num = num ^ mask;
            mask <<= 1; // Move mask to the next bit position (left shift)
        }

        // After flipping all bits up to the MSB, 'num' becomes its complement
        return num;
    }
}