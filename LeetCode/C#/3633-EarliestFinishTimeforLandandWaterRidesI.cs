/*
Title: 3633. Earliest Finish Time for Land and Water Rides I
Solution: https://leetcode.com/problems/earliest-finish-time-for-land-and-water-rides-i/solutions/8308883/simplest-solution-c-time-onm-space-on-pl-sggm/
Difficulty: Easy
Approach: Greedy — try both orderings, pick earliest-finishing first task
Tags: Array, Greedy
1) Try both orderings: land-then-water and water-then-land.
2) For each ordering, greedily pick the earliest-finishing "first" ride across all options.
3) For each candidate "second" ride, actual start = max(its start time, first ride finish time).
4) Compute total finish = actual start + second ride duration.
5) Track the minimum finish time across all second ride choices.
6) Return the minimum result from both orderings.

Time Complexity: O(n + m) where n = number of land rides, m = number of water rides
Space Complexity: O(1) — only scalar variables used
Tip: The key insight is that you only need the single earliest-finishing ride from the first group (greedy choice), then check every ride in the second group against that finish time to find the best pair.
Similar Problems: 2402. Meeting Rooms III, 1353. Maximum Number of Events That Can Be Attended
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