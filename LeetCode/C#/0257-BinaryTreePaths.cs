/*
Title: 257. Binary Tree Paths
Solution: https://leetcode.com/problems/binary-tree-paths/solutions/7583013/simplest-solution-c-time-on-space-oh-ple-0iaw/
Difficulty: Easy
Approach: Depth-First Search (DFS) with Path Tracking
Tags: Tree, Depth-First Search, Binary Tree, String, Backtracking
1) Use DFS to traverse the tree from root to all leaf nodes.
2) Maintain a path string that tracks the current path from root.
3) For each node visited, append its value to the current path.
4) Base case: If node is null, return immediately.
5) If current node is a leaf (no left or right child), add the complete path to result.
6) Recursively explore left and right subtrees with the updated path.
7) Path is built as: "node1->node2->...->leafNode".
8) Return the list of all root-to-leaf paths.

Time Complexity: O(n) where n = number of nodes (visit each node once)
Space Complexity: O(h) where h = height of tree (recursion call stack depth)
Tip: This is a classic DFS backtracking problem. The key is to build the path as you traverse and only add it to results when you reach a leaf node. Since strings are immutable in C#, passing the path as a parameter naturally handles backtracking - each recursive call gets its own copy of the path up to that point.
Similar Problems: 113. Path Sum II, 988. Smallest String Starting From Leaf, 129. Sum Root to Leaf Numbers, 437. Path Sum III
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    List<string> result;                                       // Store all root-to-leaf paths
    public IList<string> BinaryTreePaths(TreeNode root) {
        result = new List<string>();                           // Initialize result list
        DFS(root,"");                                          // Start DFS from root with empty path
        return result;                                         // Return all paths found
    }
    private void DFS(TreeNode root, string path) {
        if (root == null)                                      // Base case: null node, return
            return;

        // Build path
        if (path == "")                                        // If path is empty (root node)
            path = root.val.ToString();                        // Start path with root value
        else                                                   // If path already has values
            path = path + "->" + root.val;                     // Append current node with arrow notation

        // If leaf node → add to result
        if (root.left == null && root.right == null) {         // Check if current node is a leaf
            result.Add(path);                                  // Add complete root-to-leaf path to result
            return;                                            // Backtrack (return from this path)
        }

        DFS(root.left,path);                                   // Recursively explore left subtree with current path
        DFS(root.right,path);                                  // Recursively explore right subtree with current path
    }
}