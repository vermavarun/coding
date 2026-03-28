/*
Title: 2573. Find the String With LCP
Solution: https://leetcode.com/problems/find-the-string-with-lcp/solutions/7709895/simplest-solution-c-time-on2-space1-plea-cr8b/
Difficulty: Hard
Approach: Greedy construction with validation - build string character by character by reusing characters where valid and assigning smallest available character otherwise, then verify using LCP matrix properties.
Tags: String, Array, Matrix
1) Initialize character array with placeholder '$'.
2) For each position, try to reuse a character from earlier positions that have non-zero LCP (meaning they share a common prefix).
3) If no reusable character, find the smallest available character that doesn't violate LCP constraints (positions with 0 LCP must have different characters).
4) Build the forbidden set by checking positions with 0 LCP values and marking their characters as forbidden.
5) Assign the smallest unused character from 'a' to 'z'.
6) Validate the constructed string against the LCP matrix using the CheckLCP function.
7) LCP[i][j] consistency rules: if word[i] == word[j], then LCP[i][j] should equal 1 + LCP[i+1][j+1] (recursive property).
8) If word[i] != word[j], then LCP[i][j] must be 0 (no common prefix).

Time Complexity: O(n²) for constructing the string and O(n²) for validation = O(n²) overall
Space Complexity: O(n) for the word array and O(26) = O(1) for forbidden character tracking
Tip: The key insight is that the LCP matrix has strict properties - use these to guide character assignment and validate correctness. If construction would require more than 26 characters, return empty string.
Similar Problems: 28. Find the Index of the First Occurrence in a String, 1316. Distinct Echo Substrings
*/
public class Solution
{
    private bool CheckLCP(string word, int[][] lcp)
    {
        int n = word.Length;

        // Validate last column - each character against last character
        for (int i = 0; i < n; i++)
        {
            if (word[i] != word[n - 1])                             // If characters differ
            {
                if (lcp[i][n - 1] != 0) return false;               // LCP must be 0
            }
            else                                                    // If characters match
            {
                if (lcp[i][n - 1] != 1) return false;               // LCP must be 1 (same start)
            }
        }

        // Validate last row - last character against all previous positions
        for (int j = 0; j < n; j++)
        {
            if (word[n - 1] != word[j])                             // If characters differ
            {
                if (lcp[n - 1][j] != 0) return false;               // LCP must be 0
            }
            else                                                    // If characters match
            {
                if (lcp[n - 1][j] != 1) return false;               // LCP must be 1 (same start)
            }
        }

        // Validate remaining cells - use recursive LCP property
        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = n - 2; j >= 0; j--)
            {
                if (word[i] == word[j])                             // If characters match
                {
                    // If chars match at i,j they share 1 more char than i+1,j+1
                    if (lcp[i][j] != 1 + lcp[i + 1][j + 1]) return false;
                }
                else                                                // If characters differ
                {
                    if (lcp[i][j] != 0) return false;               // LCP must be 0 (no common prefix)
                }
            }
        }

        return true;
    }

    public string FindTheString(int[][] lcp)
    {
        int n = lcp.Length;

        char[] word = new char[n];                                  // Array to store constructed string
        Array.Fill(word, '$');                                      // Initialize with placeholder

        // Build string greedily, position by position
        for (int i = 0; i < n; i++)
        {
            // Try to reuse character from previous positions where LCP > 0
            for (int j = 0; j < i; j++)
            {
                if (lcp[j][i] != 0)                                 // If LCP[j][i] > 0, chars must match
                {
                    word[i] = word[j];                              // Reuse same character
                    break;                                          // Found a valid character, break
                }
            }

            // If no character reused, assign smallest valid character
            if (word[i] == '$')
            {
                bool[] forbidden = new bool[26];                    // Track forbidden characters (a-z)

                // Mark characters of positions with LCP[j][i] == 0 as forbidden
                for (int j = 0; j < i; j++)
                {
                    if (lcp[j][i] == 0 && word[j] != '$')           // If LCP is 0, chars must differ
                    {
                        forbidden[word[j] - 'a'] = true;            // Block this character
                    }
                }

                // Find smallest available character
                for (int k = 0; k < 26; k++)
                {
                    if (!forbidden[k])                              // If character not forbidden
                    {
                        word[i] = (char)('a' + k);                  // Assign this character
                        break;                                      // Use first available
                    }
                }

                if (word[i] == '$') return "";                      // More than 26 chars needed - impossible
            }
        }

        string result = new string(word);                           // Convert character array to string

        // Validate constructed string matches the LCP matrix
        return CheckLCP(result, lcp) ? result : "";
    }
}