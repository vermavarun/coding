/*
Solution: 
Difficulty: Easy
Approach: Binary Search
Tags: Array, Two Pointers, Binary Search
1) Initialize the left and right pointers
2) Iterate through the array
3) Calculate the mid
4) If the mid element is equal to the target, return the mid
5) If the mid element is less than the target, increment the left pointer
6) If the mid element is greater than the target, decrement the right pointer
7) Return -1
Space complexity: O(1)

Time Complexity: O(?)
*/
public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0;                   // Initialize the left pointer
        int right = nums.Length - 1;    // Initialize the right pointer
        int mid = (right+left)/2;       // Calculate the mid

        while(left<=right) {            // Iterate through the array  
            mid = (right+left)/2;       // Calculate the mid

            if(nums[mid] == target) {   // If the mid element is equal to the target, return the mid
                return mid;             // Return the mid
            }

            if(nums[mid] < target) {    // If the mid element is less than the target, increment the left pointer
                left = mid + 1;         // Increment the left pointer
            }
            else {
                right = mid - 1 ;       // If the mid element is greater than the target, decrement the right pointer
            }
        }

        return -1;                      // Return -1 if the target is not found
    }
}