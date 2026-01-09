/*
Title: 865. Smallest Subtree with all the Deepest Nodes
Solution: https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/solutions/7480664/simplest-solution-c-time-on-spaceh-pleas-txjp/
Difficulty: Medium
Approach: DFS with Depth Tracking (Post-Order Traversal)
Tags: Tree, Binary Tree, DFS, Recursion, Depth, Lowest Common Ancestor
1) Use DFS to traverse tree and track depth of each subtree.
2) Return a tuple containing (depth, node) for each recursive call.
3) Base case: if node is null, return (0, null).
4) If left subtree deeper than right, return (leftDepth + 1, leftNode).
5) If right subtree deeper than left, return (rightDepth + 1, rightNode).
6) If both subtrees have equal depth, current node is the smallest subtree containing all deepest nodes.

Time Complexity: O(n) - visit each node once
Space Complexity: O(h) - recursion stack where h is tree height
Tip: This is identical to problem 1123! When both subtrees have equal depth, the current node is the root of the smallest subtree containing all deepest nodes.
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
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        return DFS(root).node;                                          // Extract and return the subtree root from tuple
    }
    private (int depth, TreeNode node) DFS(TreeNode root) {             // Returns (depth, subtree root) tuple

        if (root == null)                                               // Base case: reached null node
            return (0, null);                                           // Return depth 0 and null node

        var left = DFS(root.left);                                      // Recursively get left subtree depth and result
        var right = DFS(root.right);                                    // Recursively get right subtree depth and result

        if (left.depth > right.depth)                                   // Left subtree is deeper
            return (left.depth + 1, left.node);                         // Return left depth + 1, propagate left result

        if (right.depth > left.depth)                                   // Right subtree is deeper
            return (right.depth + 1, right.node);                       // Return right depth + 1, propagate right result

        // equal depth → current node is LCA
        return (left.depth + 1, root);                                  // Both subtrees equal depth, current node is smallest subtree root
    }
}