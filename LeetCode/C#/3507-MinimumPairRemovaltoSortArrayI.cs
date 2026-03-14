/*
Title: 3507. Minimum Pair Removal to Sort Array I
Solution: https://leetcode.com/problems/minimum-pair-removal-to-sort-array-i/solutions/7515159/simplest-solution-c-time-on3-space-on-pl-91v7/
Difficulty: Medium
Approach: Greedy simulation with pair removal
Tags: Array, Greedy, Simulation
1) Convert array to a mutable list for easier manipulation.
2) While the list is not non-decreasing (sorted), find the leftmost adjacent pair with minimum sum.
3) Replace that pair with their sum and remove the second element.
4) Count each operation and continue until the list becomes non-decreasing.
5) Return the total number of operations performed.

Time Complexity: O(n³) where n = nums.length (worst case requires n-1 operations, each iteration checks IsNonDecreasing O(n) + finds min pair O(n) + RemoveAt O(n))
Space Complexity: O(n) for the list
Tip: The greedy approach works by always selecting the leftmost pair with minimum sum, which helps minimize the number of operations needed to make the array non-decreasing. The key is to keep merging elements until no inversions remain.
Similar Problems: 2683. Neighboring Bitwise XOR, 453. Minimum Moves to Equal Array Elements
*/
public class Solution {
    public int MinimumPairRemoval(int[] nums) {
        List<int> list = new List<int>(nums);                   // Convert array to list for easier manipulation
        int operations = 0;                                     // Counter for number of operations performed

        while (!IsNonDecreasing(list)) {                        // Continue until list is sorted (non-decreasing)
            int minSum = int.MaxValue;                          // Track minimum sum found so far
            int index = 0;                                      // Store index of the leftmost pair with min sum

            // Find leftmost adjacent pair with minimum sum
            for (int i = 0; i < list.Count - 1; i++) {          // Iterate through all adjacent pairs
                int sum = list[i] + list[i + 1];                // Calculate sum of current adjacent pair
                if (sum < minSum) {                             // If this sum is smaller than current minimum
                    minSum = sum;                               // Update minimum sum
                    index = i;                                  // Update index of pair to remove
                }
            }

            // Replace the pair with their sum
            list[index] = minSum;                               // Replace first element with sum
            list.RemoveAt(index + 1);                           // Remove second element of the pair

            operations++;                                       // Increment operation counter
        }

        return operations;                                      // Return total operations needed
    }

    private bool IsNonDecreasing(List<int> list) {
        for (int i = 1; i < list.Count; i++) {                  // Check each element against previous
            if (list[i] < list[i - 1])                          // If any element is less than previous
                return false;                                   // List is not non-decreasing
        }
        return true;                                            // All elements are in non-decreasing order
    }
}
