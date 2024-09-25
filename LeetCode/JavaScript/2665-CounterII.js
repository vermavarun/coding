/**

Approach:
- We can create a function that returns an object with three functions: increment, decrement, and reset.
- We can use the closure property of JavaScript to achieve this.

Time complexity:
- O(1)

Space complexity:
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