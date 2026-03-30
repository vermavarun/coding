/*
Title: 2840. Check if Strings Can be Made Equal With Operations II
Solution: https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-ii/solutions/7719167/simplest-solution-c-time-on-space-o1-ple-bih5/
Difficulty: Medium
Approach: Frequency counting for even and odd indexed characters separately
Tags: String, Hash Table, Counting
1) Key insight: We can swap characters at positions that differ by exactly 2.
   - This means characters at even indices (0,2,4,6,...) can only swap among themselves
   - Characters at odd indices (1,3,5,7,...) can only swap among themselves
2) Create two frequency arrays: one for even indices, one for odd indices (size 26 for lowercase letters).
3) Iterate through both strings simultaneously:
   - For characters at even indices: increment count for s1 character, decrement for s2 character
   - For characters at odd indices: increment count for s1 character, decrement for s2 character
4) If both strings can be made equal through valid swaps, the frequency counts will balance to zero.
5) Verify all counts are zero in both frequency arrays.
6) If any count is non-zero, strings cannot be made equal (return false).

Time Complexity: O(n) where n = length of strings (one pass to count + 26 checks)
Space Complexity: O(1) - using fixed-size arrays of 26 elements (constant space)
Tip: The crucial insight is that even-indexed and odd-indexed positions form two independent groups. By tracking frequency differences (incrementing for s1, decrementing for s2), we can check if both strings have identical character sets at even positions and identical character sets at odd positions. If all differences are zero, the strings can be rearranged to match.
Similar Problems: 1247. Minimum Swaps to Make Strings Equal, 2839. Check if Strings Can be Made Equal With Operations I, 567. Permutation in String, 242. Valid Anagram
*/
public class Solution {
    public bool CheckStrings(string s1, string s2) {
        int[] evenCount = new int[26];                              // Frequency array for characters at even indices
        int[] oddCount = new int[26];                               // Frequency array for characters at odd indices

        for (int i = 0; i < s1.Length; i++) {                       // Iterate through both strings
            if (i % 2 == 0) {                                       // Check if current index is even
                evenCount[s1[i] - 'a']++;                           // Increment count for s1 character at even index
                evenCount[s2[i] - 'a']--;                           // Decrement count for s2 character at even index
            } else {                                                // Current index is odd
                oddCount[s1[i] - 'a']++;                            // Increment count for s1 character at odd index
                oddCount[s2[i] - 'a']--;                            // Decrement count for s2 character at odd index
            }
        }

        // If all counts are zero → valid
        for (int i = 0; i < 26; i++) {                              // Check all 26 possible characters
            if (evenCount[i] != 0 || oddCount[i] != 0)              // If any frequency difference is non-zero
                return false;                                       // Strings cannot be made equal
        }

        return true;                                                // All frequencies match - strings can be made equal
    }
}