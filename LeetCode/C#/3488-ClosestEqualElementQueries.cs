/*
Title: 3488. Closest Equal Element Queries
Solution: https://leetcode.com/problems/closest-equal-element-queries/solutions/7945346/simplest-solution-c-time-on-qlogm-space-2t4p8/
Difficulty: Medium
Approach: Hash Map with Binary Search and Circular Distance
Tags: Array, Hash Table, Binary Search
1) Create a dictionary mapping each unique value to all its occurrence indices.
2) Iterate through the array and populate the dictionary with value -> list of indices.
3) For each query index:
   - Get the value at that index and find all occurrence indices.
   - If value appears only once, return -1 (no other occurrence exists).
   - Use binary search to find position of query index in occurrence list.
   - Check right neighbor (next occurrence in circular manner).
   - Check left neighbor (previous occurrence in circular manner).
   - For each neighbor, calculate both direct and circular distances.
   - Track the minimum distance among all calculations.
4) Return list of minimum distances for all queries.

Time Complexity: O(n + q*log(m)) where n = array length, q = queries, m = avg occurrences per value
Space Complexity: O(n) for the hash map storing all indices
Tip: The key insight is to precompute all occurrence positions for each value, then use binary search to quickly locate the query position and check only its immediate neighbors (left and right) in the circular occurrence list. Since occurrences are naturally sorted by index, this avoids checking every occurrence.
Similar Problems: 2515. Shortest Distance to Target String in a Circular Array, 1848. Minimum Distance to the Target Element, 1652. Defuse the Bomb
*/
using System;
using System.Collections.Generic;

public class Solution
{
    public IList<int> SolveQueries(int[] numbers, int[] queryIndices)
    {
        int arrayLength = numbers.Length;                           // Store total length of input array

        // Map each number to all its indices in the array
        Dictionary<int, List<int>> valueToIndicesMap = new Dictionary<int, List<int>>();    // Dictionary to store value -> indices mapping

        for (int index = 0; index < arrayLength; index++)           // Iterate through entire array
        {
            if (!valueToIndicesMap.ContainsKey(numbers[index]))     // Check if value is new
            {
                valueToIndicesMap[numbers[index]] = new List<int>();    // Create new list for this value
            }

            valueToIndicesMap[numbers[index]].Add(index);           // Add current index to value's occurrence list
        }

        List<int> results = new List<int>();                        // List to store results for all queries

        // Process each query
        foreach (int queryIndex in queryIndices)                    // Iterate through each query index
        {
            int currentValue = numbers[queryIndex];                 // Get value at query index
            List<int> occurrenceIndices = valueToIndicesMap[currentValue];  // Get all indices where this value appears

            int occurrenceCount = occurrenceIndices.Count;          // Count total occurrences

            // If the value appears only once, no valid answer
            if (occurrenceCount == 1)                               // Check if only one occurrence exists
            {
                results.Add(-1);                                    // Add -1 for no other occurrence
                continue;                                           // Skip to next query
            }

            // Find the position of queryIndex in the sorted occurrence list
            int positionInList = occurrenceIndices.BinarySearch(queryIndex);    // Binary search to find position

            int minimumDistance = int.MaxValue;                     // Initialize minimum distance to max value

            // -------- Right Neighbor --------
            int rightNeighborIndex = occurrenceIndices[(positionInList + 1) % occurrenceCount]; // Get next occurrence (circular)

            int directDistance = Math.Abs(queryIndex - rightNeighborIndex);     // Calculate direct distance
            int circularDistance = arrayLength - directDistance;                 // Calculate circular distance

            minimumDistance = Math.Min(minimumDistance, Math.Min(directDistance, circularDistance));    // Update minimum with right neighbor

            // -------- Left Neighbor --------
            int leftNeighborIndex = occurrenceIndices[(positionInList - 1 + occurrenceCount) % occurrenceCount];  // Get previous occurrence (circular)

            directDistance = Math.Abs(queryIndex - leftNeighborIndex);          // Calculate direct distance
            circularDistance = arrayLength - directDistance;                     // Calculate circular distance

            minimumDistance = Math.Min(minimumDistance, Math.Min(directDistance, circularDistance));    // Update minimum with left neighbor

            results.Add(minimumDistance);                           // Add minimum distance to results
        }

        return results;                                             // Return list of all query results
    }
}