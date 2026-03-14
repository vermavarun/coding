/*
Title: 2351. First Letter to Appear Twice
Solution: https://leetcode.com/problems/first-letter-to-appear-twice/solutions/7638163/simplest-solution-c-time-o1-space-o1-ple-nomo/
Difficulty: Easy
Approach: Frequency Array (Hash Set)
Tags: String, Hash Table, Counting
1) Create an integer array of size 26 to track character occurrences (a-z).
2) Iterate through each character in the string.
3) Convert character to array index using (c - 'a').
4) If the character count is already 1, it's appearing for the second time - return it.
5) Otherwise, increment the count for that character.
6) Return null character if no duplicate found (though problem guarantees a solution).

Time Complexity: O(1) - iterating through the string is O(n) but we only check 26 characters, so effectively O(1)
Space Complexity: O(1) - constant space of 26 for lowercase English letters
Tip: Using a fixed-size array instead of a HashSet is more efficient for lowercase letters since we know the exact range (a-z). The array index directly maps to each letter, providing O(1) lookup and update without hash function overhead.
Similar Problems: 387. First Unique Character in a String, 3. Longest Substring Without Repeating Characters, 217. Contains Duplicate
*/
public class Solution {
    public char RepeatedCharacter(string s) {
        int[] set = new int[26];                        // Array to track character frequencies (a-z)
        foreach(char c in s) {                          // Iterate through each character in string
            if (set[c - 'a'] == 1)                      // If character already seen once (second occurrence)
                return c;                               // Return the repeated character
            set[c-'a']+=1;                              // Mark character as seen (increment count)
        }
        return '\0';                                    // Return null character (not expected per problem constraints)
    }
}