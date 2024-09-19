/**
Approach 1:
Use Sorting and then find first missing number

Approach 2:
Use HashSet to insert the numbers and then in second iteration check which number is missing

Approach 3:
Use the array itself to store which number is present
    1) Replace all negative numbers to zero
    2) Replace numbers if lies between (absolute value from 1 to Len(A))
        if gt 0
            num = -1*num
        if eq 0
            num = -1* Len(A+1)
    3) return first value greater than zero


*/
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        for (int i=0; i<nums.Length; i++) {
            if(nums[i] < 0) {
                nums[i] = 0;
            }
        }

        for (int i=0; i<nums.Length; i++) {
            int val = Math.Abs(nums[i]);
            if(val >=1 && val <= nums.Length) { //if current num lies between [1 to Len(Num)]
                if (nums[val-1] > 0)
                    nums[val-1] *= -1;
                else if(nums[val-1] ==0) // value is zero it's corner case
                    nums[val-1] = -1 * (nums.Length+1);
            }

        }

        for(int i=1; i<nums.Length+1 ;i++) {
            if(nums[i-1] >= 0)
                return i;
        }
        return nums.Length + 1;
    }
}