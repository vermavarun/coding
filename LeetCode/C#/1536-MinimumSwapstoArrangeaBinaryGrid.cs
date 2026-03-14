/*
Title: 1536. Minimum Swaps to Arrange a Binary Grid
Solution: https://leetcode.com/problems/minimum-swaps-to-arrange-a-binary-grid/solutions/7619820/simplest-solution-c-time-on2-space-on-pl-2bp5/
Difficulty: Medium
Approach: Greedy with Row Swapping
Tags: Array, Greedy, Matrix
1) Count trailing zeros for each row (zeros from right until first 1 is found).
2) For each row position i from top to bottom, determine the required trailing zeros (n - i - 1).
3) Find the first row at or below position i that has enough trailing zeros.
4) If no such row exists, return -1 (impossible to arrange).
5) Swap the found row upward to position i using adjacent swaps.
6) Count the number of swaps performed.
7) Return total swap count.

Time Complexity: O(n²) where n = grid.length
Space Complexity: O(n) for storing trailing zeros count
Tip: The key insight is that row i needs at least (n - i - 1) trailing zeros to satisfy the upper triangle constraint. Use greedy approach: for each position, find the nearest suitable row below and bubble it up with adjacent swaps.
Similar Problems: 1217. Minimum Cost to Move Chips to The Same Position, 1769. Minimum Number of Operations to Move All Balls to Each Box, 2471. Minimum Number of Operations to Sort a Binary Tree by Level
*/
public class Solution {
    public int MinSwaps(int[][] grid) {

        int n = grid.Length;                                    // Get grid dimensions (n x n)

        // Step 1: Count trailing zeros in each row
        int[] trailingZeros = new int[n];                       // Array to store trailing zero count for each row

        for (int i = 0; i < n; i++) {                           // Iterate through each row
            int count = 0;                                      // Initialize trailing zero counter

            // Traverse row from right to left
            for (int j = n - 1; j >= 0; j--) {                  // Count from rightmost column
                if (grid[i][j] == 0)                            // If current cell is zero
                    count++;                                    // Increment trailing zero count
                else
                    break;                                      // Stop when first 1 is found
            }

            trailingZeros[i] = count;                           // Store trailing zero count for row i
        }

        int swaps = 0;                                          // Initialize total swap counter

        // Step 2: Try to fix each row from top to bottom
        for (int i = 0; i < n; i++) {                           // Process each row position

            // Required trailing zeros for row i
            int required = n - i - 1;                           // Row i needs at least (n-i-1) trailing zeros

            int j = i;                                          // Start searching from current row position

            // Step 3: Find a row below that satisfies requirement
            while (j < n && trailingZeros[j] < required) {      // Search for suitable row
                j++;                                            // Move to next row
            }

            // If no such row found → impossible
            if (j == n) {                                       // If no suitable row exists
                return -1;                                      // Return -1 (impossible to arrange)
            }

            // Step 4: Bring row j to position i
            // Swap upward one by one (like bubble sort)
            while (j > i) {                                     // Bubble row j up to position i
                int temp = trailingZeros[j];                    // Store current row's trailing zeros
                trailingZeros[j] = trailingZeros[j - 1];        // Move row above down
                trailingZeros[j - 1] = temp;                    // Move current row up

                swaps++;                                        // Increment swap counter
                j--;                                            // Move pointer up
            }
        }

        return swaps;                                           // Return total number of swaps needed
    }
}