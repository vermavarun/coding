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

        return true;
    }
}