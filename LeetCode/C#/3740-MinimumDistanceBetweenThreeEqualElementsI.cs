/*
Title: 3740. Minimum Distance Between Three Equal Elements I
Solution: https://leetcode.com/problems/minimum-distance-between-three-equal-elements-i/solutions/7857284/simplest-solution-c-time-on-space-on-ple-la4d/
Difficulty: Easy
Approach: Hash Map with Index Tracking
Tags: Array, Hash Table, Sliding Window
1) Create a dictionary to map each number to all its indices in the array.
2) Iterate through the array and build the index map for each unique number.
3) For each number that appears at least 3 times, check all possible triplets.
4) For each valid triplet (i, j, k), calculate distance as 2 * (k - i).
5) Track the minimum distance found across all valid triplets.
6) Return -1 if no valid triplet exists, otherwise return minimum distance.

Time Complexity: O(n) where n = nums.length (building map) + O(m) where m = total valid triplets
Space Complexity: O(n) for the hash map storing all indices
Tip: The key insight is that for three equal elements at indices i < j < k, the distance formula is 2 * (k - i). We only need to track indices and check consecutive triplets (indices at positions i, i+1, i+2 in our sorted list) to find the minimum.
Similar Problems: 1. Two Sum, 532. K-diff Pairs in an Array, 219. Contains Duplicate II
*/
using System;
using System.Collections.Generic;

public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int length = nums.Length;                                   // Store array length

        // Dictionary to store indices of each number
        // Key   -> number value
        // Value -> list of indices where that number appears
        Dictionary<int, List<int>> indexMap = new Dictionary<int, List<int>>();

        // Build the index map
        for (int idx = 0; idx < length; idx++)                      // Iterate through array with index
        {
            int value = nums[idx];                                  // Get current number value

            if (!indexMap.ContainsKey(value))                       // If number not yet in map
                indexMap[value] = new List<int>();                  // Initialize new list for this number

            indexMap[value].Add(idx);                               // Add current index to this number's list
        }

        int result = int.MaxValue;                                  // Initialize result with max value

        // Iterate over each group of same numbers
        foreach (var indexList in indexMap.Values)                  // For each unique number's index list
        {
            int count = indexList.Count;                            // Get count of occurrences

            // We need at least 3 occurrences to check distance
            for (int start = 0; start < count - 2; start++)         // Check all valid triplet starting positions
            {
                int leftIndex = indexList[start];                   // First element index in triplet
                int rightIndex = indexList[start + 2];              // Third element index in triplet (skip middle)

                // Distance calculation: 2 * (k - i) for indices i, j, k
                int distance = (rightIndex - leftIndex) * 2;        // Calculate distance between i and k, multiply by 2

                result = Math.Min(result, distance);                // Update minimum distance found
            }
        }

        // If no valid triplet found, return -1
        return result == int.MaxValue ? -1 : result;                // Return -1 if no triplet, otherwise minimum distance
    }
}