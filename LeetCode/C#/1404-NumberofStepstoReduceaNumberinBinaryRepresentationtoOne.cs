/*
Title: 1404. Number of Steps to Reduce a Number in Binary Representation to One
Solution: https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/solutions/7610535/simplest-solution-c-time-on-space-o1-ple-1aio/
Difficulty: Medium
Approach: Binary Simulation with Carry Propagation
Tags: String, Bit Manipulation
1) Initialize steps counter and carry flag to track binary addition overflow.
2) Traverse the binary string from right to left (LSB to MSB), stopping before the first bit.
3) For each bit, calculate effective value as (bit + carry).
4) If effective value is 1 (odd number): add 1 (which creates carry) then divide by 2 → requires 2 steps.
5) If effective value is 0 or 2 (even number): just divide by 2 → requires 1 step.
6) When effective value is 2, it means we have a carry that propagates to the next bit.
7) After processing all bits, if carry remains, we need one additional step to handle the overflow.
8) Return total steps count.

Time Complexity: O(n) where n = s.length
Space Complexity: O(1) constant space, only using two variables
Tip: The key insight is that you don't need to actually modify the string or convert to integer. Simulate the operations in binary: odd numbers (bit=1) require add+divide (2 steps), even numbers (bit=0) require just divide (1 step). Track carry for add operations since adding 1 to an odd binary number creates a carry that affects the next bit.
Similar Problems: 231. Power of Two, 342. Power of Four, 191. Number of 1 Bits, 67. Add Binary
*/
public class Solution {
    public int NumSteps(string s) {
        int steps = 0;                                          // Counter for total steps needed
        int carry = 0;                                          // Flag to track carry from addition operation

        // Traverse from last bit to second bit (skip first bit as it's always 1)
        for (int i = s.Length - 1; i > 0; i--) {
            int bit = s[i] - '0';                               // Convert char to int (0 or 1)

            if (bit + carry == 1) {                             // If effective bit is 1 (odd number)
                // odd → add 1 (carry becomes 1), then divide
                steps += 2;                                     // Need 2 steps: add 1, then divide by 2
                carry = 1;                                      // Adding 1 to odd creates carry
            } else {                                            // If effective bit is 0 or 2 (even number)
                // even → just divide
                steps += 1;                                     // Need 1 step: divide by 2
            }
        }

        // If carry remains after processing MSB
        return steps + carry;                                   // Add final carry if it exists (means we need one more step)
    }
}