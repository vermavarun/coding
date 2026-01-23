/*
Title: 3510. Minimum Pair Removal to Sort Array II
Solution: https://leetcode.com/problems/minimum-pair-removal-to-sort-array-ii/solutions/7518614/simplest-solution-c-time-on-log-n-space-ex5xc/
Difficulty: Hard
Approach: Greedy with SortedSet and Linked List simulation
Tags: Array, Greedy, SortedSet, Linked List
1) Use arrays to simulate a doubly linked list (prev/next pointers) to efficiently track adjacency.
2) Use a SortedSet to maintain pairs sorted by sum (naturally picks leftmost on tie due to index ordering).
3) Count inversions (descending pairs) and track them dynamically as we merge.
4) For each operation: remove smallest pair, update inversions, merge elements, update neighbors in sorted set.
5) Continue until no inversions remain (array is non-decreasing).
6) Return the total number of operations performed.

Time Complexity: O(n log n) where n = nums.length (SortedSet operations dominate)
Space Complexity: O(n) for the arrays and sorted set
Tip: The key is properly updating the sorted set when pairs change - remove old pairs, add new ones. Track inversions by checking before/after relationships. The SortedSet naturally maintains pairs sorted by (sum, index) which gives us leftmost selection on ties.
Similar Problems: 3507. Minimum Pair Removal to Sort Array I, 1642. Furthest Building You Can Reach, 630. Course Schedule III
*/
public class Solution {
    public int MinimumPairRemoval(int[] nums) {
        int n = nums.Length;                                    // Store array length
        int ans = 0;                                            // Counter for number of operations performed

        long[] values = new long[n];                            // Use long to handle potential overflow from sums
        for (int i = 0; i < n; i++) {                           // Copy values to long array
            values[i] = nums[i];
        }

        // Count initial inversions (descending pairs)
        int inversionsCount = 0;                                // Counter for inversions
        for (int i = 0; i < n - 1; i++) {                       // Check all adjacent pairs
            if (values[i + 1] < values[i]) inversionsCount++;   // Increment if pair is descending
        }

        if (inversionsCount == 0) return 0;                     // Already sorted, no operations needed

        int[] nextIndices = new int[n];                         // Array to track next element index in linked list
        int[] prevIndices = new int[n];                         // Array to track previous element index in linked list
        for (int i = 0; i < n; i++) {                           // Initialize linked list structure
            nextIndices[i] = i + 1;                             // Next element is at i+1
            prevIndices[i] = i - 1;                             // Previous element is at i-1
        }

        // SortedSet maintains pairs sorted by (sum, index) - naturally picks leftmost on tie
        var pairSums = new SortedSet<(long sum, int index)>();
        for (int i = 0; i < n - 1; i++) {                       // Add all initial adjacent pairs
            pairSums.Add((values[i] + values[i + 1], i));       // Add (sum, index) tuple
        }

        while (inversionsCount > 0) {                           // Continue until no inversions remain
            ans++;                                              // Increment operation counter
            var smallestPair = pairSums.Min;                    // Get pair with minimum sum (leftmost if tied)
            pairSums.Remove(smallestPair);                      // Remove it from sorted set
            long pairSum = smallestPair.sum;                    // Extract the sum
            int currIndex = smallestPair.index;                 // Extract the index
            int nextIndex = nextIndices[currIndex];             // Get next element index
            int prevIndex = prevIndices[currIndex];             // Get previous element index

            // Update left neighbor's pair
            if (prevIndex >= 0) {                               // If there's a previous element
                long oldPairSum = values[prevIndex] + values[currIndex]; // Old pair sum
                long newPairSum = values[prevIndex] + pairSum;  // New pair sum after merge
                pairSums.Remove((oldPairSum, prevIndex));       // Remove old pair from sorted set
                pairSums.Add((newPairSum, prevIndex));          // Add new pair to sorted set
                if (values[prevIndex] > values[currIndex]) {    // If old pair was descending
                    inversionsCount--;                          // Decrement inversion count
                }
                if (values[prevIndex] > pairSum) {              // If new pair is descending
                    inversionsCount++;                          // Increment inversion count
                }
            }

            // Check if current pair being merged is descending
            if (values[nextIndex] < values[currIndex]) {        // If current pair is descending
                inversionsCount--;                              // Decrement inversion count (it's being removed)
            }

            // Update right neighbor's pair
            int nextNextIndex = nextIndex < n ? nextIndices[nextIndex] : n; // Get element after next
            if (nextNextIndex < n) {                            // If there's an element after next
                long oldPairSum = values[nextIndex] + values[nextNextIndex]; // Old pair sum
                long newPairSum = pairSum + values[nextNextIndex]; // New pair sum after merge
                pairSums.Remove((oldPairSum, nextIndex));       // Remove old pair from sorted set
                pairSums.Add((newPairSum, currIndex));          // Add new pair to sorted set
                if (values[nextNextIndex] < values[nextIndex]) { // If old pair was descending
                    inversionsCount--;                          // Decrement inversion count
                }
                if (values[nextNextIndex] < pairSum) {          // If new pair is descending
                    inversionsCount++;                          // Increment inversion count
                }
                prevIndices[nextNextIndex] = currIndex;         // Update previous pointer
            }

            nextIndices[currIndex] = nextNextIndex;             // Update next pointer to skip merged element
            values[currIndex] = pairSum;                        // Update current value to merged sum
        }

        return ans;                                             // Return total operations needed
    }
}
