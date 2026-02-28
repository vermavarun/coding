/*
Title: 1680. Concatenation of Consecutive Binary Numbers
Solution: https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers/solutions/7615415/simplest-solution-c-time-on-space-o1-ple-aw0o/
Difficulty: Medium
Approach: Bit Manipulation with Modular Arithmetic
Tags: Math, Bit Manipulation, Simulation
1) Initialize result as 0 (long type to prevent overflow) and bitLength to track binary representation length.
2) Iterate from 1 to n, processing each number sequentially.
3) For each number i, check if it's a power of 2 using bit trick (i & (i-1)) == 0.
4) If i is a power of 2, increment bitLength (binary representation length increases).
5) Left shift result by bitLength to make space for new binary digits.
6) Add current number i to the shifted result and apply modulo operation.
7) Return final result cast to int.

Time Complexity: O(n) where n is the input number
Space Complexity: O(1) - only using constant extra space
Tip: The key insight is recognizing that you don't need to convert numbers to binary strings. Instead, use bit shifting to concatenate binary representations mathematically. Track the bit length efficiently by incrementing only at powers of 2 (when bit length increases), avoiding expensive log operations.
Similar Problems: 190. Reverse Bits, 191. Number of 1 Bits, 201. Bitwise AND of Numbers Range, 338. Counting Bits
*/
public class Solution {
    public int ConcatenatedBinary(int n) {

        const int MOD = 1000000007;                                 // Modulo constant as per problem requirement (10^9 + 7)

        long result = 0;                                            // Use long to prevent overflow during bit shifting

        int bitLength = 0;                                          // Tracks number of bits needed for current number's binary representation

        for (int i = 1; i <= n; i++) {                              // Iterate from 1 to n inclusive

            /*
             * If i is a power of 2, then its binary representation
             * increases in length.
             *
             * Example:
             * 1  -> 1       (1 bit)
             * 2  -> 10      (2 bits)  ← power of 2
             * 3  -> 11      (2 bits)
             * 4  -> 100     (3 bits)  ← power of 2
             * 5  -> 101     (3 bits)
             *
             * Trick to check power of 2:
             * A number is power of 2 if (i & (i - 1)) == 0
             */
            if ((i & (i - 1)) == 0) {                               // Check if i is a power of 2 using bitwise AND trick
                bitLength++;                                        // Increment bit length when power of 2 is reached
            }

            /*
             * To concatenate binary of i:
             *
             * Step 1: Left shift existing result by bitLength
             *         (makes space for new binary digits)
             *
             * Step 2: Add current number i
             *
             * Example:
             * Suppose result = binary(1,2) = "110"
             * Now i = 3 (binary "11", length = 2)
             *
             * result << 2  -> "11000"
             * + 3          -> "11011"
             */
            result = ((result << bitLength) + i) % MOD;             // Shift left by bitLength, add i, apply modulo
        }

        return (int)result;                                         // Cast back to int as problem expects int return type
    }
}