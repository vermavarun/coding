/*
Title: 3600. Maximize Spanning Tree Stability with Upgrades
Solution: https://leetcode.com/problems/maximize-spanning-tree-stability-with-upgrades/solutions/7643708/simplest-solution-c-time-oe-logmaxstabil-bdcr/
Difficulty: Hard
Approach: Binary Search + Union-Find (Disjoint Set Union)
Tags: Graph, Union-Find, Binary Search, Spanning Tree
1) Build a Disjoint Set Union (DSU) data structure to track connected components.
2) Check if mandatory edges (m=1) form valid connections (no cycles).
3) Use binary search to find maximum achievable stability value.
4) For each mid value in binary search:
   a) Add mandatory edges with stability >= mid
   b) Add optional edges with stability >= mid
   c) Collect upgrade candidates (edges where 2*s >= mid)
   d) Use up to k upgrades to connect remaining components
   e) Verify all nodes are connected in a single component
5) Return maximum stability where graph can be fully connected.

Time Complexity: O(E * log(maxStability) * α(N)) where E = edges, N = nodes, α = inverse Ackermann
Space Complexity: O(N) for DSU structure
Tip: The key insight is using binary search on the stability value combined with greedy edge selection - prioritize mandatory edges, then high-stability optional edges, and finally use upgrades strategically on edges that can be doubled to meet the threshold.
Similar Problems: 1489. Find Critical and Pseudo-Critical Edges in MST, 1579. Remove Max Number of Edges to Keep Graph Fully Traversable, 1168. Optimize Water Distribution in a Village
*/

// Disjoint Set Union (Union-Find) data structure for efficient set operations
public class DSU
{
    private int[] parent;                                       // Parent array for tracking set representatives
    private int[] rank;                                         // Rank array for union by rank optimization

    public DSU(int n)
    {
        parent = new int[n];                                    // Initialize parent array
        rank = new int[n];                                      // Initialize rank array

        for (int i = 0; i < n; i++)                             // Initialize each node as its own parent
        {
            parent[i] = i;                                      // Each node starts as its own set
            rank[i] = 1;                                        // Initial rank is 1
        }
    }

    public int Find(int x)
    {
        if (x == parent[x])                                     // If x is root of its set
            return x;                                           // Return x as representative

        return parent[x] = Find(parent[x]);                     // Path compression: flatten tree structure
    }

    public bool Union(int x, int y)
    {
        int xParent = Find(x);                                  // Find root of x's set
        int yParent = Find(y);                                  // Find root of y's set

        if (xParent == yParent)                                 // If already in same set
            return false;                                       // No union needed, return false

        if (rank[xParent] > rank[yParent])                      // Union by rank: attach smaller tree to larger
        {
            parent[yParent] = xParent;                          // Make xParent the root
        }
        else if (rank[xParent] < rank[yParent])                 // yParent has higher rank
        {
            parent[xParent] = yParent;                          // Make yParent the root
        }
        else                                                    // Equal rank
        {
            parent[xParent] = yParent;                          // Arbitrarily choose yParent as root
            rank[yParent]++;                                    // Increment rank of new root
        }

        return true;                                            // Union successful
    }
}

public class Solution
{
    // Check if we can achieve stability 'mid' using at most 'k' upgrades
    private bool Check(int n, int[][] edges, int k, int mid)
    {
        DSU dsu = new DSU(n);                                   // Create new DSU for this stability check

        List<int[]> upgradeCandidates = new List<int[]>();      // Store edges that can be upgraded to meet mid

        foreach (var edge in edges)                             // Process all edges
        {
            int u = edge[0];                                    // First node of edge
            int v = edge[1];                                    // Second node of edge
            int s = edge[2];                                    // Current stability of edge
            int m = edge[3];                                    // Mandatory flag (1 = must include, 0 = optional)

            if (m == 1)                                         // Mandatory edge must be included
            {
                if (s < mid)                                    // If mandatory edge stability < mid
                    return false;                               // Impossible to achieve mid stability

                dsu.Union(u, v);                                // Add mandatory edge to spanning tree
            }
            else                                                // Optional edge
            {
                if (s >= mid)                                   // If stability already meets threshold
                {
                    dsu.Union(u, v);                            // Add edge without upgrade
                }
                else if (2 * s >= mid)                          // If upgrade would meet threshold (2x stability)
                {
                    upgradeCandidates.Add(new int[] { u, v });  // Save as potential upgrade candidate
                }
            }
        }

        foreach (var edge in upgradeCandidates)                 // Process upgrade candidates
        {
            int u = edge[0];                                    // First node of candidate edge
            int v = edge[1];                                    // Second node of candidate edge

            if (dsu.Find(u) != dsu.Find(v))                     // If nodes are in different components
            {
                if (k <= 0)                                     // If no upgrades left
                    return false;                               // Cannot connect all components

                dsu.Union(u, v);                                // Use upgrade to connect components
                k--;                                            // Decrement available upgrades
            }
        }

        int root = dsu.Find(0);                                 // Find root of component containing node 0

        for (int node = 1; node < n; node++)                    // Check all other nodes
        {
            if (dsu.Find(node) != root)                         // If any node is in different component
                return false;                                   // Graph is not fully connected
        }

        return true;                                            // All nodes connected with stability >= mid
    }

    // Main function to find maximum achievable stability with k upgrades
    public int MaxStability(int n, int[][] edges, int k)
    {
        DSU dsu = new DSU(n);                                   // Create DSU to validate mandatory edges

        foreach (var edge in edges)                             // Check all mandatory edges first
        {
            int u = edge[0];                                    // First node of edge
            int v = edge[1];                                    // Second node of edge
            int m = edge[3];                                    // Mandatory flag

            if (m == 1)                                         // If edge is mandatory
            {
                if (dsu.Find(u) == dsu.Find(v))                 // If creates a cycle
                    return -1;                                  // Invalid configuration, impossible to solve

                dsu.Union(u, v);                                // Add mandatory edge
            }
        }

        int result = -1;                                        // Store maximum achievable stability
        int l = 1;                                              // Binary search left boundary (minimum stability)
        int r = (int)2e5;                                       // Binary search right boundary (maximum possible stability)

        while (l <= r)                                          // Binary search for maximum stability
        {
            int mid = l + (r - l) / 2;                          // Calculate middle stability value

            if (Check(n, edges, k, mid))                        // If we can achieve stability 'mid' with k upgrades
            {
                result = mid;                                   // Update result with current valid stability
                l = mid + 1;                                    // Try higher stability values
            }
            else                                                // Cannot achieve stability 'mid'
            {
                r = mid - 1;                                    // Try lower stability values
            }
        }

        return result;                                          // Return maximum achievable stability or -1
    }
}