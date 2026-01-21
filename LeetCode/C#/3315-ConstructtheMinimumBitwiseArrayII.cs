/*
Title: 3315. Construct the Minimum Bitwise Array II
Solution: https://leetcode.com/problems/construct-the-minimum-bitwise-array-ii/solutions/7512283/simplest-solution-c-time-on-logmax_value-stnt/
Difficulty: Medium
Approach: Bit Manipulation - Trailing Ones Pattern
Tags: Bit Manipulation, Array
1) Initialize result array of same size as input.
2) For each number, check if it's even - if so, return -1 (impossible).
3) For odd numbers, count the trailing ones in binary representation.
4) The answer is num - 2^(k-1) where k is the count of trailing ones.
5) This works because (num - 2^(k-1)) | ((num - 2^(k-1)) + 1) = num.
6) Return the constructed result array.

Time Complexity: O(n * log(max_value)) where n = nums.length and log operations for counting bits
Space Complexity: O(n) for the result array
Tip: The key insight is understanding that for prime[i] to exist, nums[i] must be odd. The pattern involves finding trailing ones and flipping the rightmost 0 after the trailing ones block. For a number with k trailing ones, subtracting 2^(k-1) gives the answer.
Similar Problems: 191. Number of 1 Bits, 201. Bitwise AND of Numbers Range, 338. Counting Bits
*/
public class Solution {
    public int[] MinBitwiseArray(IList<int> nums) {
        int n = nums.Count;                                         // Get the size of input array
        int[] ans = new int[n];                                     // Initialize result array

        for (int i = 0; i < n; i++) {                               // Iterate through each number
            int num = nums[i];                                      // Get current number

            // Even numbers are impossible
            if ((num & 1) == 0) {                                   // Check if number is even using bitwise AND
                ans[i] = -1;                                        // Impossible case: set result to -1
                continue;                                           // Skip to next number
            }

            // Count trailing ones
            int k = 0;                                              // Counter for trailing ones
            int temp = num;                                         // Copy number for bit manipulation
            while ((temp & 1) == 1) {                               // While least significant bit is 1
                k++;                                                // Increment trailing ones counter
                temp >>= 1;                                         // Right shift to check next bit
            }

            ans[i] = num - (1 << (k - 1));                          // Calculate answer: subtract 2^(k-1) from num
        }

        return ans;                                                 // Return the result array
    }
}