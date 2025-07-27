/*
Videos: https://www.youtube.com/watch?v=NK83TS3xi0c
Solution: https://leetcode.com/problems/count-hills-and-valleys-in-an-array/solutions/7011664/simplest-solution-c-time-on-space1-pleas-vthe/
Tags: Array, Two-Pointers
Approach: Two Pointers
1) Initialize two pointers, i and j, both starting at 0.
2) Use a while loop to iterate through the array until j reaches the second last element.
3) Check if the current element at j is a hill or a valley by comparing it with its neighbors.
4) If it is a hill or a valley, increment the count and update i to j.
5) Move j to the next element.
6) Return the count of hills and valleys.
Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution
{
    public int CountHillValley(int[] nums)
    {
        int i = 0;                                          // Pointer to track the last hill or valley
        int j = 0;                                          // Pointer to iterate through the array
        int numOfValleysOrHills = 0;                        // Counter for hills and valleys

        while (j < nums.Length - 1)                         // Iterate through the array
        {
            if (                                            // Check if the current element is a hill or a valley
            (nums[i] < nums[j] && nums[j] > nums[j + 1])
            ||
            (nums[i] > nums[j] && (nums[j] < nums[j + 1]))
            )
            {
                numOfValleysOrHills++;                      // Increment the count if a hill or valley is found
                i = j;                                      // Update i to the current position j
            }
            j++;                                            // Move to the next element
        }

        return numOfValleysOrHills;                         // Return the total count of hills and valleys

    }
}