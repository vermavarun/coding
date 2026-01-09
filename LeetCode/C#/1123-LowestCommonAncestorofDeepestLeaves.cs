/*
Title: 1123. Lowest Common Ancestor of Deepest Leaves
Solution: https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/solutions/7480469/simplest-solution-c-time-on-spaceh-pleas-brnb/
Difficulty: Medium
Approach: DFS with Depth Tracking (Post-Order Traversal)
Tags: Tree, Binary Tree, DFS, Recursion, Depth, Lowest Common Ancestor
1) Use DFS to traverse tree and track depth of each subtree.
2) Return a tuple containing (depth, node) for each recursive call.
3) Base case: if node is null, return (0, null).
4) If left subtree deeper than right, return (leftDepth + 1, leftNode).
5) If right subtree deeper than left, return (rightDepth + 1, rightNode).
6) If both subtrees have equal depth, current node is LCA of deepest leaves.

Time Complexity: O(n) - visit each node once
Space Complexity: O(h) - recursion stack where h is tree height
Tip: Use post-order DFS to compare depths bottom-up. When both subtrees have equal depth, you've found the LCA of the deepest leaves. DFS is returning “How deep is the deepest leaf under me, and who is their LCA?”
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

    public TreeNode LcaDeepestLeaves(TreeNode root) {
        return DFS(root).node;                                          // Extract and return the LCA node from tuple
    }

    // “How deep is the deepest leaf under me, and who is their LCA?”
    private (int depth, TreeNode node) DFS(TreeNode root) {             // Returns (depth, LCA node) tuple

        if (root == null)                                               // Base case: reached null node
            return (0, null);                                           // Return depth 0 and null node

        var left = DFS(root.left);                                      // Recursively get left subtree depth and LCA
        var right = DFS(root.right);                                    // Recursively get right subtree depth and LCA

        if (left.depth > right.depth)                                   // Left subtree is deeper
            return (left.depth + 1, left.node);                         // Return left depth + 1, propagate left LCA

        if (right.depth > left.depth)                                   // Right subtree is deeper
            return (right.depth + 1, right.node);                       // Return right depth + 1, propagate right LCA

        // equal depth → current node is LCA
        return (left.depth + 1, root);                                  // Both subtrees equal depth, current node is LCA
    }
}
