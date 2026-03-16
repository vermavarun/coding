/*
Title: 1878. Get Biggest Three Rhombus Sums in a Grid
Solution: https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid/solutions/7652564/simplest-solution-c-time-omnminmn-space-s3iht/
Difficulty: Medium
Approach: Diagonal Prefix Sums with Rhombus Edge Calculation
Tags: Array, Math, Matrix, Sorting, Prefix Sum
1) Build two diagonal prefix sum arrays: d1 for top-left to bottom-right, d2 for top-right to bottom-left.
2) For each cell in the grid as a potential rhombus center, try different rhombus sizes.
3) For size 0, the rhombus is just the single cell value.
4) For larger sizes, calculate the sum of rhombus edges using diagonal prefix sums.
5) Use prefix sum ranges to get each of the 4 edges (top-right, right-bottom, bottom-left, left-top).
6) Subtract the 4 corner values since they get counted twice in the edge calculations.
7) Maintain a sorted set of the top 3 unique sums encountered.
8) Return the top 3 values in descending order.

Time Complexity: O(m*n*min(m,n)) where m = rows, n = columns, min(m,n) = max rhombus size
Space Complexity: O(m*n) for the two diagonal prefix sum arrays
Tip: The key insight is using diagonal prefix sums to calculate rhombus edge sums in O(1) time. Without this optimization, calculating each rhombus would require iterating through all edge cells, making it much slower. The diagonal prefix sum technique transforms an expensive edge traversal into simple array lookups.
Similar Problems: 304. Range Sum Query 2D - Immutable, 1277. Count Square Submatrices with All Ones, 221. Maximal Square
*/
public class Solution
{
    public int[] GetBiggestThree(int[][] grid)
    {
        int m = grid.Length;                                    // Number of rows in the grid
        int n = grid[0].Length;                                 // Number of columns in the grid

        // d1 -> prefix sums for diagonals from top-left to bottom-right (↘ direction)
        int[][] d1 = new int[m][];                             // Stores cumulative sums along ↘ diagonals
        // d2 -> prefix sums for diagonals from top-right to bottom-left (↙ direction)
        int[][] d2 = new int[m][];                             // Stores cumulative sums along ↙ diagonals

        for (int i = 0; i < m; i++)                            // Initialize both diagonal prefix sum arrays
        {
            d1[i] = new int[n];                                // Allocate space for each row in d1
            d2[i] = new int[n];                                // Allocate space for each row in d2
        }

        /*
        Build prefix sum for left→right diagonals (↘ direction)

        Example:
        grid:
        1 2 3
        4 5 6
        7 8 9

        d1 (each cell = cell value + previous diagonal value):
        1 2 3
        4 6 8
        7 12 15
        */
        for (int i = 0; i < m; i++)                            // Iterate through all rows
        {
            for (int j = 0; j < n; j++)                        // Iterate through all columns
            {
                d1[i][j] = grid[i][j];                         // Start with current cell value
                if (i > 0 && j > 0)                            // If not on first row or column
                    d1[i][j] += d1[i - 1][j - 1];              // Add the diagonal prefix sum from top-left
            }
        }

        /*
        Build prefix sum for right→left diagonals (↙ direction)

        Example:
        grid:
        1 2 3
        4 5 6
        7 8 9

        d2 (each cell = cell value + previous diagonal value):
        1 2 3
        6 8 6
        15 14 9
        */
        for (int i = 0; i < m; i++)                            // Iterate through all rows
        {
            for (int j = n - 1; j >= 0; j--)                   // Iterate through columns from right to left
            {
                d2[i][j] = grid[i][j];                         // Start with current cell value
                if (i > 0 && j + 1 < n)                        // If not on first row or last column
                    d2[i][j] += d2[i - 1][j + 1];              // Add the diagonal prefix sum from top-right
            }
        }

        // Sorted set keeps values sorted automatically and ensures uniqueness
        // We'll keep only top 3 values using AddToSet method
        SortedSet<int> set = new SortedSet<int>();             // Store unique sums in sorted order

        for (int r = 0; r < m; r++)                            // Iterate through all rows as potential rhombus centers
        {
            for (int c = 0; c < n; c++)                        // Iterate through all columns as potential rhombus centers
            {
                // side = 0 -> single cell rhombus (diamond of size 0)
                AddToSet(set, grid[r][c]);                     // Add single cell value as smallest rhombus

                // try increasing rhombus size while it fits within grid boundaries
                for (int side = 1; r - side >= 0 && r + side < m && c - side >= 0 && c + side < n; side++)  // Expand rhombus size
                {
                    int sum = 0;                                   // Initialize sum for current rhombus

                    int top_r = r - side, top_c = c;              // Top corner of rhombus
                    int right_r = r, right_c = c + side;          // Right corner of rhombus
                    int bottom_r = r + side, bottom_c = c;        // Bottom corner of rhombus
                    int left_r = r, left_c = c - side;            // Left corner of rhombus

                    // top → right edge (using d1 diagonal prefix sum)
                    sum += d1[right_r][right_c];                   // Get prefix sum up to right corner
                    if (top_r - 1 >= 0 && top_c - 1 >= 0)          // If there's a previous diagonal prefix to subtract
                        sum -= d1[top_r - 1][top_c - 1];           // Subtract to get only the edge sum

                    // right → bottom edge (using d2 diagonal prefix sum)
                    sum += d2[bottom_r][bottom_c];                 // Get prefix sum up to bottom corner
                    if (right_r - 1 >= 0 && right_c + 1 < n)       // If there's a previous diagonal prefix to subtract
                        sum -= d2[right_r - 1][right_c + 1];       // Subtract to get only the edge sum

                    // bottom → left edge (using d1 diagonal prefix sum)
                    sum += d1[bottom_r][bottom_c];                 // Get prefix sum up to bottom corner
                    if (left_r - 1 >= 0 && left_c - 1 >= 0)        // If there's a previous diagonal prefix to subtract
                        sum -= d1[left_r - 1][left_c - 1];         // Subtract to get only the edge sum

                    // left → top edge (using d2 diagonal prefix sum)
                    sum += d2[left_r][left_c];                     // Get prefix sum up to left corner
                    if (top_r - 1 >= 0 && top_c + 1 < n)           // If there's a previous diagonal prefix to subtract
                        sum -= d2[top_r - 1][top_c + 1];           // Subtract to get only the edge sum

                    // corners were counted twice (once in each adjacent edge) -> subtract them
                    sum -= grid[top_r][top_c];                     // Remove duplicate count of top corner
                    sum -= grid[right_r][right_c];                 // Remove duplicate count of right corner
                    sum -= grid[bottom_r][bottom_c];               // Remove duplicate count of bottom corner
                    sum -= grid[left_r][left_c];                   // Remove duplicate count of left corner

                    AddToSet(set, sum);                            // Add the rhombus sum to our top-3 tracker
                }
            }
        }

        return BuildAnswer(set);                                   // Convert sorted set to descending array
    }

