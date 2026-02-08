/*
Title: 110. Balanced Binary Tree
Solution:
Difficulty: Easy
Approach: DFS with Height Tracking and Early Termination
Tags: Tree, Binary Tree, Depth-First Search, Recursion
1) Use a recursive helper function to calculate height while checking balance.
2) Base case: null node has height 0 (balanced by definition).
3) Recursively get the height of the left subtree.
4) If left subtree is unbalanced (height = -1), propagate failure upward.
5) Recursively get the height of the right subtree.
6) If right subtree is unbalanced (height = -1), propagate failure upward.
7) Check if current node is balanced: |left height - right height| ≤ 1.
8) If unbalanced, return -1 to signal failure to parent nodes.
9) If balanced, return actual height: max(left, right) + 1.
10) Final result: tree is balanced if root height != -1.

Time Complexity: O(n) where n = number of nodes (visit each node once)
Space Complexity: O(h) where h = height of tree (recursion stack)
Tip: The key optimization is using -1 as a sentinel value to signal imbalance. This allows early termination - once any subtree is found unbalanced, we propagate -1 upward without further computation. This avoids redundant height calculations in unbalanced trees.
Similar Problems: 104. Maximum Depth of Binary Tree, 111. Minimum Depth of Binary Tree, 543. Diameter of Binary Tree, 1448. Count Good Nodes in Binary Tree
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

    // Main function: Check if tree is balanced
    public bool IsBalanced(TreeNode root) {
        return Height(root) != -1;                          // Tree is balanced if Height() doesn't return -1 (failure signal)
    }

    // Helper function: Calculate height while checking balance
    private int Height(TreeNode node) {
        if (node == null) return 0;                         // Base case: null node has height 0

        int left = Height(node.left);                       // Recursively get left subtree height
        if (left == -1) return -1;                          // If left subtree unbalanced, propagate failure

        int right = Height(node.right);                     // Recursively get right subtree height
        if (right == -1) return -1;                         // If right subtree unbalanced, propagate failure

        if (Math.Abs(left - right) > 1)                     // Check if current node violates balance property
            return -1;                                      // Return -1 to signal this subtree is unbalanced

        return Math.Max(left, right) + 1;                   // Return actual height: max of children + 1 for current node
    }
}
