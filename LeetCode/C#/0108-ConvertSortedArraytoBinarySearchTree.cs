/*
Title: 108. Convert Sorted Array to Binary Search Tree
Solution: https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/solutions/7565725/simplest-solution-c-time-on-space-olog-n-6p30/
Difficulty: Easy
Approach: Recursive Binary Tree Construction with Middle Element as Root
Tags: Array, Divide and Conquer, Tree, Binary Search Tree, Binary Tree
1) Use recursive approach to build balanced BST from sorted array.
2) Find the middle element of the current subarray to use as root.
3) Middle element ensures height balance (equal elements on left and right).
4) Recursively build left subtree using left half of array.
5) Recursively build right subtree using right half of array.
6) Base case: if left > right, return null (no elements to process).

Time Complexity: O(n) where n = nums.length, visit each element once
Space Complexity: O(log n) for recursion stack in balanced tree
Tip: The key insight is that choosing the middle element as root guarantees a height-balanced BST. Since the array is sorted, elements to the left are smaller and elements to the right are larger, satisfying BST property. The divide-and-conquer approach naturally creates balanced subtrees.
Similar Problems: 109. Convert Sorted List to Binary Search Tree, 1008. Construct Binary Search Tree from Preorder Traversal, 110. Balanced Binary Tree
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
    // Main method to convert sorted array to height-balanced BST
    public TreeNode SortedArrayToBST(int[] nums) {
        return BuildBST(nums,0,nums.Length-1);                      // Start with full array range
    }

    // Recursive helper method to build BST from array segment
    private TreeNode BuildBST(int[] nums,int left, int right){
        if (left > right)                                           // Base case: no elements in range
            return null;                                            // Return null for empty subtree

        int mid = left + (right - left) / 2;                        // Find middle index (avoids overflow)

        TreeNode root = new TreeNode(nums[mid]);                    // Create root with middle element
        root.left = BuildBST(nums, left, mid - 1);                  // Recursively build left subtree
        root.right = BuildBST(nums, mid+1, right);                  // Recursively build right subtree

        return root;                                                // Return constructed subtree
    }
}