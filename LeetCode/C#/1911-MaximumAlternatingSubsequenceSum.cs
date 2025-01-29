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

Time complexity: O(n)
Space complexity: O(n)
*/
public class Solution {
    long[,] dp = new long[100001,2];                                // 2D array to store the maximum sum we can get starting from the ith element and whether we have taken the previous element or not.
    int n = 0;                                                      // Length of the input array

    public long MaxAlternatingSum(int[] nums) {                     // Function to get the maximum alternating subsequence sum
        n = nums.Length;                                            // Length of the input array
        for(int i=0; i<100001; i++) {                               // Initialize the 2D array with -1
            for (int j=0; j<2; j++) {                               // Initialize the 2D array with -1
                dp[i,j] = -1;                                       // Initialize the 2D array with -1
            }
        }
        return AlternatingSum(nums, true, 0);                       // Return the maximum sum starting from the 0th element and whether we have taken the previous element or not.
    }

    public long AlternatingSum(int[] nums, bool flag, int i) {

        if(i >= n) {                                                // If the index is greater than or equal to the length of the input array, then return 0
            return 0;                                               // If the index is greater than or equal to the length of the input array, then return 0
        }

        int flagBit = flag ? 1 : 0;                                 // If the flag is true, then set the flagBit to 1, otherwise set the flagBit to 0
        if(dp[i,flagBit] != -1) {                                   // If we have already calculated the maximum sum starting from the ith element and whether we have taken the previous element or not, then return it
            return dp[i,flagBit];                                   // If we have already calculated the maximum sum starting from the ith element and whether we have taken the previous element or not, then return it
        }

        long valToTake = nums[i];                                   // Value to take
        if(!flag) valToTake = -valToTake;                           // If we have not taken the previous element, then set the value to take to -value to take
        long skip = AlternatingSum(nums, flag, i+1);                // Skip the current element
        long take = valToTake + AlternatingSum(nums, !flag, i+1);   // Take the current element
        return dp[i,flagBit] = Math.Max(take, skip);                // Return the maximum of the two
    }

}