/*
Title: 799. Champagne Tower
Solution: https://leetcode.com/problems/champagne-tower/solutions/7579192/simplest-solution-c-time-oquery_row2-spa-qpye/
Difficulty: Medium
Approach: Dynamic Programming with Memoization (Top-Down)
Tags: Dynamic Programming, Recursion, Memoization, Matrix
1) Visualize champagne glasses as a pyramid: row 0 has 1 glass, row 1 has 2 glasses, etc.
2) When a glass overflows (> 1.0), excess splits equally to two glasses below (left and right).
3) Use a 2D memoization table to cache computed values for each glass position.
4) Base case: Top glass (0,0) receives all poured champagne initially.
5) Recursive case: Each glass receives overflow from two glasses above it.
6) For glass at (i,j), calculate overflow from (i-1,j-1) and (i-1,j).
7) Overflow from a glass = max(0, (amount - 1) / 2).
8) Return minimum of 1.0 and calculated amount (glass capacity is 1.0).

Time Complexity: O(query_row²) - at most we compute query_row rows
Space Complexity: O(101²) = O(1) - fixed size memoization table
Tip: The key insight is that champagne flows down like a triangle - each glass can overflow to exactly two glasses below. Use memoization to avoid recalculating the same glass positions. Remember that each glass has capacity 1.0, and excess splits equally to both children.
Similar Problems: 118. Pascal's Triangle, 120. Triangle, 931. Minimum Falling Path Sum
*/

public class Solution {
    double[][] dp = new double[101][];                          // Memoization table for DP (101 rows max)

    public double Solve(int poured, int i, int j) {
        if (i < 0 || j > i || j < 0) {                         // Out of bounds: invalid glass position
            return 0.0;
        }

        if (i == 0 && j == 0) {                                // Base case: top glass receives all champagne
            return dp[i][j] = poured;
        }

        if (dp[i][j] != -1) {                                   // If already computed, return cached value
            return dp[i][j];
        }

        // Calculate overflow from upper-left glass (i-1, j-1)
        double up_left = (Solve(poured, i - 1, j - 1) - 1) / 2.0;
        // Calculate overflow from upper-right glass (i-1, j)
        double up_right = (Solve(poured, i - 1, j) - 1) / 2.0;

        if (up_left < 0) {                                     // No overflow from left (glass wasn't full)
            up_left = 0.0;
        }

        if (up_right < 0) {                                    // No overflow from right (glass wasn't full)
            up_right = 0.0;
        }

        return dp[i][j] = up_left + up_right;                   // Current glass = sum of overflows from above
    }

    public double ChampagneTower(int poured, int query_row, int query_glass) {
        for (int i = 0; i < 101; i++) {                        // Initialize memoization table
            dp[i] = new double[101];                            // Create array for each row
            for (int j = 0; j < 101; j++) {
                dp[i][j] = -1;                                  // Mark all cells as uncomputed (-1)
            }
        }

        return Math.Min(1.0, Solve(poured, query_row, query_glass));  // Return min of 1.0 and computed amount
    }
}