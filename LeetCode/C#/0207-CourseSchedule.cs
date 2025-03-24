/*
Solution: https://leetcode.com/problems/course-schedule/solutions/6572782/simplest-solution-c-time-ove-spaceve-ple-qdgk/
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
    public bool CanFinish(int numCourses, int[][] prerequisites) {

        List<List<int>> courseGraph = new List<List<int>>();                                    // Create graph
        Queue<int> zeroDegreeQueue = new Queue<int>();                                          // Create queue
        int[] indegree = new int[numCourses];                                                   // Create indegree array
        int nodesVisited = 0;                                                                   // Number of nodes visited
        int n = 0;                                                                              // Variable to iterate through number of courses

        // Create Graph

        // Create empty graph
        while (n < numCourses) {                                                                // Add empty list for each course
            courseGraph.Add(new List<int>());                                                   // Add empty list for each course
            n++;                                                                                // Increment n
        }

        // Add graph nodes
        for (int prerequisite=0; prerequisite<prerequisites.Length; prerequisite++) {           // Add edges to the graph
            // prereqCourse - > courseTobeCompletedNode
            int courseTobeCompletedNode = prerequisites[prerequisite][0];                       // Add edge from prereqCourse to courseTobeCompletedNode
            int prereqCourse = prerequisites[prerequisite][1];                                  // Add edge from prereqCourse to courseTobeCompletedNode
            courseGraph[prereqCourse].Add(courseTobeCompletedNode);                             // Add edge from prereqCourse to courseTobeCompletedNode
        }

        // Calculate indegree of all nodes
        for (int _prerequisite=0; _prerequisite<prerequisites.Length; _prerequisite++) {        // Calculate indegree of all nodes
            int indegreePrerequisite = prerequisites[_prerequisite][0];                         // Calculate indegree of all nodes
            indegree[indegreePrerequisite]++;                                                   // Calculate indegree of all nodes
        }

       // Add all 0 indegree elements to queue
       int indegreeIndex = 0;                                                                   // Variable to iterate through indegree array
       while (indegreeIndex < indegree.Length) {                                                // while indegreeIndex is less than indegree array length
            if (indegree[indegreeIndex] == 0) {                                                 // If the indegree of the node is 0
                nodesVisited++;                                                                 // Increment the number of nodes visited
                zeroDegreeQueue.Enqueue(indegreeIndex);                                         // Add the node to the queue
            }
            indegreeIndex++;                                                                    // Increment indegreeIndex
       }

       // Visit adjacent nodes, remove nodes from queue and add.
       while (zeroDegreeQueue.Count != 0) {                                                     // while queue is not empty
            int courseDequeued = zeroDegreeQueue.Dequeue();                                     // Dequeue the course
            foreach(int course in courseGraph[courseDequeued]) {                                // Visit the adjacent nodes
                indegree[course]--;                                                             // Reduce the indegree of the adjacent nodes by 1
                if (indegree[course] == 0) {                                                    // If the indegree of the adjacent node becomes 0
                    nodesVisited++;                                                             // Increment the number of nodes visited
                    zeroDegreeQueue.Enqueue(course);                                            // Add the adjacent node to the queue
                }
            }
       }
       return numCourses == nodesVisited;                                                       // If the number of nodes visited is equal to the number of courses, return true else return false
    }
}