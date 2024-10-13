/*

Approach:
1) Initialize left and right pointers to 0 and 1 respectively.
2) Iterate through the array until the right pointer reaches the end of the array.
3) If the price at the left pointer is greater than the price at the right pointer, increment both pointers.
4) Otherwise, calculate the profit and update the maximum profit if the current profit is greater than the maximum profit.
5) Increment the right pointer.
6) Return the maximum profit.

Time Complexity: O(n)
Space Complexity: O(1)

*/

public class Solution {
    public int MaxProfit(int[] prices) {
        int left, right, profit;
        left = profit = 0;
        right = left+1;

        while ((left < right) && (right < prices.Length)) {
            if (prices[left] > prices[right]) {
                left=right;
            }
            else {
                profit = Math.Max(profit, prices[right] - prices[left]);
            }
            right++;
        }
        return profit;
    }
}