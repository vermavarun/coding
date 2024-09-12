public class Solution {
    public int[] GetConcatenation(int[] nums) {
        
        int[] conArray = new int[nums.Length*2];

        for(int i=0;i<nums.Length;i++) {
            conArray[i] = nums[i];
        }

         for(int i=nums.Length;i<nums.Length*2;i++) {
            conArray[i] = nums[i - nums.Length];
        }

        return conArray;
    }
}
