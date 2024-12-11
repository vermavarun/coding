using System.Collections.Generic;

public class MinStackII {

    int _min = int.MaxValue;
    Stack<int> _stack;

    public MinStackII() {
        _stack = new Stack<int>();
    }

    public void Push(int val) {
        if(_stack.Count == 0) {
            _stack.Push(val);
            _min = val;
        }
        else if(val>=_min){
            _stack.Push(val);
        }
        else {
            _stack.Push(2*val - _min);
            _min = val;
        }
    }

    public int Pop() {

        int popped = _stack.Pop();
        if (popped < _min)  {
            int prevMin = (2 * _min - popped);
                popped=_min;
                _min=prevMin;
            }
        return popped;
    }

    public int Top() {
        int val = _stack.Peek();
        if(val >= _min)
            return val;
        else
            return _min;
    }

    public int GetMin() {
        return _min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStackII obj = new MinStackII();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */