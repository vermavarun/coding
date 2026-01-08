/*
Title: 1458. Max Dot Product of Two Subsequences
Solution: https://leetcode.com/problems/max-dot-product-of-two-subsequences/solutions/7477838/simplest-solution-c-time-onm-spacenm-ple-5ykr/
Difficulty: Hard
Approach: Dynamic Programming with Memoization (Top-Down DFS)
Tags: Array, Dynamic Programming, Recursion, Memoization
1) Use DFS with memoization to explore all possible subsequence combinations.
2) At each position (i, j), calculate dot product of current elements.
3) Consider three choices: take both elements, skip nums1[i], or skip nums2[j].
4) When taking both, either start new subsequence or extend previous one.
5) Use NEG constant to represent invalid/empty subsequences.
6) Memoize results to avoid recalculating same states.

Time Complexity: O(n * m) where n = nums1.length, m = nums2.length
Space Complexity: O(n * m) for memoization array + O(n + m) recursion stack
*/
public class Solution {

    private int[] nums1, nums2;                                     // Store input arrays as class fields for access in DFS
    private int[,] memo;                                            // Memoization table to cache computed results
    private const int NEG = -1_000_000_000;                         // Sentinel value representing invalid/empty subsequence

    public int MaxDotProduct(int[] nums1, int[] nums2) {
        this.nums1 = nums1;                                         // Store first array reference
        this.nums2 = nums2;                                         // Store second array reference

        int n = nums1.Length;                                       // Length of first array
        int m = nums2.Length;                                       // Length of second array

        memo = new int[n, m];                                       // Initialize memoization table

        // mark memo as unvisited
        for (int i = 0; i < n; i++)                                 // Iterate through rows
            for (int j = 0; j < m; j++)                             // Iterate through columns
                memo[i, j] = int.MinValue;                          // Mark as unvisited using MinValue sentinel

        return DFS(0, 0);                                           // Start DFS from position (0, 0) and return result
    }

    private int DFS(int i, int j) {

        // base case: out of bounds
        if (i == nums1.Length || j == nums2.Length)                 // If either index out of bounds
            return NEG;                                             // Return invalid value (can't form subsequence)

        if (memo[i, j] != int.MinValue)                             // If this state already computed
            return memo[i, j];                                      // Return cached result (memoization)

        int product = nums1[i] * nums2[j];                          // Calculate dot product of current elements

        int takeBoth = Math.Max(                                    // Option 1: Take both current elements
            product,                                                // Start new subsequence with just this product
            product + DFS(i + 1, j + 1)                            // Extend subsequence by adding to next products
        );

        int skip1 = DFS(i + 1, j);                                  // Option 2: Skip nums1[i], continue with nums2[j]
        int skip2 = DFS(i, j + 1);                                  // Option 3: Skip nums2[j], continue with nums1[i]

        memo[i, j] = Math.Max(takeBoth, Math.Max(skip1, skip2));   // Take maximum of all three options and cache it
        return memo[i, j];                                          // Return cached result
    }
}
