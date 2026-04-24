/*
Title: 2833. Furthest Point From Origin
Solution: https://leetcode.com/problems/furthest-point-from-origin/solutions/8094144/simplest-solution-c-time-on-space-o1-ple-5e6b/
Difficulty: Easy
Approach: Count L, R, and underscores, then maximize imbalance
Tags: String, Greedy, Counting
1) Count how many times L, R, and _ appear in the moves string.
2) The fixed displacement is (L - R).
3) Each '_' can be chosen as L or R to maximize distance from origin.
4) Best possible distance is abs(L - R) + underscores.

Time Complexity: O(n) where n = moves.length
Space Complexity: O(1)
Tip: Treat each '_' as a free move that should always be assigned in the direction that increases the absolute distance from zero.
Similar Problems: 657. Robot Return to Origin
*/
public class Solution {
    public int FurthestDistanceFromOrigin(string moves) {

        int countL = 0;               // Count of left moves
        int countR = 0;               // Count of right moves
        int countUnderscore = 0;      // Count of flexible moves ('_')

        foreach(char c in moves) {    // Scan each move and update counters
            switch (c) {
                case 'L':
                    countL++;         // Fixed move to the left
                    break;
                case 'R':
                    countR++;         // Fixed move to the right
                    break;
                case '_':
                    countUnderscore++; // Can be assigned as L or R for max distance
                    break;
            }
        }

        return Math.Abs(countL - countR) + countUnderscore; // Max possible distance

    }
}