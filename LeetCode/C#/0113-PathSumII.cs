/*
Title: 113. Path Sum II
Solution: https://leetcode.com/problems/path-sum-ii/solutions/7583153/simplest-solution-c-time-on2-space-on-pl-w33q/
Difficulty: Medium
Approach: Depth-First Search (DFS) with Backtracking
Tags: Tree, Depth-First Search, Backtracking, Binary Tree
1) Use DFS to explore all root-to-leaf paths in the tree.
2) Maintain a current path list to track nodes visited along the path.
3) Subtract each node's value from targetSum as we traverse down.
4) Base case: If node is null, return (invalid path).
5) Add current node to the path and reduce targetSum by node's value.
6) If targetSum becomes 0 AND we're at a leaf node, add path copy to results.
7) Recursively explore left and right subtrees with updated path and targetSum.
8) Backtrack by removing the last node from path before returning.
9) Return all valid root-to-leaf paths that sum to targetSum.

Time Complexity: O(n²) where n = number of nodes (visit each node once, copying paths takes O(n))
Space Complexity: O(h) where h = height of tree (recursion stack + path list)
Tip: This is a classic backtracking problem. Key points: (1) Add to result only when targetSum==0 AND at a leaf node, (2) Always create a new List when adding to result (new List<int>(list)) to avoid reference issues, (3) Backtrack by removing the last element after exploring both children. The backtracking step is crucial - it restores the path state for exploring other branches.
Similar Problems: 112. Path Sum, 257. Binary Tree Paths, 437. Path Sum III, 129. Sum Root to Leaf Numbers
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

    IList<IList<int>> result;                                  // Store all valid root-to-leaf paths

    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        result = new List<IList<int>>();                       // Initialize result list
        DFS(root,new List<int>(), targetSum);                  // Start DFS with empty path
        return result;                                         // Return all paths that sum to target
    }
    private void DFS(TreeNode root, List<int> list, int targetSum) {
        if (root == null)                                      // Base case: null node, return
            return;

        list.Add(root.val);                                    // Add current node value to path
        targetSum = targetSum - root.val;                      // Subtract current value from remaining sum
        if (targetSum == 0 && root.left == null && root.right == null)  // If sum reached and at leaf node
            result.Add(new List<int>(list));                   // Add copy of current path to result

        DFS(root.left, list, targetSum);                       // Recursively explore left subtree
        DFS(root.right, list, targetSum);                      // Recursively explore right subtree
        list.RemoveAt(list.Count - 1);                         // Backtrack: remove current node from path
    }
}