/*
Solution: https://leetcode.com/problems/power-of-three/solutions/7074870/simplest-solution-c-time-olog3-n-space1-ficms/
Approach: Iterative Division
Tags: Math, Iteration
1) If n is less than or equal to 0, it cannot be a power of three.
2) While n is divisible by 3, divide n by 3.
3) After the loop, if n is reduced to 1, it is a power of three.
4) Otherwise, it is not a power of three.

Time Complexity: O(log₃ n)
Space Complexity: O(1)
*/
public class Solution {
    public bool IsPowerOfThree(int n) {
        if (n <= 0)                         // Negative numbers and zero are not powers of three
            return false;
        while(n % 3 == 0) {                 // While n is divisible by 3
            n = n / 3;                      // Divide n by 3
        }
        return n == 1;                      // If n is reduced to 1, it's a power of three
    }
}