/*
Solution: https://leetcode.com/problems/find-closest-person/solutions/7155756/simplest-solution-c-time-o1-space1-pleas-nyhr/
Difficulty: Medium
Approach: Calculate Manhattan Distance and Compare
Tags: Math, Distance Calculation
1) Calculate the absolute distance from person at position x to position z.
2) Calculate the absolute distance from person at position y to position z.
3) If both distances are equal, return 0 (tie).
4) If first person is closer, return 1; otherwise return 2.
Time Complexity: O(1)
Space Complexity: O(1)

Time Complexity: O(1)
Space Complexity: O(1)
*/
public class Solution {
    public int FindClosest(int x, int y, int z) {
        int firstPersonDistance = Math.Abs(z - x);              // Distance from person at x to position z
        int secondPersonDistance = Math.Abs(z - y);             // Distance from person at y to position z
        if (firstPersonDistance == secondPersonDistance) {      // If distances are equal
            return 0;                                           // Return 0 for tie
        }

        return firstPersonDistance < secondPersonDistance ? 1 : 2;  // Return 1 if first person closer, 2 otherwise
    }
}