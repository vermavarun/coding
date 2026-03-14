/*
Title: 1653. Minimum Deletions to Make String Balanced
Solution: https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/solutions/7560709/simplest-solution-c-time-on-space-o1-ple-4t6s/
Difficulty: Medium
Approach: Greedy with Dynamic Programming tracking
Tags: String, Dynamic Programming, Stack
1) Initialize counters: bCount (count of 'b' seen) and deletions (minimum deletions needed).
2) Iterate through each character in the string.
3) If character is 'b', increment bCount (no deletion needed for 'b' at this position).
4) If character is 'a', we have two choices:
   - Delete this 'a' (cost = deletions + 1)
   - Delete all previous 'b's (cost = bCount)
   Choose the minimum of these two options.
5) Continue until all characters are processed.
6) Return the total minimum deletions needed.

Time Complexity: O(n) where n = s.length (single pass through string)
Space Complexity: O(1) (only using two integer variables)
Tip: The key insight is that at any position with 'a', we decide whether to delete this 'a' or all previous 'b's. We maintain the minimum deletions dynamically. A balanced string means all 'a's come before all 'b's.
Similar Problems: 926. Flip String to Monotone Increasing, 1525. Number of Good Ways to Split a String, 2116. Check if a Parentheses String Can Be Valid
*/
public class Solution {
    public int MinimumDeletions(string s) {
        int bCount = 0;                                             // Count of 'b' characters seen so far
        int deletions = 0;                                          // Minimum deletions needed up to current position

        foreach (char c in s) {                                     // Iterate through each character
            if (c == 'b') {                                         // If current character is 'b'
                bCount++;                                           // Increment 'b' count (no deletion needed)
            } else { // c == 'a'                                    // If current character is 'a'
                // Either delete this 'a' OR delete all previous 'b'
                deletions = Math.Min(deletions + 1, bCount);        // Choose minimum: delete 'a' vs delete all 'b's
            }
        }

        return deletions;                                           // Return minimum deletions to make string balanced
    }
}
