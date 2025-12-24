/*
Solution: https://leetcode.com/problems/find-all-duplicates-in-an-array/solutions/7436028/simplest-solution-c-time-on-spacen-pleas-15si/
Difficulty: Medium
Approach: Hash Table for frequency counting
Tags: Array, Hash Table
1) Create a dictionary to count occurrences of each number.
2) Create a list to store the duplicate numbers.
3) Iterate through array and populate the frequency map.
4) For each number, get its current count (default 0) and increment by 1.
5) Iterate through the frequency map entries.
6) For each entry with count exactly 2, add the number to result list.
7) Return the list of all duplicate numbers.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the dictionary and result list
*/
public class Solution {
    public IList<int> FindDuplicates(int[] nums) {

        Dictionary<int,int> map = new Dictionary<int,int>();        // Store number -> frequency mapping
        IList<int> result = new List<int>();                        // List to store duplicate numbers
        foreach(int num in nums) {                                  // Iterate through array elements
            map[num] = map.GetValueOrDefault(num,0) + 1;            // Count frequency of each number
        }

        foreach(var kv in map) {                                    // Iterate through frequency map
            if (kv.Value == 2) {                                    // If number appears exactly twice
                result.Add(kv.Key);                                 // Add to result list
            }
        }

        return result;                                              // Return list of duplicates

    }
}