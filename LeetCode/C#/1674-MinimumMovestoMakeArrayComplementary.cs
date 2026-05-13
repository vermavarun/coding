/*
Title: 1674. Minimum Moves to Make Array Complementary
Solution: https://leetcode.com/problems/minimum-moves-to-make-array-complementary/solutions/8215528/simplest-solution-c-time-onlimit-space-o-4jbt/
Difficulty: Medium
Approach: Difference Array (Sweep Line) with Range Updates
Tags: Array, Hash Table, Prefix Sum
1) Pair elements symmetrically: nums[i] with nums[n-1-i] for all i from 0 to n/2-1.
2) For each pair, determine the cost (0, 1, or 2 moves) for every possible target sum.
3) Use a difference array to efficiently track changes in move count across all target sums.
4) For each pair (a, b), identify three ranges: 2 moves (default), 1 move [min+1, max+limit], 0 moves [a+b].
5) Mark transitions in the difference array: entering/exiting each range.
6) Apply prefix sum on the difference array starting from 2*n moves to find minimum moves for each target sum.
7) Return the minimum moves across all valid target sums (from 2 to 2*limit).

Time Complexity: O(n + limit) where n = nums.length (process each pair once, then sweep through possible sums)
Space Complexity: O(limit) for the difference array
Tip: The key insight is using a difference array to avoid checking every target sum for every pair (which would be O(n*limit)). Instead, mark range boundaries for when move counts change, then use prefix sum to calculate actual costs. Each pair contributes: 2 moves by default, 1 move in specific ranges, 0 moves at their natural sum.
Similar Problems: 1854. Maximum Population Year, 370. Range Addition, 1109. Corporate Flight Bookings, 2251. Number of Flowers in Full Bloom
*/
public class Solution
{
    public int MinMoves(int[] numbers, int limit)
    {
        int totalNumbers = numbers.Length;                          // Store total length of array
        int pairCount = totalNumbers / 2;                           // Calculate number of pairs (symmetric from ends)

        // Minimum operations required across all possible target sums
        int minimumMoves = totalNumbers;                            // Initialize to worst case (2 moves per pair)

        /*
         * differenceArray[targetSum] stores how the required move count changes
         * when we move from (targetSum - 1) to targetSum.
         *
         * We use a sweep-line / prefix-sum approach to efficiently calculate
         * the number of moves needed for every possible pair sum.
         */
        int[] differenceArray = new int[(limit * 2) + 2];           // Difference array for range updates (size = max possible sum + buffer)

        // Process mirrored pairs:
        // (numbers[0], numbers[n-1]),
        // (numbers[1], numbers[n-2]), etc.
        for (int leftIndex = 0; leftIndex < pairCount; leftIndex++)    // Iterate through first half of array
        {
            int firstValue = numbers[leftIndex];                    // Get element from left side
            int secondValue = numbers[totalNumbers - 1 - leftIndex];    // Get mirrored element from right side

            int smallerValue = Math.Min(firstValue, secondValue);   // Find smaller value in the pair
            int largerValue = Math.Max(firstValue, secondValue);    // Find larger value in the pair

            /*
             * For every pair (firstValue, secondValue):
             *
             * 2 moves are needed by default (replace both numbers).
             *
             * 1 move is enough for sums in:
             * [smallerValue + 1, largerValue + limit]
             * (replace one number to achieve target sum)
             *
             * 0 moves are needed for:
             * [firstValue + secondValue]
             * (current sum is already the target)
             *
             * We mark these transitions in the difference array.
             */

            // Enter 1-move range (reduce from 2 moves to 1 move)
            differenceArray[smallerValue + 1]--;                    // Mark start of range where only 1 move needed

            // Enter 0-move point (reduce from 1 move to 0 moves)
            differenceArray[firstValue + secondValue]--;            // Mark the exact sum where no moves needed

            // Exit 0-move point back to 1 move (increase from 0 to 1 move)
            differenceArray[firstValue + secondValue + 1]++;        // Mark end of 0-move range

            // Exit 1-move range back to 2 moves (increase from 1 to 2 moves)
            differenceArray[largerValue + limit + 1]++;             // Mark end of 1-move range
        }

        /*
         * Initially assume every pair needs 2 moves.
         * Since there are pairCount pairs:
         *
         * initialMoves = pairCount * 2 = totalNumbers
         */
        int currentMoves = totalNumbers;                            // Start with assumption of 2 moves per pair

        // Evaluate every possible target sum from 2 to (2 * limit)
        for (int targetSum = 2; targetSum <= limit * 2; targetSum++)   // Iterate through all valid target sums
        {
            currentMoves += differenceArray[targetSum];             // Apply difference to get actual move count for this target

            minimumMoves = Math.Min(minimumMoves, currentMoves);    // Update minimum if current is better
        }

        return minimumMoves;                                        // Return the minimum moves found across all targets
    }
}