/*
Solution: 
Difficulty: Easy
Approach: Recursion
Tags: Binary Tree, Recursion
1. If both the nodes are null, then they are same, so return true.
2. If both the nodes are not null and their values are same, then check for left and right subtrees.
3. If any of the above conditions are not met, then return false.

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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        return IsTreeSame(p, q);                                                    // Call the helper function.
    }

    public static bool IsTreeSame(TreeNode p, TreeNode q) {                         // Helper function to check if the trees are same.
        if (p == null && q == null) {                                               // If both the nodes are null, then they are same, so return true.
            return true;                                                            // Return true.
        }
        if (p != null && q != null && q.val == p.val) {                             // If both the nodes are not null and their values are same, then check for left and right subtrees.
             return (IsTreeSame(p.left, q.left) && IsTreeSame(p.right, q.right));   // Check for left and right subtrees.
        }
        else {
            return false;                                                           // If any of the above conditions are not met, then return false.
        }
    }
}