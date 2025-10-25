/*
Solution: https://leetcode.com/problems/calculate-money-in-leetcode-bank/solutions/7299967/simplest-solution-c-time-o1-space1-pleas-4dlh/
Approach: Mathematical Pattern Recognition and Arithmetic Sequence
Tags: Math, Arithmetic Sequence, Pattern Recognition
1) If n <= 7, use simple arithmetic sequence formula for first week.
2) Calculate complete weeks (q) and remaining days (r).
3) For complete weeks: each week adds 7 more than previous (28, 35, 42...).
4) For remaining days: start from (1 + q) and form arithmetic sequence.
5) Sum complete weeks contribution and remaining days contribution.

Time Complexity: O(1)
Space Complexity: O(1)
*/
public class Solution {
    public int TotalMoney(int n) {
        if (n <= 7) {                                           // If within first week
            return n * (n + 1) / 2;                            // Simple arithmetic sequence: 1+2+...+n
        } else {
            int q = n / 7;                                      // Number of complete weeks
            int r = n % 7;                                      // Remaining days after complete weeks
            int a = 1 + q;                                      // First day amount in the remaining week
            int l = a + (r - 1);                               // Last day amount in remaining days

            // total = full weeks + remaining days
            return (28 * q) + (7 * q * (q - 1)) / 2 + (r * (a + l)) / 2;  // Sum of complete weeks + remaining days
        }
    }
}
