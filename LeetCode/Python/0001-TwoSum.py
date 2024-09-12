'''
Approach:
1. Create a hashmap to store the index of the elements.
2. Iterate through the list of numbers.
3. For each number, calculate the difference between the target and the number.
4. If the difference is already present in the hashmap, return the indices of the current number and the difference.
5. Else, store the current number and its index in the hashmap.
6. If no such pair is found, return an empty list.

Time complexity:
O(n) - We iterate through the list of numbers once.

Space complexity:
O(n) - We store the indices of the numbers in the hashmap.

'''
class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        hashmap = {}
        for i, num in enumerate(nums):
            diff = target - num
            if diff in hashmap:
                return [i, hashmap[diff]]
            hashmap[num] = i
        return []