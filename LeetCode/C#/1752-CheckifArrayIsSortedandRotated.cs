/*
Solution:
Difficulty: Easy
Approach: Single Pass with rotation point detection
Tags: Array, Simulation
1) Initialize a flag to track if rotation point has been found.
2) Iterate through the array comparing adjacent elements.
3) When current element is greater than next (descending), mark rotation point.
4) If more than one rotation point found, return false (not rotated sorted).
5) After iteration, check if rotation point exists and last > first.
6) If so, return false (violates sorted and rotated property).
7) Otherwise return true (array is sorted or sorted-and-rotated).

Time Complexity: O(n) where n = nums.length
Space Complexity: O(1) only using constant extra space
*/
public class Solution {
    public bool Check(int[] nums) {
        bool peekFound = false;                                     // Track if rotation point has been found
        for(int i=0; i<nums.Length-1; i++) {                        // Iterate through array up to second-to-last element
            if(nums[i] > nums[i+1]) {                               // If current element > next (descending order)
                if(peekFound == false)                              // If this is the first rotation point
                    peekFound = true;                               // Mark rotation point as found
                else                                                // If second rotation point found
                    return false;                                   // Not a valid sorted-rotated array
            }
        }
        if(peekFound && nums[nums.Length-1] > nums[0]) {            // If rotated but last element > first element
            return false;                                           // Violates sorted property after rotation
        }
        return true;                                                // Array is sorted or properly sorted-and-rotated
    }
}