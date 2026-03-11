'''
Title: 1009. Complement of Base 10 Integer
Solution: https://leetcode.com/problems/complement-of-base-10-integer/solutions/7639986/simplest-solution-c-time-olog-n-space-o1-kqrr/
Difficulty: Easy
Approach: Bit Manipulation - XOR with all-ones mask
Tags: Bit Manipulation
1) Start with mask = 1.
2) Expand mask by left-shifting and adding 1 until mask >= n (mask has same bit-length as n).
3) XOR n with the mask to flip all bits of n.
4) Return the result.

Time Complexity: O(log n) where log n = number of bits in n
Space Complexity: O(1)
Tip: The key insight is constructing a mask of all 1s with the same bit-length as n. XOR-ing n with this mask flips every bit, giving the bitwise complement. For n = 0, mask starts at 1 so the result is correctly 1.
Similar Problems: 476. Number Complement, 832. Flipping an Image
'''
class Solution:
    def bitwiseComplement(self, n: int) -> int:
        mask = 1                                        # Start with smallest all-ones mask (1)
        while mask < n:                                 # Expand mask until it covers all bits of n
            mask = (mask << 1) + 1                      # Left shift adds a 0 bit, +1 turns it to 1 (e.g. 1 -> 11 -> 111)
        return n ^ mask                                 # XOR flips all bits of n within its bit-length
