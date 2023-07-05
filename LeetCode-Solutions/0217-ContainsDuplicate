public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        Dictionary<int,int> dict = new Dictionary<int,int>();

        int index = 0;
        while(index < nums.Length) {

            if(dict.ContainsKey(nums[index])) {
                return true;
            }
            else{
                dict.Add(nums[index],nums[index]);
            }

            index++;
        }

        return false;
    }
}


// Another Solution
public class Solution {
    public bool ContainsDuplicate(int[] nums) {
       
        int index = 0;
        Array.Sort(nums);
        while(index < nums.Length - 1) {
            if(nums[index] == nums[index+1])
                return true;
            index++;
        }

        return false;


    }
}
