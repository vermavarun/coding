/*
Title: 3653. XOR After Range Multiplication Queries I
Solution: https://leetcode.com/problems/xor-after-range-multiplication-queries-i/solutions/7830560/simplest-solution-c-time-oq-n-space-o1-p-gc37/
Difficulty: Medium
Approach: Sequential query processing with range multiplication and final XOR computation
Tags: Array, Bit Manipulation, Math, Simulation
1) Initialize modulo constant (10^9 + 7) for preventing integer overflow.
2) Process each query sequentially:
   - Extract query parameters: left boundary, right boundary, step size, multiplier
   - Iterate through array from left to right with given step size
   - Multiply each selected element by the multiplier (with modulo)
3) After all queries are processed, compute XOR of all array elements.
4) Initialize XOR result to 0 (identity element for XOR).
5) XOR each element in the modified array to get final result.
6) Return the XOR result.

Time Complexity: O(Q * N) where Q = number of queries, N = array length (worst case all elements affected per query)
Space Complexity: O(1) - modifying array in-place, only using constant extra space
Tip: The key is to process queries sequentially since each query modifies the array and affects subsequent operations. Use modulo arithmetic to prevent overflow when multiplying. XOR has useful properties: x ^ 0 = x (identity), x ^ x = 0 (self-inverse), and it's commutative and associative, so order doesn't matter in final XOR computation.
Similar Problems: 1310. XOR Queries of a Subarray, 1738. Find Kth Largest XOR Coordinate Value, 2433. Find The Original Array of Prefix Xor, 1829. Maximum XOR for Each Query
*/
public class Solution {
    public int XorAfterQueries(int[] numbers, int[][] queries) {
        int MOD = (int)1e9 + 7;                                     // Modulo constant to prevent overflow (10^9 + 7)

        foreach (var q in queries) {                                // Process each query sequentially
            int left = q[0];                                        // Left boundary of range (inclusive)
            int right = q[1];                                       // Right boundary of range (inclusive)
            int step = q[2];                                        // Step size for iteration within range
            int multiplier = q[3];                                  // Multiplier to apply to selected elements

            for (int i = left; i <= right; i += step) {             // Iterate from left to right with given step
                numbers[i] = (int)((1L * numbers[i] * multiplier) % MOD);  // Multiply element by multiplier with modulo (use long to avoid overflow)
            }
        }

        int xorResult = 0;                                          // Initialize XOR result (0 is identity for XOR)

        foreach (int val in numbers) {                              // Iterate through all modified array elements
            xorResult ^= val;                                       // XOR current element with accumulated result
        }

        return xorResult;                                           // Return final XOR of all elements
    }
}