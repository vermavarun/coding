'''
Title: 191. Number of 1 Bits
Solution: https://leetcode.com/problems/number-of-1-bits/
Difficulty: Easy
Approach: Brian Kernighan's Algorithm - Clear rightmost set bit
Tags: Bit Manipulation
1) Initialize counter to track number of set bits.
2) Use n & (n-1) operation to clear the rightmost set bit in each iteration.
3) Continue until n becomes 0 (no more set bits).
4) The number of iterations equals the number of 1 bits.

Time Complexity: O(k) where k = number of set bits
Space Complexity: O(1) constant space
'''
class Solution:
    def hammingWeight(self, n: int) -> int:
        ans = 0                                         # Counter for number of 1 bits
        while (n != 0):                                 # Continue until all bits are cleared
            n = n & (n-1)                               # Clear rightmost set bit (Brian Kernighan's algorithm)
            ans = ans+1                                 # Increment counter for each set bit found
        return ans                                      # Return total count of 1 bits
