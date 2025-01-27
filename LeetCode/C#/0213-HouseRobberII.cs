/*
Solution: https://leetcode.com/problems/house-robber-ii/solutions/6336237/simplest-solution-c-time-on-spacen-pleas-n0ta/

Approach : Dynamic Programming Recursion with Memoization (Top-Down)
1. Create a dp array of size 101
2. Call the RobWay method with nums, 0, and n-2
3. Call the RobWay method with nums, 1, and n-1
4. Return the maximum of start0 and start1
5. In the RobWay method:
    a. Check if i > size, if yes return 0
    b. Check if dp[i] != -1, if yes return dp[i]
    c. Calculate the rob amount by adding the current house amount and calling the RobWay method with nums, i+2, and size
    d. Calculate the skip amount by calling the RobWay method with nums, i+1, and size
    e. Return the maximum of rob and skip
Time complexity: O(n)
Space complexity: O(n)
*/
public class Solution {
    int[] dp = new int[101];                            // create a dp array of size 101

    public int Rob(int[] nums) {                        // declare the Rob method
        int n = nums.Length;                            // get the length of the nums array
        if (n == 1)                                     // check if n == 1
            return nums[0];                             // return the first element of the nums array
        if (n == 2)                                     // check if n == 2
            return Math.Max(nums[0], nums[1]);          // return the maximum of the first and second element of the nums array
        Array.Fill(dp,-1);                              // fill the dp array with -1
        int start0 = RobWay(nums, 0, n - 2);            // call the RobWay method with nums, 0, and n-2

        Array.Fill(dp,-1);                              // fill the dp array with -1
        int start1 = RobWay(nums, 1, n - 1);            // call the RobWay method with nums, 1, and n-1

        return Math.Max(start0,start1);                 // return the maximum of start0 and start1
    }
    public int RobWay(int[] nums, int i, int size) {    // declare the RobWay method
        if (i > size) {                                 // check if i > size
            return 0;                                   // return 0
        }
        if(dp[i] != -1) {                               // check if dp[i] != -1
            return dp[i];                               // return dp[i]
        }
        int rob = nums[i] + RobWay(nums, i+2, size);    // calculate the rob amount
        int skip = RobWay(nums, i+1, size);             // calculate the skip amount

        return dp[i] = Math.Max(rob, skip);             // return the maximum of rob and skip
    }
}
/*
Approach : Dynamic Programming Iterative with Constant Space (Bottom-Up)
TBD
*/