/*
Solution: 
Difficulty: Easy
Approach: [To be documented]
Tags: Array
1) [Step 1]
2) [Step 2]

Time Complexity: O(?)
Space Complexity: O(?)
*/

/*
Solution: https://leetcode.com/problems/is-graph-bipartite/submissions/1587185288/
Approach : DFS
1. Create an array colors of size graph.Length and initialize it with 0.
2. Iterate through each node in the graph.
3. If the color of the node is 0 and DFS returns false, return false.
4. If DFS returns true for all the nodes, return true.
5. In the DFS function, if the color of the node is not 0, return true if the color is equal to the given color.
6. If the color of the node is 0, set the color of the node to the given color.
7. Iterate through each neighbor of the node and call the DFS function with the opposite color.
8. If the DFS function returns false, return false.
9. If the DFS function returns true for all the neighbors, return true.
Time complexity : O(V+E)
Space complexity : O(V)
*/
public class Solution {
    public bool IsBipartite(int[][] graph) {
        int[] colors = new int[graph.Length];                               // 1 -> Red, -1 -> Blue, 0 -> Not colored
        for (int i=0; i<graph.Length; i++) {                                // Iterate through each node in the graph
            if (colors[i] == 0 && !DFS(graph, colors, 1, i)) {              // If the color of the node is 0 and DFS returns false, return false
                return false;                                               // If DFS returns true for all the nodes, return true
            }
        }
        return true;                                                        // Return true
    }
    public bool DFS(int[][] graph, int[] colors, int color, int node) {     // DFS function
        if(colors[node] != 0) {                                             // If the color of the node is not 0
            return color == colors[node];                                   // Return true if the color is equal to the given color
        }
        colors[node] = color;                                               // Set the color of the node to the given color
        foreach(int neighbor in graph[node]) {                              // Iterate through each neighbor of the node
            if (!DFS(graph, colors, -color, neighbor)) {                    // Call the DFS function with the opposite color
                return false;                                               // If the DFS function returns false, return false
            }
        }
        return true;                                                        // If the DFS function returns true for all the neighbors, return true
    }
}
