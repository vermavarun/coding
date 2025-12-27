/*
Solution: https://leetcode.com/problems/sort-by/solutions/7385305/simplest-solution-javascript-time-on-log-auxs/
Difficulty: Medium
Approach: Custom Sorting with Function-Based Comparison
Tags: JavaScript, Array Sorting, Higher-Order Functions
1) Use the built-in sort() method with a custom comparator function.
2) Apply the given function fn to both elements being compared.
3) Return the difference fn(a) - fn(b) to determine sort order.
4) Positive result means a comes after b, negative means a comes before b.

Time Complexity: O(n log n)
Space Complexity: O(log n) for the sorting algorithm
*/

/**
 * @param {Array} arr
 * @param {Function} fn
 * @return {Array}
 */
var sortBy = function(arr, fn) {
    return arr.sort((a,b) => fn(a) - fn(b));           // Sort array using custom function for comparison
};