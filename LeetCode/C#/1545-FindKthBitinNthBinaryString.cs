/*
Title: 1545. Find Kth Bit in Nth Binary String
Solution: https://leetcode.com/problems/find-kth-bit-in-nth-binary-string/solutions/7621790/simplest-solution-c-time-on-space-on-ple-09tf/
Difficulty: Medium
Approach: Recursion with Pattern Analysis
Tags: String, Recursion, Simulation
1) Understand the pattern: Sn = Sn-1 + "1" + reverse(invert(Sn-1))
2) Base case: S1 = "0", so if n == 1, return '0'
3) Calculate length of Sn using formula: 2^n - 1
4) Find middle position: (length / 2) + 1
5) If k equals middle position, return '1' (middle is always '1')
6) If k is in left half (k < mid), recursively find in Sn-1
7) If k is in right half (k > mid), mirror it to left half position
8) Find corresponding bit in left half and invert it ('0' -> '1' or '1' -> '0')

Time Complexity: O(n) where n is the recursion depth (maximum n levels)
Space Complexity: O(n) for the recursion call stack
Tip: The key insight is recognizing the recursive structure without generating the entire string. The middle is always '1', left half mirrors Sn-1, and right half is the inverted reverse of Sn-1. Use mirroring to map right positions to left.
Similar Problems: 779. K-th Symbol in Grammar, 1620. Coordinate With Maximum Network Quality, 894. All Possible Full Binary Trees
*/
public class Solution {
    public char FindKthBit(int n, int k) {

        // Base case:
        // S1 = "0"
        if (n == 1)                                                 // If we're at S1, it only contains '0'
            return '0';                                             // Return the base value

        // Length of Sn = 2^n - 1
        int length = (1 << n) - 1;                                  // Calculate length using bit shift: 2^n - 1

        // Middle index
        int mid = (length / 2) + 1;                                 // Find middle position (1-indexed)

        // Case 1: If k is middle element
        if (k == mid)                                               // Middle element is always '1' by construction
            return '1';                                             // Return '1' for middle position

        // Case 2: If k is in left half
        if (k < mid)                                                // If k is before middle, it's in Sn-1 part
            return FindKthBit(n - 1, k);                            // Recursively find in previous string

        // Case 3: If k is in right half
        // Mirror position in left half
        int mirroredIndex = length - k + 1;                         // Calculate mirrored position from right to left

        // Get value from left half
        char bit = FindKthBit(n - 1, mirroredIndex);                // Get the bit at mirrored position in Sn-1

        // Invert it
        return bit == '0' ? '1' : '0';                              // Invert the bit and return ('0' <-> '1')
    }
}