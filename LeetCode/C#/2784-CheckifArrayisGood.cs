/*
Title: 2784. Check if Array is Good
Solution: https://leetcode.com/problems/check-if-array-is-good/solutions/8219718/simplest-solution-c-time-on-space-on-ple-idwy/
Difficulty: Easy
Approach: Frequency Counting Array
Tags: Array, Hash Table, Counting
1) Calculate the expected maximum value which should be n-1 (where n is array length).
2) Create a frequency array of size n+1 to count occurrences of each number.
3) Iterate through the input array and validate each number is in valid range [1, n-1].
4) Count the frequency of each number in the frequency array.
5) Verify that all numbers from 1 to n-2 appear exactly once.
6) Verify that the number n-1 appears exactly twice.
7) A "good" array follows the pattern: [1, 2, 3, ..., n-1, n-1] where n-1 appears twice.

Time Complexity: O(n) where n = nums.length (single pass to count + single pass to verify)
Space Complexity: O(n) for the frequency array
Tip: A "good" array is defined as [base[n], n] where base[n] = [1, 2, 3, ..., n] and the array has n+1 elements. This means all numbers from 1 to n appear, with n appearing twice. Use frequency counting to validate this pattern efficiently.
Similar Problems: 217. Contains Duplicate, 41. First Missing Positive, 442. Find All Duplicates in an Array, 448. Find All Numbers Disappeared in an Array
*/
public class Solution
{
    public bool IsGood(int[] nums)
    {
        int n = nums.Length;                                    // Get the length of input array
        int expectedMax = n - 1;                                // Calculate expected max value (n-1)

        int[] frequency = new int[n + 1];                       // Create frequency array with size n+1

        foreach (int num in nums)                               // Iterate through each number in input array
        {
            // Values must be between 1 and n - 1
            if (num < 1 || num > expectedMax)                   // Validate number is in valid range [1, n-1]
                return false;                                   // Return false if out of range

            frequency[num]++;                                   // Increment frequency count for this number
        }

        // Numbers 1 to n-2 must appear exactly once
        for (int value = 1; value < expectedMax; value++)       // Check all numbers from 1 to n-2
        {
            if (frequency[value] != 1)                          // Each must appear exactly once
                return false;                                   // Return false if not exactly once
        }

        // Number n-1 must appear exactly twice
        return frequency[expectedMax] == 2;                     // Return true only if n-1 appears exactly twice
    }
}