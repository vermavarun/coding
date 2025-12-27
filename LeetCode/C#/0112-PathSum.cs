/*
Solution: 
Difficulty: Medium
Approach:
Tags: Binary Tree, Recursion
1. If the root is null, return false.
2. Call the recursive function HasPathSumBelow with the root, targetSum, and currentSum as 0.
3. In the recursive function, if the node is null, return false.
4. Add the value of the current node to the currentSum.
5. If the node is a leaf node, check if the currentSum is equal to the targetSum. If yes, return true.
6. Otherwise, recursively call the function for the left and right children of the node.
7. Return the logical OR of the results from the left and right children.

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
    public bool HasPathSum(TreeNode root, int targetSum) {
        if (root == null) return false;                                             // if the root is null, return false
        return HasPathSumBelow(root, targetSum, 0);                                 // call the recursive function with the root, targetSum, and currentSum as 0
    }

    public bool HasPathSumBelow(TreeNode node, int targetSum, int currentSum) {
        if (node == null) return false;                                             // if the node is null, return false

        currentSum += node.val;                                                     // add the value of the current node to the currentSum

        if (node.left == null && node.right == null) {                              // if the node is a leaf node
            return targetSum == currentSum;                                         // check if the currentSum is equal to the targetSum
        }

        return HasPathSumBelow(node.left, targetSum, currentSum)                    // recursively call the function for the left and right children of the node
                || HasPathSumBelow(node.right, targetSum, currentSum);              // return the logical OR of the results from the left and right children
    }
}