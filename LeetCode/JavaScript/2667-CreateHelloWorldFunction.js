/*

Approach:
- We can create a function that returns another function that returns "Hello World" when called.
- We can use the closure property of JavaScript to achieve this.

Time complexity:
- O(1)

Space complexity:
- O(1)

*/


/**
 * @return {Function}
 */
var createHelloWorld = function() {

    return function(...args) {
        return "Hello World"
    }
};

/**
 * const f = createHelloWorld();
 * f(); // "Hello World"
 */