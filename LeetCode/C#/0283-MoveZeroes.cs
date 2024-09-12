// Two pointer approach
public class Solution {
    public void MoveZeroes(int[] nums) {
        int  i = 0;
        int  j = 0;
        int  k = 0;
        while(j < nums.Length) { // just swap the number if the current number is non zero
            if (nums[j] != 0) {
                k=nums[i];
                nums[i] = nums[j];
                nums[j] = k ;
                i++;
            }
            j++;
        }
    }
}