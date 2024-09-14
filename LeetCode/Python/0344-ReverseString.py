'''
Approach:
1. Initialize two pointers, left and right, at the start and end of the string, respectively.
2. Swap the characters at the left and right pointers.
3. Increment the left pointer and decrement the right pointer.
4. Continue swapping the characters until the left pointer is greater than the right pointer.
5. The string is now reversed in place.

Time complexity:
O(n) - We iterate through the string once.

Space complexity:
O(1) - We do not use any extra space.

'''
class Solution:
    def reverseString(self, s: List[str]) -> None:
        """
        Do not return anything, modify s in-place instead.
        """
        left = 0
        right = len(s) - 1
        while(left <= right):
            temp = s[left]
            s[left] = s[right]
            s[right] = temp
            left = left + 1
            right = right - 1
