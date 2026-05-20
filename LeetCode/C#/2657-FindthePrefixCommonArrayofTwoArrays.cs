/*
Title: 2657. Find the Prefix Common Array of Two Arrays
Solution: https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays/solutions/8281513/simplest-solution-c-time-on-space-on-ple-2gja/
Difficulty: Medium
Approach: Frequency Map / Hash Table
Tags: Array, Hash Table, Bit Manipulation
1) Iterate through both arrays simultaneously at each index i.
2) Maintain a frequency map counting how many times each value has appeared across both arrays.
3) When a value's count reaches 2, it has appeared in both prefixes — increment the common count.
4) Store the running common count in the result array at each index.

Time Complexity: O(n) where n = length of the arrays
Space Complexity: O(n) for the frequency map
Tip: The key insight is that since both arrays are permutations of [1..n], each value appears exactly once per array. So a frequency count of 2 means the value has been seen in BOTH arrays up to index i.
Similar Problems: 2215. Find the Difference of Two Arrays, 349. Intersection of Two Arrays, 1. Two Sum
*/

public class Solution
{
    public int[] FindThePrefixCommonArray(int[] firstArray, int[] secondArray)
    {
        int length = firstArray.Length;

        // Result array where result[i] = number of common elements
        // in prefixes firstArray[0..i] and secondArray[0..i]
        int[] prefixCommonCount = new int[length];

        // Dictionary to track how many times a number has appeared
        // across both arrays so far
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        // Tracks how many numbers have appeared in BOTH arrays (i.e., count == 2)
        int commonElementsCount = 0;

        for (int index = 0; index < length; index++)
        {
            int valueFromFirst = firstArray[index];
            int valueFromSecond = secondArray[index];

            // ---- Process value from first array ----
            frequencyMap[valueFromFirst] = frequencyMap.GetValueOrDefault(valueFromFirst, 0) + 1;

            // If this value has now appeared twice, it means
            // it has been seen in both arrays
            if (frequencyMap[valueFromFirst] == 2)
            {
                commonElementsCount++;
            }

            // ---- Process value from second array ----
            frequencyMap[valueFromSecond] = frequencyMap.GetValueOrDefault(valueFromSecond, 0) + 1;

            // Same logic for second array value
            if (frequencyMap[valueFromSecond] == 2)
            {
                commonElementsCount++;
            }

            // Store the current count of common elements for this prefix
            prefixCommonCount[index] = commonElementsCount;
        }

        return prefixCommonCount;
    }
}