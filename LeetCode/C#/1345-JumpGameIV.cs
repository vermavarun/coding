/*
Title: 1345. Jump Game IV
Solution: https://leetcode.com/problems/jump-game-iv/solutions/8269396/simplest-solution-c-time-on-space-on-ple-w1uz/
Difficulty: Hard
Approach: BFS (Breadth-First Search) on an implicit graph
Tags: Array, Hash Table, BFS
1) Build a graph mapping each value to all indices that contain that value.
2) Start BFS from index 0, tracking visited indices and current step count.
3) From each index i, explore 3 types of neighbors: i-1, i+1, and all indices with the same value (arr[i]).
4) After expanding a value group, clear it from the graph to prevent redundant re-visits (key optimization).
5) If index n-1 is reached, return the current step count.

Time Complexity: O(n) — each index is visited at most once; graph[u].Clear() prevents reprocessing
Space Complexity: O(n) for the graph, queue, and seen array
Tip: The critical optimization is clearing graph[u] after processing a value group. Without it, BFS degrades to O(n²) because the same large group gets re-explored from every node in it.
Similar Problems: 45. Jump Game II, 55. Jump Game, 1340. Jump Game V
*/
public class Solution {
    public int MinJumps(int[] arr) {
        int n = arr.Length;

        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();    // value -> list of indices with that value

        Queue<int> q = new Queue<int>();
        q.Enqueue(0);                                                           // Start BFS from index 0

        bool[] seen = new bool[n];
        seen[0] = true;

        // Build graph: map each value to all its indices
        for (int i = 0; i < n; i++) {
            if (!graph.ContainsKey(arr[i])) {
                graph[arr[i]] = new List<int>();
            }
            graph[arr[i]].Add(i);
        }

        for (int step = 0; q.Count > 0; step++) {                              // BFS level by level, step = jump count
            int size = q.Count;

            for (int s = 0; s < size; s++) {
                int i = q.Dequeue();

                if (i == n - 1)                                                 // Reached last index
                    return step;

                int u = arr[i];

                // Also explore left and right neighbors
                if (i + 1 < n)
                    graph[u].Add(i + 1);

                if (i - 1 >= 0)
                    graph[u].Add(i - 1);

                foreach (int v in graph[u]) {
                    if (seen[v])
                        continue;

                    seen[v] = true;
                    q.Enqueue(v);
                }

                graph[u].Clear();                                               // Clear to avoid re-processing same value group
            }
        }

        throw new ArgumentException();
    }
}