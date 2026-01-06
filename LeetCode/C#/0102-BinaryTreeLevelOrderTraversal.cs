/*
Title: 102. Binary Tree Level Order Traversal
Solution: https://leetcode.com/problems/binary-tree-level-order-traversal/solutions/6527012/simplest-solution-c-time-on-spacen-pleas-w5cs/
Difficulty: Medium
Approach: BFS using Queue for level-by-level traversal
Tags: Tree, Breadth-First Search, Binary Tree
1) Initialize result list to store all levels.
2) Handle edge case: if root is null, return empty result.
3) Create a queue and enqueue the root node.
4) While queue is not empty, process current level:
   - Create a list for current level values.
   - Get count of nodes at current level.
   - For each node in current level:
     * Dequeue node and add its value to level list.
     * Enqueue left child if it exists.
     * Enqueue right child if it exists.
5) Add completed level list to result.
6) Return result containing all levels.

Time Complexity: O(n) where n = number of nodes in the tree
Space Complexity: O(n) for the queue and result list
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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();  // Initialize the result list
        if (root == null) return result;                    // If the root is null, return the result list

        Queue<TreeNode> queue = new Queue<TreeNode>();      // Initialize the queue
        queue.Enqueue(root);                                // Enqueue the root node

        while (queue.Count > 0) {                           // Iterate through the queue
            IList<int> level = new List<int>();             // Initialize the level list
            for(int i=queue.Count; i>0; i--) {              // Iterate through the queue
                TreeNode current = queue.Dequeue();         // Dequeue the current node
                level.Add(current.val);                     // Add the current node value to the level list
                if(current.left != null)                    // If the left child is not null, enqueue the left child
                    queue.Enqueue(current.left);            // Enqueue the left child
                if(current.right != null)                   // If the right child is not null, enqueue the right child
                    queue.Enqueue(current.right);           // Enqueue the right child

            }
            result.Add(level);                              // Add the level list to the result list
        }
        return result;                                      // Return the result list
    }
}