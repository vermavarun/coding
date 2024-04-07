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
