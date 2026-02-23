/*
Title: 1461. Check If a String Contains All Binary Codes of Size K
Solution: https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/solutions/7601455/simplest-solution-c-time-on-k-space-o2k-9uqur/
Difficulty: Medium
Approach: Sliding window with HashSet for unique substrings
Tags: Hash Table, String, Bit Manipulation, Sliding Window
1) Compute total required binary codes of length k as 2^k.
2) Iterate all substrings of length k using window start i.
3) Insert each substring into a hash set.
4) If set size reaches required count, return true early.
5) If loop finishes without reaching required count, return false.

Time Complexity: O((n - k + 1) * k) due to substring extraction
Space Complexity: O(min(2^k, n - k + 1) * k) for stored unique substrings
Tip: Early return is important: once the set size reaches 2^k, no further scanning is needed.
Similar Problems: 187. Repeated DNA Sequences, 3. Longest Substring Without Repeating Characters
*/
public class Solution {
    public bool HasAllCodes(string s, int k) {
        HashSet<string> hs = new HashSet<string>();               // Stores unique substrings of length k
        int maxSubStringsCount = (int)Math.Pow(2, k);             // Total binary strings possible: 2^k

        for (int i = 0; i <= s.Length - k; i++) {
            string subStr = s.Substring(i, k);                    // Current window substring of size k
            hs.Add(subStr);                                       // Add substring to set

            if (hs.Count == maxSubStringsCount)
                return true;                                      // All possible codes are present
        }

        return false;                                             // Not all binary codes were found
    }
}