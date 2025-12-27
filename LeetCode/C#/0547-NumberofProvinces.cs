/*
Solution: https://leetcode.com/problems/number-of-provinces/solutions/6566544/simplest-solution-c-time-onn-spacen-plea-d53p/
Difficulty: Medium
Approach: Depth First Search
Tags: Array, Depth-First Search, Breadth-First Search
1. Create a list of visited nodes and initialize all nodes as not visited.
2. For each node, if it is not visited, call DFS and increment the number of provinces.
3. In DFS, mark the current node as visited and for all the nodes that are not visited and are connected to the current node, call DFS.
4. Return the number of provinces.
Time complexity: O(n^2)

Space Complexity: O(?)
*/
public class Solution {
    List<bool> visited = new List<bool>();                                              // List to store visited nodes
    public int FindCircleNum(int[][] isConnected) {                                     // Function to find the number of provinces
        int numOfProvinces = 0;                                                         // Variable to store the number of provinces
        for (int node=0; node<isConnected.Length; node++) {                             // Initialize all nodes as not visited
            visited.Add(false);                                                         // Add false to the list
        }
        for(int node=0; node<visited.Count; node++) {                                   // For each node, if it is not visited, call DFS and increment the number of provinces
            if (!visited[node]) {                                                       // If the node is not visited
                DFS(isConnected, visited, node);                                        // Call DFS
                numOfProvinces++;                                                       // Increment the number of provinces
            }
        }
        return numOfProvinces;                                                          // Return the number of provinces
    }

    public void DFS(int[][] isConnected, List<bool> visited, int currentNode) {         // Function to perform Depth First Search
        visited[currentNode] = true;                                                    // Mark the current node as visited
        for(int node=0; node<visited.Count; node++) {                                   // For all the nodes that are not visited and are connected to the current node, call DFS
            if (!visited[node] && isConnected[currentNode][node] == 1) {                // If the node is not visited and is connected to the current node
                DFS(isConnected, visited, node);                                        // Call DFS
            }
        }
    }
}

/*
Approach: BFS
TODO
*/