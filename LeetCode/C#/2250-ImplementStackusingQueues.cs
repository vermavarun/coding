/*

Approach:
1. We can implement a stack using one queue.
2. We can use the queue to implement the stack.

Time complexity: O(n)
Space complexity: O(n)

*/
public class MyStack {
    private Queue<int> _q;                          // Queue to implement stack

    public MyStack() {
        _q = new Queue<int>();                      // Initialize the queue
    }

    public void Push(int x) {
        _q.Enqueue(x);                              // Enqueue the element
         for(int i=0; i<_q.Count-1; i++) {          // Move the elements to the front of the queue
            _q.Enqueue(_q.Dequeue());               // Dequeue the element and enqueue it again
        }
    }

    public int Pop() {
        return _q.Dequeue();                        // Dequeue the element
    }

    public int Top() {
        return _q.Peek();                           // Peek the element
    }

    public bool Empty() {
        return _q.Count == 0;                       // Check if the queue is empty
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */