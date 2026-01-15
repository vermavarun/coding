/*
Title: 2943. Maximize Area of Square Hole in Grid
Solution: https://leetcode.com/problems/maximize-area-of-square-hole-in-grid/solutions/7496677/simplest-solution-c-time-oh-log-h-v-log-k3xfh/
Difficulty: Medium
Approach: Find Longest Consecutive Sequences in Both Dimensions
Tags: Array, Sorting, Greedy
1) Find the maximum consecutive sequence in horizontal bars.
2) Find the maximum consecutive sequence in vertical bars.
3) A hole of size k×k requires k+1 consecutive bars in each dimension.
4) The maximum square side is limited by the smaller of the two dimensions.
5) Calculate area by squaring the minimum side length.

Time Complexity: O(h log h + v log v) where h = hBars.length, v = vBars.length (due to sorting)
Space Complexity: O(1) excluding space used by sorting algorithm
Tip: The key insight is that to create a hole, you need consecutive bars. A square hole of side k requires k+1 consecutive bars (the gaps between them). Find the longest consecutive sequence in both dimensions, add 1 to convert from bar count to hole size, then take the minimum to ensure a square fits.
Similar Problems: 128. Longest Consecutive Sequence, 298. Binary Tree Longest Consecutive Sequence, 1940. Longest Common Subsequence Between Sorted Arrays
*/
public class Solution {
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        int maxH = MaxConsecutive(hBars);                           // Find max consecutive horizontal bars
        int maxV = MaxConsecutive(vBars);                           // Find max consecutive vertical bars

        int side = Math.Min(maxH + 1, maxV + 1);                    // Square side = min(h+1, v+1), +1 converts bars to hole size
        return side * side;                                         // Return area of square (side squared)
    }

    private int MaxConsecutive(int[] bars) {
        if (bars.Length == 0) return 0;                             // Handle empty array case

        Array.Sort(bars);                                           // Sort bars to find consecutive sequences
        int max = 1, curr = 1;                                      // Track maximum and current consecutive count

        for (int i = 1; i < bars.Length; i++) {                     // Iterate through sorted bars
            if (bars[i] == bars[i - 1] + 1) {                       // If current bar is consecutive to previous
                curr++;                                             // Increment current consecutive count
            } else {                                                // If sequence breaks
                curr = 1;                                           // Reset current count to 1
            }
            max = Math.Max(max, curr);                              // Update maximum consecutive count
        }

        return max;                                                 // Return longest consecutive sequence length
    }
}
