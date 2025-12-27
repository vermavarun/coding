/*
Solution: 
Difficulty: Medium
Approach: Linear Search
Tags: Array, Sorting, Math
1. Count the positive numbers in the array
2. Count the negative numbers in the array
3. Return the maximum of the positive and negative numbers count
Space complexity: O(1)

Time Complexity: O(?)
*/
public class Solution {
    public int MaximumCount(int[] nums) {
       int positive_numbers_count = nums.Where(x=>x>0).Count();             // Count the positive numbers in the array
       int negative_numbers_count = nums.Where(x=>x<0).Count();             // Count the negative numbers in the array
       return Math.Max(positive_numbers_count,negative_numbers_count);      // Return the maximum of the positive and negative numbers count
    }
}

/*
Approach: Binary Search as the array is sorted
TODO: Implement Binary Search

*/
public class Solution {
    public int MaximumCount(int[] nums) {

    }
}