'''
Title: 1758. Minimum Changes To Make Alternating Binary String
Solution: https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/
Difficulty: Easy
Approach: Count mismatches for both possible alternating patterns
Tags: String, Greedy
1) An alternating binary string can start with either '0' or '1'.
2) Count mismatches when string should start with '0' (pattern: 010101...).
3) Count mismatches when string should start with '1' (pattern: 101010...).
4) For each position i, determine expected character based on pattern.
5) If current character doesn't match expected, increment mismatch counter.
6) Return minimum of both mismatch counts.

Time Complexity: O(n) where n = len(s)
Space Complexity: O(1) only using counters
'''
class Solution:
    def minOperations(self, s: str) -> int:

        startWith0 = 0                                  # Count mismatches for pattern starting with '0'
        startWith1 = 0                                  # Count mismatches for pattern starting with '1'

        for i in range(len(s)):                         # Iterate through each character
            expected0 = '0' if i % 2 == 0  else '1'     # Expected char for pattern 010101...
            expected1 = '1' if i % 2 == 0  else '0'     # Expected char for pattern 101010...

            if s[i] != expected0:                       # If character doesn't match first pattern
                startWith0 +=1                          # Increment mismatch count for pattern 0

            if s[i] != expected1:                       # If character doesn't match second pattern
                startWith1 +=1                          # Increment mismatch count for pattern 1

        return min(startWith1,startWith0)               # Return minimum changes needed
