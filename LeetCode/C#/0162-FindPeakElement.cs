/*
Approach: Binary Search
1. We can use binary search to find the peak element.
2. We can compare the mid element with the next element.
3. If the mid element is less than the next element, then the peak element will be on the right side of the mid element.
4. If the mid element is greater than the next element, then the peak element will be on the left side of the mid element.
5. We can keep on reducing the search space by moving the left and right pointers accordingly.
6. We can return the left pointer as the peak element.

Time complexity: O(log n)
Space complexity: O(1)
*/
public class Solution {
    public int FindPeakElement(int[] nums) {
        int left = 0;                               // left pointer
        int right = nums.Length - 1;                // right pointer
        while (left < right)                        // binary search
        {
            int mid = left + (right - left) / 2;    // calculate mid element index and avoid integer overflow
            if (nums[mid] < nums[mid + 1]) {        // if mid element is less than the next element
                left = mid + 1;                     // peak element will be on the right side of mid element
            }
            else {                                  // if mid element is greater than the next element
                right = mid;                        // peak element will be on the left side of mid element
            }
        }
        return left;                                // return left pointer as peak element
    }
}