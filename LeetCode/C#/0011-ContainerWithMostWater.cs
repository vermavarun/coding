/*

Approach:
1) Initialize the area, left and right pointers
2) Iterate through the array
3) Calculate the area using the formula: area = Math.Max( (right - left) * (Math.Min(height[right],height[left])) ,area)
4) If the height of the left pointer is less than the height of the right pointer, increment the left pointer
5) If the height of the left pointer is greater than the height of the right pointer, decrement the right pointer
6) Return the area

Time complexity: O(n)
Space complexity: O(1)

*/
public class Solution {
    public int MaxArea(int[] height) {
        int left, right, area;                                                                      // Initialize the area, left and right pointers
        area = left = 0;                                                                            // Initialize the area and left pointer
        right = height.Length - 1;                                                                  // Initialize the right pointer

        while(left < right) {                                                                       // Iterate through the array
            area = Math.Max( (right - left) * (Math.Min(height[right],height[left])) ,area);        // Calculate the area
            if (height[left] < height[right])                                                       // If the height of the left pointer is less than the height of the right pointer, increment the left pointer
                left++;
            else
                right--;
        }
        return area;                                                                                // Return the area
    }
}