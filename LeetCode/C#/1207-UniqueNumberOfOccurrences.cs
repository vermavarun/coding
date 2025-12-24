/*
Solution: https://leetcode.com/problems/unique-number-of-occurrences/solutions/7435254/simplest-solution-c-time-on-spacen-pleas-x2b5/
Difficulty: Easy
Approach: Hash Table for counting + HashSet for uniqueness check
Tags: Array, Hash Table, HashSet
1) Create a dictionary to count the occurrences of each number.
2) Create a HashSet to track unique occurrence counts.
3) Iterate through array and populate the frequency map.
4) Iterate through the frequency map's values.
5) For each count, check if it already exists in the HashSet.
6) If duplicate count found, return false; otherwise add to HashSet.
7) If all counts are unique, return true.

Time Complexity: O(n) where n = arr.length
Space Complexity: O(n) for the dictionary and HashSet
*/
public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        Dictionary<int,int> map = new Dictionary<int,int>();        // Store number -> frequency mapping
        HashSet<int> hs = new HashSet<int>();                       // Track unique occurrence counts

        foreach(int num in arr) {                                   // Iterate through array elements
            if (!map.ContainsKey(num))                              // If number is new
                map[num]=1;                                         // Initialize count to 1
            else                                                    // If number already exists
                map[num]++;                                         // Increment its count
        }

        foreach(var kv in map) {                                    // Iterate through frequency map
            if(hs.Contains(kv.Value))                               // If this occurrence count already exists
                return false;                                       // Not unique, return false
            else                                                    // If occurrence count is new
                hs.Add(kv.Value);                                   // Add to HashSet
        }

        return true;                                                // All occurrence counts are unique
    }
}