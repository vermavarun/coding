/*
Approach: Recursion
1. If the subRoot is null, then return true.
2. If the root is null, then return false.
3. If the root and subRoot are same, then return true.
4. Else, check for left and right subtrees.
5. If any of the above conditions are met, then return true.
6. Else, return false.

Time complexity: O(n*m), where n is the number of nodes in the root tree and m is the number of nodes in the subRoot tree.
Space complexity: O(n), where n is the number of nodes in the root tree. The space complexity is O(n) because the maximum depth of the recursion is the height of the tree, which is O(n) in the worst case and O(logn) in the best case.

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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (subRoot == null) {                                                                          // if subRoot is null, then return true.
            return true;                                                                                // return true.
        }
        if (root == null) {                                                                             // if root is null, then return false.
            return false;                                                                               // return false.
        }
        if (IsSametree(root, subRoot)) {                                                                // if root and subRoot are same, then return true.
            return true;                                                                                // return true.
        }
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);                         // check for left and right subtrees.
    }

    public static bool IsSametree(TreeNode root, TreeNode subRoot) {                                    // Helper function to check if the trees are same.
        if (root == null && subRoot == null) {                                                          // If both the nodes are null, then they are same, so return true.
            return true;                                                                                // Return true.
        }
        if (root != null && subRoot != null && root.val == subRoot.val) {                               // If both the nodes are not null and their values are same, then check for left and right subtrees.
                return IsSametree(root.left, subRoot.left) && IsSametree(root.right, subRoot.right);    // Check for left and right subtrees.
            }
        else {
            return false;                                                                               // If any of the above conditions are not met, then return false.
        }
    }
}
