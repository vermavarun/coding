/*
Title: 1888. Minimum Number of Flips to Make the Binary String Alternating
Solution: https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating/solutions/7632135/simplest-solution-c-time-on-space-on-ple-fzrp/
Difficulty: Medium
Approach: Sliding Window with String Concatenation
Tags: String, Sliding Window, Greedy
1) Store the original string length n.
2) Double the string (s + s) to simulate all possible Type-1 operations (rotations).
3) Use a sliding window of size n to traverse the doubled string.
4) For each character position, calculate expected characters for both alternating patterns (010101... and 101010...).
5) Count mismatches with both patterns in the current window.
6) As window slides, update mismatch counts by removing left character and adding right character.
7) Track the minimum flips needed across all window positions.
8) Return the minimum number of flips required.

Time Complexity: O(n) where n = length of string s
Space Complexity: O(n) for storing the doubled string
Tip: Key insight is that Type-1 operations (moving first char to end) can be simulated by doubling the string and using a sliding window. Type-2 operations (flipping bits) are represented by counting character mismatches with alternating patterns. By checking all rotations via the window, you find the optimal combination of both operation types.
Similar Problems: 926. Flip String to Monotone Increasing, 1529. Minimum Suffix Flips, 1540. Can Convert String in K Moves
*/
public class Solution {
    public int MinFlips(string s) {
        int n = s.Length;                                   // Store original string length
        string ss = s + s;                                  // Concatenate string with itself for rotation simulation

        int diff1 = 0;                                      // Count of flips to match pattern 010101...
        int diff2 = 0;                                      // Count of flips to match pattern 101010...

        int left = 0;                                       // Left pointer of sliding window
        int res = int.MaxValue;                             // Initialize result to maximum value

        for (int right = 0; right < ss.Length; right++) {   // Right pointer traverses doubled string

            char expected1 = (right % 2 == 0) ? '0' : '1';  // Calculate expected char for pattern 010101...
            char expected2 = (right % 2 == 0) ? '1' : '0';  // Calculate expected char for pattern 101010...

            if (ss[right] != expected1) diff1++;            // Increment if current char doesn't match pattern 1
            if (ss[right] != expected2) diff2++;            // Increment if current char doesn't match pattern 2

            // keep window size = n
            if (right - left + 1 > n) {                     // If window exceeds original string length

                char leftExpected1 = (left % 2 == 0) ? '0' : '1';  // Expected char at left for pattern 010101...
                char leftExpected2 = (left % 2 == 0) ? '1' : '0';  // Expected char at left for pattern 101010...

                if (ss[left] != leftExpected1) diff1--;     // Decrement diff1 if left char was a mismatch
                if (ss[left] != leftExpected2) diff2--;     // Decrement diff2 if left char was a mismatch

                left++;                                     // Move left pointer forward to maintain window size
            }

            if (right - left + 1 == n) {                    // When window size matches original length
                res = Math.Min(res, Math.Min(diff1, diff2)); // Update result with minimum flips needed
            }
        }

        return res;                                         // Return minimum flips required
    }
}