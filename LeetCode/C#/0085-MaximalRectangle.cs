/*
Title: 85. Maximal Rectangle
Solution: https://leetcode.com/problems/maximal-rectangle/solutions/7486589/simplest-solution-c-time-omn-spacen-plea-y1kg/
Difficulty: Hard
Approach: Dynamic Programming with Largest Rectangle in Histogram
Tags: Array, Dynamic Programming, Stack, Matrix, Monotonic Stack
1) Treat each row as the base of a histogram where heights are consecutive '1's above.
2) For each row, calculate the height of consecutive '1's ending at that row for each column.
3) For each row's histogram, find the largest rectangle using stack-based approach.
4) Use monotonic stack to efficiently find largest rectangle in O(n) time.
5) Track maximum rectangle area found across all rows.

Time Complexity: O(m * n) where m = rows, n = columns
Space Complexity: O(n) for heights array and stack
Tip: Key insight - treat each row as the base of a histogram! Update heights array for consecutive '1's, then use monotonic stack to find max rectangle in O(n). The stack maintains increasing heights, allowing efficient width calculation when popping.
Similar Problems: 84. Largest Rectangle in Histogram, 221. Maximal Square, 1727. Largest Submatrix With Rearrangements
*/
public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)  // Check for empty matrix
            return 0;

        int rows = matrix.Length;                                   // Number of rows in matrix
        int cols = matrix[0].Length;                                // Number of columns in matrix
        int[] heights = new int[cols];                              // Array to store histogram heights
        int maxArea = 0;                                            // Track maximum rectangle area

        for (int i = 0; i < rows; i++)                              // Iterate through each row
        {
            for (int j = 0; j < cols; j++)                          // Update heights for current row
            {
                if (matrix[i][j] == '1')                            // If current cell is '1'
                    heights[j]++;                                   // Increment height (consecutive '1's)
                else                                                // If current cell is '0'
                    heights[j] = 0;                                 // Reset height to 0
            }

            // Find largest rectangle in current histogram
            int area = LargestRectangleInHistogram(heights);        // Calculate max area for this histogram
            maxArea = Math.Max(maxArea, area);                      // Update global maximum area
        }

        return maxArea;                                             // Return maximum rectangle area found
    }

    // Helper method: Find largest rectangle in histogram using monotonic stack
    private int LargestRectangleInHistogram(int[] heights) {
        Stack<int> stack = new Stack<int>();                        // Stack to store indices in increasing height order
        int maxArea = 0;                                            // Track maximum area in histogram
        int n = heights.Length;                                     // Length of heights array

        for (int i = 0; i <= n; i++)                                // Iterate through heights (including one past end)
        {
            int currentHeight = (i == n) ? 0 : heights[i];          // Use 0 for virtual bar at end

            // Pop stack when current height is less than stack top height
            while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
            {
                int height = heights[stack.Pop()];                  // Height of rectangle
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;  // Width calculation
                maxArea = Math.Max(maxArea, height * width);        // Update max area
            }

            stack.Push(i);                                          // Push current index to stack
        }

        return maxArea;                                             // Return largest rectangle area
    }
}