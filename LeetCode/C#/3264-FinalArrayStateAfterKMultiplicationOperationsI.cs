/*
Approach: Brute Force
1) Find the minimum element in the array.
2) Multiply the minimum element by the multiplier.
3) Repeat the above steps k times.
4) Return the final state of the array.

Time Complexity: O(k*n)
Space Complexity: O(1)

*/
public class Solution {
    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        int min = int.MaxValue;                                 // Initialize the minimum element to the maximum value
        int minIndex = -1;                                      // Initialize the index of the minimum element to -1
        for(int i=0; i<k; i++) {                                // Repeat the above steps k times
            for(int j=nums.Length-1; j>=0; j--) {               // Find the minimum element in the array
                if(nums[j] <= min) {                            // Check if the current element is less than or equal to the minimum element
                    min = nums[j];                              // Update the minimum element
                    minIndex = j;                               // Update the index of the minimum element
                }
            }
            nums[minIndex] = nums[minIndex] * multiplier;       // Multiply the minimum element by the multiplier
            min = int.MaxValue;                                 // Reset the minimum element to the maximum value
        }

        return nums;                                            // Return the final state of the array
    }
}