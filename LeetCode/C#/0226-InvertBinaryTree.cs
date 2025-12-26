/*
Solution: 
Difficulty: Easy
Approach: Recursive
Tags: Binary Tree, Recursion
1. Call the Invert method with the root
2. Return the root
3. Invert method:
Space complexity: O(1)

Time Complexity: O(?)
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
    public TreeNode InvertTree(TreeNode root) {
        Invert(root);                           // call invert tree method
        return root;                            // return the root
    }
    public static void Invert(TreeNode root) {  // declare the invert method
        if (root == null) {                     // check if the root is null
            return;                             // return
        }
        Invert(root.left);                      // call the invert method with the left child of the root
        Invert(root.right);                     // call the invert method with the right child of the root
        TreeNode temp;                          // declare a temp variable
        temp = root.left;                       // swap the left and right child of the root
        root.left = root.right;                 // swap the left and right child of the root
        root.right = temp;                      // swap the left and right child of the root
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
Approach: Iterative
TODO
*/