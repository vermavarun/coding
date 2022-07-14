// Simple Detailed Solution
public class Solution
{
    public int Search(int[] nums, int target)
    {

        int left = 0, right = nums.Length - 1, mid = (left + right) / 2;
        int targetIndex = -1;

        while (true)
        {

            if (target == nums[left])
            {
                targetIndex = left;
                break;
            }

            if (target == nums[right])
            {
                targetIndex = right;
                break;
            }

            if (target == nums[mid])
            {
                targetIndex = mid;
                break;
            }

            if (right == left || mid == 0)
                break;

            if (target > nums[mid])
            {
                left = mid + 1;
            }
            else if (target < nums[mid])
            {
                right = mid - 1;
            }

            mid = (left + right) / 2;


        }

        return targetIndex;

    }
}