    /*
    Keep only the largest 3 unique values in the set.
    SortedSet automatically handles uniqueness and sorting.

    Example:
    set = {3,7,9,12}
    After adding 12: set has 4 elements
    -> remove smallest -> {7,9,12}
    */
    private void AddToSet(SortedSet<int> set, int val)     // Helper method to maintain top 3 values
    {
        set.Add(val);                                       // Add new value (duplicates automatically ignored)
        if (set.Count > 3)                                  // If we now have more than 3 values
            set.Remove(set.Min);                            // Remove the smallest to keep only top 3
    }

    /*
    Convert set into descending array.
    SortedSet stores in ascending order, so we reverse it.

    Example:
    set = {7,9,12} (ascending)
    After reverse: list = [12,9,7] (descending)
    result = [12,9,7]
    */
    private int[] BuildAnswer(SortedSet<int> set)          // Helper method to build final result
    {
        int[] res = new int[set.Count];                    // Create result array with size = number of unique sums found
        int idx = 0;                                       // Index tracker for result array

        List<int> list = new List<int>(set);               // Convert SortedSet to List
        list.Reverse();                                    // Reverse to get descending order (largest first)

        foreach (var v in list)                            // Iterate through reversed list
            res[idx++] = v;                                // Add each value to result array

        return res;                                        // Return top 3 (or fewer) largest unique sums in descending order
    }
}