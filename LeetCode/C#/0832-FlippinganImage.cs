/*
Title: 832. Flipping an Image
Solution: https://leetcode.com/problems/flipping-an-image/solutions/7630066/simplest-solution-c-time-onm-space-o1-pl-g49j/
Difficulty: Easy
Approach: Two-Pass Array Manipulation (Flip then Invert)
Tags: Array, Two Pointers, Matrix
1) Iterate through each row of the image matrix.
2) For each row, first flip it horizontally (reverse the array).
3) Then invert each element (0 becomes 1, 1 becomes 0).
4) Return the modified image matrix.

Time Complexity: O(n * m) where n = number of rows, m = number of columns
Space Complexity: O(1) as we modify the array in-place
Tip: This problem combines two simple operations: reversing an array and flipping binary values. You can optimize by doing both operations in a single pass using two pointers, swapping and inverting simultaneously.
Similar Problems: 48. Rotate Image, 867. Transpose Matrix, 1886. Determine Whether Matrix Can Be Obtained By Rotation
*/
public class Solution {
    public int[][] FlipAndInvertImage(int[][] image) {

        foreach (int[] img in image) {                  // Process each row of the image
            Flip(img);                                  // Flip the row horizontally (reverse)
            Invert(img);                                // Invert binary values (0->1, 1->0)
        }

        return image;                                   // Return modified image matrix
    }

    private void Flip(int[] img) {
        int left = 0;                                   // Initialize left pointer at start
        int right = img.Length - 1;                     // Initialize right pointer at end

        while (left < right) {                          // Continue until pointers meet
            int temp = img[left];                       // Store left element temporarily
            img[left] = img[right];                     // Move right element to left position
            img[right] = temp;                          // Move stored left element to right position

            left++;                                     // Move left pointer inward
            right--;                                    // Move right pointer inward
        }
    }

    private void Invert(int[] img) {
        for (int i=0; i<img.Length; i++) {              // Iterate through each element in row
            img[i] = img[i] == 0 ? 1 : 0;               // Flip binary value (0->1 or 1->0)
        }
    }
}