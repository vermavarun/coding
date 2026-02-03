/*
Title: 3637. Trionic Array I
Solution: https://leetcode.com/problems/trionic-array-i/solutions/7547644/simplest-solution-c-time-on-space-o1-ple-5vb1/
Difficulty: Easy
Approach: Three-phase pattern validation with single pass
Tags: Array, Greedy
1) Check if array has at least 4 elements (minimum for three distinct segments).
2) Phase 1: Traverse while array is strictly increasing, track end position.
3) Validate that Phase 1 exists (at least one increasing pair).
4) Phase 2: Traverse while array is strictly decreasing, track end position.
5) Validate that Phase 2 exists (at least one decreasing pair).
6) Phase 3: Traverse while array is strictly increasing again, track end position.
7) Validate that Phase 3 exists (at least one increasing pair).
8) Ensure entire array is consumed (reached the last element).

Time Complexity: O(n) where n = nums.length - single pass through array
Space Complexity: O(1) - only using a few pointer variables
Tip: A trionic array has exactly three segments: strictly increasing → strictly decreasing → strictly increasing. The key is to ensure each phase exists and the entire array is covered without any extra elements or missing transitions.
Similar Problems: 941. Valid Mountain Array, 845. Longest Mountain in Array, 896. Monotonic Array
*/
public class Solution {
    public bool IsTrionic(int[] nums) {
        int n = nums.Length;                                        // Store array length
        if (n < 4) return false;                                    // Need at least 3 segments (4 elements minimum)

        int i = 0;                                                  // Initialize pointer to start of array

        // 1️⃣ strictly increasing
        while (i + 1 < n && nums[i] < nums[i + 1]) {                // Traverse while strictly increasing
            i++;                                                    // Move to next position
        }
        if (i == 0) return false;                                   // No increasing part found - invalid trionic

        // 2️⃣ strictly decreasing
        int firstPeak = i;                                          // Mark the peak position (end of increasing phase)
        while (i + 1 < n && nums[i] > nums[i + 1]) {                // Traverse while strictly decreasing
            i++;                                                    // Move to next position
        }
        if (i == firstPeak) return false;                           // No decreasing part found - invalid trionic

        // 3️⃣ strictly increasing again
        int secondValley = i;                                       // Mark the valley position (end of decreasing phase)
        while (i + 1 < n && nums[i] < nums[i + 1]) {                // Traverse while strictly increasing again
            i++;                                                    // Move to next position
        }
        if (i == secondValley) return false;                        // No final increasing part found - invalid trionic

        // must consume entire array
        return i == n - 1;                                          // Valid trionic only if we reached the last element
    }
}
