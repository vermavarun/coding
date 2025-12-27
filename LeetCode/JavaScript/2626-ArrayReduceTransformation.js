/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array
1. Initialize a variable res with the initial value.
2. Iterate through the array and apply the function fn on the current element and the result.
3. Update the result with the new value.
4. Return the result.
Space complexity: O(1)

*/

/**
 * @param {number[]} nums
 * @param {Function} fn
 * @param {number} init
 * @return {number}
 */
var reduce = function(nums, fn, init) {
    let res = init;
    for(const n of nums) {
        res = fn(res,n)
    }
    return res;
};
