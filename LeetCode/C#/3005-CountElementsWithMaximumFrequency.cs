/*
Solution: https://leetcode.com/problems/count-elements-with-maximum-frequency/solutions/7438597/simplest-solution-c-time-on-spacen-pleas-t6vk/
Difficulty: Easy
Approach: Hash Table for frequency counting with max tracking
Tags: Array, Hash Table, Counting
1) Create a dictionary to count occurrences of each number.
2) Initialize variables to track sum and maximum frequency.
3) Iterate through array and populate the frequency map.
4) Find the maximum frequency by iterating through all counts.
5) Iterate through the frequency map again.
6) For each entry with count equal to max frequency, add count to sum.
7) Return the total count of elements with maximum frequency.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the dictionary
*/
public class Solution {
    public int MaxFrequencyElements(int[] nums) {

        Dictionary<int,int> map = new Dictionary<int,int>();        // Store number -> frequency mapping
        int sum = 0;                                                // Accumulate count of max frequency elements
        int maxFreq = 0;                                            // Track maximum frequency value

        foreach(int num in nums) {                                  // Iterate through array elements
            map[num] = map.GetValueOrDefault(num,0) + 1;            // Count frequency of each number
        }

        foreach(var kv in map) {                                    // Iterate through frequency map
            maxFreq = Math.Max(kv.Value,maxFreq);                   // Find maximum frequency
        }

        foreach(var kv in map) {                                    // Iterate through frequency map again
            sum += kv.Value== maxFreq ? kv.Value : 0;               // Add count if frequency equals max
        }

        return sum;                                                 // Return total count of max frequency elements
    }
}