/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array
1. We will store the input array in a private variable _nums.
2. We will then implement the SumRange method that will return the sum of the elements from left to right.
3. We will iterate from left to right and add the elements to the sum.
4. We will return the sum.
Space complexity: O(1)

Time Complexity: O(?)
*/
public class NumArray {
    private int[] _nums;                                    // private variable to store the input array
    public NumArray(int[] nums) {
        _nums = nums;                                       // store the input array
    }

    public int SumRange(int left, int right) {              // method to return the sum of elements from left to right
        int sum = 0;                                        // variable to store the sum
        while (left <= right) {                             // iterate from left to right
            sum = sum + _nums[left];                        // add the element to the sum
            left++;                                         // increment left
        }
        return sum;                                         // return the sum
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */
