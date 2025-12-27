/*
Solution: 
Difficulty: Medium
Approach:
Tags: String
1. Use two pointers i and j to iterate through the string.
2. Initialize i and j to 0.
3. Iterate through the string until j is less than the length of the string.
4. Find the word and reverse it.
5. Move i and j to the next word.
6. Return the reversed string.

Time Complexity: O(n)
Space Complexity: O(n)
*/

public class Solution
{
    public string ReverseWords(string s)
    {
        int i, j, sp;                                                             // Initialize two pointers i and j and a variable sp to store the space
        char t = '\0';                                                            // Initialize a temporary variable t
        StringBuilder sb = new StringBuilder(s, s.Length);                        // Initialize a string builder with the input string
        i = j = sp = 0;                                                           // Initialize i, j and sp to 0

        while (j < sb.Length && i < sb.Length)
        {                                                                         // Iterate through the string

            while (j < sb.Length && sb[j] != ' ')
            {                                                                     // Find the word
                j++;                                                              // Move j to the next character
            }
            sp = j;                                                               // Store the space
            j--;                                                                  // Move j to the last character of the word
            while (i < j && i < sb.Length && j > 0)
            {                                                                     // Reverse the word
                t = sb[i];                                                        // Swap the characters
                sb[i] = sb[j];                                                    // Swap the characters
                sb[j] = t;                                                        // Swap the characters
                i++;                                                              // Move i to the next character
                j--;                                                              // Move j to the previous character
            }
            i = sp + 1;                                                           // Move i to the next word
            j = sp + 1;                                                           // Move j to the next word

        }
        return sb.ToString();                                                     // Return the reversed string
    }
}