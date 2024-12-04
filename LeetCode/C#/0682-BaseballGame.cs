/*

Approach:
1. Create a stack to store the scores.
2. Iterate through the operations array.
3. If the current operation is "C", pop the last score from the stack.
4. If the current operation is "D", double the last score and push it to the stack.
5. If the current operation is "+", add the sum of the last two scores and push it to the stack.
6. If the current operation is a number, push it to the stack.
7. After iterating through all the operations, pop all the scores from the stack and calculate the sum.
8. Return the sum.

Time complexity: O(n)
Space complexity: O(n)

*/
public class Solution {
    public int CalPoints(string[] operations) {
        Stack<int> stack = new Stack<int>();                // To store the scores
        int sum = 0;                                        // To store the sum of all the scores

        foreach(string ch in operations) {                  // Iterating through the operations array
            switch(ch) {
                case "C":                                   // If the current operation is "C"
                    if(stack.Count() == 0) break;           // If the stack is empty, do nothing
                    stack.Pop();                            // Pop the last score from the stack
                    break;                                  // Break from the switch case

                case "D":                                   // If the current operation is "D"
                    if(stack.Count() == 0) break;           // If the stack is empty, do nothing
                    int peeked = stack.Peek();              // Peek the last score from the stack
                    peeked*=2;                              // Double the last score
                    stack.Push(peeked);                     // Push the doubled score to the stack
                    break;                                  // Break from the switch case

                case "+":                                   // If the current operation is "+"
                    if(stack.Count() == 0) break;           // If the stack is empty, do nothing
                    int poped = stack.Pop();                // Pop the last score from the stack
                    peeked = stack.Peek();                  // Peek the second last score from the stack
                    stack.Push(poped);                      // Push the last score back to the stack
                    stack.Push(poped+peeked);               // Push the sum of the last two scores to the stack
                    break;                                  // Break from the switch case

                default:                                    // If the current operation is a number
                    stack.Push(Int32.Parse(ch));            // Push the number to the stack
                    break;                                  // Break from the switch case
            }
        }
        while(stack.Count() != 0) {                         // Pop all the scores from the stack and calculate the sum
            int num = stack.Pop();                          // Pop the score from the stack
            sum=sum+num;                                    // Add the score to the sum
        }
        return sum;                                         // Return the sum
    }
}