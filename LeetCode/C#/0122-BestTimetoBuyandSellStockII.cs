/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Two Pointers
1) Initialize left and right pointers to 0 and 1 respectively.
2) Iterate through the array until the right pointer reaches the end of the array.
3) If the price at the left pointer is less than the price at the right pointer, calculate the profit and update the profit.
4) Increment both pointers.
5) Return the profit.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int MaxProfit(int[] prices) {
        int left, right, profit;
        left = profit = 0;
        right = left+1;

        while ((left < right) && (right < prices.Length)) {
            if (prices[left] < prices[right]) {
                profit = profit + prices[right] - prices[left];
            }
            left++;
            right++;
        }
        return profit;
    }
}