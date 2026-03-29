/*
Title: 2839. Check if Strings Can be Made Equal With Operations I
Solution: https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-i/solutions/7714157/simplest-solution-c-time-o1-space-o1-ple-x8p2/
Difficulty: Easy
Approach: Compare character pairs at swappable positions
Tags: String, Hash Table
1) Understand the constraint: we can only swap characters at positions that differ by exactly 2.
   - This means we can swap s[0] with s[2], or s[1] with s[3]
2) Key insight: We don't need to perform actual swaps. We just need to check if the same characters
   exist at the pairs of swappable positions in both strings (order doesn't matter within the pair).
3) Check if characters at positions 0 and 2 in s1 match characters at positions 0 and 2 in s2
   (in any order).
4) Check if characters at positions 1 and 3 in s1 match characters at positions 1 and 3 in s2
   (in any order).
5) Both pairs must match for strings to be made equal.

Time Complexity: O(1) - fixed number of comparisons for strings of length 4
Space Complexity: O(1) - only using constant extra space
Tip: The key insight is recognizing that swappable positions form independent pairs. Characters at indices 0 and 2 can only swap with each other, and characters at indices 1 and 3 can only swap with each other. So we just need to verify that each pair contains the same characters in both strings, regardless of order.
Similar Problems: 1247. Minimum Swaps to Make Strings Equal, 859. Buddy Strings, 1790. Check if One String Swap Can Make Strings Equal
*/
public class Solution {
    public bool CanBeEqual(string s1, string s2) {
        return EqualPair(s1[0], s1[2], s2[0], s2[2]) &&            // Check if even-indexed pair (0,2) matches in both strings
               EqualPair(s1[1], s1[3], s2[1], s2[3]);              // Check if odd-indexed pair (1,3) matches in both strings
    }

    private bool EqualPair(char a, char b, char c, char d) {
        return (a == c && b == d) || (a == d && b == c);           // Check if pair (a,b) equals (c,d) in either order
    }
}