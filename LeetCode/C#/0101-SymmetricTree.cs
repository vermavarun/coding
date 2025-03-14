/*
Approach:
1. Check if the tree is symmetric or not.
2. If the tree is null, return true.
3. Call the helper function IsInverted with left and right nodes of the root.
4. In the helper function, check if both left and right nodes are null, return true.
5. If any one of the left or right nodes is null, return false.
6. Check if the values of left and right nodes are equal.
7. Call the helper function recursively with left.right and right.left nodes.
8. Call the helper function recursively with left.left and right.right nodes.
9. Return the result of the above two recursive calls.

Time Complexity: O(n)
Space Complexity: O(n)

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
    public bool IsSymmetric(TreeNode root) {
        return IsInverted(root.left, root.right);                   // Call the helper function with left and right nodes of the root.
    }

    public bool IsInverted(TreeNode left, TreeNode right) {

        if (left == null && right == null)                          // If both left and right nodes are null, return true.
            return true;

        if (left == null || right == null)                          // If any one of the left or right nodes is null,
            return false;                                           // return false.

        return left.val == right.val &&                             // Check if the values of left and right nodes are equal.
                IsInverted(left.right,right.left) &&                // Call the helper function recursively with left.right and right.left nodes.
                IsInverted(left.left, right.right);                 // Call the helper function recursively with left.left and right.right nodes.

    }
}