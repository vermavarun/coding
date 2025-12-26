/*
Solution: Add Two Promises
Difficulty: Medium
Approach: Async/Await to Resolve Promises and Sum Values
Tags: JavaScript, Promises, Async/Await
1) Use async function to handle promises asynchronously.
2) Await the resolution of the first promise to get its value.
3) Await the resolution of the second promise to get its value.
4) Return the sum of both resolved values.
5) Alternative: Use Promise.all() to resolve both promises simultaneously.
Time Complexity: O(1) - depends on promise resolution time
Space Complexity: O(1)

Time Complexity: O(1) - depends on promise resolution time
Space Complexity: O(1)
*/

/**
 * @param {Promise} promise1
 * @param {Promise} promise2
 * @return {Promise}
 */
var addTwoPromises = async function(promise1, promise2) {
    const val1 = await promise1;                    // Await and get value from first promise
    const val2 = await promise2;                    // Await and get value from second promise
    return val1 + val2;                             // Return sum of both values
};

/**
 * addTwoPromises(Promise.resolve(2), Promise.resolve(2))
 *   .then(console.log); // 4
 */



// Approach 2: Using Promise.all() for concurrent resolution
// var addTwoPromises = function(promise1, promise2) {
//     return Promise.all([promise1, promise2])    // Resolve both promises concurrently
//         .then(([a, b]) => a + b);               // Destructure and sum the results
// };
