/*
Title: 2515. Shortest Distance to Target String in a Circular Array
Solution: https://leetcode.com/problems/shortest-distance-to-target-string-in-a-circular-array/solutions/7927375/simplest-solution-c-time-on-space-o1-ple-o1yl/
Difficulty: Easy
Approach: Linear Scan with Circular Distance Calculation
Tags: Array, String
1) Store the total length of the words array.
2) Initialize minimum distance to maximum integer value.
3) Iterate through all words in the array with index tracking.
4) For each word that matches the target, calculate two distances:
   - Direct distance: absolute difference between current and start index
   - Circular distance: array length minus direct distance (wrapping around)
5) Take the minimum of both distances as the shortest path.
6) Update overall minimum distance if current is smaller.
7) If no match found, return -1; otherwise return minimum distance.

Time Complexity: O(n) where n = words.length
Space Complexity: O(1) - only using constant extra space
Tip: The key insight is recognizing that in a circular array, you can reach any element by going either left or right. The shorter path is either the direct distance or (total length - direct distance). Always compare both to find the minimum.
Similar Problems: 1848. Minimum Distance to the Target Element, 1652. Defuse the Bomb, 189. Rotate Array
*/
public class Solution
{
    public int ClosestTarget(string[] words, string targetWord, int startIndex)
    {
        int totalWords = words.Length;                              // Store total number of words in array
        int minimumDistance = int.MaxValue;                         // Initialize minimum distance to max value

        // Traverse all words to find occurrences of targetWord
        for (int currentIndex = 0; currentIndex < totalWords; currentIndex++)   // Iterate through entire array
        {
            if (words[currentIndex] == targetWord)                  // Check if current word matches target
            {
                // Distance moving directly (linear)
                int directDistance = Math.Abs(currentIndex - startIndex);       // Calculate straight-line distance

                // Distance considering circular traversal
                int circularDistance = totalWords - directDistance;             // Calculate wrap-around distance

                // Take the minimum of both distances
                int shortestDistance = Math.Min(directDistance, circularDistance);  // Find shorter of two paths

                minimumDistance = Math.Min(minimumDistance, shortestDistance);  // Update overall minimum distance
            }
        }

        // If targetWord was never found, return -1
        return minimumDistance == int.MaxValue ? -1 : minimumDistance;  // Return -1 if not found, else minimum distance
    }
}