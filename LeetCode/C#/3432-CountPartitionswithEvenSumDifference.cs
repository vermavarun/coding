/*
Solution: https://leetcode.com/problems/count-partitions-with-even-sum-difference/solutions/7394579/simplest-solution-c-time-on-space1-pleas-7joj/
Approach: Prefix Sum with Two Pointers Technique
Tags: Array, Prefix Sum, Math
1) Calculate the total sum of all elements (initial right sum).
2) Iterate through the array, treating each position as a partition point.
3) For each position, update left sum by adding current element.
4) Update right sum by removing current element.
5) Calculate the absolute difference between left and right sums.
6) If the difference is even, increment the count.

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int CountPartitions(int[] nums) {

        int result = 0;                                         // Counter for valid partitions
        int rightCurrentSum = 0;                                // Sum of elements on the right side
        int leftCurrentSum = 0;                                 // Sum of elements on the left side

        foreach(int num in nums) {                              // Calculate total sum (initial right sum)
            rightCurrentSum += num;
        }

        for(int i = 0; i < nums.Length - 1; i++) {             // Iterate through partition points
            leftCurrentSum = nums[i] + leftCurrentSum;          // Add current element to left sum
            rightCurrentSum = rightCurrentSum - nums[i];        // Remove current element from right sum
            int diff = leftCurrentSum - rightCurrentSum;        // Calculate difference between sums
            if (Math.Abs(diff) % 2 == 0) {                      // Check if absolute difference is even
                result++;                                       // Increment count for valid partition
            }
        }

        return result;                                          // Return total count of valid partitions
    }
}