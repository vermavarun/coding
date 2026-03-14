/*
Title: 190. Reverse Bits
Solution: https://leetcode.com/problems/reverse-bits/solutions/7582942/simplest-solution-c-time-o1-space-o1-ple-m11t/
Difficulty: Easy
Approach: Bit Manipulation with Shift Operations
Tags: Bit Manipulation, Divide and Conquer
1) Initialize result to 0 to build the reversed bits.
2) Process all 32 bits (since it's a 32-bit integer).
3) For each iteration:
   - Left shift result by 1 to make room for the next bit.
   - Extract the rightmost bit from n using (n & 1).
   - Add extracted bit to result using OR operation (result | bit).
   - Right shift n by 1 to process the next bit.
4) After 32 iterations, result contains the reversed bits.
5) Return the reversed result.

Time Complexity: O(1) - always processes exactly 32 bits
Space Complexity: O(1) - only uses a few variables
Tip: Think of this as building a new number from right to left while consuming the input from left to right. Each iteration: (1) shift result left to make space, (2) extract rightmost bit of n with & 1, (3) add it to result with |, (4) shift n right. The key operations are << (left shift), >> (right shift), & (AND to extract bit), and | (OR to set bit).
Optimization: Instead of reversing all 32 bits every time, we can: (1) Split the number into 4 bytes (8 bits each), (2) Precompute reversed values for all 256 possible bytes in a lookup table, (3) Reassemble the answer using the lookup table. This is especially efficient when the function is called multiple times.
Similar Problems: 7. Reverse Integer, 191. Number of 1 Bits, 461. Hamming Distance, 693. Binary Number with Alternating Bits
*/

public class Solution {
    public int ReverseBits(int n) {
        int result = 0;                                        // Initialize result to build reversed bits
        int i = 0;                                             // Counter for 32 iterations
        while (i < 32) {                                       // Process all 32 bits
            result = result << 1;                              // Left shift result by 1 to make room for next bit
            result = result | (n & 1);                         // Extract rightmost bit of n and add to result
            n = n >> 1;                                        // Right shift n to process next bit
            i++;                                               // Increment counter
        }
        return result;                                         // Return reversed 32-bit integer
    }
}