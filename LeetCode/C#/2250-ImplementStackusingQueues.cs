/*
Solution:
Difficulty: Easy
Approach: Single Queue Implementation
Tags: Stack, Design, Queue
1) Initialize a queue to store stack elements.
2) For push operation: enqueue element, then rotate all previous elements to back.
3) This makes the newest element appear at front of queue.
4) For pop/top: simply dequeue/peek from queue.
5) For empty: check if queue is empty.

Time Complexity: O(n) for push, O(1) for pop/top
Space Complexity: O(n) for storing elements
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