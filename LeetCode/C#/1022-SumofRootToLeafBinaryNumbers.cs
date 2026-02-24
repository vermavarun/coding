/*
Title: 1022. Sum of Root To Leaf Binary Numbers
Solution: https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/solutions/7604426/simplest-solution-c-time-on-space-oh-ple-6utt/
Difficulty: Easy
Approach: DFS with binary value accumulation
Tags: Tree, Depth-First Search, Binary Tree
1) Start DFS from the root with an initial accumulated value of 0.
2) At each node, shift the current value left (multiply by 2) and add the node's bit: val = 2*val + root.val.
3) If the current node is a leaf (no left or right child), return the accumulated value.
4) Otherwise, recurse on both left and right subtrees.
5) Return the sum of results from both subtrees.
6) Return 0 for null nodes as the base case.

Time Complexity: O(n) where n = number of nodes in the tree
Space Complexity: O(h) where h = height of the tree (recursion call stack)
Tip: The key insight is that shifting left by 1 bit (multiply by 2) and adding the current node's value mirrors how binary numbers are built digit by digit from the most significant bit.
Similar Problems: 129. Sum Root to Leaf Numbers, 112. Path Sum, 113. Path Sum II
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
    public int SumRootToLeaf(TreeNode root) {
        return Solve(root, 0);                                      // Start DFS with initial binary value 0
    }
    private int Solve(TreeNode root, int val) {

        if (root == null) {                                         // Base case: null node contributes 0
            return 0;
        }

        val = 2 * val + root.val;                                   // Shift left by 1 bit and add current node's bit

        if (root.left == null && root.right == null) {              // Leaf node: return the complete binary number
            return val;
        }

        return Solve(root.left, val) + Solve(root.right, val);      // Sum of binary numbers from left and right subtrees
    }
}