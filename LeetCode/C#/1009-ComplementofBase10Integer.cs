/*
Title: 1009. Complement of Base 10 Integer
Solution: https://leetcode.com/problems/complement-of-base-10-integer/solutions/7639984/simplest-solution-c-time-olog-n-space-o1-h7w8/
Difficulty: Easy
Approach: Bit Manipulation - XOR with all-ones mask
Tags: Bit Manipulation
1) Start with mask = 1.
2) Expand mask by left-shifting and adding 1 until mask >= n (mask has same bit length as n).
3) XOR n with the mask to flip all bits of n.
4) Return the result.

Time Complexity: O(log n) where log n = number of bits in n
Space Complexity: O(1)
Tip: The key insight is constructing a mask of all 1s with the same bit-length as n. XOR-ing n with this mask flips every bit, giving the bitwise complement. For n = 0, mask starts at 1 so the result is correctly 1.
Similar Problems: 476. Number Complement, 832. Flipping an Image
*/
public class Solution {
    public int BitwiseComplement(int n) {

        // mask will become a number with all bits = 1
        // Example progression:
        // 1 (1)
        // 3 (11)
        // 7 (111)
        // 15 (1111)
        int mask = 1;

        // Keep expanding mask until it has
        // the same number of bits as n
        while (mask < n)
            // Left shift adds a 0, +1 turns it into 1
            // Example:
            // mask = 1   -> 1
            // mask = 3   -> 11
            // mask = 7   -> 111
            mask = (mask << 1) + 1;

        /*
        Example:
        n = 5

        n (binary)      = 101
        mask generated  = 111

        XOR operation flips bits:

            111
        ^   101
        --------
            010  -> 2
        */

        return mask ^ n;
    }
}