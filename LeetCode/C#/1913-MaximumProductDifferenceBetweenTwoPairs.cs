/*

Approach:
1. Initialize max1, max2, min1, min2 to int.MinValue and int.MaxValue respectively.
2. Iterate through the array.
3. If the current number is greater than max2, update max2.
4. If the current number is greater than max1, update max2 to max1 and max1 to the current number.
5. If the current number is less than min2, update min2.
6. If the current number is less than min1, update min2 to min1 and min1 to the current number.
7. Return the difference between the product of max1 and max2 and the product of min1 and min2.

Time complexity: O(n)
Space complexity: O(1)
where n is the number of elements in the array.


*/
public class Solution {
    public int MaxProductDifference(int[] nums) {
         int max1, max2, min1, min2, index,currentNumber;
            max1 = max2 = int.MinValue;
            min1 = min2 = int.MaxValue;
            index = 0;

            while (index < nums.Length) {

                currentNumber = nums[index];

                if (currentNumber > max2) {
                    max2 = currentNumber;
                }

                if(currentNumber > max1) {
                    max2 = max1;
                    max1 = currentNumber;
                }

                if(currentNumber < min2) {
                    min2 = currentNumber;
                }

                if(currentNumber < min1) {
                    min2 = min1;
                    min1 = currentNumber;
                }

                index++;

            }

            return (max1 * max2) - (min1 * min2);
    }
}