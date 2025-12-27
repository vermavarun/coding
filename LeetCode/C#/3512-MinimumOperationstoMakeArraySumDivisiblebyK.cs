/*
Solution: Minimum Operations to Make Array Sum Divisible by K
Difficulty: Medium
Approach: Calculate Sum Remainder and Determine Operations Needed
Tags: Array, Math, Modular Arithmetic
1) Calculate the total sum of all elements in the array.
2) Find the remainder when the sum is divided by k.
3) The remainder represents the minimum operations needed.
4) If remainder is 0, no operations are needed (sum is already divisible by k).
5) Otherwise, we need to remove 'remainder' amount to make sum divisible by k.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int MinOperations(int[] nums, int k) {
        int sum = 0;                                            // Initialize sum counter
        foreach (int num in nums) {                             // Iterate through each element
            sum += num;                                         // Add each element to total sum
        }
        return sum % k;                                         // Return remainder (minimum operations needed)
    }
}