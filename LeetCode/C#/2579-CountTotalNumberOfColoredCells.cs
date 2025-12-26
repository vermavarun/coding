/*
Solution: 
Difficulty: Medium
Approach:
Tags: Algorithm
- For n > 1, there are 4 * n * (n - 1) / 2 colored cells.
- So, the total number of colored cells = 1 + 4 * n * (n - 1) / 2. because there is 1 colored cell for n = 1.
- 1 + 4*1 + 4*2 + 4*3 + ... + 4*(n-1) = 1 + 4 * (1 + 2 + 3 + ... + n - 1) = 1 + 4 * n * (n - 1) / 2
- So, the total number of colored cells = 1 + 4 * n * (n - 1) / 2. Sum of n natural numbers = n * (n + 1) / 2. Here n = n - 1. So, the sum of n natural numbers = n * (n - 1) / 2.
- So, the total number of colored cells = 1 + 4 * n * (n - 1) / 2.
Time complexity: O(1)
Space complexity: O(1)

*/
public class Solution {
    public long ColoredCells(int n) {
        return n == 1 ? 1 : (1 + 4L * n * (n - 1) / 2);
    }
}