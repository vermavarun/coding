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
    public bool IsIdealPermutation(int[] nums) {
     for(int i=0; i<nums.Length; i++) {
         if(Math.Abs(nums[i] - i) > 1) { // Array num to it's index difference should not be greater than 1
             return false;
         }
     }   
     return true;
    }
}