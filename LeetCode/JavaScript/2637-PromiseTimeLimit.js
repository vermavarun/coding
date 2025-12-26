/*
Solution: 
Difficulty: Medium
Approach:
Tags: String
1) We can create a function that returns a function that resolves a promise after a certain amount of time.
2) We can use the setTimeout function to achieve this.
3) We can use the async and await keywords to make the function asynchronous.
4) We can use the Promise constructor to create a promise that resolves after a certain amount of time.
- O(1)
- O(1)

*/

/**
 * @param {Function} fn
 * @param {number} t
 * @return {Function}
 */
var timeLimit = function (fn, t) {

    return async function (...args) {

        return new Promise(async (resolve, reject) => {

            const setTimeId = setTimeout(() => reject("Time Limit Exceeded"), t);

            try {
                const result = await fn(...args);
                resolve(result);
            } catch (err) {
                reject(err);
            }

        });

    }
};

/**
 * const limited = timeLimit((t) => new Promise(res => setTimeout(res, t)), 100);
 * limited(150).catch(console.log) // "Time Limit Exceeded" at t=100ms
 */