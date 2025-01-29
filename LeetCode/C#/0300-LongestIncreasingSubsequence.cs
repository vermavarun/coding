/*
Approach: Recursion with memoization
1. We can either take the current element or skip it.
2. If we take the current element, we need to check if we have taken the previous element or not.
3. If we have taken the previous element, then we need to skip the current element.
4. If we have not taken the previous element, then we can take the current element.
5. We can use a flag to keep track of whether we have taken the previous element or not.
6. We can use a 2D array to store the maximum sum we can get starting from the ith element and whether we have taken the previous element or not.
7. If we have already calculated the maximum sum starting from the ith element and whether we have taken the previous element or not, then we can return it.
8. Otherwise, we can calculate the maximum sum starting from the ith element and whether we have taken the previous element or not.
9. If we have taken the current element, then we need to skip the next element.
10. If we have not taken the current element, then we can take the next element.
11. We can return the maximum of the two.
12. We can keep track of the maximum sum we can get starting from the 0th element and whether we have taken the previous element or not.
13. We can return the maximum sum starting from the 0th element and whether we have taken the previous element or not.

Time complexity: O(n^2)
Space complexity: O(n^2)

*/
public class Solution {
    int n = 0;                                              // Length of the input array
    int[,] dp = new int[2501,2501];                         // 2D array to store the maximum sum we can get starting from the ith element and whether we have taken the previous element or not.
    public int LengthOfLIS(int[] nums) {                    // Function to get the length of the longest increasing subsequence
        n = nums.Length;                                    // Length of the input array
        for (int i=0; i<2501; i++) {                        // Initialize the 2D array with -1
            for (int j=0; j<2501; j++) {                    // Initialize the 2D array with -1
                dp[i,j] = -1;                               // Initialize the 2D array with -1
            }
        }
        return FindLengthOfLIS(nums, 0, -1);                // Return the length of the longest increasing subsequence
    }

    public int FindLengthOfLIS(int[] nums, int i, int p) {  // Function to find the length of the longest increasing subsequence
        if (i >= n) {                                       // If the index is greater than or equal to the length of the input array, then return 0
            return 0;                                       // If the index is greater than or equal to the length of the input array, then return 0
        }
        if (p!= -1 && dp[i,p] != -1)                        // If we have already calculated the maximum sum starting from the ith element and whether we have taken the previous element or not, then return it
            return dp[i,p];                                 // If we have already calculated the maximum sum starting from the ith element and whether we have taken the previous element or not, then return it

        int take = 0;                                       // Value to take
        if (p == -1 || nums[i] > nums[p]) {                 // If we have not taken the previous element or the current element is greater than the previous element, then we can take the current element
            take = 1 + FindLengthOfLIS(nums, i+1, i);       // Take the current element
        }

        int skip = FindLengthOfLIS(nums, i+1, p);           // Skip the current element
        if (p != -1)                                        // If we have taken the previous element, then we need to skip the current element
            dp[i,p] = Math.Max(take, skip);                 // Return the maximum of the two
        return Math.Max(take, skip);                        // Return the maximum of the two
    }
}