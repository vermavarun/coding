/*
Approach:
1. Iterate through the array from 1 to n-1.
2. Check if the current element and the previous element are both even or both odd.
3. If they are, return false.
4. If the loop completes, return true.
Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public bool IsArraySpecial(int[] nums) {
        for(int i=1; i<nums.Length; i++) {      //  Iterating through the array from 1 to n-1
            if(nums[i]%2 == nums[i-1]%2)        //  Checking if the current element and the previous element are both even or both odd
                return false;                   //  If they are, return false
        }
        return true;                            //  If the loop completes, return true
    }
}