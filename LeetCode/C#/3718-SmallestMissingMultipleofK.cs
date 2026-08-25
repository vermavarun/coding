/*
Title: 3718. Smallest Missing Multiple of K
Solution: https://leetcode.com/problems/smallest-missing-multiple-of-k/solutions/8481731/simplest-solution-c-time-on-space-on-ple-agcf/
Difficulty: Medium
Approach: Hash Set for O(1) lookup with linear iteration through multiples
Tags: Array, Hash Table, Math
1) Create a hash set from the input array for fast O(1) lookup.
2) Iterate through positive multiples of k starting from k itself.
3) For each multiple (k, 2k, 3k, ...), check if it exists in the hash set.
4) Return the first multiple that is NOT present in the hash set.
5) This is guaranteed to be the smallest missing multiple of k.

Time Complexity: O(n + m) where n = nums.length and m = smallest missing multiple position
Space Complexity: O(n) for the hash set storing input numbers
Tip: The key insight is that we only need to check multiples of k. By using a HashSet for O(1) lookup, we can efficiently find the first missing multiple without needing to iterate through all numbers. The answer is guaranteed to exist and will be found relatively quickly for reasonable inputs.
Similar Problems: 41. First Missing Positive, 268. Missing Number
*/
public class Solution {
    public int MissingMultiple(int[] nums, int k) {
        HashSet<int> numbers = new HashSet<int>(nums);              // Create hash set from array for O(1) lookup

        for (int i = 1; ; i++) {                                     // Iterate through positive integers
            int multiple = k * i;                                    // Calculate the multiple k*i (k, 2k, 3k, ...)

            if (!numbers.Contains(multiple))                         // If this multiple is NOT in the set
                return multiple;                                     // Return it as the smallest missing multiple
        }
    }
}