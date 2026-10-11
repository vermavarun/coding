/*
Title: 2778. Sum of Squares of Special Elements
Solution: https://leetcode.com/problems/sum-of-squares-of-special-elements/solutions/8567398/simplest-solution-c-time-on-spacen-pleas-esdz/
Difficulty: Easy
Approach: Check which 1-based indices divide the array length
Tags: Array, Math
1) Store the length of the array.
2) Iterate through each element while tracking its 1-based index.
3) If the array length is divisible by the index, the element is special.
4) Add the square of each special element to the result.
5) Return the sum after checking all elements.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(1)
Tip: The problem uses 1-based indices, so the element at zero-based position i has index i + 1. An element is special when that index divides the array length evenly.
*/
public class Solution {
    public int SumOfSquares(int[] nums) {
        int result = 0;            // Sum of squares for special elements
        int n = nums.Length;       // Store the array length

        for(int i=0; i<n; i++) {   // Visit each element
            int index = i+1;       // Convert the zero-based position to a 1-based index

            if (n%index == 0) {    // The element is special if its index divides the length
                result+= nums[i]*nums[i]; // Add the square of this special element
            }
        }

        return result;             // Return the total
    }
}