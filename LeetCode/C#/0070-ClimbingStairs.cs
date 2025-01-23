/*
Approach: Recursion with Memoization
1. If n is 0, then there is only 1 way to climb the stairs.
2. If n is less than 0, then there is no way to climb the stairs.
3. If dp[n] is not -1, then return dp[n].
4. Otherwise, return FindClimbStairs(n-1,dp) + FindClimbStairs(n-2,dp).
5. FindClimbStairs is a recursive function which calculates the number of ways to climb the stairs.
6. If n is 0, then there is only 1 way to climb the stairs.
7. If n is less than 0, then there is no way to climb the stairs.
8. If dp[n] is not -1, then return dp[n].
9. Otherwise, return FindClimbStairs(n-1,dp) + FindClimbStairs(n-2,dp).
10. dp[n] is set to FindClimbStairs(n-1,dp) + FindClimbStairs(n-2,dp).
11. Return dp[n].

Time complexity: O(n)
Space complexity: O(n)

*/
public class Solution {
    public int ClimbStairs(int n) {
        if (n==0) {                                                     // base case you reached the top
            return 1;                                                   // there is only 1 way to reach the top
        }
        if (n < 0) {                                                    // base case you went above the top
            return 0;                                                   // there is no way to reach the top
        }
        int[] dp = new int[n+1];                                        // create a dp array of size n+1
        for(int i=0;i<dp.Length;i++) {                                  // iterate through the dp array
            dp[i] = -1;                                                 // set all the values to -1
        }
        if(dp[n] != -1) {                                               // if dp[n] is not -1
            return dp[n];                                               // return dp[n]
        }
        return FindClimbStairs(n-1,dp) + FindClimbStairs(n-2,dp);       // return the number of ways to climb the stairs
    }

    public static int FindClimbStairs(int n, int[] dp) {                // recursive function to calculate the number of ways to climb the stairs
        if (n==0) {                                                     // base case you reached the top
            return 1;                                                   // there is only 1 way to reach the top
        }
        if (n < 0) {                                                    // base case you went above the top
            return 0;                                                   // there is no way to reach the top
        }
        if(dp[n] != -1) {                                               // if dp[n] is not -1
            return dp[n];                                               // return dp[n]
        }
        dp[n] = FindClimbStairs(n-1,dp) + FindClimbStairs(n-2,dp);      // set dp[n] to the number of ways to climb the stairs
        return dp[n];                                                   // return dp[n]
    }
}