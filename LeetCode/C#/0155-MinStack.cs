/*

Approach:
1) Initialize the minimum value and the stack
2) Push the value to the stack if the stack is empty
3) If the value is greater than or equal to the minimum value, push the value to the stack
4) If the value is less than the minimum value, push 2 * value - minimum value to the stack and update the minimum value
5) Pop the value from the stack
6) If the popped value is less than the minimum value, calculate the previous minimum value and update the popped value and the minimum value
7) Get the top value from the stack
8) If the value is greater than or equal to the minimum value, return the value
9) If the value is less than the minimum value, return the minimum value
10) Return the minimum value
11) Make sure you cast long to int where ever required for C# :)
Time complexity: O(1)
Space complexity: O(n)

*/
public class MinStack
{
    long _min;                                                            // Initialize the minimum value
    Stack<long> _stack;                                                   // Initialize the stack

    public MinStack()
    {
        _stack = new Stack<long>();                                       // Initialize the stack
    }

    public void Push(int val)
    {
        if (_stack.Count == 0)                                            // If the stack is empty
        {
            _stack.Push((long)val);                                       // Push the value to the stack
            _min = (long)val;                                             // Update the minimum value
        }
        else if ((long)val >= _min)                                       // If the value is greater than or equal to the minimum value
        {
            _stack.Push((long)val);                                       // Push the value to the stack
        }
        else
        {
            long temp = 2 * (long)val;
            temp = temp - _min;
            _stack.Push(temp);                                            // Push the value to the stack
            _min = (long)val;                                             // Update the minimum value
        }
    }

    public void Pop()
    {
        long popped = _stack.Pop();                                       // Pop the value from the stack
        if (popped < _min)                                                // If the popped value is less than the minimum value
        {
            long prevMin = 2 * _min;
            prevMin = prevMin - popped;
            popped = _min;                                                // Update the popped value
            _min = prevMin;                                               // Update the minimum value
        }
        // return popped if the return type of Pop() is int
    }

    public int Top()
    {
        long val = _stack.Peek();                                    // Get the top value from the stack
        if (val >= _min)                                            // If the value is greater than or equal to the minimum value
            return (int)val;                                             // Return the value
        else
            return (int)_min;                                            // Return the minimum value
    }

    public int GetMin()
    {
        return (int)_min;                                                // Return the minimum value
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */