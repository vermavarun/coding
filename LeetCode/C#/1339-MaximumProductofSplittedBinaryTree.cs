/*
Title: 1339. Maximum Product of Splitted Binary Tree
Solution: https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/solutions/7474119/simplest-solution-c-time-on-spaceh-pleas-eh2k/
Difficulty: Medium
Approach: Two-Pass DFS (Calculate Total Sum, Then Find Max Product)
Tags: Tree, Binary Tree, Depth-First Search, Post-Order Traversal
1) First pass: Calculate total sum of all nodes in the tree.
2) Second pass: For each possible split (removing an edge), calculate subtree sum.
3) Product of split = subtree_sum * (total_sum - subtree_sum).
4) Track maximum product across all possible splits.
5) Return result modulo 10^9 + 7.

Time Complexity: O(n) where n = number of nodes in the tree
Space Complexity: O(h) where h = height of the tree (recursion stack)
*/
public class Solution {

    private long totalSum = 0;                                      // Store total sum of all nodes in the tree
    private long maxProduct = 0;                                    // Track maximum product found across all splits
    private const int MOD = 1_000_000_007;                          // Modulo value for result

    public int MaxProduct(TreeNode root) {
        // First pass: total sum
        GetTotalSum(root);                                          // Calculate total sum of all nodes

        // Second pass: compute max product
        GetSubtreeSum(root);                                        // Find maximum product by trying all splits

        return (int)(maxProduct % MOD);                             // Return result modulo 10^9 + 7
    }

    private void GetTotalSum(TreeNode root) {
        if (root == null) return;                                   // Base case: if node is null, return

        totalSum += root.val;                                       // Add current node's value to total sum
        GetTotalSum(root.left);                                     // Recursively process left subtree
        GetTotalSum(root.right);                                    // Recursively process right subtree
    }

    private long GetSubtreeSum(TreeNode root) {
        if (root == null) return 0;                                 // Base case: null node contributes 0 to sum

        long left = GetSubtreeSum(root.left);                       // Get sum of left subtree
        long right = GetSubtreeSum(root.right);                     // Get sum of right subtree

        long subTreeSum = left + right + root.val;                  // Calculate current subtree sum (left + right + current)

        long product = subTreeSum * (totalSum - subTreeSum);        // Calculate product if we split here (subtree * remaining)
        maxProduct = Math.Max(maxProduct, product);                 // Update maximum product if current is larger

        return subTreeSum;                                          // Return subtree sum for parent's calculation
    }
}
