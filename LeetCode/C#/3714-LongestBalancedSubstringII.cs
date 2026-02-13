/*
Title: 3714. Longest Balanced Substring II
Solution: https://leetcode.com/problems/longest-balanced-substring-ii/solutions/7575737/simplest-solution-c-time-on-log-n-space-d05zp/
Difficulty: Medium
Approach: Three Cases - Same Character, Two Characters, Three Characters
Tags: String, Hash Table, Prefix Sum
1) Case 1: Find longest substring where all characters are the same.
2) Case 2: Find longest substring with two distinct characters (a,b or a,c or b,c) appearing in equal count.
3) Case 3: Find longest substring with all three characters (a,b,c) appearing in equal count using difference pairs.
4) Use HashMap to track first occurrence of each (diff1, diff2) pair where diff1 = count(a)-count(b) and diff2 = count(a)-count(c).
5) Return maximum length among all three cases.

Time Complexity: O(n log n) where n is length of string
Space Complexity: O(n) for storing difference pairs in HashMap
Tip: The key insight is breaking the problem into three distinct cases: (1) all same characters, (2) two characters balanced, and (3) three characters balanced. For case 3, use prefix sums with difference pairs (ca-cb, ca-cc) as hash keys to track when the same relative differences occurred before, indicating a balanced substring.
Similar Problems: 1394. Find Lucky Integer in an Array, 1854. Maximum Population Year, 1876. Substrings of Size Three with Distinct Characters, 2957. Remove Adjacent Almost-Equal Characters
*/

public class Solution {
    // Helper class to store pair of differences for hashing
    private class Pair {
        public int d1, d2;                                          // d1 = count(a) - count(b), d2 = count(a) - count(c)

        public Pair(int d1, int d2) {
            this.d1 = d1;
            this.d2 = d2;
        }

        public override bool Equals(object obj) {                   // Override Equals for HashMap key comparison
            if (obj == null || !(obj is Pair)) return false;
            Pair p = (Pair)obj;
            return d1 == p.d1 && d2 == p.d2;
        }

        public override int GetHashCode() {                         // Override GetHashCode for HashMap key hashing
            return 31 * d1 + d2;
        }
    }

    public int LongestBalanced(string s) {
        char[] c = s.ToCharArray();                                 // Convert string to char array for easier indexing
        int n = c.Length;                                           // Length of string
        int res = 0;                                                // Result to store maximum length

        // Case-1: All characters are the same
        int cur = 1;                                                // Current consecutive count

        for (int i = 1; i < n; i++) {                               // Iterate through string
            if (c[i] == c[i - 1]) {                                 // If current char equals previous char
                cur++;                                              // Increment consecutive count
            } else {
                res = Math.Max(res, cur);                           // Update result with current count
                cur = 1;                                            // Reset count for new sequence
            }
        }
        res = Math.Max(res, cur);                                   // Update result with last sequence

        // Case-2: Two different characters with equal count
        res = Math.Max(res, Find2(c, 'a', 'b'));                    // Find longest balanced substring with 'a' and 'b'
        res = Math.Max(res, Find2(c, 'a', 'c'));                    // Find longest balanced substring with 'a' and 'c'
        res = Math.Max(res, Find2(c, 'b', 'c'));                    // Find longest balanced substring with 'b' and 'c'

        // Case-3: All three characters with equal count
        int ca = 0, cb = 0, cc = 0;                                 // Counters for 'a', 'b', 'c'

        Dictionary<Pair, int> mp = new Dictionary<Pair, int>();     // Map to store first occurrence of difference pairs

        for (int i = 0; i < n; i++) {                               // Iterate through string
            if (c[i] == 'a') ca++;                                  // Increment 'a' counter
            else if (c[i] == 'b') cb++;                             // Increment 'b' counter
            else cc++;                                              // Increment 'c' counter

            if (ca == cb && ca == cc)                               // If all three counts are equal
                res = Math.Max(res, ca + cb + cc);                  // Update result with total count

            Pair key = new Pair(ca - cb, ca - cc);                  // Create key with differences

            if (mp.ContainsKey(key)) {                              // If this difference pair seen before
                res = Math.Max(res, i - mp[key]);                   // Update result with length from first occurrence
            } else {
                mp[key] = i;                                        // Store first occurrence of this difference pair
            }
        }

        return res;                                                 // Return maximum length found
    }

    // Helper method to find longest substring with two specific characters appearing in equal count
    private int Find2(char[] c, char x, char y) {
        int n = c.Length;                                           // Length of array
        int max_len = 0;                                            // Maximum length found

        int[] first = new int[2 * n + 1];                           // Array to store first occurrence of each difference
        Array.Fill(first, -2);                                      // Initialize with -2 (not seen yet)

        int clear_idx = -1;                                         // Index where sequence was reset (third char found)
        int diff = n;                                               // Difference offset (starts at n for positive indexing)

        first[diff] = -1;                                           // Base case: difference 0 at index -1

        for (int i = 0; i < n; i++) {                               // Iterate through array
            if (c[i] != x && c[i] != y) {                           // If character is neither x nor y
                clear_idx = i;                                      // Reset sequence at this index
                diff = n;                                           // Reset difference to base
                first[diff] = clear_idx;                            // Mark reset position
            } else {
                if (c[i] == x) diff++;                              // Increment difference for character x
                else diff--;                                        // Decrement difference for character y

                if (first[diff] < clear_idx) {                      // If this difference not seen after last reset
                    first[diff] = i;                                // Mark first occurrence of this difference
                } else {
                    max_len = Math.Max(max_len, i - first[diff]);   // Update max length with current span
                }
            }
        }

        return max_len;                                             // Return maximum length found
    }
}