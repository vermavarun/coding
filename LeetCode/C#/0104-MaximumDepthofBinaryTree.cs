/*
Solution: 
Difficulty: Medium
Approach: Recursive
Tags: Binary Tree, Recursion, Depth-First Search
1. Call the MaxDepth method with the root and the result
2. CalculateDepth method:
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
    public int MaxDepth(TreeNode root) {
        int result = 0;                                                     // declare the result
        result = CalculateDepth(root, result);                              // call the CalculateDepth method with the root and the result
        return result;                                                      // return the result
    }

    public static int CalculateDepth(TreeNode root, int result) {           // declare the CalculateDepth method
        if (root == null) {                                                 // check if the root is null
            return 0;                                                       // return 0
        }
        int leftHeight = CalculateDepth(root.left, result);                 // call the CalculateDepth method with the left child of the root
        int rightHeight = CalculateDepth(root.right, result);               // call the CalculateDepth method with the right child of the root
        return rightHeight > leftHeight ? rightHeight + 1 : leftHeight + 1; // return the maximum of the leftHeight and rightHeight + 1
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
Approach: Iterative
TODO
*/