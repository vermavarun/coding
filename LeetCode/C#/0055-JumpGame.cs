/*
Title: 55. Jump Game
Solution: https://leetcode.com/problems/jump-game/solutions/8256487/simplest-solution-c-time-on-space-o1-ple-3on6/
Difficulty: Medium
Approach: Greedy - track the maximum reachable index
Tags: Array, Greedy
1) Maintain a variable maxReach to track the furthest index reachable so far.
2) Iterate through each index i in the array.
3) If i exceeds maxReach, the current position is unreachable — return false.
4) Update maxReach to the maximum of itself and i + nums[i] (furthest jump from i).
5) If the loop completes without returning false, the last index is reachable.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(1) — only a single variable used
Tip: The key insight is you don't need to simulate every jump. Just greedily track the furthest reachable index. If you ever encounter an index beyond maxReach, you're stuck.
Similar Problems: 45. Jump Game II, 1306. Jump Game III, 1345. Jump Game IV
*/
public class Solution {
    public bool CanJump(int[] nums) {

        int maxReach = 0;                                           // Furthest index reachable so far
        for (int i=0; i<nums.Length; i++) {

            if (i > maxReach) {                                     // Current index is unreachable
                return false;
            }

            maxReach = Math.Max(maxReach, i + nums[i]);             // Update furthest reachable index

        }

        return true;                                                // Reached the end successfully

    }
}