/*
Solution: 
Difficulty: Medium
Approach:
Tags: Algorithm
1. Initialize a variable alreadyCalled with false.
2. Return a function which takes any number of arguments.
3. If alreadyCalled is false, set it to true and call the function with the arguments.
4. Otherwise, return undefined.
Time complexity: O(1)
Space complexity: O(1)

*/

/**
 * @param {Function} fn
 * @return {Function}
 */
var once = function(fn) {

    let alreadyCalled = false;

    return function(...args){
        if (!alreadyCalled)    {
            alreadyCalled = true;
            return fn(...args)
        }
    }
};

/**
 * let fn = (a,b,c) => (a + b + c)
 * let onceFn = once(fn)
 *
 * onceFn(1,2,3); // 6
 * onceFn(2,3,6); // returns undefined without calling fn
 */
