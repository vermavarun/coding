/*
Title: 696. Count Binary Substrings
Solution: https://leetcode.com/problems/count-binary-substrings/solutions/7590986/simplest-solution-c-time-on-space-o1-ple-ahtw/
Difficulty: Easy
Approach: Group consecutive characters and count valid adjacent pairs
Tags: String
1) Track the size of the previous group and current group of consecutive equal characters.
2) Start current group count as 1 (first character).
3) Traverse from index 1 and compare current char with previous char.
4) If same, expand current group.
5) If different, add min(previous group, current group) to result because that many valid substrings can be formed across the boundary.
6) Shift current group to previous group, and reset current group to 1.
7) After loop, add contribution from the final boundary.

Time Complexity: O(n) where n = s.Length
Space Complexity: O(1)
Tip: You do not need to generate substrings. Counting adjacent group sizes is enough because each valid substring must contain equal consecutive 0s and 1s.
Similar Problems: 003. Longest Substring Without Repeating Characters, 076. Minimum Window Substring
*/
public class Solution {
    public int CountBinarySubstrings(string s) {
        int result = 0;                                           // Total valid binary substrings

        int prevCount = 0;                                        // Size of previous consecutive group
        int currCount = 1;                                        // Size of current consecutive group

        for(int i = 1; i < s.Length; i++) {                       // Start from second character
            if(s[i] == s[i-1]) {                                  // Same character, extend current group
                currCount++;
            } else {                                              // Group boundary found
                result += Math.Min(prevCount, currCount);         // Add valid substrings from adjacent groups
                prevCount = currCount;                            // Current group becomes previous group
                currCount = 1;                                    // Reset current group count
            }
        }

        return result + Math.Min(prevCount, currCount);           // Add contribution from final group boundary
    }
}