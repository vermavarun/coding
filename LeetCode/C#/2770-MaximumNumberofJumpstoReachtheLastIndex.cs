/*
Title: 2770. Maximum Number of Jumps to Reach the Last Index
Solution: https://leetcode.com/problems/maximum-number-of-jumps-to-reach-the-last-index/solutions/8184051/simplest-solution-c-time-on2-space-on-pl-i0iy/
Difficulty: Medium
Approach: Dynamic Programming (bottom-up, O(n²))
Tags: Array, Dynamic Programming
1) Create a dp array maxJumpsToIndex where maxJumpsToIndex[i] = max jumps to reach index i.
2) Initialize all values to -1 (unreachable); set maxJumpsToIndex[0] = 0 (start).
3) For each destination index, check every previous source index.
4) Skip sources that are unreachable (value == -1).
5) A jump from source to destination is valid if |nums[dest] - nums[src]| <= target.
6) If valid, update maxJumpsToIndex[dest] = max(current, maxJumpsToIndex[src] + 1).
7) Return maxJumpsToIndex[last] which is -1 if the last index is unreachable.

Time Complexity: O(n²) where n = numbers.Length
Space Complexity: O(n) for the dp array
Tip: Think of it as a longest-path problem on a DAG — each valid jump is a directed edge, and you want the longest path to the last node.
Similar Problems: 45. Jump Game II, 55. Jump Game, 1345. Jump Game IV
*/
public class Solution
{
    public int MaximumJumps(int[] numbers, int target)
    {
        int totalNumbers = numbers.Length;                          // Total number of elements

        // maxJumpsToIndex[i]
        // Stores the maximum number of jumps needed
        // to reach index i starting from index 0.
        //
        // Value = -1 means index i is not reachable.
        int[] maxJumpsToIndex = new int[totalNumbers];          // dp array; -1 = unreachable

        Array.Fill(maxJumpsToIndex, -1);                        // Initialize all indices as unreachable

        // Starting position requires 0 jumps
        maxJumpsToIndex[0] = 0;                                 // Base case: 0 jumps to reach start

        // Try to reach every destination index
        for (int destinationIndex = 1; destinationIndex < totalNumbers; destinationIndex++)  // Iterate over each target index
        {
            // Check all previous indices as possible jump sources
            for (int sourceIndex = 0; sourceIndex < destinationIndex; sourceIndex++)        // Check every valid source before destination
            {
                // Skip if source index is unreachable
                if (maxJumpsToIndex[sourceIndex] == -1)                                     // Can't jump from an unreachable source
                {
                    continue;
                }

                // A jump is valid only if the difference
                // between values is within the target range
                bool isValidJump =
                    Math.Abs(numbers[destinationIndex] - numbers[sourceIndex]) <= target;   // Check jump constraint

                if (isValidJump)
                {
                    // Either keep the existing best answer
                    // or use the current jump path
                    maxJumpsToIndex[destinationIndex] = Math.Max(
                        maxJumpsToIndex[destinationIndex],           // Best known jumps to reach destination
                        maxJumpsToIndex[sourceIndex] + 1            // Jumps via this source + 1 more jump
                    );
                }
            }
        }

        // Returns -1 if the last index cannot be reached
        return maxJumpsToIndex[totalNumbers - 1];               // Answer is the max jumps to reach last index
    }
}