/*
Title: 1. Two Sum
Solution:
Difficulty: Easy
Approach: Hash Table for O(n) lookup
Tags: Array, Hash Table
1) Create a dictionary to store numbers and their indices.
2) Iterate through the array with index tracking.
3) For each number, check if (target - number) exists in the dictionary.
4) If complement found, return current index and complement's index.
5) If not found, add current number and its index to the dictionary.
6) Continue until pair is found.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the hash table
*/
public class Solution {
    public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];                              // Array to store result indices
            Dictionary<int,int> keyvalue = new Dictionary<int,int>();   // Dictionary to store number -> index mapping
            int index = 0;                                          // Track current index manually
            foreach (int num in nums)                               // Iterate through each number
            {
                if (keyvalue.ContainsKey(target - num))             // If complement exists in dictionary
                {
                    result[0] = index;                              // Set first index to current position
                    result[1] = keyvalue[target - num];             // Set second index to complement's position
                }
                else                                                // If complement not found
                {
                    keyvalue.TryAdd(num,index);                     // Add current number with its index to dictionary
                }

                index++;                                            // Increment index for next iteration
            }
            return result;                                          // Return result with the two indices
        }
}