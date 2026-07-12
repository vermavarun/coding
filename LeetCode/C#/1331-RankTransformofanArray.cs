/*
Title: 1331. Rank Transform of an Array
Solution: https://leetcode.com/problems/rank-transform-of-an-array/solutions/8392751/simplest-solution-c-time-on-logn-space-o-bv2s/
Difficulty: Easy
Approach: Sorting + Hash Table
Tags: Array, Hash Table, Sorting
1) Clone the original array and sort the copy.
2) Iterate through the sorted array, assigning ranks starting from 1.
3) Use a dictionary to map each unique value to its rank (skip duplicates).
4) Iterate through the original array and replace each element with its rank from the dictionary.
5) Return the modified array.

Time Complexity: O(n log n) due to sorting
Space Complexity: O(n) for the sorted copy and the hash table
Tip: Sorting first lets you assign ranks in order. Using a dictionary handles duplicate values naturally - only the first occurrence gets a new rank assigned.
Similar Problems: 852. Peak Index in a Mountain Array, 1030. Matrix Cells in Distance Order, 1337. The K Weakest Rows in a Matrix
*/
public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        int[] sortedArray = (int[])arr.Clone();                         // Clone to preserve original order
        Array.Sort(sortedArray);                                        // Sort the clone to determine rank order

        Dictionary<int, int> valueToRank = new Dictionary<int, int>(); // Map each unique value to its rank
        int currentRank = 1;                                            // Ranks start at 1

        foreach (int value in sortedArray)
        {
            if (!valueToRank.ContainsKey(value))                        // Skip duplicates - they share the same rank
            {
                valueToRank[value] = currentRank++;                     // Assign next rank and increment
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = valueToRank[arr[i]];                               // Replace each element with its rank
        }

        return arr;                                                     // Return the rank-transformed array
    }
}