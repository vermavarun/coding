/*
Title: 1833. Maximum Ice Cream Bars
Solution: https://leetcode.com/problems/maximum-ice-cream-bars/solutions/8348694/simplest-solution-c-time-on-log-n-space-wfhxt/
Difficulty: Medium
Approach: Greedy with Sorting
Tags: Array, Greedy, Sorting
1) Sort the costs array in ascending order.
2) Start buying from the cheapest bar first.
3) If current cost is greater than remaining coins, stop.
4) Otherwise subtract cost from coins and increment result.
5) Return total bars purchased.

Time Complexity: O(n log n) due to sorting
Space Complexity: O(1) extra space (ignoring sort internals)
Tip: Greedy works because buying cheaper bars first always maximizes the total count you can afford.
Similar Problems: 455. Assign Cookies, 561. Array Partition, 948. Bag of Tokens
*/
public class Solution {
    public int MaxIceCream(int[] costs, int coins) {
        Array.Sort(costs);                         // Sort costs to buy cheapest bars first
        int result = 0;                            // Track how many bars can be purchased
        foreach(int cost in costs) {               // Iterate through each sorted cost
            if (cost > coins || coins <=0)         // Stop when current bar cannot be afforded
                break;
            coins = coins - cost;                  // Spend coins on current bar
            result++;                              // Count purchased bar
        }
        return result;                             // Return maximum bars purchased
    }
}