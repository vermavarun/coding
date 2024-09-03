/*
Approach: Prefix Sum
1. Calculate the total sum of the array.
2. Iterate through the array and calculate the sum of the left side and right side of the current index.
3. If the sum of the left side and right side is equal, return the current index.
4. If the sum of the left side and right side is not equal, update the sum of the left side and move to the next index.
5. If no such index is found, return -1.

Time complexity: O(n)
Space complexity: O(1)
where n is the number of elements in the array.

*/
public class Solution {
    public int PivotIndex(int[] nums) {
        int currentIndex = 0;
            int sumLeft = 0;
            int sumRight = 0;
            int totalSum = nums.Sum();

            while(currentIndex < nums.Length) {
                sumRight = totalSum - sumLeft - nums[currentIndex];

                if(sumLeft == sumRight) {
                    return currentIndex;
                }
                sumLeft = sumLeft + nums[currentIndex];
                currentIndex++;
            }

            return -1;
    }
}