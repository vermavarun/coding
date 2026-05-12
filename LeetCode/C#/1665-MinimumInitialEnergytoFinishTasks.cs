/*
Title: 1665. Minimum Initial Energy to Finish Tasks
Solution: https://leetcode.com/problems/minimum-initial-energy-to-finish-tasks/solutions/8204207/simplest-solution-c-time-on-log-n-space-04x1p/
Difficulty: Hard
Approach: Greedy Sorting (by energy difference)
Tags: Array, Greedy, Sorting
1) Sort tasks by ascending order of (actual - minimum), where actual is energy spent and minimum is energy required to start.
2) Initialize minimumInitialEnergy to track total energy needed and remainingEnergy to track current energy after each task.
3) Iterate through each task in sorted order.
4) For each task, check if remainingEnergy is sufficient to start (>= minimumEnergyRequired).
5) If not sufficient, calculate additionalEnergyNeeded and add to minimumInitialEnergy, then update remainingEnergy.
6) If sufficient, simply subtract actualEnergyCost from remainingEnergy.
7) Return minimumInitialEnergy as the answer.

Time Complexity: O(n log n) where n = tasks.length (dominated by sorting)
Space Complexity: O(log n) for sorting (in-place sort with recursion stack)
Tip: The key insight is greedy sorting - tasks with smaller (actual - minimum) difference should be done first. This means tasks where minimum >> actual (harder to start but cheap to execute) should be prioritized. This ordering minimizes the peak energy requirement.
Similar Problems: 630. Course Schedule III, 1029. Two City Scheduling, 502. IPO, 1353. Maximum Number of Events That Can Be Attended
*/
public class Solution
{
    public int MinimumEffort(int[][] tasks)
    {
        // Sort tasks by (actualEnergy - minimumRequiredEnergy) in ascending order
        // Tasks with smaller difference (harder to start) should be done first
        // This greedy ordering minimizes the initial energy needed
        Array.Sort(tasks, (firstTask, secondTask) =>
            (firstTask[0] - firstTask[1])                           // Calculate energy difference for each task
                .CompareTo(secondTask[0] - secondTask[1]));         // Compare to sort in ascending order

        // Total minimum initial energy required to complete all tasks
        int minimumInitialEnergy = 0;                               // Track total energy needed at start

        // Current remaining energy after completing previous tasks
        int remainingEnergy = 0;                                    // Track energy left after each task

        foreach (int[] task in tasks)                               // Process each task in sorted order
        {
            int actualEnergyCost = task[0];                         // Energy consumed when executing task
            int minimumEnergyRequired = task[1];                    // Minimum energy needed to start task

            // If current energy is below the minimum required,
            // we must increase our initial energy
            if (remainingEnergy < minimumEnergyRequired)            // Check if we have enough energy to start
            {
                int additionalEnergyNeeded =                        // Calculate how much more energy we need
                    minimumEnergyRequired - remainingEnergy;        // Gap between required and current

                minimumInitialEnergy += additionalEnergyNeeded;     // Add to total initial energy needed

                // After performing the task:
                // remainingEnergy = minimumRequired - actualCost
                remainingEnergy =                                   // Update remaining energy after task
                    minimumEnergyRequired - actualEnergyCost;       // Start with minimum, subtract actual cost
            }
            else                                                    // We have enough energy to start
            {
                // We already have enough energy to start this task
                // Simply consume the actual energy cost
                remainingEnergy -= actualEnergyCost;                // Subtract only the actual cost from current energy
            }
        }

        return minimumInitialEnergy;                                // Return total minimum initial energy needed
    }
}