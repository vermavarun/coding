/*
Title: 657. Robot Return to Origin
Solution: https://leetcode.com/problems/robot-return-to-origin/solutions/7634858/simplest-solution-c-time-o1-space-o1-ple-ven4/
Difficulty: Easy
Approach: Coordinate tracking and simulation
Tags: String, Simulation
1) Initialize position at origin (0, 0) with x and y coordinates.
2) Iterate through each move character in the moves string.
3) For 'R' (right), increment x coordinate.
4) For 'L' (left), decrement x coordinate.
5) For 'U' (up), increment y coordinate.
6) For 'D' (down), decrement y coordinate.
7) After all moves, check if robot is back at origin (x == 0 && y == 0).
8) Return true if at origin, false otherwise.

Time Complexity: O(n) where n = moves.length
Space Complexity: O(1) - only two integer variables used
Tip: The robot returns to origin only if the number of left moves equals right moves AND the number of up moves equals down moves. You can solve this by tracking coordinates or by counting pairs of opposite moves.
Similar Problems: 1041. Robot Bounded In Circle, 874. Walking Robot Simulation, 2028. Find Missing Observations
*/
public class Solution {
    public bool JudgeCircle(string moves) {
        int x = 0, y = 0;                                       // Initialize robot position at origin (0, 0)

        foreach (char c in moves) {                             // Process each move character
            switch (c) {                                        // Determine move direction
                case 'R': x++; break;                           // Right - increment x coordinate
                case 'L': x--; break;                           // Left - decrement x coordinate
                case 'U': y++; break;                           // Up - increment y coordinate
                case 'D': y--; break;                           // Down - decrement y coordinate
            }
        }

        return x == 0 && y == 0;                                // Return true if robot is back at origin
    }
}