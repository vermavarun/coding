/*
Solution: 
Difficulty: Easy
Approach: Recursive
Tags: Binary Tree, Binary Search, Recursion
1. Check if the root is null, return true
2. Check if the root value is greater than the left value and less than the right value
3. Recursively check the left and right nodes
4. If all the nodes satisfy the above conditions, return true
5. Otherwise, return false

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
    public bool IsValidBST(TreeNode root) {
        return IsValidNode(root, long.MinValue, long.MaxValue);                                 // Check if the root is a valid node
    }

    public bool IsValidNode(TreeNode node, long left, long right) {
        if (node == null)                                                                       // Check if the root is null, return true
            return true;                                                                        // If the root is null, return true

        if (!(left < node.val && node.val < right))                                             // Check if the root value is greater than the left value and less than the right value
            return false;                                                                       // If the root value is not greater than the left value and less than the right value, return false

        return IsValidNode(node.left,left,node.val) && IsValidNode(node.right,node.val,right);  // Recursively check the left and right nodes
    }
}