/*
Solution: https://leetcode.com/problems/sort-colors/solutions/6869499/simplest-solution-c-time-on-space1-pleas-83hk/
Approach: Two Pointers
1. Initialize three pointers: `start` at the beginning, `mid` at the beginning, and `end` at the last index of the array.
2. Iterate through the array using the `mid` pointer:
   - If `nums[mid]` is 0, swap it with `nums[start]`, increment both `start` and `mid`.
   - If `nums[mid]` is 1, just increment `mid`.
   - If `nums[mid]` is 2, swap it with `nums[end]` and decrement `end`.
   - Continue this process until `mid` exceeds `end`.
Time Complexity: O(n), where n is the length of the input array.
Space Complexity: O(1), as we are sorting the array in place without using any additional data structures.
*/
public class Solution
{
    public void SortColors(int[] nums)
    {
        int start = 0;                              // Pointer for the next position of 0
        int mid = 0;                                // Pointer for the current element being evaluated
        int end = nums.Length - 1;                  // Pointer for the next position of 2

        while (mid <= end)                          // Continue until mid pointer exceeds end pointer
        {
            switch (nums[mid])                      // Check the value at the mid pointer
            {
                case 0:                             // If the value is 0, swap it with the value at the start pointer
                    swap(nums, start, mid);         // Swap the values at start and mid
                    start++;                        // Increment the start pointer
                    mid++;                          // Increment the mid pointer to evaluate the next element
                    break;                          // break;
                case 1:                             // If the value is 1, just move the mid pointer forward
                    mid++;                          // Increment the mid pointer to evaluate the next element
                    break;                          // break;
                case 2:                             // If the value is 2, swap it with the value at the end pointer
                    swap(nums, end, mid);           // Swap the values at end and mid
                    end--;                          // Decrement end pointer
                    break;                          // break;
            }
        }
    }

    private void swap(int[] nums, int i, int j)     // Helper method to swap two elements in the array
    {
        int temp = nums[i];                         // Store the value at index i in a temporary variable
        nums[i] = nums[j];                          // Assign the value at index j to index i
        nums[j] = temp;                             // Assign the value of temp (originally nums[i]) to index j
    }
}