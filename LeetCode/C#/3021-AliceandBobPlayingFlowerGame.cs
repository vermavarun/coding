/*
Solution: https://leetcode.com/problems/alice-and-bob-playing-flower-game/solutions/7134602/simplest-solution-c-time-o1-space1-pleas-2xa1/
Difficulty: Medium
Approach: Math, Parity Counting
Tags: Math, Combinatorics
1) Alice and Bob take turns picking flowers from two rows of n and m flowers.
2) The number of ways Alice can win is the number of pairs (i, j) where i + j is odd.
3) This is equivalent to counting odd-even and even-odd pairs between the two rows.
4) Calculate odd/even counts for both n and m, then multiply accordingly.
5) Return the total number of such pairs.
Time Complexity: O(1)
Space Complexity: O(1)

Time Complexity: O(1)
Space Complexity: O(1)
*/
public class Solution {
    public long FlowerGame(int n, int m) {
        long aliceTakesNFirst = ((long)(n + 1) / 2) * (m / 2);   // Cast to long before multiplication
        long aliceTakesMFirst = ((long)(m + 1) / 2) * (n / 2);   // Cast to long before multiplication

        return aliceTakesNFirst + aliceTakesMFirst;
    }
}