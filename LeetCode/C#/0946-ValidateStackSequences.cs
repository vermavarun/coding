/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Stack
1) Initialize the currentItemToBePoppedIndex to 0
2) Initialize the stack
3) Iterate through the pushed array
4) Push the element to the stack
5) While the stack is not empty and the top element of the stack is equal to the element at currentItemToBePoppedIndex in the popped array
6) Pop the element from the stack
7) Increment the currentItemToBePoppedIndex
8) Return true if the stack is empty, else return false

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        int currentItemToBePoppedIndex = 0;                                                             // Initialize the currentItemToBePoppedIndex to 0
        Stack<int> stack = new Stack<int>();                                                            // Initialize the stack
        foreach(int num in pushed) {                                                                    // Iterate through the pushed array
            stack.Push(num);                                                                            // Push the element to the stack
            while(stack.Count > 0 && stack.Peek() == popped[currentItemToBePoppedIndex]) {              // While the stack is not empty and the top element of the stack is equal to the element at currentItemToBePoppedIndex in the popped array
                stack.Pop();                                                                            // Pop the element from the stack
                currentItemToBePoppedIndex++;                                                           // Increment the currentItemToBePoppedIndex
            }
        }
        return stack.Count>0?false:true;                                                                // Return true if the stack is empty, else return false
    }
}