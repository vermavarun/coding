/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Queue, Binary Tree, Breadth-First Search
1. Initialize the result list
2. If the root is null, return the result list
3. Initialize the queue
4. Enqueue the root node
5. Iterate through the queue
6. Initialize the level list
7. Iterate through the queue
8. Dequeue the current node
9. Add the current node value to the level list
10. If the left child is not null, enqueue the left child
11. If the right child is not null, enqueue the right child
12. Add the level list to the result list
13. Return the result list

Time Complexity: O(?)
Space Complexity: O(?)
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