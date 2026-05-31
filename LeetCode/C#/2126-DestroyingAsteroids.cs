/*
Title: 2126. Destroying Asteroids
Solution: https://leetcode.com/problems/destroying-asteroids/solutions/8303593/simplest-solution-c-time-on-log-n-space-x8d4a/
Difficulty: Medium
Approach: Greedy (Sort asteroids, always absorb the smallest one possible)
Tags: Greedy, Sorting, Simulation
Key Steps:
1) Sort the asteroids in ascending order.
2) Iterate through each asteroid:
   - If your mass >= asteroid, absorb it (add its mass to yours).
   - If not, return false (cannot destroy all asteroids).
3) If all asteroids are absorbed, return true.

Time Complexity: O(n log n) for sorting, O(n) for iteration
Space Complexity: O(1) extra (in-place sort)

Tip: Always absorb the smallest asteroid available to maximize your mass for future asteroids.
Similar Problems: 1353. Maximum Number of Events That Can Be Attended, 870. Advantage Shuffle
*/
public class Solution {
    public bool AsteroidsDestroyed(int mass, int[] asteroids) {

        Array.Sort(asteroids); // Sort asteroids by mass (smallest first)

        long currentMass = mass; // Use long to prevent overflow

        foreach (int asteroid in asteroids) {
            if (currentMass >= asteroid) {
                currentMass += asteroid; // Absorb asteroid, increase mass
            }
            else {
                return false; // Cannot absorb this asteroid, fail
            }
        }

        return true; // All asteroids absorbed
    }
}