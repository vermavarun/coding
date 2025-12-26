/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array
1. Return a function that takes a value x as input.
2. Iterate through the functions in reverse order and apply each function on x.
3. Return the final value.
Space complexity: O(1)

*/

/**
 * @param {Function[]} functions
 * @return {Function}
 */
var compose = function(functions) {

    return function(x) {

        for (const fn of functions.reverse()) {
            x = fn(x);
        }

        return x;
    }
};

/**
 * const fn = compose([x => x + 1, x => 2 * x])
 * fn(4) // 9
 */