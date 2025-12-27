/*
Solution:
Difficulty: Easy
Approach: Dictionary (Hash Map) for frequency counting
Tags: Array, Hash Table, Divide and Conquer, Sorting, Counting
1) Create a dictionary to store frequency of each element.
2) Iterate through array and increment count for each element.
3) Track element with maximum frequency during iteration.
4) Return the element that appears more than n/2 times.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the dictionary
*/
// Approach 1: Using Dictionary to store the frequency of each element in the array. Then, iterate over the dictionary to find the element with the maximum frequency.
public class Solution {
    public int MajorityElement(int[] nums) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
            int resultValue = int.MinValue;
            int resultIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                    if(dict[nums[i]] > resultValue){
                        resultValue = dict[nums[i]];
                        resultIndex = i;
                    }
                }
                else
                {
                    dict[nums[i]] = 1;
                }
            }
            return nums[resultIndex];
    }
}
// Approach 2: Using Boyer-Moore Voting Algorithm
public class Solution {
    public int MajorityElement(int[] nums) {

        int currentNum = nums[0];
        int currentNumCount = 0;

        for(int i=0; i<nums.Length; i++) {
            if(nums[i] == currentNum) {
                currentNumCount++;
            }
            else {
                if(currentNumCount == 0) {
                    currentNum = nums[i];
                }
                else {
                currentNumCount--;
                }
            }
        }

        return currentNum;

    }
}
