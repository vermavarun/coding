/*
Title: 1732. Find the Highest Altitude
Solution:
Difficulty: Easy
Approach: Running Prefix Sum
Tags: Array, Prefix Sum
1) Start from altitude 0 because the biker begins at point 0.
2) Track the current altitude after each gain or loss.
3) Keep updating the maximum altitude seen so far.
4) Return the highest altitude reached during the trip.

Time Complexity: O(n) where n = gain.length
Space Complexity: O(1) because only a few variables are used
Tip: This is a prefix sum pattern where you do not need to store every altitude. Just keep a running total and the maximum value seen so far.
Similar Problems: 724. Find Pivot Index, 1480. Running Sum of 1d Array, 1991. Find the Middle Index in Array
*/
public class Solution {
    public int LargestAltitude(int[] gain) {
        int highestAltitude = 0;                       // Stores the maximum altitude reached so far
        int previousAltitude = 0;                      // Starting altitude before processing gains
        for (int i = 0; i < gain.Length; i++) {       // Process each altitude change in order
            int currentAltitude = previousAltitude + gain[i]; // Compute the new altitude after this segment
            previousAltitude = currentAltitude;        // Update previous altitude for the next iteration
            highestAltitude = Math.Max(highestAltitude, currentAltitude); // Keep track of the highest point reached
        }
        return highestAltitude;                        // Return the maximum altitude encountered
    }
}