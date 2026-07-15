/*
Title: 3658. GCD of Even and Odd Sums
Difficulty: Easy
Approach: Math - Sum Formulas and GCD Properties
Tags: Math
1) Sum of first n odd numbers equals n² (well-known identity).
2) Sum of first n even numbers equals n(n+1).
3) Compute gcd(n², n(n+1)).
4) Factor out n: gcd = n * gcd(n, n+1).
5) Consecutive integers are coprime, so gcd(n, n+1) = 1.
6) Therefore the answer is simply n.

Time Complexity: O(1) - pure math formula, no iteration needed
Space Complexity: O(1) - no extra space used
Tip: Recognize the patterns for sum of odd/even numbers, then use the property that gcd(k, k+1) = 1 for any integer k to simplify gcd(n², n(n+1)) = n.
Similar Problems: 2413. Smallest Even Multiple, 1979. Find Greatest Common Divisor of Array
*/
public class Solution {
    public int GcdOfOddEvenSums(int n) {
        // First n odd numbers:
        // 1, 3, 5, ..., (2n - 1)
        //
        // Sum of first n odd numbers:
        // = 1 + 3 + 5 + ... + (2n - 1)
        // = n²
        //
        // This is a well-known identity that can be proved by induction
        // or by observing that each new odd number increases the previous
        // perfect square:
        // 1 = 1²
        // 1 + 3 = 4 = 2²
        // 1 + 3 + 5 = 9 = 3²
        // ...

        // First n even numbers:
        // 2, 4, 6, ..., 2n
        //
        // Sum:
        // = 2(1 + 2 + ... + n)
        // = 2 * n(n + 1) / 2
        // = n(n + 1)

        // Therefore we need:
        // gcd(n², n(n + 1))
        //
        // Factor out n:
        // = n * gcd(n, n + 1)
        //
        // Consecutive integers are always coprime:
        // gcd(n, n + 1) = 1
        //
        // Hence:
        // gcd(n², n(n + 1)) = n

        return n;
    }
}