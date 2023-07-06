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
