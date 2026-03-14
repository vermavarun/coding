/*
Title: 3650. Minimum Cost Path with Edge Reversals
Solution: https://leetcode.com/problems/minimum-cost-path-with-edge-reversals/solutions/7528727/simplest-solution-c-time-oe-log-v-space-zp3h3/
Difficulty: Medium
Approach: Dijkstra's Algorithm with Edge Weight Modeling
Tags: Graph, Shortest Path, Dijkstra, Priority Queue, Weighted Graph
1) Build adjacency list with bidirectional edges.
2) For each directed edge u → v with weight w:
   - Add forward edge u → v with cost w (following original direction)
   - Add reverse edge v → u with cost 2*w (reversing the edge)
3) Use standard Dijkstra's algorithm with min-heap priority queue.
4) Initialize distance array with infinity, start node with 0.
5) Process nodes in order of increasing distance.
6) For each neighbor, relax edge if shorter path found.
7) Return distance to node (n-1) when first dequeued.
8) If unreachable, return -1.

Time Complexity: O(E * log V) where E = edges, V = vertices
Space Complexity: O(V + E) for adjacency list and priority queue
Tip: Model the problem as a weighted graph where reversing an edge costs 2x. Since each edge can be traversed forward (cost w) or reversed (cost 2w), simply add both directions to the graph and run Dijkstra. This eliminates the need for complex state tracking.
Similar Problems: 743. Network Delay Time, 787. Cheapest Flights Within K Stops, 1334. Find the City With the Smallest Number of Neighbors at a Threshold Distance
*/
public class Solution {
    public int MinCost(int n, int[][] edges) {
        // Build adjacency list with forward and reverse edges
        Dictionary<int, List<(int neighbor, int cost)>> adj = new Dictionary<int, List<(int, int)>>();

        for (int i = 0; i < n; i++) {                               // Initialize adjacency list for each node
            adj[i] = new List<(int, int)>();
        }

        foreach (int[] edge in edges) {
            int u = edge[0];
            int v = edge[1];
            int wt = edge[2];

            adj[u].Add((v, wt));                                    // Forward edge: u → v with original cost
            adj[v].Add((u, 2 * wt));                                // Reverse edge: v → u with doubled cost
        }

        // Dijkstra's algorithm using priority queue
        int[] result = new int[n];                                  // Distance array to track minimum cost to each node
        Array.Fill(result, int.MaxValue);                           // Initialize all distances to infinity
        result[0] = 0;                                              // Starting node has distance 0

        PriorityQueue<(int distance, int node), int> pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((0, 0), 0);                                      // Enqueue (distance=0, sourceNode=0) with priority 0

        while (pq.Count > 0) {                                      // Process until priority queue is empty
            var (d, node) = pq.Dequeue();                           // Dequeue node with minimum distance

            if (node == n - 1)                                      // If reached destination node
                return result[node];                                // Return minimum cost to reach last node

            if (d > result[node]) continue;                         // Skip if already processed with better distance

            foreach (var (adjNode, dist) in adj[node]) {            // Explore all neighbors of current node
                if (d + dist < result[adjNode]) {                   // If found shorter path to neighbor
                    result[adjNode] = d + dist;                     // Update distance to neighbor
                    pq.Enqueue((d + dist, adjNode), d + dist);      // Add neighbor to priority queue with new distance
                }
            }
        }

        return -1;                                                  // Destination not reachable
    }
}