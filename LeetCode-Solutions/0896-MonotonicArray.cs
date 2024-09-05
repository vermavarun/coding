/*
Approach:
1. Check if the array is increasing monotonic or decreasing monotonic.
2. If the array is increasing monotonic or decreasing monotonic, return true.
3. If the array is neither increasing monotonic nor decreasing monotonic, return false.

Time complexity: O(n)
Space complexity: O(1)


*/
public class Solution {
    public bool IsMonotonic(int[] nums) {
            return IsIncreasingMonotonic(nums) || IsDecreasingMonotonic(nums);
    }
    static bool IsIncreasingMonotonic(int[] nums) {
            int index = 0;
            while(index < nums.Length - 1) {
                if (nums[index] > nums [index + 1])  return false;
                index++;
            }

            return true;
        }

        static bool IsDecreasingMonotonic(int[] nums) {
            int index = 0;
            while(index < nums.Length - 1) {
                if (nums[index] < nums [index + 1])  return false;
                index++;
            }

            return true;
        }
}