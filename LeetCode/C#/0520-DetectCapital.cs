/*
Title: 520. Detect Capital
Solution: https://leetcode.com/problems/detect-capital/solutions/8296670/simplest-solution-c-time-on-space-o1-ple-oyb7/
Difficulty: Easy
Approach: Count uppercase and lowercase letters, check valid capital usage patterns
Tags: String, Simulation
1) Count total uppercase and lowercase letters in the word.
2) Check three valid cases:
   - All letters are uppercase (e.g., "USA")
   - All letters are lowercase (e.g., "leetcode")
   - Only the first letter is uppercase and the rest are lowercase (e.g., "Google")
3) Return true if any of the above cases is satisfied.

Time Complexity: O(n) where n = word.Length
Space Complexity: O(1)
Tip: The key is to check all three valid capital usage patterns efficiently in a single pass.
Similar Problems: 925. Long Pressed Name, 205. Isomorphic Strings
*/
public class Solution {
    public bool DetectCapitalUse(string word) {
        bool firstCapital = char.IsUpper(word[0]); // Check if first letter is uppercase
        int totalCapital = 0; // Count of uppercase letters
        int totalLower = 0;   // Count of lowercase letters

        // Count uppercase and lowercase letters
        foreach(char c in word) {
            if (char.IsLower(c)) {
                totalLower++;
            }
            else {
                totalCapital++;
            }
        }

        // Valid if all uppercase, all lowercase, or only first is uppercase
        return (totalCapital == word.Length) || (totalCapital == 0) || (firstCapital && totalLower == word.Length - 1);
    }
}