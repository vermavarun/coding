/*
Solution: 
Difficulty: Easy
Approach:
Tags: Array, Stack

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> stack = new Stack<int>();                                                            // Use a stack to keep track of the asteroids
        foreach(int asteroid in asteroids) {                                                            // Iterate through the asteroids
            if(asteroid > 0) {                                                                          // If the asteroid is positive, push it to the stack
                stack.Push(asteroid);                                                                   // Push the asteroid to the stack
            }
            else {
                while(stack.Count != 0 && stack.Peek() > 0 && stack.Peek() < -asteroid) {               // If the top of the stack is positive and the asteroid is negative, check if the top of the stack is smaller than the asteroid
                    stack.Pop();                                                                        // Pop the top of the stack
                }
                if(stack.Count == 0 || stack.Peek() < 0) {                                              // If the stack is empty or the top of the stack is negative, push the asteroid to the stack
                    stack.Push(asteroid);                                                               // Push the asteroid to the stack
                }
                else if(stack.Peek() == -asteroid) {                                                    // If the top of the stack is equal to the asteroid, pop the top of the stack
                    stack.Pop();                                                                        // Pop the top of the stack
                }
            }
        }
        return stack.Reverse().ToArray();                                                               // Reverse the stack and return the result
    }
}