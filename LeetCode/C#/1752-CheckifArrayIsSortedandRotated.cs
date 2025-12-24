/*
Difficulty: Easy
Approach: Single Pass with Peek Detection
Tags: Array
1. Initialize peekFound to false.
2. Iterate through the array from 0 to n-2.
3. If the current element is greater than the next element, check if peekFound is false.
4. If peekFound is false, set peekFound to true.
5. If peekFound is true, return false.
6. If peekFound is true and the last element is greater than the first element, return false.
7. Return true.
Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public bool Check(int[] nums) {
        bool peekFound = false;                             //  Initializing peekFound to false
        for(int i=0; i<nums.Length-1; i++) {                //  Iterating through the array from 0 to n-2
            if(nums[i] > nums[i+1]) {                       //  If the current element is greater than the next element
                if(peekFound == false)                      //  Check if peekFound is false
                    peekFound = true;                       //  If peekFound is false, set peekFound to true
                else
                    return false;                           //  If peekFound is true, return false
            }
        }
        if(peekFound && nums[nums.Length-1] > nums[0]) {    //  If peekFound is true and the last element is greater than the first element
            return false;                                   //  Return false
        }
        return true;                                        //  Return true
    }
}