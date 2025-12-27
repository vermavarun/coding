/*
Solution: 
Difficulty: Medium
Approach:
Tags: Algorithm
- O(1)
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