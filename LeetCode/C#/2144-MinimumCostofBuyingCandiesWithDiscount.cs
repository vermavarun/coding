/*
Title: 2144. Minimum Cost of Buying Candies With Discount
Solution: https://leetcode.com/problems/minimum-cost-of-buying-candies-with-discount/solutions/8305651/simplest-solution-c-time-on-log-n-space-g4ef6/
Difficulty: Easy
Approach: Greedy with Sorting
Tags: Array, Greedy, Sorting
1) Sort the cost array in descending order to prioritize expensive candies.
2) Use a pointer to iterate through the sorted array in groups of 3.
3) For every 3 candies, buy the 2 most expensive and get the cheapest one free.
4) Accumulate the cost of the first two in each group (index 0 and 1 within group).
5) Skip the third candy in each group (the free one at index+2).
6) Return the total accumulated cost.

Time Complexity: O(n log n) for sorting
Space Complexity: O(1) extra space
Tip: The key insight is that after sorting descending, every 3rd candy (index 2, 5, 8, ...) is always the cheapest in its group and should be taken for free. Buying the two most expensive first maximizes the discount on each free candy.
Similar Problems: 1403. Minimum Subsequence in Non-Increasing Order, 976. Largest Perimeter Triangle
*/
public class Solution {
    public int MinimumCost(int[] cost) {

        Array.Sort(cost);                               // Sort in ascending order
        Array.Reverse(cost);                            // Reverse to get descending order (most expensive first)

        int index = 0;                                  // Pointer to track current position
        int minCost = 0;                                // Accumulate total cost

        while (index < cost.Length) {
            minCost += cost[index];                     // Always pay for the most expensive candy in the group

            if (index + 1 < cost.Length) {              // Check if a second candy exists in this group
                minCost += cost[index + 1];             // Pay for the second most expensive candy
            }

            index += 3;                                 // Skip 3: advance past the free candy (index+2)
        }

        return minCost;                                 // Return total minimum cost
    }
}