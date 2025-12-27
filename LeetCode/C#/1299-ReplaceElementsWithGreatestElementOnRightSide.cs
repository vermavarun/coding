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
    public int[] ReplaceElements(int[] arr) {

        int oldMax = -1;
        int newMax = -1;
        
        for(int i=arr.Length - 1; i > -1; i--) {

         newMax = Math.Max(oldMax,arr[i]);
         arr[i] = oldMax;
         oldMax = newMax;
    
        }
        return arr;   
    }
}
