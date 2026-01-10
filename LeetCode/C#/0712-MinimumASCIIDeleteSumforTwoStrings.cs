/*
Title: 712. Minimum ASCII Delete Sum for Two Strings
Solution: https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings/solutions/7483855/simplest-solution-c-time-omn-spacemn-ple-qlje/
Difficulty: Medium
Approach: Top-Down Dynamic Programming with Memoization (DFS)
Tags: String, Dynamic Programming, Memoization, Recursion
1) Use 2D memoization array dp[i,j] to store minimum ASCII delete sum from positions i and j.
2) Base cases: if both strings exhausted return 0; if one exhausted, delete remaining from other.
3) If characters match at s1[i] and s2[j], move both pointers forward without deletion.
4) If characters don't match, try deleting from s1 (cost s1[i]) or s2 (cost s2[j]).
5) Take minimum of both deletion options and store in dp[i,j].
6) Initialize dp with -1 to mark uncomputed states; check memo after base cases.

Time Complexity: O(m * n) - each state computed once
Space Complexity: O(m * n) - memoization array + O(m + n) recursion stack
Tip: This is like edit distance, but instead of counting operations, we sum ASCII values of deleted characters. Always handle base cases before memoization check!
*/

public class Solution {

    int m, n;                                                           // Lengths of s1 and s2
    int[,] dp = new int[1001, 1001];                                    // Memoization array for storing min delete sum
    string s1, s2;                                                      // Input strings stored as instance variables

    public int MinimumDeleteSum(string s1, string s2) {
        this.s1 = s1;                                                   // Store first string
        this.s2 = s2;                                                   // Store second string

        m = s1.Length;                                                  // Get length of first string
        n = s2.Length;                                                  // Get length of second string

        for (int i = 0; i <= m; i++)                                    // Initialize dp array
            for (int j = 0; j <= n; j++)                                // For all positions
                dp[i, j] = -1;                                          // Mark as uncomputed with -1

        return Solve(0, 0);                                             // Start recursion from beginning of both strings
    }

    private int Solve(int i, int j) {                                   // Returns min ASCII delete sum from positions i, j

        // ✅ Base cases FIRST
        if (i == m && j == n)                                           // Both strings fully processed
            return 0;                                                   // No more characters to delete

        if (i == m)                                                     // s1 exhausted, s2 has remaining chars
            return s2[j] + Solve(i, j + 1);                             // Delete s2[j] and recurse (add ASCII value)

        if (j == n)                                                     // s2 exhausted, s1 has remaining chars
            return s1[i] + Solve(i + 1, j);                             // Delete s1[i] and recurse (add ASCII value)

        // ✅ Memo check AFTER base cases
        if (dp[i, j] != -1)                                             // Already computed this state
            return dp[i, j];                                            // Return cached result

        if (s1[i] == s2[j])                                             // Characters match
            return dp[i, j] = Solve(i + 1, j + 1);                      // No deletion needed, move both pointers

        int deleteS1 = s1[i] + Solve(i + 1, j);                         // Option 1: delete from s1, add ASCII value of s1[i]
        int deleteS2 = s2[j] + Solve(i, j + 1);                         // Option 2: delete from s2, add ASCII value of s2[j]

        return dp[i, j] = Math.Min(deleteS1, deleteS2);                 // Store and return minimum of both options
    }
}
