/*
Solution: https://leetcode.com/problems/maximum-unique-subarray-sum-after-deletion/solutions/7016748/simplest-solution-c-time-on-space1-pleas-in2n/
Approach: Iteration
Video: https://www.youtube.com/watch?v=0Q4cqxmR0qc
Tags: Array, Greedy, Iteration, Dictionary, Hash Table
1) Iterate through the array and maintain a sum of positive unique numbers.
2) Use an array to track seen numbers (from 0 to 100).
3) If a number is negative or zero, keep track of the maximum negative number.
4) If the sum of positive numbers is zero, return the maximum negative number.
5) Otherwise, return the sum of positive unique numbers.

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution
{
    public int MaxSum(int[] nums)
    {
        int sum = 0;                                // Initialize sum of positive unique numbers
        int[] seen = new int[101];                  // Array to track seen numbers (0 to 100)
        int maxNeg = int.MinValue;                  // Initialize max negative number

        foreach (int num in nums)                   // Iterate through each number in the array
        {
            if (num > 0 && seen[num] == 0)          // If the number is positive and not seen before
            {
                seen[num] = 1;                      // Mark the number as seen
                sum = sum + num;                    // Add the number to the sum
            }
            else if (num <= 0)                      // If the number is negative or zero
            {
                maxNeg = Math.Max(maxNeg, num);     // Update the maximum negative number
            }
        }

        return sum == 0 ? maxNeg : sum;             // Return the sum of positive unique numbers or the maximum negative number if sum is zero
    }
}
