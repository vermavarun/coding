/*
Solution: https://leetcode.com/problems/is-object-empty/solutions/7385292/simplest-solution-javascript-time-on-spa-b9iu/
Difficulty: Medium
Approach: Check Object Keys Length
Tags: JavaScript, Object Manipulation, Array
1) Use Object.keys() to get an array of all enumerable property names.
2) Check if the length of the keys array equals 0.
3) Return true if no keys exist (empty), false otherwise.
4) Alternative approaches: JSON.stringify comparison or for...in loop.

Time Complexity: O(n) where n is the number of keys
Space Complexity: O(n) for the keys array
*/

/**
 * @param {Object|Array} obj
 * @return {boolean}
 */
var isEmpty = function(obj) {
     return Object.keys(obj).length === 0;          // Check if object has no enumerable properties

     // Alternative Approach 1: JSON comparison
     // return JSON.stringify(obj) === JSON.stringify({});

     // Alternative Approach 2: for...in loop (early termination)
     //  for (let key in obj) {
     //   return false;   // If any key exists, not empty
     // }
    //  return true;        // No keys found
};