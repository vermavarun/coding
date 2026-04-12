
/*
Title: 1320. Minimum Distance to Type a Word Using Two Fingers
Solution: https://leetcode.com/problems/minimum-distance-to-type-a-word-using-two-fingers/solutions/7880952/simplest-solution-c-time-on-space-on-ple-mpoc/
Difficulty: Hard
Approach: Dynamic Programming with Memoization (Top-Down DP)
Tags: Dynamic Programming, Memoization, String, Recursion
1) Model the QWERTY keyboard as a grid with coordinates (row, col), where each character A-Z maps to positions 0-25.
2) Use 3D memoization: memo[index][finger1][finger2] stores minimum distance from current state.
3) Define state: at each character index, track positions of both fingers (0-25 for A-Z, 26 for unused).
4) Base case: when all characters are typed, return 0.
5) For first character, place finger1 at no cost (both fingers initially unused).
6) For subsequent characters, recursively try moving either finger1 or finger2.
7) Calculate Manhattan distance = |row1-row2| + |col1-col2| for any finger movement.
8) Choose the option (finger1 or finger2) that yields minimum total distance.
9) Memoize results to avoid recomputing same states.

Time Complexity: O(n * 27 * 27) where n = word.length, 27 possible positions per finger
Space Complexity: O(n * 27 * 27) for memoization table
Tip: The key insight is that at any position, you have at most two choices: move finger1 or move finger2. The first character is free (place any finger). Use memoization to cache subproblem results, avoiding exponential recalculation. Represent unused fingers with index 26 to handle initial state cleanly.
Similar Problems: 72. Edit Distance, 1143. Longest Common Subsequence, 935. Knight Dialer, 576. Out of Boundary Paths
*/
public class Solution
{
    // 3D DP array: memo[index][finger1Position][finger2Position]
    // Stores minimum distance from current state to end
    // 301 = max word length, 27 = 26 letters + 1 for unused state
    private int[,,] memo = new int[301, 27, 27];

    /// <summary>
    /// Converts a character index (0–25) into keyboard coordinates (row, col)
    /// Keyboard layout is 6 columns wide: ABCDEF, GHIJKL, MNOPQR, STUVWX, YZ____
    /// </summary>
    private (int row, int col) GetCoordinates(int charIndex)
    {
        return (charIndex / 6, charIndex % 6);              // Row = index/6, Column = index%6
    }

    /// <summary>
    /// Calculates Manhattan distance between two character positions
    /// Manhattan distance = |x1-x2| + |y1-y2|
    /// </summary>
    private int GetDistance(int fromChar, int toChar)
    {
        var (r1, c1) = GetCoordinates(fromChar);            // Get coordinates of starting character
        var (r2, c2) = GetCoordinates(toChar);              // Get coordinates of target character

        return Math.Abs(r1 - r2) + Math.Abs(c1 - c2);       // Calculate Manhattan distance
    }

    /// <summary>
    /// Recursive function with memoization to find minimum typing distance
    /// index = current character index in the word
    /// finger1 = position of first finger (0–25 for A-Z, 26 if unused)
    /// finger2 = position of second finger (0–25 for A-Z, 26 if unused)
    /// Returns minimum distance needed from this state onwards
    /// </summary>
    private int Solve(string word, int index, int finger1, int finger2)
    {
        // Base case: all characters processed, no more distance needed
        if (index >= word.Length)
            return 0;

        // Convert current character to index (0–25 for A-Z)
        int currentChar = word[index] - 'A';

        // Return memoized result if already computed for this state
        if (memo[index, finger1, finger2] != -1)
            return memo[index, finger1, finger2];

        int result;                                         // Will store minimum distance for current state

        // Case 1: Both fingers are unused (first character)
        if (finger1 == 26 && finger2 == 26)
        {
            // Place finger1 at current character (no cost for first character)
            result = Solve(word, index + 1, currentChar, finger2);
        }
        // Case 2: Only finger2 is unused (second character)
        else if (finger2 == 26)
        {
            // Option 1: Place finger2 at current position (no movement cost)
            int useFinger2 = Solve(word, index + 1, finger1, currentChar);

            // Option 2: Move finger1 to current character (incur distance cost)
            int useFinger1 = GetDistance(finger1, currentChar) +
                             Solve(word, index + 1, currentChar, finger2);

            result = Math.Min(useFinger1, useFinger2);      // Choose minimum of two options
        }
        // Case 3: Both fingers are already placed
        else
        {
            // Option 1: Move finger1 to current character
            int moveFinger1 = GetDistance(finger1, currentChar) +
                              Solve(word, index + 1, currentChar, finger2);

            // Option 2: Move finger2 to current character
            int moveFinger2 = GetDistance(finger2, currentChar) +
                              Solve(word, index + 1, finger1, currentChar);

            result = Math.Min(moveFinger1, moveFinger2);    // Choose minimum of two options
        }

        // Store result in memo table before returning
        memo[index, finger1, finger2] = result;
        return result;                                      // Return minimum distance from this state
    }

    public int MinimumDistance(string word)
    {
        // Initialize memo table with -1 (indicating uncomputed state)
        for (int i = 0; i < 301; i++)                       // Loop through all possible indices
        {
            for (int j = 0; j < 27; j++)                    // Loop through all finger1 positions
            {
                for (int k = 0; k < 27; k++)                // Loop through all finger2 positions
                {
                    memo[i, j, k] = -1;                     // Mark state as uncomputed
                }
            }
        }

        // Start recursion with both fingers unused (26 represents unused state)
        return Solve(word, 0, 26, 26);                      // Begin at index 0 with both fingers unplaced
    }
}