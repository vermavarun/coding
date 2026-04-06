/*
Title: 874. Walking Robot Simulation
Solution: https://leetcode.com/problems/walking-robot-simulation/solutions/7796855/simplest-solution-c-time-on-km-space-om-4mvh4/
Difficulty: Medium
Approach: Direction Array with HashSet for obstacle lookup
Tags: Array, Hash Table, Simulation
1) Create a 2D direction array to represent North, East, South, West movements.
2) Store all obstacles in a HashSet using a unique encoding to allow O(1) lookup.
3) Simulate robot movement starting at (0, 0) facing North.
4) For each command: if -2, turn left (rotate direction index); if -1, turn right; otherwise move forward step by step.
5) For each forward step, check if next position contains an obstacle before moving.
6) Track the maximum distance squared from origin throughout the simulation.
7) Return the maximum distance squared when all commands are processed.

Time Complexity: O(n + k*m) where n = number of commands, k = max command value, m = obstacle count for hashing
Space Complexity: O(m) where m = number of obstacles stored in HashSet
Tip: Encode coordinates as a single long value (x * 60001 + y) to efficiently store and lookup obstacles in a HashSet. Move step-by-step to check for obstacles before each move rather than jumping directly to the end position.
Similar Problems: 657. Robot Return to Origin, 1266. Minimum Time Visiting All Points, 1496. Path Crossing
*/
public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        // Directions: North, East, South, West (arranged for right turn rotation)
        int[][] dirs = new int[][] {
            new int[] {0, 1},                                       // North: move up (y+1)
            new int[] {1, 0},                                       // East: move right (x+1)
            new int[] {0, -1},                                      // South: move down (y-1)
            new int[] {-1, 0}                                       // West: move left (x-1)
        };

        // Store obstacles in HashSet for O(1) lookup
        HashSet<long> obstacleSet = new HashSet<long>();
        foreach (var obs in obstacles) {
            long key = Encode(obs[0], obs[1]);                      // Encode obstacle coordinates as single long value
            obstacleSet.Add(key);                                   // Add to set for fast collision detection
        }

        int x = 0, y = 0;                                           // Starting position at origin
        int dir = 0;                                                // Direction index: 0=North, 1=East, 2=South, 3=West
        int maxDist = 0;                                            // Track maximum distance squared from origin

        foreach (int cmd in commands) {
            if (cmd == -2) {
                // Turn left: rotate counter-clockwise
                dir = (dir + 3) % 4;                                // Add 3 to rotate left in 0-3 range
            } 
            else if (cmd == -1) {
                // Turn right: rotate clockwise
                dir = (dir + 1) % 4;                                // Add 1 to rotate right in 0-3 range
            } 
            else {
                // Move forward cmd steps
                for (int i = 0; i < cmd; i++) {
                    int nx = x + dirs[dir][0];                      // Calculate next x coordinate
                    int ny = y + dirs[dir][1];                      // Calculate next y coordinate

                    if (obstacleSet.Contains(Encode(nx, ny))) {     // Check if next position is blocked by obstacle
                        break;                                      // Stop movement if obstacle encountered
                    }

                    x = nx;                                         // Move to next position
                    y = ny;

                    maxDist = Math.Max(maxDist, x * x + y * y);     // Update maximum distance squared
                }
            }
        }

        return maxDist;                                             // Return the maximum distance squared from origin
    }

    private long Encode(int x, int y) {
        return (long)x * 60001 + y;                                 // Encode x,y as single long: x*60001+y (60001 > 30000*2)
    }
}