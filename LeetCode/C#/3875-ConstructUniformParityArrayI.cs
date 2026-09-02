/*
Title: 3875. Construct Uniform Parity Array I
Solution: Always possible
Difficulty: Easy
Approach: Parity transformation
Tags: Array, Math
1) If every number has the same parity, keep the array unchanged.
2) If both parities occur, choose an odd number as a reference.
3) Subtracting an odd number from an even number produces an odd number.
4) Convert each even number to odd while leaving odd numbers unchanged.
5) Therefore, a uniform-parity array can always be constructed.

Time Complexity: O(1)
Space Complexity: O(1)
Tip: The operation lets every even value become odd when an odd value exists; otherwise, the array is already uniform.
*/
public class Solution
{
    public bool UniformArray(int[] nums1)
    {
        /*
         * The answer is always true.
         *
         * We need to determine whether we can construct an array
         * where all elements have the same parity (all even or all odd).
         *
         * Consider every possible situation:
         *
         * 1. All numbers are already even
         *    -> Keep them unchanged.
         *    -> The array is already uniformly even.
         *
         * 2. All numbers are already odd
         *    -> Keep them unchanged.
         *    -> The array is already uniformly odd.
         *
         * 3. The array contains both even and odd numbers
         *    -> Choose any odd number as a reference.
         *
         *    For every even number:
         *
         *        even - odd = odd
         *
         *    So we can convert every even number into an odd number.
         *
         *    All numbers that are already odd can remain unchanged.
         *
         * Therefore, even in a mixed-parity array, we can make
         * every element odd.
         *
         * Since one of these three cases covers every possible input,
         * it is always possible to construct a uniform parity array.
         */

        return true; // A uniform-parity array can always be constructed.
    }
}