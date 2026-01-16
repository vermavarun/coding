/*
Title: 2975. Maximum Square Area by Removing Fences From a Field
Solution: https://leetcode.com/problems/maximum-square-area-by-removing-fences-from-a-field/solutions/7499601/simplest-solution-c-time-oh2-v2-space-oh-tn99/
Difficulty: Medium
Approach: HashSet for common side lengths
Tags: Array, Hash Table, Enumeration
1) Add boundaries (1 and m/n) to horizontal and vertical fence arrays.
2) Sort both fence arrays to process gaps in order.
3) Generate all possible side lengths (gaps) from horizontal fences.
4) Generate all possible side lengths (gaps) from vertical fences.
5) Find the maximum common gap that exists in both horizontal and vertical sets.
6) Return the area of the largest square (gap * gap) modulo 10^9 + 7.
7) Return -1 if no valid square can be formed.

Time Complexity: O(h^2 + v^2) where h = hFences.length, v = vFences.length
Space Complexity: O(h^2 + v^2) for storing side lengths in HashSets
Tip: The key insight is that a square can only be formed if both horizontal and vertical fences can create the same side length. Use HashSets to efficiently find the maximum common side length between horizontal and vertical fence gaps.
Similar Problems: 1849. Splitting a String Into Descending Consecutive Values, 939. Minimum Area Rectangle
*/
public class Solution {
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {
        const int MOD = 1_000_000_007;                              // Modulo constant (10^9 + 7) for result

        // Add boundaries 1 and m / n
        int[] h = new int[hFences.Length + 2];                      // Create array with space for boundaries
        int[] v = new int[vFences.Length + 2];                      // Create array with space for boundaries

        Array.Copy(hFences, h, hFences.Length);                     // Copy horizontal fences to new array
        Array.Copy(vFences, v, vFences.Length);                     // Copy vertical fences to new array

        h[h.Length - 2] = 1;                                        // Add top boundary (1) to horizontal fences
        h[h.Length - 1] = m;                                        // Add bottom boundary (m) to horizontal fences
        v[v.Length - 2] = 1;                                        // Add left boundary (1) to vertical fences
        v[v.Length - 1] = n;                                        // Add right boundary (n) to vertical fences

        Array.Sort(h);                                              // Sort horizontal fences for gap calculation
        Array.Sort(v);                                              // Sort vertical fences for gap calculation

        HashSet<int> hGaps = GetGaps(h);                            // Get all possible horizontal side lengths
        HashSet<int> vGaps = GetGaps(v);                            // Get all possible vertical side lengths

        int maxGap = -1;                                            // Initialize max common gap to -1 (not found)

        foreach (int gap in hGaps) {                                // Iterate through horizontal gaps
            if (vGaps.Contains(gap)) {                              // Check if gap exists in vertical gaps too
                maxGap = Math.Max(maxGap, gap);                     // Update maximum common gap
            }
        }

        return maxGap == -1 ? -1 : (int)((long)maxGap * maxGap % MOD);  // Return -1 if no square, else area mod 10^9+7
    }

    private HashSet<int> GetGaps(int[] fences) {
        HashSet<int> gaps = new HashSet<int>();                     // Create set to store unique gap sizes
        for (int i = 0; i < fences.Length; i++) {                   // Iterate through each fence position
            for (int j = 0; j < i; j++) {                           // Compare with all previous fence positions
                gaps.Add(fences[i] - fences[j]);                    // Add gap (distance) between fences to set
            }
        }
        return gaps;                                                // Return set of all possible side lengths
    }
}
