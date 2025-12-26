/*
Solution: 
Difficulty: Easy
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public int LastStoneWeight(int[] stones) {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
            for (int i = 0; i < stones.Length; i++)
                pq.Enqueue(stones[i], stones[i]);
            int fe = pq.Dequeue();
            while (pq.Count > 0)
            {
                int se = pq.Dequeue();
                int ne;
                ne = Math.Abs(se - fe);
                if (ne > 0)
                {
                    pq.Enqueue(ne, ne);
                    se = 0;
                }
                if (ne == 0)
                {
                    fe = se = -1;
                }
                if (pq.Count > 0)
                {
                    fe = pq.Dequeue();
                }
            }
            return fe == -1 ? 0 : fe;
        }
}
