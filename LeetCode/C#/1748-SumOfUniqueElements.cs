/*
Solution: https://leetcode.com/problems/sum-of-unique-elements/solutions/7437988/simplest-solution-c-time-on-spacen-pleas-469o/
Difficulty: Easy
Approach: Hash Table for frequency counting
Tags: Array, Hash Table, Counting
1) Create a dictionary to count occurrences of each number.
2) Initialize sum variable to accumulate unique element values.
3) Iterate through array and populate the frequency map.
4) For each number, get its current count (default 0) and increment by 1.
5) Iterate through the frequency map entries.
6) For each entry with count exactly 1, add the number to sum.
7) Return the total sum of all unique elements.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the dictionary
*/
public class Solution {
    public int SumOfUnique(int[] nums) {
        Dictionary<int,int> map = new Dictionary<int,int>();        // Store number -> frequency mapping
        int sum = 0;                                                // Accumulate sum of unique elements
        foreach(int num in nums) {                                  // Iterate through array elements
            map[num] = map.GetValueOrDefault(num,0) + 1;            // Count frequency of each number
        }
        foreach (var kv in map) {                                   // Iterate through frequency map
            sum += kv.Value == 1 ? kv.Key : 0;                      // Add number to sum if appears exactly once
        }
        return sum;                                                 // Return total sum of unique elements
    }
}