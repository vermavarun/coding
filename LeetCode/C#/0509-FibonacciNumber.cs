/*
Solution: 
Difficulty: Medium
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    int[]  fib = new int[31];
    public int Fib(int n) {

        fib[0] = 0;
        fib[1] = 1;
        int i  = 0;

        for( i=2 ; i<=n; i++ ) {
            fib[i] = fib[i-1] + fib[i-2];
        }
        return fib[n];
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////
///Approach 2: Recursion without Memoization
//////////////////////////////////////////////////////////////////////////////////////////////////////
public class Solution {
    public int Fib(int n) {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        return Fib(n-1) + Fib(n-2);
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////
///Approach 3: Recursion with Memoization
/*
1) Initialize an array memo of size n+1 to store the Fibonacci numbers.
2) Return memo[n] if this value has been computed before.
3) If not, use recursion to calculate the value, add it to memo, and return it.
4) The recursion uses memo to store and reuse the previously computed values to reduce the number of recursive calls.
5) The recursion has a time complexity of O(n) since each number, starting at 2 up to n, is computed once.
Space complexity is O(n) as well due to the usage of the memo array.
*/
//////////////////////////////////////////////////////////////////////////////////////////////////////
public class Solution {

    public int Fib(int n) {
        if (n == 0)                             // base case
            return 0;                           // base case
        if (n == 1)                             // base case
            return 1;                           // base case
        int[] dp = new int[31];                 // dp array to store the values
        for (int i=0; i<dp.Length;i++) {        // initialize the dp array with -1
            dp[i] = -1;                         // initialize the dp array with -1
        }
        return Solve(n-1,dp) + Solve(n-2,dp);   // call the recursive function
    }
    public int Solve(int n, int[] dp) {         // recursive function
        if (n == 0)                             // base case
            return 0;                           // base case
        if (n == 1)                             // base case
            return 1;                           // base case
        if(dp[n] != -1) {                       // if the value is already calculated
            return dp[n];                       // return the value
        }
        return Solve(n-1,dp) + Solve(n-2,dp);   // recursive call
    }
}