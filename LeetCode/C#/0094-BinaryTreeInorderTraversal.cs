/*
Approach: Recursive
1. Create a list of integers to store the result
2. Call the Traverse method with the root and the result list
3. Return the result list
4. Traverse method:
    a. Check if the root is null
    b. Call the Traverse method with the left child of the root and the result list
    c. Add the value of the root to the result list
    d. Call the Traverse method with the right child of the root and the result list

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
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();                        // declare the result list
        Traverse(root, result);                                     // call the Traverse method with the root and the result list
        return result;                                              // return the result list
    }
    public static void Traverse(TreeNode root, IList<int> result) { // declare a Traverse method
        if(root == null) {                                          // check if the root is null
            return ;                                                // return
        }
        Traverse(root.left, result);                                // call the Traverse method with the left child of the root
        result.Add(root.val);                                       // add the value of the root to the result list
        Traverse(root.right, result);                               // call the Traverse method with the right child of the root
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/*
Approach: Iterative
TODO
*/