/*
Solution: Return Length of Arguments Passed
Difficulty: Medium
Approach: Use Rest Parameters and Length Property
Tags: JavaScript, Rest Parameters, Array
1) Use rest parameters (...args) to collect all arguments into an array.
2) Access the length property of the arguments array.
3) Return the count of arguments passed to the function.
Time Complexity: O(1)

Time Complexity: O(1)
Space Complexity: O(n) where n is the number of arguments
*/

/**
 * @param {...(null|boolean|number|string|Array|Object)} args
 * @return {number}
 */
var argumentsLength = function(...args) {
    return ([...args].length)                       // Return the number of arguments passed
};

/**
 * argumentsLength(1, 2, 3); // 3
 */