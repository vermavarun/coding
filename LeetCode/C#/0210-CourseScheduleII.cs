/*
Approach: Kahn's Algorithm
1. Create a graph with number of courses as nodes and prerequisites as edges.
2. Create an indegree array to store the indegree of each node.
3. Create a queue to store the nodes with 0 indegree.
4. Add all the nodes with 0 indegree to the queue.
5. Visit the adjacent nodes of the node with 0 indegree, reduce the indegree of the adjacent nodes by 1.
6. If the indegree of the adjacent node becomes 0, add it to the queue.
7. Repeat the process until the queue is empty.
8. If the number of nodes visited is equal to the number of courses, return true else return false.

Time complexity: O(V+E) where V is the number of courses and E is the number of prerequisites.
Space complexity: O(V+E) where V is the number of courses and E is the number of prerequisites.
*/
public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        List<int> order = new List<int>();                                              // Create order list
        List<List<int>> graph = new List<List<int>>();                                  // Create graph
        Queue<int> queue = new Queue<int>();                                            // Create queue
        int[] inDegree = new int[numCourses];                                           // Create indegree array

        int numCourseIndex = 0;                                                         // Variable to iterate through number of courses
        while(numCourseIndex++ < numCourses) {                                          // Add empty list for each course
            graph.Add(new List<int>());                                                 // Add empty list for each course
        }

        for (int i=0; i < prerequisites.Length; i++) {                                  // Add edges to the graph
            int course = prerequisites[i][0];                                           // Add edge from prereqCourse to courseTobeCompletedNode
            int coursePreq = prerequisites[i][1];                                       // Add edge from prereqCourse to courseTobeCompletedNode
            graph[coursePreq].Add(course);                                              // Add edge from prereqCourse to courseTobeCompletedNode
        }

        for (int i=0; i<prerequisites.Length; i++) {                                    // Calculate indegree of all nodes
            int course = prerequisites[i][0];                                           // Calculate indegree of all nodes
            inDegree[course]++;                                                         // Calculate indegree of all nodes
        }

        for (int i=0; i<inDegree.Length; i++) {                                         // Add all 0 indegree elements to queue
            if (inDegree[i] == 0) {                                                     // If the indegree of the node is 0
                queue.Enqueue(i);                                                       // Add the node to the queue
                order.Add(i);                                                           // Add the node to the order list
            }
        }

        while(queue.Count != 0) {                                                       // Visit adjacent nodes, remove nodes from queue and add.
            int courseP = queue.Dequeue();                                              // Dequeue the course
            foreach(int course in graph[courseP]) {                                     // Visit the adjacent nodes
                inDegree[course]--;                                                     // Reduce the indegree of the adjacent nodes by 1
                if (inDegree[course] == 0) {                                            // If the indegree of the adjacent node becomes 0
                    queue.Enqueue(course);                                              // Add the adjacent node to the queue
                    order.Add(course);                                                  // Add the adjacent node to the order list
                }
            }
        }

        return order.Count == numCourses ? order.ToArray() : new int [0];               // If the number of nodes visited is equal to the number of courses, return true else return false.
    }
}

/*
Approach: DFS
TODO
*/