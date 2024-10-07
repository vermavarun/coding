/*

Approach:
1) We can create a function that returns a promise that resolves after a certain amount of time.
2) We can use the setTimeout function to achieve this.

Time complexity:
- O(1)

Space complexity:
- O(1)


*/

/**
 * @param {number} millis
 * @return {Promise}
 */
async function sleep(millis) {
    return new Promise((resolve) => {
     setTimeout(resolve, millis);
   });
}

/**
* let t = Date.now()
* sleep(100).then(() => console.log(Date.now() - t)) // 100
*/