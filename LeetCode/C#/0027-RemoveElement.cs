/*

Approach:
1) Initialize left and right pointers to 0 and nums.Length - 1 respectively.
2) Iterate through the array until the left pointer is less than the right pointer.
3) If the value at the right pointer is equal to the target value, decrement the right pointer.
4) If the value at the right pointer is not equal to the target value, swap the values at the left and right pointers and increment the left pointer.
5) Return the left pointer if the value at the left pointer is equal to the target value, otherwise return left pointer + 1.

Time Complexity: O(n)
Space Complexity: O(1)


*/
public class Solution {
    public int RemoveElement(int[] nums, int val) {

        int left, right, temp;
        left = temp = 0;
        right = nums.Length - 1;

        if (nums== null || nums.Length == 0) return 0;

        while (left < right) {
            while(nums[right] == val && left < right) {
                right--;
            }

            if(nums[right] != val) {
                temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
            }
        }

        return nums[left] == val ? left : left + 1;
    }
}