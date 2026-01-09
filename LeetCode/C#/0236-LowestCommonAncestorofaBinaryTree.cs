/*
Title: 236. Lowest Common Ancestor of a Binary Tree
Solution: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/solutions/7480182/simplest-solution-c-time-on-spaceh-pleas-5o37/
Difficulty: Medium
Approach: Recursive DFS (Depth-First Search)
Tags: Tree, Binary Tree, DFS, Recursion, Lowest Common Ancestor
1) Use recursive DFS to traverse the tree and search for nodes p and q.
2) Base case: if root is null or equals p or q, return root.
3) Recursively search in left and right subtrees.
4) If both left and right return non-null, current root is the LCA (p and q in different subtrees).
5) If only one side returns non-null, that side contains both nodes, so return that result.
6) If both sides return null, neither p nor q is in this subtree.

Time Complexity: O(n) - visit each node once in worst case
Space Complexity: O(h) - recursion stack depth where h is tree height
Tip: The key insight is that if p and q are in different subtrees, the current node is their LCA. Otherwise, the LCA is in the subtree that returns non-null.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        return LCA(root, p, q);                                         // Call helper function to find LCA
    }

    private TreeNode LCA(TreeNode root, TreeNode p, TreeNode q) {

        // Base case
        if (root == null || root == p || root == q)                     // If null or found p or q
            return root;                                                // Return current node (null or found node)

        TreeNode left = LCA(root.left, p, q);                           // Recursively search left subtree
        TreeNode right = LCA(root.right, p, q);                         // Recursively search right subtree

        // If both sides return non-null, root is LCA
        if (left != null && right != null)                              // p and q found in different subtrees
            return root;                                                // Current root is the LCA

        // Otherwise return the non-null child
        return left != null ? left : right;                             // Return whichever subtree has results (or null if neither)
    }
}