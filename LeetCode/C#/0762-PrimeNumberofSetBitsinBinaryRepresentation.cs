/*
Title: 762. Prime Number of Set Bits in Binary Representation
Solution: https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/solutions/7596425/simplest-solution-c-time-on-space-o1-ple-pdpw/
Difficulty: Easy
Approach: Bit Count + Prime Set Lookup
Tags: Bit Manipulation, Math
1) Precompute possible prime set-bit counts in a hash set.
2) Iterate through each number from left to right.
3) Count set bits using BitOperations.PopCount.
4) If bit count is prime, increment result.
5) Return total count.

Time Complexity: O(n) where n = right - left + 1
Space Complexity: O(1) since prime set size is constant
Tip: For this range, the maximum set bits are small, so storing valid prime counts in a hash set gives clear and efficient membership checks.
Similar Problems: 191. Number of 1 Bits, 338. Counting Bits
*/
public class Solution {
    public int CountPrimeSetBits(int left, int right) {
        HashSet<int> primes = new HashSet<int>{2,3,5,7,11,13,17,19}; // Prime counts of set bits possible in constraints
        int result = 0;                                                // Count how many numbers have prime set-bit count

        for (int i = left; i <= right; i++) {                          // Iterate through all numbers in range
            int bitCount = BitOperations.PopCount((uint)i);            // Count number of 1s in binary representation
            if (primes.Contains(bitCount))                             // If set-bit count is prime
                result++;                                              // Increment valid count
        }

        return result;                                                 // Return total prime set-bit counts
    }
}