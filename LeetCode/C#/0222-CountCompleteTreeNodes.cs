/*
Title: 222. Count Complete Tree Nodes
Solution: https://leetcode.com/problems/count-complete-tree-nodes/solutions/7576227/simplest-solution-c-time-on-space-on-ple-b8jr/
Difficulty: Easy
Approach: Recursive DFS Traversal
Tags: Binary Tree, Depth-First Search, Tree Traversal, Complete Binary Tree
1) Base case: If root is null, return 0 (empty tree has 0 nodes).
2) Recursively count nodes in the left subtree.
3) Recursively count nodes in the right subtree.
4) Return 1 (current node) + left subtree count + right subtree count.
5) The recursion naturally traverses the entire tree and counts all nodes.

Time Complexity: O(n) where n = number of nodes in the tree (visits each node once)
Space Complexity: O(h) where h = height of the tree (recursion stack depth)
Tip: While this solution works for any binary tree, you could optimize for complete binary trees by checking if left and right heights are equal. If they are, the left subtree is perfect and you can use the formula 2^h - 1. This optimization can achieve O(log²n) time complexity for complete trees.
Similar Problems: 104. Maximum Depth of Binary Tree, 110. Balanced Binary Tree, 958. Check Completeness of a Binary Tree
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
    public int CountNodes(TreeNode root) {
        if (root == null)                                      // Base case: empty tree has no nodes
            return 0;
        int leftChildrenCount = CountNodes(root.left);         // Recursively count all nodes in left subtree
        int rightChildrenCount = CountNodes(root.right);       // Recursively count all nodes in right subtree

        return 1 + leftChildrenCount + rightChildrenCount;     // Return 1 (current node) + left count + right count
    }
}