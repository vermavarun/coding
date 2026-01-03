/*
Solution: https://leetcode.com/problems/number-of-ways-to-paint-n-3-grid/solutions/7462106/simplest-solution-c-time-on-space1-pleas-bwj9/
Difficulty: Hard
Approach: Dynamic Programming with pattern counting
Tags: Dynamic Programming, Math
1) Define MOD constant for result modulo operations.
2) Initialize two patterns: same (ABA-type: 2 colors) and diff (ABC-type: 3 colors).
3) For first row, there are 6 ways for each pattern type (total 12 ways).
4) For each subsequent row, calculate new patterns based on previous row:
   - New same patterns = (old same * 3 + old diff * 2) % MOD
   - New diff patterns = (old same * 2 + old diff * 2) % MOD
5) Update same and diff with the new calculated values.
6) Return total ways as (same + diff) % MOD.

Time Complexity: O(n) where n = number of rows
Space Complexity: O(1) - only storing pattern counts
*/
public class Solution {
    public int NumOfWays(int n) {
        const int MOD = 1_000_000_007;                              // Modulo constant to prevent overflow

        long same = 6;                                              // Count of ABA-type patterns (2 colors: R-G-R, G-R-G, etc.)
        long diff = 6;                                              // Count of ABC-type patterns (3 colors: R-G-Y, G-R-Y, etc.)

        for (int i = 2; i <= n; i++) {                              // Iterate from row 2 to n
            long newSame = (same * 3 + diff * 2) % MOD;             // Calculate new ABA patterns from previous row
            long newDiff = (same * 2 + diff * 2) % MOD;             // Calculate new ABC patterns from previous row

            same = newSame;                                         // Update same pattern count
            diff = newDiff;                                         // Update diff pattern count
        }

        return (int)((same + diff) % MOD);                          // Return total ways modulo MOD
    }
}
