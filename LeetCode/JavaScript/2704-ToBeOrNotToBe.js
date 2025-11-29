/*
Solution: https://leetcode.com/problems/to-be-or-not-to-be/solutions/7381921/simplest-solution-javascript-time-o1-spa-s8j0/
Approach: Object with Methods for Value Comparison
Tags: JavaScript, Object Methods, Error Handling
1) Create a function that returns an object with two methods.
2) Implement toBe method that checks strict equality and throws error if not equal.
3) Implement notToBe method that checks strict inequality and throws error if equal.
4) Both methods return true on successful assertion, throw string on failure.

Time Complexity: O(1)
Space Complexity: O(1)
*/

/**
 * @param {string} val
 * @return {Object}
 */
var expect = function(val) {
    return {
        toBe: function(val1) {                      // Method to assert equality
            if (val === val1) return true;          // Return true if values are strictly equal
            throw "Not Equal";                      // Throw error if not equal
        },
        notToBe: function(val1) {                   // Method to assert inequality
            if (val !== val1) return true;          // Return true if values are not equal
            throw "Equal";                          // Throw error if equal
        }
    }
};

/**
 * expect(5).toBe(5); // true
 * expect(5).notToBe(5); // throws "Equal"
 */