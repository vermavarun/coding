/*
Solution: https://leetcode.com/problems/kth-distinct-string-in-an-array/solutions/6886598/simplest-solution-c-time-on-spacen-pleas-kfpg/
Difficulty: Medium
Approach: Using Dictionary
Tags: Array, Hash Table, String
1. Create a dictionary to count occurrences of each string in the array.
2. Iterate through the array and populate the dictionary with counts.
3. Iterate through the array again, checking the counts in the dictionary.
4. If the count is 1, increment an index counter.
5. If the index counter matches k, return the current string.
6. If no such string exists, return an empty string.

Time Complexity: O(n), where n is the length of the array.
Space Complexity: O(n), for the dictionary to store counts.
*/
public class Solution
{
    public string KthDistinct(string[] arr, int k)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>(); // Dictionary to store string counts
        int index = 0;                                                // Index to track the k-th distinct string

        foreach (string str in arr)                                   // Iterate through the array to count occurrences
        {
            if (!dict.ContainsKey(str))                               // If the string is not in the dictionary
            {
                dict[str] = 1;                                        // Add it with a count of 1
            }
            else                                                      // If the string is already in the dictionary
            {
                dict[str] = dict[str] + 1;                            // Increment its count
            }
        }

        foreach (string str in arr)                                   // Iterate through the array again
        {
            if (dict[str] > 1)                                        // Check if the count is greater than 1
            {
                continue;                                             // If it is, skip to the next string
            }
            else                                                      // If the string is already in the dictionary
            {
                index++;                                              // Increment the index counter
            }

            if (index == k) return str;                               // If the index matches k, return the current string
        }

        return "";                                                    // If no k-th distinct string is found, return an empty string
    }
}