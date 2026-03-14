/*
Title: 761. Special Binary String
Solution: https://leetcode.com/problems/special-binary-string/solutions/7593685/simplest-solution-c-time-on-log-n-space-hd6jg/
Difficulty: Hard
Approach: Divide into primitive special substrings + recursion + descending sort
Tags: String, Recursion, Sorting
1) Scan the string and use a balance counter (+1 for '1', -1 for '0').
2) Whenever balance returns to 0, one primitive special substring is found.
3) Extract its inner part (without outer '1' and '0') and recursively maximize it.
4) Rebuild that piece as "1" + optimizedInner + "0" and store it.
5) Sort all primitive pieces in descending lexicographical order.
6) Concatenate sorted pieces to form the largest possible special string.

Time Complexity: O(n log n) on average due to sorting at each recursion level
Space Complexity: O(n) for recursion stack and substring storage
Tip: Any special string can be decomposed into independent primitive special blocks, so maximizing each block recursively and sorting blocks descending gives the global optimum.
Similar Problems: 394. Decode String, 856. Score of Parentheses
*/
public class Solution
{
    public string MakeLargestSpecial(string s)
    {
        List<string> specials = new List<string>();                // Stores primitive special substrings after recursive optimization
        int count = 0;                                             // Balance: +1 for '1', -1 for '0'
        int start = 0;                                             // Start index of current primitive special substring

        for (int i = 0; i < s.Length; i++)
        {
            // Increase count for '1', decrease for '0'
            count += (s[i] == '1') ? 1 : -1;

            // When count becomes 0, we found a primitive special substring
            if (count == 0)
            {
                // Get inner substring (excluding outer 1 and 0)
                string inner = s.Substring(start + 1, i - start - 1);

                // Recursively process inner part
                string processed = "1" + MakeLargestSpecial(inner) + "0";

                specials.Add(processed);                           // Save optimized primitive block

                start = i + 1;                                     // Move to next primitive block
            }
        }

        // Sort in descending order
        specials.Sort((a, b) => string.Compare(b, a));

        // Build final result by joining sorted blocks
        StringBuilder result = new StringBuilder();
        foreach (string str in specials)
        {
            result.Append(str);
        }

        return result.ToString();
    }
}