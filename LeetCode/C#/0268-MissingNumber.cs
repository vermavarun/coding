/*
Approach: Xor
1. We know that the numbers are from 0 to n. So, we can xor all the numbers from 0 to n and all the numbers in the array.
2. The result will be the missing number.
3. The reason is that the xor of the same number is 0. So, the missing number will be left out.

Time Complexity: O(n)
Space Complexity: O(1)

*/
public class Solution {
    public int MissingNumber(int[] nums) {
        int lengthOfNums = nums.Length;         // Length of the array
        int result = lengthOfNums;              // Initialize the result with the length of the array
        for(int i=0; i<lengthOfNums; i++) {     // Loop through the array
            result = result ^ i ^ nums[i];      // Xor the result with the index and the number in the array
        }                                       // The result will be the missing number
        return result;                          // Return the result
     }
}


/*
Approach: Sum of n numbers
1. We know that the numbers are from 0 to n. So, we can calculate the sum of n numbers.
2. We can calculate the sum of all the numbers in the array.
3. The difference between the sum of n numbers and the sum of all the numbers in the array will be the missing number.

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int MissingNumber(int[] nums) {
        int sumOfElements = nums.Sum();                                     // Sum of all the elements in the array
        int lengthOfElements = nums.Length;                                 // Length of the array
        int sumOfNElements = (lengthOfElements*(lengthOfElements+1)) / 2;   // Sum of n numbers
        int result = sumOfNElements - sumOfElements;                        // Missing number
        return result;                                                      // Return the missing number
    }
}