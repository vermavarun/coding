/*
Approach: Binary Search
1) Initialize the left and right pointers
2) Iterate through the array
3) Calculate the mid
4) If the mid element is equal to the target, return the mid
5) If the mid element is less than the target, increment the left pointer
6) If the mid element is greater than the target, decrement the right pointer
7) Return the left pointer
Time complexity: O(log n)
Space complexity: O(1)
*/
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int left = 0;                   // Initialize the left pointer
        int right = nums.Length - 1 ;   // Initialize the right pointer
        int mid = (right+left)/2;       // Calculate the mid

        while(left<=right) {            // Iterate through the array
            mid =(right+left)/2;        // Calculate the mid

            if(nums[mid] == target) {   // If the mid element is equal to the target, return the mid
                return mid;             // Return the mid
            }

            if (nums[mid] > target) {   // If the mid element is greater than the target, decrement the right pointer
                right = mid - 1;        // Decrement the right pointer
            }
            else {                      // If the mid element is less than the target, increment the left pointer
                left = mid + 1;         // Increment the left pointer
            }
        }

        return left;                    // Return the left pointer if the target is not found
    }
}