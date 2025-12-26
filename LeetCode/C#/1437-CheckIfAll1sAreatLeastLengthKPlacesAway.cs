/*
Solution: Check If All 1's Are at Least K Places Away
Difficulty: Medium
Approach: Track Distance Between Consecutive 1's
Tags: Array, Greedy
1) Initialize the last position of 1 to -(k+1) to handle the first 1 correctly.
2) Iterate through the array and check each element.
3) When a 1 is found, calculate the distance from the previous 1.
4) If the distance between consecutive 1's is less than k, return false.
5) Update the last position of 1 and continue.
6) If all 1's are at least k places apart, return true.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public bool KLengthApart(int[] nums, int k) {
        int lastOneFoundAtIndex = -(k + 1);                     // Initialize to ensure first 1 is always valid
        for (int i = 0; i < nums.Length; i++) {                 // Iterate through each element in array

            if (nums[i] == 1) {                                 // If current element is 1
                if ((i - lastOneFoundAtIndex - 1) < k) {        // Check distance from previous 1 (excluding both 1's)
                    return false;                               // Return false if distance is less than k
                }
                lastOneFoundAtIndex = i;                        // Update last position of 1
            }
        }
        return true;                                            // All 1's are at least k places apart
    }
}