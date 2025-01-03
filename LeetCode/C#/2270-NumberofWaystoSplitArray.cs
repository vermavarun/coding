/*
Approach:
1. Calculate the total sum of the array.
2. Iterate through the array and calculate the leftSum and rightSum.
3. If the leftSum is greater than or equal to the rightSum, increment the result.
4. Return the result.

Time Complexity: O(n) where n is the length of the nums array.
Space Complexity: O(1)
*/
public class Solution {
    public int WaysToSplitArray(int[] nums) {
        long totalSum, leftSum, rightSum;           // Declare the variables
        int result = 0;                             // Initialize the result to 0
        leftSum = rightSum = 0;                     // Initialize the leftSum and rightSum to 0
        totalSum = FindSum(nums);                   // Calculate the total sum of the array
        for (int i = 0; i<nums.Length - 1; i++) {   // Iterate through the array up to the second last element
            leftSum = leftSum + nums[i];            // Calculate the leftSum
            rightSum = totalSum - leftSum;          // Calculate the rightSum
            if (leftSum >= rightSum) {              // Check if the leftSum is greater than or equal to the rightSum
                result++;                           // Increment the result
            }
        }
        return result;                              // Return the result
    }

    public static long FindSum(int[] nums) {        // Function to calculate the total sum of the array
        long totalSum = 0;                          // Initialize the totalSum to 0
        foreach (int num in nums) {                 // Iterate through the array
            totalSum+= num;                         // Calculate the total sum
        }
        return totalSum;                            // Return the total sum
    }
}