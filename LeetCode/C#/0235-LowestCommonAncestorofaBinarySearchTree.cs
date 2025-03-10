/*
Approach:
1. If the value of p and q is less than the value of the root, then the lowest common ancestor will be in the left subtree.
2. If the value of p and q is greater than the value of the root, then the lowest common ancestor will be in the right subtree.
3. Else, the root is the lowest common ancestor.
4. Recursively call the function with the left or right subtree based on the value of p and q.
5. Return the root if the value of p and q is less than the value of the root or greater than the value of the root.
6. Else, return the root.
7. If the root is null or p or q is null, return null.

Time complexity is O(h) where h is the height of the tree.
Space complexity is O(h) where h is the height of the tree.

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
        if (root == null || p == null || q == null) {           // if anyone is null return null
            return null;
        }
        if(p.val < root.val && q.val < root.val) {              // if both are less than root, then go to left subtree
            return LowestCommonAncestor(root.left, p , q);      // recursively call the function with left subtree
        }
        else if (p.val > root.val && q.val > root.val) {        // if both are greater than root, then go to right subtree
            return LowestCommonAncestor(root.right, p , q);     // recursively call the function with right subtree
        }
        else {
            return root;                                        // else return root
        }
    }
}