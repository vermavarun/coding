/*
Approach:
1. Create two Priority Queues, one for the left part of the array and the other for the right part of the array.
2. Add the number to the left part if the number is less than or equal to the top of the left part Priority Queue.
3. Add the number to the right part if the number is greater than the top of the left part Priority Queue.
4. Balance the heaps by moving the top of the left part Priority Queue to the right part Priority Queue if the size of the left part Priority Queue is greater than the size of the right part Priority Queue by more than 1.
5. Balance the heaps by moving the top of the right part Priority Queue to the left part Priority Queue if the size of the right part Priority Queue is greater than the size of the left part Priority Queue.
6. If the size of the left part Priority Queue is equal to the size of the right part Priority Queue, return the average of the top of the left part Priority Queue and the top of the right part Priority Queue.
7. If the size of the left part Priority Queue is greater than the size of the right part Priority Queue, return the top of the left part Priority Queue.

Time Complexity: O(log n) for AddNum and O(1) for FindMedian
Space Complexity: O(n)

*/

public class MedianFinder {

    PriorityQueue<int,int> _rightMinPQ;                                                     // Priority Queue for the right part of the array
    PriorityQueue<int,int> _leftMaxPQ;                                                      // Priority Queue for the left part of the array

    public MedianFinder() {
        _rightMinPQ = new PriorityQueue<int,int>();                                         // Initialize the Priority Queues
        _leftMaxPQ = new PriorityQueue<int,int>(Comparer<int>.Create((x, y) => y - x));     // Initialize the Priority Queues
    }


    public void AddNum(int num) {
        if (_leftMaxPQ.Count == 0 || num <= _leftMaxPQ.Peek()) {                            // Add the number to the left part if the number is less than or equal to the top of the left part Priority Queue
            _leftMaxPQ.Enqueue(num,num);                                                    // Add the number to the left part
        }
        else {
            _rightMinPQ.Enqueue(num,num);                                                   // Add the number to the right part
        }
        // Balance the heaps
        if (_leftMaxPQ.Count > _rightMinPQ.Count + 1 ) {                                    // Balance the heaps by moving the top of the left part Priority Queue to the right part Priority Queue if the size of the left part Priority Queue is greater than the size of the right part Priority Queue by more than 1
            int tempR = _leftMaxPQ.Dequeue();                                               // Move the top of the left part Priority Queue to the right part Priority Queue
           _rightMinPQ.Enqueue(tempR,tempR);                                                // Move the top of the left part Priority Queue to the right part Priority Queue
        }
        else if(_rightMinPQ.Count > _leftMaxPQ.Count) {                                     // Balance the heaps by moving the top of the right part Priority Queue to the left part Priority Queue if the size of the right part Priority Queue is greater than the size of the left part Priority Queue
            int tempL = _rightMinPQ.Dequeue();                                              // Move the top of the right part Priority Queue to the left part Priority Queue
            _leftMaxPQ.Enqueue(tempL,tempL);                                                // Move the top of the right part Priority Queue to the left part Priority Queue
        }

    }

    public double FindMedian() {
        if (_leftMaxPQ.Count == _rightMinPQ.Count) {                                        // If the size of the left part Priority Queue is equal to the size of the right part Priority Queue, return the average of the top of the left part Priority Queue and the top of the right part Priority Queue
            return (_leftMaxPQ.Peek() + _rightMinPQ.Peek()) / 2.0;                          // Return the average of the top of the left part Priority Queue and the top of the right part Priority Queue
        }
        else {
            return _leftMaxPQ.Peek();                                                       // If the size of the left part Priority Queue is greater than the size of the right part Priority Queue, return the top of the left part Priority Queue
        }

    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */