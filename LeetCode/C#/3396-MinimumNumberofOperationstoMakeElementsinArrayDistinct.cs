/*
Solution: https://leetcode.com/problems/minimum-number-of-operations-to-make-elements-in-array-distinct/solutions/6630129/simplest-solution-c-time-on-spacen-pleas-29rf/
Difficulty: Medium
Approach: Using HashSet and Reverse Iteration
Tags: Array, Math
1) We will use a HashSet to store the unique elements of the array.
2) We will iterate through the array in reverse order.
3) For each element, we will check if it is already in the HashSet.
4) If it is, we will return the number of operations needed to make the elements distinct.
5) If it is not, we will add it to the HashSet.
6) If we finish iterating through the array without finding any duplicates, we will return 0.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public int MinimumOperations(int[] nums) {
        HashSet<int> hs = new HashSet<int>();         // HashSet to store unique elements
        for(int i=nums.Length - 1; i>=0; i--) {       // Reverse iterate through the array
            if (hs.Contains(nums[i])) {               // If the element is already in the HashSet
                return (int)Math.Ceiling((i+1)/3.0);  // Return the number of operations needed
            }
            hs.Add(nums[i]);                          // Add the element to the HashSet
        }
        return 0;                                     // If all elements are unique, return 0
    }
}
