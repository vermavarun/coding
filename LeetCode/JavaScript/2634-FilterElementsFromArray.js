/*

Approach:
- We can create a function that takes an array and a function as arguments.
- We can iterate over the array and apply the function to each element.
- We can return the new array.

Time complexity:
- O(n)

Space complexity:
- O(n)

*/
/**
 * @param {number[]} arr
 * @param {Function} fn
 * @return {number[]}
 */
var filter = function(arr, fn) {
    let res = [];

    for(let i in arr) {
        if(fn(arr[i],Number(i))) {
            res.push(arr[i]);
        }
    }

    return res;
};