/*
Title: 1189. Maximum Number of Balloons
Solution: https://leetcode.com/problems/maximum-number-of-balloons/solutions/8351788/simplest-solution-c-time-on-space-o1-ple-ji5n/
Difficulty: Easy
Approach: Hash Table with character counting
Tags: String, Hash Table
1) Create a dictionary to count the frequency of each character in the text.
2) Count occurrences of each character by iterating through the text.
3) For the word "balloon", we need: b(1), a(1), l(2), o(2), n(1).
4) Return the minimum of: b_count, a_count, l_count/2, o_count/2, n_count.
5) The minimum value determines how many complete "balloon" words can be formed.

Time Complexity: O(n) where n = length of text (single pass to count characters)
Space Complexity: O(1) as we store at most 26 lowercase letters
Tip: The key insight is that to form "balloon", we need specific character counts. Since 'l' and 'o' appear twice in "balloon", we divide their counts by 2. The minimum among all counts determines the maximum number of complete words we can form.
Similar Problems: 383. Ransom Note, 387. First Unique Character in a String, 1784. Check if Binary String Has at Most One Segment of Ones
*/
public class Solution {
    public int MaxNumberOfBalloons(string text) {

        Dictionary<char, int> count = new Dictionary<char, int>();   // Dictionary to store character frequencies

        foreach (char c in text) {                                    // Iterate through each character in text
            count[c] = count.GetValueOrDefault(c, 0) + 1;            // Increment count for current character
        }

        return Math.Min(                                              // Find the limiting factor (minimum count)
            Math.Min(
                Math.Min(
                    count.GetValueOrDefault('b', 0),                 // Count of 'b' (needed 1 per balloon)
                    count.GetValueOrDefault('a', 0)                  // Count of 'a' (needed 1 per balloon)
                ),
                Math.Min(
                    count.GetValueOrDefault('l', 0) / 2,             // Count of 'l' divided by 2 (needed 2 per balloon)
                    count.GetValueOrDefault('o', 0) / 2              // Count of 'o' divided by 2 (needed 2 per balloon)
                )
            ),
            count.GetValueOrDefault('n', 0)                          // Count of 'n' (needed 1 per balloon)
        );
    }
}