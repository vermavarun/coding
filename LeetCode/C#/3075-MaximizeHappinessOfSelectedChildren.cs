/*
Solution: https://leetcode.com/problems/maximize-happiness-of-selected-children/solutions/7437241/simplest-solution-c-time-on-log-n-space1-v3gz/
Difficulty: Medium
Approach: Greedy with sorting
Tags: Array, Greedy, Sorting
1) Initialize variables to track maximum happiness sum and decrement factor.
2) Sort the happiness array in ascending order.
3) Iterate through array from end (highest values) selecting k children.
4) For each selected child, subtract the decrement factor from their happiness.
5) Add the adjusted happiness (or 0 if negative) to the total sum.
6) Increment the decrement factor for the next selection.
7) Return the maximum happiness sum after selecting k children.

Time Complexity: O(n log n) where n = happiness.length (due to sorting)
Space Complexity: O(1) excluding sorting space
*/
public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {

        long maxHappiness = 0;                                      // Store total maximum happiness sum
        int decrementBy = 0;                                        // Track decrement factor for each selection
        Array.Sort(happiness);                                      // Sort array in ascending order

        for(int i=happiness.Length-1; i>=0 && decrementBy < k; i--) { // Iterate from highest to lowest, select k children
            maxHappiness += Math.Max(happiness[i] - decrementBy,0); // Add adjusted happiness (minimum 0)
            decrementBy++;                                          // Increment decrement for next child
        }

        return maxHappiness;                                        // Return total maximum happiness
    }
}