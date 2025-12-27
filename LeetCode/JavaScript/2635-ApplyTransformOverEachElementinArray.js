/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array
1) [Step 1]
2) [Step 2]

*/
/**
 * @param {number[]} arr
 * @param {Function} fn
 * @return {number[]}
 */
var map = function(arr, fn) {

    let res = []

    for(let i in arr) {
        res[i] = fn(arr[i],Number(i));
    }
    return res;

};