/*
Solution: https://leetcode.com/problems/count-subarrays-of-length-three-with-a-condition/solutions/6691977/simplest-solution-c-time-on-space1-pleas-0ee5/
Approach: Sliding Window
1) We need to find the number of subarrays of length 3 such that the sum of the first and last elements is equal to twice the middle element.
2) We can use a sliding window of size 3 to check each subarray.
3) We will maintain three pointers: a, b, and c.
4) a will point to the first element of the subarray, b will point to the middle element, and c will point to the last element.
5) We will check if the sum of the first and last elements is equal to twice the middle element.
6) If it is, we will increment the count.
7) We will move the window by incrementing a, b, and c.
8) We will return the count at the end.

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int CountSubarrays(int[] nums) {
        int a=0;                                    // First element of the subarray
        int c=2;                                    // Last element of the subarray
        int b=1;                                    // Middle element of the subarray
        int count=0;                                // Count of subarrays satisfying the condition
        while(c < nums.Length) {                    // Loop until the last element of the array
            if (2*(nums[a]+nums[c]) == nums[b]) {   // Check if the sum of the first and last elements is equal to twice the middle element. Not dividing because of decimal comparison
                count++;                            // Increment the count if the condition is satisfied
            }
            a++;                                    // Move the first element of the subarray
            b++;                                    // Move the middle element of the subarray
            c++;                                    // Move the last element of the subarray
        }
        return count;                               // Return the count of subarrays satisfying the condition
    }
}