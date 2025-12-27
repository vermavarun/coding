/*
Solution: 
Difficulty: Medium
Approach:
Tags: Algorithm
- O(1)
- O(1)

*/


/**
 * @param {integer} init
 * @return { increment: Function, decrement: Function, reset: Function }
 */
var createCounter = function(init) {
    let num = init;
    function increment() {
        return ++num;
    }
    function decrement() {
        return --num;
    }
    function reset() {
        num = init;
        return num;
    }

    return {
        increment:increment,
        decrement:decrement,
        reset:reset
    }
};

/**
 * const counter = createCounter(5)
 * counter.increment(); // 6
 * counter.reset(); // 5
 * counter.decrement(); // 4
 */