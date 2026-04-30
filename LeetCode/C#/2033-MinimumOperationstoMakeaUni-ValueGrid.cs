/*
Title: 2033. Minimum Operations to Make a Uni-Value Grid
Solution:
Difficulty: Medium
Approach: Flatten + Sort + Median (Greedy)
Tags: Array, Math, Sorting, Matrix
1) Flatten the 2D grid into a single list of integers.
2) Sort the flattened list to enable median selection.
3) Check feasibility: every value must share the same remainder mod x
   (i.e., (value - firstValue) % x == 0); otherwise return -1.
4) Pick the median element as the target value (median minimizes sum of absolute deviations).
5) For each element, accumulate |value - median| / x as the number of operations.
6) Return the total operation count.

Time Complexity: O(n * m * log(n * m)) due to sorting all grid elements
Space Complexity: O(n * m) for the flattened list
Tip: The median minimizes the sum of absolute differences, which is exactly what we need since each operation changes a value by +/-x. The feasibility check works because adding/subtracting x preserves the value's remainder modulo x, so all elements must share the same remainder.
Similar Problems: 462. Minimum Moves to Equal Array Elements II, 453. Minimum Moves to Equal Array Elements, 2448. Minimum Cost to Make Array Equal
*/
public class Solution
{
    public int MinOperations(int[][] grid, int x)
    {
        // Flatten 2D grid into a list
        List<int> allValues = new List<int>();          // Holds every cell value from the grid

        foreach (int[] row in grid)                     // Iterate through each row of the grid
        {
            foreach (int value in row)                  // Iterate through each cell in the row
            {
                allValues.Add(value);                   // Append the cell value to the flattened list
            }
        }

        // Sort all elements
        allValues.Sort();                               // Sorting enables median lookup and ordered traversal

        // Check if making all values equal is possible
        int firstValue = allValues[0];                  // Reference value to validate modular consistency

        foreach (int value in allValues)                // Verify every value shares the same remainder mod x
        {
            if ((value - firstValue) % x != 0)          // If difference isn't divisible by x, equality is impossible
            {
                return -1;                              // Return -1 to signal an unreachable target
            }
        }

        // Median minimizes total operations
        int medianValue = allValues[allValues.Count / 2]; // Median minimizes sum of absolute deviations

        int operationCount = 0;                         // Accumulator for total operations needed

        foreach (int value in allValues)                // For each value, count steps of size x to reach median
        {
            operationCount += Math.Abs(value - medianValue) / x; // Number of x-sized increments/decrements required
        }

        return operationCount;                          // Return total minimum operations
    }
}