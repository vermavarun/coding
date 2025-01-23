/*
Approach : Recursion with Memoization
1. Create a dp array of size nums.Length and fill it with -1
2. Call the RobWay method with nums, 0, and dp
3. In the RobWay method:
    a. Check if i >= nums.Length, if yes return 0
    b. Check if dp[i] != -1, if yes return dp[i]
    c. Calculate the rob amount by adding the current house amount and calling the RobWay method with nums, i+2, and dp
    d. Calculate the skip amount by calling the RobWay method with nums, i+1, and dp
    e. Return the maximum of rob and skip
4. Return the result
Time complexity: O(n)
Space complexity: O(n)
*/
public class Solution {
    public int Rob(int[] nums) {
        int[] dp = new int[nums.Length];                // create a dp array of size nums.Length
        Array.Fill(dp,-1);                              // fill the dp array with -1
        return RobWay(nums,0,dp);                       // call the RobWay method with nums, 0, and dp
    }
    public int RobWay(int[] nums, int i, int[] dp) {    // declare the RobWay method
        if(i >= nums.Length)                            // check if i >= nums.Length
            return 0;                                   // return 0
        if(dp[i] != -1)                                 // check if dp[i] != -1
            return dp[i];                               // return dp[i]
        int rob = nums[i] + RobWay(nums, i+2, dp);      // calculate the rob amount
        int skip = RobWay(nums, i+1, dp);               // calculate the skip amount
        return dp[i] = Math.Max(rob, skip);             // return the maximum of rob and skip
    }
}
///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
/*
Approach : Iterative with Constant Space (Optimized) (Bottom-Up)
TBU
*/
