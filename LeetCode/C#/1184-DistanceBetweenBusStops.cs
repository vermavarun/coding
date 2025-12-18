/*
Solution: https://leetcode.com/problems/distance-between-bus-stops/solutions/7422205/simplest-solution-c-time-on-space1-pleas-xnl0/
Difficulty: Easy
Approach: Calculate both clockwise and counterclockwise distances
Tags: Array, Math
1) Normalize the start and destination so start is always less than destination.
2) Calculate forward distance by summing array elements from start to destination.
3) Calculate backward distance (circular) by summing from destination to end of array.
4) Add remaining elements from beginning to start for complete backward path.
5) Return the minimum of forward and backward distances.

Time Complexity: O(n) where n = distance.length
Space Complexity: O(1) only using constant extra space
*/
public class Solution {
    public int DistanceBetweenBusStops(int[] distance, int start, int destination) {
        int sumForward = 0;                                     // Distance going forward (clockwise)
        int sumBackward = 0;                                    // Distance going backward (counterclockwise)

        // Ensure start < destination
        if (start > destination) {                              // Swap if start is greater
            int temp = start;
            start = destination;
            destination = temp;
        }

        // Forward distance: start -> destination
        for (int i = start; i < destination; i++) {             // Sum elements from start to destination
            sumForward += distance[i];
        }

        // Backward distance: destination -> start (circular)
        // Part 1: destination -> end
        for (int i = destination; i < distance.Length; i++) {   // Sum from destination to array end
            sumBackward += distance[i];
        }

        // Part 2: start -> beginning
        for (int i = 0; i < start; i++) {                       // Sum from array beginning to start
            sumBackward += distance[i];
        }

        return Math.Min(sumForward, sumBackward);               // Return minimum distance
    }
}
