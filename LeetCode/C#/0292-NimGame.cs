/*
Solution: https://leetcode.com/problems/nim-game/solutions/7415742/simplest-solution-c-time-o1-space1-pleas-9o5a/
Difficulty: Easy
Approach: Mathematical Pattern Recognition
Tags: Math, Game Theory, Brainteaser
1) Analyze the game: You can remove 1-3 stones per turn, lose if you take the last stone.
2) Recognize pattern: If n is divisible by 4, opponent can always mirror your moves to force you to lose.
3) Key insight: If n % 4 == 0, you will always lose with optimal play.
4) Otherwise, you can always force opponent into a position where n % 4 == 0.

Time Complexity: O(1) - Simple modulo operation
Space Complexity: O(1) - No extra space needed
*/
public class Solution {
    public bool CanWinNim(int n) {
        return n % 4 != 0;                          // Win if n is not divisible by 4
    }
}