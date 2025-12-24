/*
Solution: https://leetcode.com/problems/find-lucky-integer-in-an-array/solutions/7435555/simplest-solution-c-time-on-spacen-pleas-9p5f/
Difficulty: Easy
Approach: Hash Table for frequency counting
Tags: Array, Hash Table, Counting
1) Create a dictionary to count the occurrences of each number.
2) Iterate through array and populate the frequency map.
3) Initialize result as -1 (for case when no lucky number exists).
4) Iterate through the frequency map entries.
5) For each entry, check if the number equals its frequency (lucky condition).
6) If lucky number found, update result to the maximum lucky number.
7) Return the largest lucky number or -1 if none exists.

Time Complexity: O(n) where n = arr.length
Space Complexity: O(n) for the dictionary
*/
public class Solution {
    public int FindLucky(int[] arr) {
        Dictionary<int,int> map = new Dictionary<int,int>();        // Store number -> frequency mapping
        foreach(int num in arr) {                                   // Iterate through array elements
            map[num] = map.GetValueOrDefault(num,0) + 1;            // Count frequency of each number
        }
        int result = -1;                                            // Initialize result (default if no lucky number)
        foreach(var kv in map) {                                    // Iterate through frequency map
            if (kv.Key == kv.Value) {                               // If number equals its frequency (lucky)
                result = Math.Max(kv.Key, result);                  // Update result to largest lucky number
            }
        }

        return result;                                              // Return largest lucky number or -1
    }
}