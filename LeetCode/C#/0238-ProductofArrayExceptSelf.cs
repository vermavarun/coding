/*
Solution: 
Difficulty: Easy
Approach:
Tags: Array
1. Initialize preFix and postFix to 1.
2. Initialize an array res of the same length as nums.
3. Iterate through the array and update res[i] to preFix.
4. Update preFix to preFix * nums[i].
5. Iterate through the array in reverse and update res[i] to res[i] * postFix.
6. Update postFix to postFix * nums[i].
7. Return res.
Space complexity: O(1)

Time Complexity: O(?)
*/
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {

        int preFix = 1, postFix = 1;
        int[] res = new int[nums.Length];

        for (int i=0; i < nums.Length; i++) {
            res[i] = preFix;
            preFix = preFix * nums[i];
        }

        for (int i=nums.Length - 1; i >= 0; i--) {
            res[i] = res[i] * postFix;
            postFix = postFix * nums[i];
        }

        return res;
    }
}