/*
 *
Title: 191. Number of 1 Bits
Solution: hhttps://leetcode.com/problems/number-of-1-bits/solutions/7511992/simplest-solution-c-time-on-space-o1-ple-m1oa/
Difficulty: Easy
 * Approach: Bit Shifting and Masking
Tags: Bit Manipulation
 * 1. Initialize a counter to track the number of 1 bits.
 * 2. Iterate through all 32 bits of the integer.
 * 3. For each bit position, right shift n by i positions and AND with 1.
 * 4. If the result is 1, increment the counter.
 * 5. Return the total count of 1 bits.

 * Time Complexity: O(1) - Always 32 iterations
 * Space Complexity: O(1)
*/
class Solution {
    public int hammingWeight(int n) {
        int ans = 0;                                                    // Counter for number of 1 bits
        for(int i=0; i<32; i++) {                                       // Iterate through all 32 bits of the integer
            if (((n >> i) & 1) == 1)                                    // Right shift n by i positions and check if bit is 1
                ans++;                                                  // Increment counter if bit is 1
        }
        return ans;                                                     // Return total count of 1 bits
    }
}