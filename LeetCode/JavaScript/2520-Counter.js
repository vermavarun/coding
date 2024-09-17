/*

Approach:
- We can create a function that returns another function that returns a counter value when called.
- We can use the closure property of JavaScript to achieve this.

Time complexity:
- O(1)

Space complexity:
- O(1)

*/

/**
 * @param {number} n
 * @return {Function} counter
 */
var createCounter = function(n) {
    let num = n;
    return function() {
        return num++;
    };
};

/**
 * const counter = createCounter(10)
 * counter() // 10
 * counter() // 11
 * counter() // 12
 */