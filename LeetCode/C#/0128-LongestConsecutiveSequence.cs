/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Math
1. Create a hashset to store the numbers.
2. Create a variable to store the current initial length.
3. Create a variable to store the current initial number.
4. Create a variable to store the current maximum length.
5. Iterate through the numbers array and add the numbers to the hashset.
6. Iterate through the numbers array and for each number, check if the number-1 is present in the hashset.
7. If it is not present, then it is the starting number of a sequence.
8. Iterate through the sequence and increment the current initial length.
9. Update the current maximum length.
10. Return the current maximum length.

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        int currentInitialLength = 0;
        int index = 0;
        int currentInitial = 0;
        int currentMax = 0;

        foreach(int num in nums) {
            set.Add(num);
        }

        while(index < nums.Length) {

            if(!set.Contains(nums[index]-1)) {
                currentInitial = nums[index];

                while (set.Contains(currentInitial)) {
                    currentInitialLength++;
                    currentInitial++;
                }

                currentMax = Math.Max(currentMax,currentInitialLength);
                currentInitialLength=0;
            }

            index++;
        }

        return currentMax;
    }

}