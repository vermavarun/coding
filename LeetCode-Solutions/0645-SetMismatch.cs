/*

Approach:
1. Create a hashset to store the unique numbers.
2. Initialize the current sum, first duplicate number, and missing number.
3. Iterate through the numbers array and for each number, check if it is already present in the hashset.
4. If it is present, update the first duplicate number.
5. If it is not present, add the number to the hashset and update the current sum.
6. Calculate the missing number using the formula (n*(n+1)/2) - current sum.
7. Return the first duplicate number and the missing number.

Time complexity: O(n)
Space complexity: O(n)

*/
public class Solution {
    public int[] FindErrorNums(int[] nums) {

        HashSet<int> set = new HashSet<int>();
        int currentSum = 0;
        int firstDupNum = -1;
        int missingNum = -1;

        foreach(int num in nums) {
            if(set.Contains(num)) {
                firstDupNum = num;
            }
            else {
                set.Add(num);
                currentSum = currentSum + num;
            }
        }

        missingNum = ( nums.Length*(nums.Length + 1) / 2 ) - currentSum;

        return [firstDupNum,missingNum];

    }
}