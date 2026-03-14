/*
Title: 1758. Minimum Changes To Make Alternating Binary String
Solution: https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/solutions/7626305/simplest-solution-c-time-on-space-o1-ple-6glr/
Difficulty: Easy
Approach: Count mismatches for both possible alternating patterns
Tags: String, Greedy
1) An alternating binary string can start with either '0' or '1'.
2) Initialize two counters: one for pattern starting with '0' (010101...) and one for pattern starting with '1' (101010...).
3) Iterate through each character in the string.
4) For each position, determine the expected character for both patterns:
   - Pattern starting with '0': even indices have '0', odd indices have '1'
   - Pattern starting with '1': even indices have '1', odd indices have '0'
5) Count mismatches for each pattern separately.
6) Return the minimum of the two counts - this is the minimum operations needed.

Time Complexity: O(n) where n = s.length - single pass through the string
Space Complexity: O(1) - only using two counter variables
Tip: The key insight is that there are only two possible valid alternating patterns. Count mismatches for both and take the minimum - this greedy approach gives the optimal solution in one pass.
Similar Problems: 926. Flip String to Monotone Increasing, 1785. Minimum Elements to Add to Form a Given Sum, 2124. Check if All A's Appears Before All B's
*/
public class Solution {
    public int MinOperations(string s) {

        int startWith0 = 0;                                 // Counter for changes needed if pattern starts with '0' (010101...)
        int startWith1 = 0;                                 // Counter for changes needed if pattern starts with '1' (101010...)

        for (int i = 0; i < s.Length; i++) {                // Iterate through each character in string

            // Determine expected characters for both patterns at current position
            char expected0 = (i % 2 == 0) ? '0' : '1';      // Pattern 010101: even index = '0', odd index = '1'
            char expected1 = (i % 2 == 0) ? '1' : '0';      // Pattern 101010: even index = '1', odd index = '0'

            // Count mismatches for both patterns
            if (s[i] != expected0)                          // If current char doesn't match pattern starting with '0'
                startWith0++;                               // Increment count for pattern 010101...

            if (s[i] != expected1)                          // If current char doesn't match pattern starting with '1'
                startWith1++;                               // Increment count for pattern 101010...
        }

        // Return minimum operations needed
        return Math.Min(startWith0, startWith1);            // Return the smaller of the two counts
    }
}