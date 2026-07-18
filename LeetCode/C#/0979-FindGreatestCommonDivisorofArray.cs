/*
Title: 1979. Find Greatest Common Divisor of Array
Solution: https://leetcode.com/problems/find-greatest-common-divisor-of-array/solutions/8405660/simplest-solution-c-time-on-space-o1-ple-cyl4/
Difficulty: Easy
Approach: Find min/max then apply Euclidean algorithm
Tags: Array, Math, Number Theory
1) Find the minimum and maximum values in the array.
2) Apply the Euclidean algorithm to compute GCD(min, max).
3) Euclidean algorithm: GCD(a, b) = GCD(b, a % b) until b == 0.
4) Return the GCD result.

Time Complexity: O(n + log(min)) where n is array length (for min/max scan) and log(min) for GCD
Space Complexity: O(1) — no extra space used
Tip: The GCD only needs to be computed between the smallest and largest elements since all other elements are irrelevant to the result. The Euclidean algorithm is the most efficient way to compute GCD.
Similar Problems: 858. Mirror Reflection, 914. X of a Kind in a Deck of Cards, 2447. Number of Subarrays With GCD Equal to K
*/
public class Solution {
    public int FindGCD(int[] nums) {
        int min = nums[0];                                          // Initialize min with first element
        int max = nums[0];                                          // Initialize max with first element

        foreach (int num in nums)                                   // Scan array to find min and max
        {
            if (num < min) min = num;                               // Update min if smaller value found
            if (num > max) max = num;                               // Update max if larger value found
        }

        return GCD(min, max);                                       // Return GCD of smallest and largest
    }

    private int GCD(int a, int b) {
        while (b != 0)                                              // Euclidean algorithm: repeat until remainder is 0
        {
            int temp = b;                                           // Store b before overwriting
            b = a % b;                                              // New b is remainder of a / b
            a = temp;                                               // New a is old b
        }
        return a;                                                   // a holds the GCD when b reaches 0
    }
}
