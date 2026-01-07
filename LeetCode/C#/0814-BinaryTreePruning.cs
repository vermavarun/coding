/*
Title: 814. Binary Tree Pruning
Solution: https://leetcode.com/problems/binary-tree-pruning/solutions/7475631/simplest-solution-c-time-on-spaceh-pleas-xb3k/
Difficulty: Medium
Approach: Post-Order DFS (Process Children First, Then Current Node)
Tags: Tree, Binary Tree, Depth-First Search, Recursion
1) Use post-order traversal to process subtrees before current node.
2) Recursively prune left and right subtrees first.
3) After pruning children, check if current node should be removed.
4) Remove node if: node value is 0 AND both children are null.
5) Return null to remove node, or return node to keep it.
6) This bottom-up approach ensures all 0-only subtrees are removed.

Time Complexity: O(n) where n = number of nodes in the tree
Space Complexity: O(h) where h = height of the tree (recursion stack)
Tip: Why post-order? Because you must decide whether to delete a node after knowing the fate of its children.

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
    public TreeNode PruneTree(TreeNode root) {

        if (root == null) return null;                              // Base case: if node is null, return null

        root.left = PruneTree(root.left);                           // Recursively prune left subtree (post-order)
        root.right = PruneTree(root.right);                         // Recursively prune right subtree (post-order)

        if (root.val == 0 && root.left == null && root.right == null) {    // If node is 0 and has no children
            return null;                                            // Remove this node by returning null
        }

        return root;                                                // Keep this node (has value 1 or has children)
    }
}
