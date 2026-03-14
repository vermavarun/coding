/*
Title: 2648. Generate Fibonacci Sequence
Solution: https://leetcode.com/problems/generate-fibonacci-sequence/solutions/7566038/simplest-solution-c-time-o1-space-o1-ple-tugi/
Difficulty: Easy
Approach: Generator Function with State Variables
Tags: Generator, Math, Fibonacci Sequence
1) Initialize two variables to store the first two Fibonacci numbers (0 and 1)
2) Yield the first two Fibonacci numbers
3) Calculate the third number by adding the first two
4) Enter infinite loop to generate subsequent Fibonacci numbers
5) Yield the current Fibonacci number
6) Update variables: shift num2 to num1, num3 to num2, and calculate new num3

Time Complexity: O(1) per next() call
Space Complexity: O(1) - only stores three numbers at a time
Tip: Generator functions use yield to produce values on-demand without computing the entire sequence upfront. The key insight is maintaining only three variables (current and two previous numbers) to generate infinite Fibonacci numbers with constant space. Each call to next() resumes execution from where it last paused, making generators memory-efficient for infinite sequences.
Similar Problems: 509. Fibonacci Number, 1137. N-th Tribonacci Number, 70. Climbing Stairs, 2619. Array Prototype Last
*/

/**
 * @return {Generator<number>}
 */
var fibGenerator = function*() {

    let num1 = 0;                                              // First Fibonacci number
    let num2 = 1;                                              // Second Fibonacci number

    yield num1;                                                // Yield 0 (first Fibonacci number)
    yield num2;                                                // Yield 1 (second Fibonacci number)

    num3 = num1+num2;                                          // Calculate third Fibonacci number (0 + 1 = 1)

    while (true) {                                             // Infinite loop to generate Fibonacci sequence
        yield num3                                             // Yield current Fibonacci number
        num1 = num2                                            // Shift: previous num2 becomes num1
        num2 = num3                                            // Shift: current num3 becomes num2
        num3 = num1 + num2                                     // Calculate next Fibonacci number
    }
};

/**
 * const gen = fibGenerator();
 * gen.next().value; // 0
 * gen.next().value; // 1
 */