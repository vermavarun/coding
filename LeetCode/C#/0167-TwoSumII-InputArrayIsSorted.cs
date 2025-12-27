/*
Solution: 
Difficulty: Easy
Approach:
Tags: Array
1. Initialize left to 0 and right to numbers.Length - 1.
2. Initialize an array res of size 2.
3. Iterate while left is less than right.
4. If the sum of numbers[left] and numbers[right] is greater than target, decrement right.
5. If the sum of numbers[left] and numbers[right] is less than target, increment left.
6. If the sum of numbers[left] and numbers[right] is equal to target, break.
7. Update res[0] to left + 1 and res[1] to right + 1.
8. Return res.
Space complexity: O(1)

Time Complexity: O(?)
*/
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0;
        int right = numbers.Length - 1;
        int[] res = new int[2];

        while (left < right) {
            if( (numbers[left] + numbers[right]) > target ) {
                right--;
            }

            if( (numbers[left] + numbers[right]) < target ) {
                left++;
            }

            if( (numbers[left] + numbers[right]) == target ) {
                break;
            }
        }

        res[0] = left + 1;
        res[1] = right + 1;
        return res;
    }
}