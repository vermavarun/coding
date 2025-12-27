/*
Solution: https://leetcode.com/problems/fizz-buzz/solutions/7175850/simplest-solution-c-time-on-spacen-pleas-rk09/
Difficulty: Medium
Approach: Iteration with Modulo Operations
Tags: Array, Math, String Manipulation
1) Initialize a list to store results for numbers 1 to n.
2) Iterate through each number from 1 to n.
3) If divisible by both 3 and 5 (i.e., 15), add "FizzBuzz".
4) If divisible by 3 only, add "Fizz".
5) If divisible by 5 only, add "Buzz".
6) Otherwise, add the number as a string.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public IList<string> FizzBuzz(int n) {
        var result = new List<string>(n);                       // Initialize result list with capacity n

        for (int i = 1; i <= n; i++) {                         // Iterate from 1 to n inclusive
            if (i % 15 == 0) {                                 // If divisible by both 3 and 5
                result.Add("FizzBuzz");                         // Add "FizzBuzz"
            } else if (i % 3 == 0) {                           // If divisible by 3 only
                result.Add("Fizz");                             // Add "Fizz"
            } else if (i % 5 == 0) {                           // If divisible by 5 only
                result.Add("Buzz");                             // Add "Buzz"
            } else {                                           // If not divisible by 3 or 5
                result.Add(i.ToString());                       // Add number as string
            }
        }

        return result;                                          // Return the FizzBuzz result list
    }
}
