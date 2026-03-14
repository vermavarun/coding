'''
Title: 1980. Find Unique Binary String
Solution:
Difficulty: Medium
Approach: Cantor's Diagonal Argument
Tags: Array, String, Backtracking, Math
1) Initialize an empty result string and index counter.
2) Iterate through each string in the input array nums.
3) For each string at position i, look at the character at position [i] (diagonal).
4) Flip that character (if '0' make it '1', if '1' make it '0').
5) Append the flipped character to the result string.
6) Increment the index for the next iteration.
7) Return the constructed string.

Time Complexity: O(n) where n = len(nums)
Space Complexity: O(n) for the result string
Tip: This uses Cantor's diagonal argument - by flipping the i-th character of the i-th string, the result is guaranteed to differ from each string at at least one position. This elegant solution avoids checking all 2^n possible binary strings.
Similar Problems: 268. Missing Number, 287. Find the Duplicate Number, 645. Set Mismatch, 41. First Missing Positive
'''
class Solution:
    def findDifferentBinaryString(self, nums: List[str]) -> str:
        result = ""                                     # Build the result string
        i = 0                                           # Track current position for diagonal traversal
        for num in nums:                                # Iterate through each binary string in array
            result += "1" if num[i] == "0" else "0"    # Flip character at diagonal position and append
            i+=1                                        # Move to next diagonal position
        return result                                   # Return the unique binary string
