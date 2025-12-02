/*
Solution: https://leetcode.com/problems/calculator-with-method-chaining/solutions/7386749/simplest-solution-javascript-time-o1-spa-bik5/
Approach: Class-based Calculator with Fluent Interface Pattern
Tags: JavaScript, OOP, Method Chaining, Class Design
1) Create a Calculator class that stores the current value.
2) Implement arithmetic methods that modify the current value and return 'this'.
3) Each method returns the instance to enable method chaining.
4) Include error handling for division by zero.
5) Provide getResult() method to retrieve the final computed value.

Time Complexity: O(1) for each operation
Space Complexity: O(1)
*/

class Calculator {

    /**
     * @param {number} value
     */
    constructor(value) {
        this.value = value;                             // Initialize calculator with starting value
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    add(value){
        this.value = this.value + value;                // Add value to current result
        return this;                                    // Return this for method chaining
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    subtract(value){
        this.value = this.value - value;                // Subtract value from current result
        return this;                                    // Return this for method chaining
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    multiply(value) {
        this.value = this.value * value;                // Multiply current result by value
        return this;                                    // Return this for method chaining
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    divide(value) {
        if (value === 0) {                              // Check for division by zero
            throw new Error("Division by zero is not allowed");
        }
        this.value /= value;                            // Divide current result by value
        return this;                                    // Return this for method chaining
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    power(value) {
        this.value = this.value ** value;               // Raise current result to the power of value
        return this;                                    // Return this for method chaining
    }

    /**
     * @return {number}
     */
    getResult() {
        return this.value;                              // Return the final computed value
    }
}