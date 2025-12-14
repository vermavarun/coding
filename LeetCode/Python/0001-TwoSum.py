'''
Solution: https://leetcode.com/problems/two-sum/solutions/5774602/simplest-solution-python-by-varunve-wapi/
Difficulty: Easy
Approach: Hash Table for O(n) lookup
Tags: Array, Hash Table
1) Create a hashmap to store numbers and their indices.
2) Iterate through the array with index tracking.
3) For each number, calculate the complement (target - number).
4) If complement exists in hashmap, return current index and complement's index.
5) If not found, add current number and its index to the hashmap.
6) Continue until pair is found.

Time Complexity: O(n) where n = len(nums)
Space Complexity: O(n) for the hash table
'''
class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        hashmap = {}                                    # Dictionary to store number -> index mapping
        for i, num in enumerate(nums):                  # Iterate through array with index
            diff = target - num                         # Calculate required complement
            if diff in hashmap:                         # If complement exists in hashmap
                return [i, hashmap[diff]]               # Return current index and complement's index
            hashmap[num] = i                            # Add current number with its index to hashmap
        return []                                       # No solution found (should not happen per problem constraints)