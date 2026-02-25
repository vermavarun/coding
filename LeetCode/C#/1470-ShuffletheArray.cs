/*
Title: 1470. Shuffle the Array
Solution: https://leetcode.com/problems/shuffle-the-array/solutions/7608393/simplest-solution-c-time-on-space-on-ple-o7be/
Difficulty: Easy
Approach: Two pointers with result array placement
Tags: Array
1) Initialize pointers for answer positions (even and odd indices).
2) Initialize pointers for first half and second half of input array.
3) Fill answer alternately with values from first and second halves.
4) Move all pointers forward until second-half pointer reaches array end.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the output array
Tip: Since the required order is fixed as x1, y1, x2, y2, ... use two input pointers and place directly into even/odd positions of the result.
Similar Problems: 1920. Build Array from Permutation, 1929. Concatenation of Array
*/
public class Solution {
    public int[] Shuffle(int[] nums, int n) {

        int i=0;                            // Pointer for even indices in answer array
        int j=1;                            // Pointer for odd indices in answer array
        int a=0;                            // Pointer for first half of nums (x values)
        int b=n;                            // Pointer for second half of nums (y values)
        int[] ans = new int[nums.Length];   // Output array to store shuffled result

        while (j < nums.Length) {          // Continue until odd-position pointer goes out of bounds
            ans[i] = nums[a];               // Place x value at even index
            ans[j] = nums[b];               // Place y value at odd index
            i=i+2;                          // Move to next even index
            j=j+2;                          // Move to next odd index
            a++;                            // Advance first-half pointer
            b++;                            // Advance second-half pointer
        }

        return ans;                         // Return final shuffled array

    }
}
