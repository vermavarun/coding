/*

Approach:
1. We will use two stacks to implement the queue.
2. We will use one stack to push the elements and another stack to pop the elements.
3. When we push the elements, we will push them to the push stack.
4. When we pop the elements, we will check if the pop stack is empty or not.
5. If the pop stack is empty, we will pop all the elements from the push stack and push them to the pop stack.
6. Then we will pop the top element from the pop stack.
7. When we peek the elements, we will check if the pop stack is empty or not.
8. If the pop stack is empty, we will pop all the elements from the push stack and push them to the pop stack.
9. Then we will peek the top element from the pop stack.
10. When we check if the queue is empty or not, we will check if both the push and pop stacks are empty or not.

Time Complexity: O(n)
Space Complexity: O(n)

*/
public class MyQueue {
    Stack<int> _sPush;                                      // Stack to push the elements
    Stack<int> _sPop;                                       // Stack to pop the elements

    public MyQueue() {
        _sPush = new Stack<int>();                          // Initialize the push stack
        _sPop = new Stack<int>();                           // Initialize the pop stack
    }

    public void Push(int x) {
        _sPush.Push(x);                                     // Push the element to the push stack
    }

    public int Pop() {
        if(_sPop.Count() == 0) {                            // If the pop stack is empty
            while(_sPush.Count()!=0) {                      // If the pop stack is empty, pop all the elements from the push stack and push them to the pop stack
                _sPop.Push(_sPush.Pop());                   // Push the elements to the pop stack
            }
        }
        return _sPop.Pop();                                 // Pop the top element from the pop stack
    }

    public int Peek() {
        if(_sPop.Count() == 0) {                            // If the pop stack is empty
            while(_sPush.Count()!=0) {                      // If the pop stack is empty, pop all the elements from the push stack and push them to the pop stack
                _sPop.Push(_sPush.Pop());                   // Push the elements to the pop stack
            }
        }
        return _sPop.Peek();                                // Peek the top element from the pop stack
    }

    public bool Empty() {
        return _sPop.Count() == 0 && _sPush.Count() == 0;   // Check if the queue is empty or not
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */