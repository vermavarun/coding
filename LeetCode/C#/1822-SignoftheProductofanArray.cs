/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array
1. Initialize a variable to store the number of negative numbers in the array.
2. Iterate through the array and for each number, check if it is negative.
3. If the number is negative, increment the count of negative numbers.
4. If the number is zero, return 0.
5. If the count of negative numbers is even, return 1.
6. Otherwise, return -1.
Space complexity: O(1)

Time Complexity: O(?)
*/
public class Solution {
    public int ArraySign(int[] nums) {
        int numOfNegNums = 0;

        foreach(int num in nums) {
            if (num < 0) numOfNegNums++;
            if (num == 0) return 0;
        }

        return numOfNegNums % 2 == 0 ? 1 : -1;
    }
}