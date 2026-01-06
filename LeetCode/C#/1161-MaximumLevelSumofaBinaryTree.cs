/*
Title: 1161. Maximum Level Sum of a Binary Tree
Solution: https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/solutions/7471064/simplest-solution-c-time-on-spacew-pleas-g6o9/
Difficulty: Medium
Approach: BFS (Breadth-First Search) with Level Order Traversal
Tags: Tree, Binary Tree, BFS, Queue
1) Use BFS to traverse the tree level by level.
2) Track the current level number and the maximum sum found so far.
3) For each level, calculate the sum of all nodes at that level.
4) If current level sum is greater than max sum, update both max sum and result level.
5) Continue until all levels are processed.
6) Return the smallest level with maximum sum.

Time Complexity: O(n) where n = number of nodes in the tree
Space Complexity: O(w) where w = maximum width of the tree (for the queue)
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
    public int MaxLevelSum(TreeNode root) {

        int minLevel = 1;                                           // Store the level with maximum sum (result)
        int currentLevel = 1;                                       // Track current level being processed
        int maxLevelSum = int.MinValue;                             // Store maximum sum found so far (initialized to min value)

        Queue<TreeNode> queue = new Queue<TreeNode>();              // Queue for BFS traversal
        queue.Enqueue(root);                                        // Start with root node

        while (queue.Count > 0) {                                   // Process each level
            int levelSum = 0;                                       // Sum of all nodes at current level
            for (int i=queue.Count; i>0; i--) {                     // Process all nodes at current level
                TreeNode currentNode = queue.Dequeue();             // Get next node from queue
                levelSum += currentNode.val;                        // Add node's value to level sum
                if (currentNode.left != null) {                     // If left child exists
                    queue.Enqueue(currentNode.left);                // Add left child to queue for next level
                }
                if (currentNode.right != null) {                    // If right child exists
                    queue.Enqueue(currentNode.right);               // Add right child to queue for next level
                }
            }
            if (levelSum > maxLevelSum) {                           // If current level sum is greater than max
                maxLevelSum = levelSum;                             // Update maximum sum
                minLevel = currentLevel;                            // Update result level (smallest level with max sum)
            }

            currentLevel++;                                         // Move to next level
        }

        return minLevel;                                            // Return the level with maximum sum
    }
}