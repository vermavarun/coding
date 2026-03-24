/*
Title: 2906. Construct Product Matrix
Solution: https://leetcode.com/problems/construct-product-matrix/solutions/7688537/simplest-solution-c-time-omn-space-omn-p-kyd4/
Difficulty: Medium
Approach: Prefix-Suffix Product (Flattened Matrix)
Tags: Array, Matrix, Prefix Sum
1) Treat the 2D matrix as a flattened 1D array for easier prefix product calculation.
2) Build a prefix product list where prefix[i] contains the product of all elements before index i.
3) Initialize prefix with 1 as the base case.
4) Traverse the grid and compute cumulative products modulo 12345.
5) Traverse the matrix backwards while maintaining a running suffix product.
6) For each cell, multiply its prefix product by its suffix product to get the result.
7) Update the suffix product by multiplying it with the current element.
8) Return the result matrix where each element is the product of all other elements modulo 12345.

Time Complexity: O(m*n) where m = rows, n = columns
Space Complexity: O(m*n) for the prefix list and result matrix
Tip: This problem extends the "Product of Array Except Self" concept to 2D matrices. By flattening the matrix conceptually, you can apply the same prefix-suffix multiplication technique without needing division or nested loops for each cell's calculation.
Similar Problems: 238. Product of Array Except Self, 1352. Product of the Last K Numbers, 1594. Maximum Non Negative Product in a Matrix
*/
public class Solution
{
    public int[][] ConstructProductMatrix(int[][] grid)
    {
        const int MOD = 12345;                                      // Modulo constant as per problem requirement

        int rows = grid.Length;                                     // Number of rows in the input grid
        int cols = grid[0].Length;                                  // Number of columns in the input grid

        int[][] result = new int[rows][];                           // Initialize result matrix with same dimensions
        for (int i = 0; i < rows; i++)                              // Allocate each row in the result matrix
            result[i] = new int[cols];                              // Create array for each row

        // Step 1: Build prefix product (flattened matrix)
        List<int> prefix = new List<int>();                         // List to store prefix products for flattened matrix
        prefix.Add(1); // base                                      // Start with 1 (identity for multiplication)

        foreach (var row in grid)                                   // Iterate through each row in the grid
        {
            foreach (var num in row)                                // Iterate through each element in current row
            {
                long last = prefix[prefix.Count - 1];               // Get the last prefix product computed
                prefix.Add((int)((last * num) % MOD));              // Multiply by current element, apply modulo, and add to prefix list
            }
        }

        // Step 2: Traverse from end and maintain suffix product
        int suffix = 1;                                             // Initialize suffix product (starts from end of matrix)

        for (int i = rows - 1; i >= 0; i--)                         // Traverse rows from bottom to top
        {
            for (int j = cols - 1; j >= 0; j--)                     // Traverse columns from right to left
            {
                int index = i * cols + j;                           // Calculate flattened index for current cell

                // prefix[index] = product of all elements BEFORE current
                // suffix = product of all elements AFTER current
                result[i][j] = (int)((long)prefix[index] * suffix % MOD); // Multiply prefix and suffix products, apply modulo

                // Update suffix
                suffix = (int)((long)suffix * grid[i][j] % MOD);    // Include current element in suffix for next iteration
            }
        }

        return result;                                              // Return the constructed product matrix
    }
}