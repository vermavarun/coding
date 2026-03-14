/*
Title: 1356. Sort Integers by The Number of 1 Bits
Solution: https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/solutions/7607250/simplest-solution-c-time-on-log-n-space-g6jd4/
Difficulty: Easy
Approach: LINQ with BitOperations.PopCount
Tags: Array, Bit Manipulation, Sorting
1) Use OrderBy to sort elements by their 1-bit count using BitOperations.PopCount.
2) Cast each element to uint before passing to PopCount (it requires unsigned int).
3) Use ThenBy to break ties by sorting elements by their value in ascending order.
4) Return the final sorted array.

Time Complexity: O(n log n) for sorting, where n = arr.length
Space Complexity: O(n) for the output array
Tip: BitOperations.PopCount counts the number of set bits (1s) in a binary representation. Chaining OrderBy + ThenBy cleanly expresses two-key sort criteria without a custom comparator.
Similar Problems: 191. Number of 1 Bits, 461. Hamming Distance, 693. Binary Number with Alternating Bits
*/
public class Solution {
    public int[] SortByBits(int[] arr) {
        return arr
            .OrderBy(x => BitOperations.PopCount((uint)x))     // Primary sort: ascending by number of 1 bits
            .ThenBy(x => x)                                     // Secondary sort: ascending by value for ties
            .ToArray();                                         // Materialise the sorted sequence into an array
    }
}