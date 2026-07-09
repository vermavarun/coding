/*
Title: 3532. Path Existence Queries in a Graph I
Solution: https://leetcode.com/problems/path-existence-queries-in-a-graph-i/solutions/8385481/simplest-solution-c-time-on-q-space-on-p-tb6c/
Difficulty: Medium
Approach: Union-Find (Disjoint Set Union) with path compression and union by rank
Tags: Array, Union Find, Graph
1) Initialize a Disjoint Set with n nodes, each node as its own parent.
2) Since nums is sorted, only check adjacent pairs; union them if their difference is within maxDiff.
3) Connected adjacent nodes form single components via transitivity.
4) For each query, check if the start and end nodes share the same root (same component).
5) Return boolean array of all query results.

Time Complexity: O((n + q) * α(n)) ≈ O(n + q), where α is the inverse Ackermann function
Space Complexity: O(n) for the parent and rank arrays
Tip: Since nums is sorted, edges only exist between adjacent indices. This means path existence reduces to a contiguous-chain problem, making Union-Find the ideal tool to group reachable nodes into components in one pass.
Similar Problems: 323. Number of Connected Components in an Undirected Graph, 547. Number of Provinces, 684. Redundant Connection, 990. Satisfiability of Equality Equations
*/
public class DisjointSet
{
    private readonly int[] parent;
    private readonly int[] rank;

    public DisjointSet(int size)
    {
        parent = new int[size];                         // Each node tracks its own root
        rank = new int[size];                           // Rank used to keep tree balanced during union

        // Initially, every node is its own parent.
        for (int i = 0; i < size; i++)
        {
            parent[i] = i;                              // Node i is its own representative
        }
    }

    /// <summary>
    /// Finds the representative (root) of the given node.
    /// Uses path compression to flatten the tree for faster future lookups.
    /// </summary>
    public int Find(int node)
    {
        if (parent[node] != node)                       // If node is not its own root
        {
            parent[node] = Find(parent[node]);          // Path compression: point directly to root
        }

        return parent[node];                            // Return the root representative
    }

    /// <summary>
    /// Merges the sets containing the two nodes.
    /// Uses union by rank to keep the tree balanced.
    /// </summary>
    public void Union(int firstNode, int secondNode)
    {
        int firstRoot = Find(firstNode);                // Find root of first node
        int secondRoot = Find(secondNode);              // Find root of second node

        if (firstRoot == secondRoot)                    // Already in the same component
        {
            return;                                     // No union needed
        }

        if (rank[firstRoot] < rank[secondRoot])         // Attach smaller tree under larger tree
        {
            parent[firstRoot] = secondRoot;             // firstRoot goes under secondRoot
        }
        else if (rank[firstRoot] > rank[secondRoot])
        {
            parent[secondRoot] = firstRoot;             // secondRoot goes under firstRoot
        }
        else                                            // Equal ranks: attach and increment rank
        {
            parent[firstRoot] = secondRoot;             // Arbitrarily attach first under second
            rank[secondRoot]++;                         // Increment rank of new root
        }
    }
}

public class Solution
{
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
    {
        var disjointSet = new DisjointSet(n);           // Initialize Union-Find for n nodes
        bool[] result = new bool[queries.Length];       // Array to store answer for each query

        // Connect adjacent indices whose values differ by at most maxDiff.
        // Since connectivity is transitive, each connected segment becomes
        // a single component in the disjoint set.
        for (int index = 1; index < n; index++)        // Iterate through each adjacent pair
        {
            if (Math.Abs(nums[index] - nums[index - 1]) <= maxDiff)  // Check if within allowed difference
            {
                disjointSet.Union(index, index - 1);    // Connect the two indices in the same component
            }
        }

        // Two indices have a valid path if they belong to the same component.
        for (int queryIndex = 0; queryIndex < queries.Length; queryIndex++)  // Process each query
        {
            int startIndex = queries[queryIndex][0];    // Extract start node of query
            int endIndex = queries[queryIndex][1];      // Extract end node of query

            result[queryIndex] =
                disjointSet.Find(startIndex) == disjointSet.Find(endIndex);  // True if both share the same root
        }

        return result;                                  // Return boolean results for all queries
    }
}