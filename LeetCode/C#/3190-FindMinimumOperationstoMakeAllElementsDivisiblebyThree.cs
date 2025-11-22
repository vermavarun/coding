/*
Solution: https://leetcode.com/problems/find-minimum-operations-to-make-all-elements-divisible-by-three/solutions/7366777/simplest-solution-c-time-on-space1-pleas-rz6e/
Approach: Calculate Remainder and Determine Minimum Operations
Tags: Array, Math, Greedy
1) For each number, calculate the remainder when divided by 3.
2) If remainder is 0, no operation needed (already divisible by 3).
3) If remainder is 1, need 1 operation (add 2 or subtract 1).
4) If remainder is 2, need 1 operation (add 1 or subtract 2).
5) Use Math.Min(num % 3, 1) to get 0 or 1 operation count.
6) Sum all operations needed for all elements.

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int MinimumOperations(int[] nums) {
        int result = 0;                                         // Counter for total operations
        foreach (int num in nums) {                             // Iterate through each number
            result = result + Math.Min(num % 3, 1);             // Add 0 if divisible by 3, else add 1
        }
        return result;                                          // Return total minimum operations needed
    }
}