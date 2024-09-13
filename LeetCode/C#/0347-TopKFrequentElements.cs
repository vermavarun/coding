/*

Approach:
1. Create a priority queue to store the numbers based on their frequency.
2. Create a dictionary to store the frequency of each number.
3. Iterate through the numbers array and for each number, check if it is already present in the dictionary.
4. If it is present, update the frequency of the number.
5. If it is not present, add the number to the dictionary with a frequency of 1.
6. Add the numbers and their frequencies to the priority queue.
7. Iterate through the priority queue and dequeue the top k elements.
8. Return the top k elements as the result.

Time complexity: O(nlogk)
Space complexity: O(n)

*/
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {

        PriorityQueue<int,int> pq = new PriorityQueue<int,int>(Comparer<int>.Create((x, y) => y - x));
        Dictionary<int,int> dict = new Dictionary<int,int>();
        List<int> result = new List<int>();
        int index = 0;

        while (index < nums.Length) {

            if(!dict.ContainsKey(nums[index])) {
                dict.Add(nums[index],1);
            }
            else {
                dict[nums[index]] = dict[nums[index]] + 1;
            }

            index++;
        }

        foreach(var kv in dict) {
            pq.Enqueue(kv.Key,kv.Value);
        }

        index = 0;

        while(index < k && pq.Count != 0) {
            var dqNum = pq.Dequeue();
            result.Add(dqNum);
            index++;
        }

        return result.ToArray();
    }
}