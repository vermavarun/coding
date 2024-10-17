/*

Approach:
1. Sort the array
2. Take a window of size k and find the difference between the last and first element of the window
3. Keep track of the minimum difference
4. Move the window by 1 and repeat the process
5. Return the minimum difference

Time complexity: O(nlogn) + O(n) = O(nlogn)
Space complexity: O(1)

*/
public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        Array.Sort(nums);                                           // Sort the array
        int i = 0;                                                  // Initialize the window
        int j = i + k - 1;                                          // Initialize the window
        int res = int.MaxValue;                                     // Initialize the result

        while (j < nums.Length) {                                   // Iterate through the array
            res = Math.Min(res,nums[j] - nums[i]);                  // Find the difference between the last and first element of the window and update the result
            i++;                                                    // Move the window by 1
            j++;                                                    // Move the window by 1
        }
        
        return res;
    }
}