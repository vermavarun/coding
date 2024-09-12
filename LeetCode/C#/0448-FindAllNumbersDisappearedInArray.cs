/*
Approach:
1. Create a new array of size n and fill it with 1 to n.
2. Traverse the given array and mark the index of the element as -1 in the new array.
3. Traverse the new array and add the index of the element which is not marked as -1 to the result list.
4. Return the result list.

Time Complexity: O(n)
Space Complexity: O(n)


*/
public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
            int[] check = new int[nums.Length];
            IList<int> result = new List<int>();
            int i=0;

            while(i < nums.Length) {
                check[i] = i+1;
                i++;
            }

            i=0;
            while(i < nums.Length) {
                check[nums[i] - 1] = -1;
                i++;
            }

            i=0;
            while(i < check.Length) {
                if (check[i] != -1) {
                    result.Add(check[i]);
                }
                i++;
            }

            return result;
    }
}