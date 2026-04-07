/*
Title: 2069. Walking Robot Simulation II
Solution: https://leetcode.com/problems/walking-robot-simulation-ii/solutions/7811614/simplest-solution-c-time-ow-h-space-ow-h-dri4/
Difficulty: Medium
Approach: Precompute perimeter path with positions and directions, then use pointer arithmetic
Tags: Simulation, Design, Array, Precomputation
1) Precompute the entire perimeter path as a list of [x, y, direction] tuples.
2) Build path in order: Bottom edge (East), Right edge (North), Top edge (West), Left edge (South).
3) Key insight: Store direction at each position based on where robot is heading when at that spot.
4) Handle special case: Position (0,0) should have direction South when returning (not East initially).
5) For Step(k): Move pointer forward k positions cyclically using modulo.
6) For GetPos(): Return [x, y] at current pointer position.
7) For GetDir(): Return direction at current pointer (East if never moved, otherwise use stored direction).

Time Complexity: O(w + h) for constructor to build path, O(1) for Step, GetPos, and GetDir
Space Complexity: O(w + h) - storing all positions on the perimeter
Tip: This approach trades memory for simplicity by precomputing all valid positions. The robot only moves along the perimeter, so we can store each position once with its direction. The key edge case is that (0,0) has direction South when robot returns to it (after completing a lap), not East (initial state). Using a pointer with modulo arithmetic makes Step() extremely efficient.
Similar Problems: 874. Walking Robot Simulation, 489. Robot Room Cleaner, 1041. Robot Bounded In Circle, 657. Robot Return to Origin
*/
public class Robot
{
    // Pointer on perimeter path
    private int ptr = 0;                                            // Current position index in track list

    // Whether robot has moved at least once
    private bool started = false;                                   // Flag to distinguish initial East vs. returned South at origin

    // Stores perimeter positions: [x, y, direction]
    private List<int[]> track = new List<int[]>();                  // Precomputed path: each element is [x, y, direction]

    public Robot(int w, int h)
    {
        // 🔹 Bottom edge → moving East (0)
        for (int i = 0; i < w; i++)                                 // Traverse bottom row from left to right
        {
            track.Add(new int[] { i, 0, 0 });                       // Add position [x=i, y=0, direction=East(0)]
        }

        // 🔹 Right edge → moving North (1)
        for (int j = 1; j < h; j++)                                 // Traverse right column from bottom to top (skip corner)
        {
            track.Add(new int[] { w - 1, j, 1 });                   // Add position [x=w-1, y=j, direction=North(1)]
        }

        // 🔹 Top edge → moving West (2)
        for (int i = w - 2; i >= 0; i--)                            // Traverse top row from right to left (skip corner)
        {
            track.Add(new int[] { i, h - 1, 2 });                   // Add position [x=i, y=h-1, direction=West(2)]
        }

        // 🔹 Left edge → moving South (3)
        for (int j = h - 2; j > 0; j--)                             // Traverse left column from top to bottom (skip both corners)
        {
            track.Add(new int[] { 0, j, 3 });                       // Add position [x=0, y=j, direction=South(3)]
        }

        // 🔥 Important fix:
        // When we come back to (0,0), direction should be South (not East)
        track[0][2] = 3;                                            // Override origin's direction to South (for when robot returns)
    }

    public void Step(int k)
    {
        // Mark that robot has started moving
        started = true;                                             // Set flag indicating robot has moved at least once

        // Move pointer cyclically
        ptr = (ptr + k) % track.Count;                              // Advance pointer by k steps with wrap-around using modulo
    }

    public int[] GetPos()
    {
        // Return current (x, y)
        return new int[] { track[ptr][0], track[ptr][1] };          // Return x and y coordinates at current pointer position
    }

    public string GetDir()
    {
        // If never moved → always East
        if (!started) return "East";                                // Robot starts facing East before first move

        int d = track[ptr][2];                                      // Get direction value at current position

        if (d == 0) return "East";                                  // Direction 0 maps to East
        if (d == 1) return "North";                                 // Direction 1 maps to North
        if (d == 2) return "West";                                  // Direction 2 maps to West
        return "South";                                             // Direction 3 maps to South
    }
}