/*

Approach:
1) Initialize the num1 and num2 to 0
2) Initialize the stack
3) Iterate through the tokens
4) If the token is an operator, pop the top two elements from the stack
5) Perform the operation based on the operator
6) Push the result to the stack
7) If the token is an operand, push the operand to the stack
8) Return the top element from the stack

Time complexity: O(n)
Space complexity: O(n)

*/
public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        int num1 = 0;                                       // Initialize the num1 to 0
        int num2 = 0;                                       // Initialize the num2 to 0
        Stack<int> stack = new Stack<int>();                // Initialize the stack
        foreach (string op in tokens)
        {                                                   // Iterate through the tokens

            switch (op)
            {                                               // Switch based on the operator

                case "+":                                   // If the operator is +
                    if (stack.Count != 0)
                    {                                       // If the stack is not empty
                        num1 = stack.Pop();                 // Pop the top element from the stack
                    }
                    if (stack.Count != 0)
                    {                                       // If the stack is not empty
                        num2 = stack.Pop();                 // Pop the top element from the stack
                    }
                    stack.Push(num2 + num1);                // Push the result to the stack
                    break;                                  // Break the case

                case "-":                                   // If the operator is -
                    if (stack.Count != 0)
                    {                                       // If the stack is not empty
                        num1 = stack.Pop();                 // Pop the top element from the stack
                    }
                    if (stack.Count != 0)
                    {                                       // If the stack is not empty
                        num2 = stack.Pop();                 // Pop the top element from the stack
                    }
                    stack.Push(num2 - num1);                // Push the result to the stack
                    break;                                  // Break the case

                case "*":                                   // If the operator is *
                    if (stack.Count != 0)
                    {                                       // If the stack is not empty
                        num1 = stack.Pop();                 // Pop the top element from the stack
                    }
                    if (stack.Count != 0)
                    {                                       // If the stack is not empty
                        num2 = stack.Pop();                 // Pop the top element from the stack
                    }
                    stack.Push(num2 * num1);                // Push the result to the stack
                    break;                                  // Break the case

                case "/":                                   // If the operator is /
                    if (stack.Count != 0)
                    {                                       // If the stack is not empty
                        num1 = stack.Pop();                 // Pop the top element from the stack
                    }
                    if (stack.Count != 0)
                    {                                       // If the stack is not empty
                        num2 = stack.Pop();                 // Pop the top element from the stack
                    }
                    stack.Push(num2 / num1);                // Push the result to the stack
                    break;                                  // Break the case

                default:                                    // If the operator is an operand
                    stack.Push(Int32.Parse(op));            // Push the operand to the stack
                    break;                                  // Break the case
            }                                               // End of switch

        }
        return stack.Peek();                                // Return the top element from the stack
    }
}