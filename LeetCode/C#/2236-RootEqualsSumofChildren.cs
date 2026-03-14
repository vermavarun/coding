/*
Title: 2236. Root Equals Sum of Children
Solution: https://leetcode.com/problems/root-equals-sum-of-children/solutions/7591041/simplest-solution-c-time-o1-space-o1-ple-8kv8/
Difficulty: Easy
Approach: Direct value comparison
Tags: Tree, Binary Tree
1) Access the root node value.
2) Access the left and right child node values.
3) Compute the sum of both child values.
4) Compare root value with children sum.
5) Return true if equal; otherwise return false.

Time Complexity: O(1)
Space Complexity: O(1)
Tip: Since the problem guarantees exactly one root with two children, a single expression is enough.
Similar Problems: 617. Merge Two Binary Trees, 226. Invert Binary Tree
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
    public bool CheckTree(TreeNode root) {
        return root.val == root.left.val + root.right.val;        // Check if root equals sum of left and right children
    }
}