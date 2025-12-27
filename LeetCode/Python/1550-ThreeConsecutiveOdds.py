"""
Solution: 
Difficulty: Medium
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
"""
'''
Solution: https://leetcode.com/problems/three-consecutive-odds/submissions/1630979353/?envType=daily-question&envId=2025-05-11
Approach:
1. Initialize a variable `size` to the length of the input list `arr`.
2. If the size is less than or equal to 2, return False since it's impossible to have three consecutive odd numbers.
3. Iterate through the list `arr` using a for loop, checking each triplet of consecutive elements.
4. For each triplet, check if all three elements are odd (i.e., not divisible by 2).
5. If a triplet of consecutive odd numbers is found, return True.
6. If the loop completes without finding any triplet, return False.

Time Complexity: O(n), where n is the length of the input list `arr`.
Space Complexity: O(1), as we are using a constant amount of space.
'''

class Solution(object):
    def threeConsecutiveOdds(self, arr):
        """
        :type arr: List[int]
        :rtype: bool
        """
        size = len(arr)                                                         # Get the size of the array
        if size <=2:                                                            # If size is less than or equal to 2, return False
            return False                                                        # Since it's impossible to have three consecutive odds
        for i in range(size - 2):                                               # Iterate through the array
            if arr[i] % 2 != 0 and arr[i+1] % 2 != 0 and arr[i+2] % 2 != 0:     # Check if three consecutive numbers are odd
                return True                                                     # If found, return True
        return False                                                            # If no such triplet is found, return False