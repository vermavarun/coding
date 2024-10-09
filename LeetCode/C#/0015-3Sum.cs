/*

Approach:
1. Sort the array
2. Iterate through the array
3. For each element, use two pointers to find the other two elements
4. If the sum of the three elements is greater than 0, decrement the right pointer
5. If the sum of the three elements is less than 0, increment the left pointer

Time complexity: O(n^2)
Space complexity: O(1)

*/
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {

        IList<IList<int>> result = new List<IList<int>>();                                              // List to store the result
        int  left, right;                                                                               // Pointers to find the other two elements
        Array.Sort(nums);                                                                               // Sort the array

        for(int i=0; i< nums.Length; i++) {                                                             // Iterate through the array
            if(i > 0 && nums[i] == nums[i-1])                                                           // Skip the duplicate elements. num1
                continue;
            left = i+1;                                                                                 // Initialize the left pointer
            right = nums.Length - 1;                                                                    // Initialize the right pointer

            while(left< right) {                                                                        // Iterate through the array
                if( (nums[i] + nums[left] + nums[right]) > 0) {                                         // If the sum of the three elements is greater than 0, decrement the right pointer
                    right--;
                }
                else if( (nums[i] + nums[left] + nums[right]) < 0) {                                    // If the sum of the three elements is less than 0, increment the left pointer
                    left++;
                }
                else {                                                                                  // If the sum of the three elements is equal to 0, add the elements to the result
                    result.Add(new List<int>{nums[i],nums[left],nums[right]});
                    left++;                                                                             // Increment the left pointer

                    while(nums[left] == nums[left-1] && left < right) {                                 // Skip the duplicate elements. left num. No need to skip right num as it will be decremented next iteration
                        left++;
                    }
                }
            }
        }

        return result;
    }
}