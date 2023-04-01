public class Solution {
    public string[] FindRelativeRanks(int[] score) {
    
        string[] output = new string[score.Length];
        PriorityQueue<int,int> pq = new PriorityQueue<int,int>(Comparer<int>.Create((x,y)=>score[y]-score[x]));
        for(int i=0;i<score.Length;i++)
            pq.Enqueue(i,i);
        
        if(pq.Count !=0) output[pq.Dequeue()] = "Gold Medal";
        if(pq.Count !=0) output[pq.Dequeue()] = "Silver Medal";
        if(pq.Count !=0) output[pq.Dequeue()] = "Bronze Medal";

        int place = 4;

        while(pq.Count > 0){
            output[pq.Dequeue()] = place.ToString();
            place++;
        }

        return output;
    }
}