public class Solution {
    public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            Dictionary<int,int> keyvalue = new Dictionary<int,int>();
            int index = 0;
            foreach (int num in nums)
            {
                if (keyvalue.ContainsKey(target - num))
                {
                    result[0] = index;
                    result[1] = keyvalue[target - num]; 
                }
                else
                {
                    keyvalue.TryAdd(num,index);
                }

                index++;
            }
            return result;
        }
}