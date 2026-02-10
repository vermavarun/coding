/*
Title: 3719. Longest Balanced Subarray I
Solution: https://leetcode.com/problems/longest-balanced-subarray-i/solutions/7568018/simplest-solution-c-time-on2-space-on-pl-ggph/
Difficulty: Medium
Approach: Nested Loop with HashSet to Track Distinct Values
Tags: Array, Hash Table, Counting
1) Initialize result variable to track the longest balanced subarray length.
2) Use outer loop to iterate through each starting index.
3) For each starting index, use inner loop to extend the subarray.
4) Use HashSet to track distinct numbers encountered in current subarray.
5) Count distinct even and odd numbers separately.
6) If count of distinct even numbers equals distinct odd numbers, update result with max length.
7) Return the maximum length found.

Time Complexity: O(n²) where n = nums.length, nested loops with HashSet operations
Space Complexity: O(n) for the HashSet to store distinct elements
Tip: The key insight is that a balanced subarray requires equal count of distinct even and distinct odd numbers. Using a HashSet ensures we only count each distinct number once while allowing duplicates in the subarray. The nested loop approach checks all possible subarrays to find the maximum length where distinct even and odd counts match.
Similar Problems: 1. Two Sum, 525. Contiguous Array, 1124. Longest Well-Performing Interval, 930. Binary Subarrays With Sum
*/
public class Solution {
    public int LongestBalanced(int[] nums) {

        int result = 0;                                             // Variable to store the maximum balanced subarray length

        for(int i = 0; i < nums.Length; i++) {                      // Outer loop: iterate through each starting index

            HashSet<int> hs = new HashSet<int>();                   // HashSet to track distinct numbers in current subarray
            int evenNums = 0;                                       // Counter for distinct even numbers
            int oddNums = 0;                                        // Counter for distinct odd numbers

            for(int j = i; j < nums.Length; j++) {                  // Inner loop: extend subarray from index i to j

                // Only update distinct counters if new number
                if (!hs.Contains(nums[j])) {                        // Check if number is not already in HashSet
                    hs.Add(nums[j]);                                // Add new distinct number to HashSet

                    if(nums[j] % 2 == 0)                            // If number is even
                        evenNums++;                                 // Increment distinct even counter
                    else                                            // If number is odd
                        oddNums++;                                  // Increment distinct odd counter
                }

                // Always check length (even if duplicate)
                if (evenNums == oddNums)                            // If distinct even and odd counts are equal
                    result = Math.Max(result, j - i + 1);           // Update result with maximum length
            }
        }

        return result;                                              // Return the longest balanced subarray length
    }
}
