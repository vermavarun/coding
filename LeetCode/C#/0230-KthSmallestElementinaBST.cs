/*
Approach:
1) Create a list to store the inorder traversal items.
2) Call the InOrderTraversal method to traverse the tree in inorder fashion.
3) Return the kth smallest element from the list.
4) In the InOrderTraversal method, if the node is null, return.
5) Traverse the left subtree.
6) Add the current node value to the list.
7) Traverse the right subtree.

Time complexity: O(n)
Space complexity: O(n)

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
    List<int> inorderTraversalItems = new List<int>();  // Declare the list to hold inorder traversal items.
    public int KthSmallest(TreeNode root, int k) {
        InOrderTraversal(root);                         // Call the InOrderTraversal method.
        return inorderTraversalItems[k-1];              // Return the kth smallest element.
    }
    public void InOrderTraversal(TreeNode node) {
        if (node == null) return;                       // Base case.
        InOrderTraversal(node.left);                    // Traverse the left subtree.
        inorderTraversalItems.Add(node.val);            // Add the current node value to the list.
        InOrderTraversal(node.right);                   // Traverse the right subtree.
    }
}