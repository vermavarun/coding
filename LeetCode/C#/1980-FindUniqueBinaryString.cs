/*
Title: 1980. Find Unique Binary String
Solution: https://leetcode.com/problems/find-unique-binary-string/solutions/7633872/simplest-solution-c-time-on-space-o1-ple-lj0c/
Difficulty: Medium
Approach: Cantor's Diagonal Argument
Tags: Array, String, Backtracking, Math
1) Initialize an index counter to 0.
2) Create a StringBuilder to build the result string.
3) For each string in the input array nums:
   - Look at the character at position [index] in that string.
   - Flip that character (if '1' make it '0', if '0' make it '1').
   - Append the flipped character to the result.
   - Increment the index.
4) Return the constructed string.

Time Complexity: O(n) where n = length of nums array
Space Complexity: O(n) for the StringBuilder result
Tip: This uses Cantor's diagonal argument - by flipping the i-th character of the i-th string, the result is guaranteed to differ from each string at at least one position. This elegant solution avoids checking all 2^n possible binary strings.
Similar Problems: 268. Missing Number, 287. Find the Duplicate Number, 645. Set Mismatch, 41. First Missing Positive
*/
public class Solution {
    public string FindDifferentBinaryString(string[] nums) {
        int index = 0;                                      // Track current position for diagonal traversal
        StringBuilder sb = new StringBuilder();             // Build the result string efficiently
        foreach(string num in nums) {                       // Iterate through each binary string in array
            sb.Append(num[index] == '1' ? '0' : '1');      // Flip character at diagonal position and append
            index++;                                        // Move to next diagonal position
        }
        return sb.ToString();                               // Return the unique binary string
    }
}