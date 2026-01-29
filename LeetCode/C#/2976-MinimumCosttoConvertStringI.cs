/*
Title: 2976. Minimum Cost to Convert String I
Solution: https://leetcode.com/problems/minimum-cost-to-convert-string-i/solutions/7534047/simplest-solution-c-time-o1-n-space-o1-p-ogq5/
Difficulty: Medium
Approach: Floyd-Warshall Algorithm (All-Pairs Shortest Path)
Tags: Graph, String, Shortest Path, Dynamic Programming
1) Build a distance matrix (26x26) representing minimum cost to convert any letter to another.
2) Initialize all distances to infinity (long.MaxValue), treating character conversions as graph edges.
3) Populate the matrix with given conversion costs (may have multiple edges between same pair).
4) Apply Floyd-Warshall algorithm to find shortest paths between all pairs of characters.
5) For each character position, if source equals target, cost is 0 (continue).
6) Otherwise, lookup the minimum cost from distance matrix.
7) If no path exists (distance is infinity), return -1 (impossible conversion).
8) Sum up all individual character conversion costs.

Time Complexity: O(26³ + n) = O(1 + n) where n = source.Length, since 26³ is constant
Space Complexity: O(26²) = O(1) for the distance matrix, constant space
Tip: This is a graph problem disguised as a string problem. Each character is a node, and conversions are weighted edges. Floyd-Warshall finds the minimum cost path between all pairs of nodes in O(V³) time, which is perfect here since we have exactly 26 nodes (lowercase letters). The key insight is that we can pre-compute all shortest paths once, then answer each character conversion query in O(1).
Similar Problems: 399. Evaluate Division, 787. Cheapest Flights Within K Stops, 1334. Find the City With the Smallest Number of Neighbors at a Threshold Distance, 1462. Course Schedule IV
*/
public class Solution {
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
        long ans = 0;                                               // Total cost accumulator
        // dist[u][v] := the minimum distance to change ('a' + u) to ('a' + v)
        long[][] dist = new long[26][];                             // Distance matrix for 26 lowercase letters

        // Initialize distance matrix with infinity
        for (int i = 0; i < 26; i++)                                // For each character (row)
        {
            dist[i] = new long[26];                                 // Create column array
            for (int j = 0; j < 26; j++)                            // For each target character (column)
            {
                dist[i][j] = long.MaxValue;                         // Set distance to infinity initially
            }
        }

        // Build initial graph with direct conversion costs
        for (int i = 0; i < cost.Length; i++)                       // For each conversion rule
        {
            int u = original[i] - 'a';                              // Source character index (0-25)
            int v = changed[i] - 'a';                               // Target character index (0-25)
            dist[u][v] = Math.Min(dist[u][v], cost[i]);             // Take minimum if multiple edges exist
        }

        // Floyd-Warshall: find shortest paths between all pairs
        for (int k = 0; k < 26; k++)                                // For each intermediate node k
            for (int i = 0; i < 26; i++)                            // For each source node i
                if (dist[i][k] < long.MaxValue)                     // If path i->k exists
                    for (int j = 0; j < 26; j++)                    // For each destination node j
                        if (dist[k][j] < long.MaxValue)             // If path k->j exists
                            dist[i][j] = Math.Min(dist[i][j],       // Update i->j with min of:
                                                  dist[i][k] + dist[k][j]); // direct vs via k

        // Calculate total conversion cost for the string
        for (int i = 0; i < source.Length; i++)                     // For each character position
        {
            if (source[i] == target[i])                             // If characters already match
                continue;                                           // No cost needed, skip
            int u = source[i] - 'a';                                // Source character index
            int v = target[i] - 'a';                                // Target character index
            if (dist[u][v] == long.MaxValue)                        // If no conversion path exists
                return -1;                                          // Impossible to convert
            ans += dist[u][v];                                      // Add conversion cost to total
        }

        return ans;                                                 // Return total minimum cost
    }
}