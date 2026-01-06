/*
Title: 501. Find Mode in Binary Search Tree
Solution: https://leetcode.com/problems/find-mode-in-binary-search-tree/solutions/7471900/simplest-solution-c-time-on-spaceh-pleas-8xgz/
Difficulty: Easy
Approach: In-Order Traversal with Frequency Tracking
Tags: Tree, Binary Search Tree, Depth-First Search, In-Order Traversal
1) Use in-order traversal to visit BST nodes in sorted order.
2) Track the previous node value to detect consecutive duplicates.
3) Count frequency of current value being processed.
4) Maintain maximum frequency seen so far.
5) When a new maximum frequency is found, clear result list and add current value.
6) When frequency equals maximum, add current value to result list.
7) Update previous value and continue traversal.

Time Complexity: O(n) where n = number of nodes in the tree
Space Complexity: O(h) where h = height of the tree (recursion stack)
*/
public class Solution {

    private int? prev = null;                                       // Store previous node value to detect duplicates
    private int currentFrequency = 0;                               // Track frequency of current value
    private int maxFrequency = 0;                                   // Track maximum frequency found so far
    private List<int> result = new List<int>();                     // Store all values with maximum frequency

    public int[] FindMode(TreeNode root) {
        InOrderTraversal(root);                                     // Perform in-order traversal to visit nodes in sorted order
        return result.ToArray();                                    // Convert result list to array and return
    }

    private void InOrderTraversal(TreeNode root) {
        if (root == null) return;                                   // Base case: if node is null, return

        InOrderTraversal(root.left);                                // Visit left subtree first (in-order)

        // Handle frequency
        if (prev == null || root.val != prev) {                     // If first node or value changed
            currentFrequency = 1;                                   // Reset frequency to 1
        } else {                                                    // If value same as previous
            currentFrequency++;                                     // Increment frequency
        }

        // Update result
        if (currentFrequency > maxFrequency) {                      // If current frequency is new maximum
            maxFrequency = currentFrequency;                        // Update maximum frequency
            result.Clear();                                         // Clear previous results
            result.Add(root.val);                                   // Add current value as new mode
        }
        else if (currentFrequency == maxFrequency) {                // If current frequency equals maximum
            result.Add(root.val);                                   // Add current value to modes list
        }

        prev = root.val;                                            // Update previous value for next comparison

        InOrderTraversal(root.right);                               // Visit right subtree last (in-order)
    }
}
