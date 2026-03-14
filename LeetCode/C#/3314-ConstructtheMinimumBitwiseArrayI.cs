/*
Title: 3314. Construct the Minimum Bitwise Array I
Solution: https://leetcode.com/problems/construct-the-minimum-bitwise-array-i/solutions/7509163/simplest-solution-c-time-on-logmaxnums-s-qpyz/
Difficulty: Easy
Approach: Bit Manipulation - Find the minimum value whose OR with itself+1 equals target
Tags: Array, Bit Manipulation
1) For each number in the input array, we need to find ans[i] such that ans[i] | (ans[i] + 1) = nums[i].
2) Key observation: If nums[i] is even, it's impossible (return -1) because OR operation always produces odd result when one operand is even and other is odd.
3) For odd numbers, count the trailing ones in binary representation.
4) The answer is nums[i] minus 2^(k-1), where k is the count of trailing ones.
5) This works because adding 1 to a number flips all trailing ones to zeros and the bit after them to 1, and OR operation restores the original number.

Time Complexity: O(n * log(max(nums))) where n = nums.length, log factor for bit counting
Space Complexity: O(n) for the result array
Tip: The key insight is understanding that for ans | (ans+1) = nums, we need to find where the trailing ones end. When we add 1 to ans, it flips all trailing 1s to 0s and sets the next bit to 1. The OR operation then combines these to give us nums.
Similar Problems: 2997. Minimum Number of Operations to Make Array XOR Equal to K, 2939. Maximum Xor Product
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
