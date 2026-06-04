/*
Title: 3635. Earliest Finish Time for Land and Water Rides II
Solution:
Difficulty: Medium
Approach: Greedy - Try both orderings (land-then-water and water-then-land)
Tags: Array, Greedy
1) Try completing all land tasks first, then any water task.
2) Try completing all water tasks first, then any land task.
3) For each ordering, greedily find the earliest finish time of any first-category task.
4) For each second-category task, compute actual start = max(firstCompletion, taskStart).
5) Track the minimum total finish time across all second-category tasks.
6) Return the minimum finish time across both orderings.

Time Complexity: O(n + m) where n = land tasks count, m = water tasks count
Space Complexity: O(1) no extra space beyond input arrays
Tip: The key insight is that exactly one task from each category must be completed. Since we don't know which finishes first, we try both orderings. For a given ordering, we greedily pick whichever first-category task finishes earliest, then find the best second-category task that can follow.
Similar Problems: 1235. Maximum Profit in Job Scheduling, 2402. Meeting Rooms III, 630. Course Schedule III
*/
public class Solution
{
    public int EarliestFinishTime(
        int[] landStartTime, int[] landDuration,
        int[] waterStartTime, int[] waterDuration)
    {
        // Case 1: Complete land task first, then water task
        int landThenWater = CalculateSequentialFinishTime(
            landStartTime, landDuration,
            waterStartTime, waterDuration);

        // Case 2: Complete water task first, then land task
        int waterThenLand = CalculateSequentialFinishTime(
            waterStartTime, waterDuration,
            landStartTime, landDuration);

        // Return the best (earliest) possible finish time across both orderings
        return Math.Min(landThenWater, waterThenLand);
    }

    private int CalculateSequentialFinishTime(
        int[] firstStartTimes, int[] firstDurations,
        int[] secondStartTimes, int[] secondDurations)
    {
        // Step 1: Greedily find the earliest time we can finish ANY first task
        int earliestFirstCompletion = int.MaxValue;                     // Initialize to max so any value is smaller

        for (int i = 0; i < firstStartTimes.Length; i++)
        {
            int finishTime = firstStartTimes[i] + firstDurations[i];    // Finish = start + duration
            earliestFirstCompletion = Math.Min(earliestFirstCompletion, finishTime); // Keep the earliest finish
        }

        // Step 2: Try all second tasks and find the earliest total completion time
        int earliestTotalCompletion = int.MaxValue;                     // Initialize to max

        for (int i = 0; i < secondStartTimes.Length; i++)
        {
            // A second task can only start after:
            // 1. It becomes available (secondStartTimes[i])
            // 2. The first task has completed (earliestFirstCompletion)
            int actualStart = Math.Max(earliestFirstCompletion, secondStartTimes[i]); // Must wait for both conditions

            int finishTime = actualStart + secondDurations[i];          // Total finish time for this second task

            earliestTotalCompletion = Math.Min(earliestTotalCompletion, finishTime); // Track minimum across all options
        }

        return earliestTotalCompletion;                                 // Return earliest finish for this ordering
    }
}