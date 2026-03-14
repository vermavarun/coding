/*
Title: 3651. Minimum Cost Path with Teleportations
Solution: https://leetcode.com/problems/minimum-cost-path-with-teleportations/solutions/7531467/simplest-solution-c-time-ok-m-n-r-space-5z5kp/
Difficulty: Hard
Approach: Dynamic Programming with Prefix Min Optimization
Tags: Dynamic Programming, Grid, Optimization, Prefix Sum
1) Initialize a 2D DP array where dp[r][c] represents minimum cost to reach destination from position (r,c).
2) Set destination cell dp[n-1][m-1] = 0 as base case.
3) Find maximum value in grid to determine prefix array size.
4) Use prefix array to track minimum cost for each grid value seen so far.
5) Iterate k+1 times (number of allowed teleportations + normal path).
6) For each iteration, compute dp values in reverse order (bottom-right to top-left).
7) For each cell, consider moving down or right with cost, and teleporting to same value cells using prefix.
8) After each iteration, update prefix array with current dp values.
9) Build prefix min array to allow O(1) lookup of best teleportation option.
10) Return dp[0][0] as minimum cost from start to destination.

Time Complexity: O(k * (m * n + r)) where k is teleportations, m,n are grid dimensions, r is max grid value
Space Complexity: O(m * n + r) for dp array and prefix array
Tip: The key insight is using a prefix min array to efficiently find the best teleportation option. By maintaining minimum costs for each grid value and computing prefix minimums, we can check in O(1) if teleporting to any cell with value <= current cell's value is beneficial. The reverse iteration ensures we process cells in optimal order.
Similar Problems: 2435. Paths in Matrix Whose Sum Is Divisible by K, 1937. Maximum Number of Points with Cost, 64. Minimum Path Sum
*/
public class Solution {
    public int MinCost(int[][] grid, int k) {
        int n = grid.Length, m = grid[0].Length;                    // Get grid dimensions

        int[][] dp = new int[n][];                                  // Initialize dp array for minimum costs
        for(int i=0; i<n; i++){                                     // For each row
            dp[i] = new int[m];                                     // Create column array
            Array.Fill(dp[i], int.MaxValue);                        // Fill with infinity initially
        }
        dp[n-1][m-1] = 0;                                           // Base case: destination has 0 cost

        int mx = 0;                                                 // Find maximum value in grid
        for(int i=0; i<n; i++){                                     // For each row
            for(int j=0; j<m; j++){                                 // For each column
                mx = Math.Max(mx, grid[i][j]);                      // Update maximum value
            }
        }

        int[] prefix = new int[mx+1];                               // Prefix array for teleportation costs
        Array.Fill(prefix, int.MaxValue);                           // Initialize with infinity

        for(int iter=0; iter<=k; iter++){                           // Iterate k+1 times (for k teleportations)
            for(int r=n-1; r>=0; r--){                              // Iterate rows in reverse (bottom to top)
                for(int c=m-1; c>=0; c--){                          // Iterate columns in reverse (right to left)
                    if(r+1 < n){                                    // If can move down
                        dp[r][c] = Math.Min(dp[r][c], dp[r+1][c] + grid[r+1][c]);  // Update cost with down move
                    }
                    if(c+1 < m){                                    // If can move right
                        dp[r][c] = Math.Min(dp[r][c], dp[r][c+1] + grid[r][c+1]);  // Update cost with right move
                    }
                    dp[r][c] = Math.Min(dp[r][c], prefix[grid[r][c]]);  // Update with best teleportation option
                }
            }

            for(int r=0; r<n; r++){                                 // For each row
                for(int c=0; c<m; c++){                             // For each column
                    prefix[grid[r][c]] = Math.Min(prefix[grid[r][c]], dp[r][c]);  // Update prefix with current dp value
                }
            }

            for(int i=0; i<prefix.Length-1; i++){                   // Build prefix min array
                prefix[i+1] = Math.Min(prefix[i+1], prefix[i]);     // Ensure prefix[i+1] has min of all values <= i+1
            }
        }

        return dp[0][0];                                            // Return minimum cost from start to destination
    }
}