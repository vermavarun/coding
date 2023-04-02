public class KthLargest {

    private PriorityQueue<int,int> pq = new PriorityQueue<int,int>();
    private int kth {get;set;}
    public KthLargest(int k, int[] nums) {
        kth= k;
        foreach (int num in nums) {
            pq.Enqueue(num,num);
        }
        while (pq.Count > kth) {
            pq.Dequeue();
        }
    }
    public int Add(int val) {
        pq.Enqueue(val,val);
        if (pq.Count > kth) {
            pq.Dequeue();
        }
        return pq.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */