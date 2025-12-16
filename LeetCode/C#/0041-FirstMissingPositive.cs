/*
Difficulty: Hard
Approach: In-place marking using array indices
Tags: Array, Hash Table
1) Replace all negative numbers with 0 (we only care about positive integers).
2) Use the array itself as a hash table by marking presence of numbers.
3) For each number n in range [1, len], mark nums[n-1] as negative to indicate n exists.
4) Handle zero values by marking them as -(len+1) to distinguish from actual negatives.
5) Find the first index with a non-negative value - that index+1 is the missing positive.
6) If all indices are negative, return len+1.

Time Complexity: O(n) where n is array length
Space Complexity: O(1) - in-place marking
*/
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        // Step 1: Replace all negative numbers with 0
        for (int i=0; i<nums.Length; i++) {
            if(nums[i] < 0) {                       // If number is negative
                nums[i] = 0;                        // Replace with 0
            }
        }

        // Step 2: Mark presence of numbers by negating values at corresponding indices
        for (int i=0; i<nums.Length; i++) {
            int val = Math.Abs(nums[i]);            // Get absolute value to handle already negated numbers
            if(val >=1 && val <= nums.Length) {     // If value is in range [1, length]
                if (nums[val-1] > 0)                // If value at index (val-1) is positive
                    nums[val-1] *= -1;              // Make it negative to mark presence
                else if(nums[val-1] ==0)            // If value is zero (corner case)
                    nums[val-1] = -1 * (nums.Length+1);  // Mark with special negative value
            }

        }

        // Step 3: Find first index with non-negative value
        for(int i=1; i<nums.Length+1 ;i++) {
            if(nums[i-1] >= 0)                      // If value at index is non-negative
                return i;                           // Return index+1 as the missing positive
        }
        return nums.Length + 1;                     // All positives [1, length] exist, return length+1
    }
}