/*
Solution: 
Difficulty: Medium
Approach:
Tags: String
1. Start from the end of the string and check if the number is odd or even.
2. If the number is even or 0, remove it from the string.
3. If the number is odd, return the string.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public string LargestOddNumber(string num) {

        int index = num.Length - 1;                                      // Start from the end of the string
        int removals = 0;                                                // Number of removals
        while (index >= 0) {                                             // Iterate through the string
             if((num[index] - '0') % 2 == 0) {                           // If the number is even
                removals++;                                              // Remove the number
                index--;                                                 // Move to the next number
            }
            else {
                break;                                                   // If the number is odd, break the loop
            }
        }
        return num.Substring(0,num.Length - removals);                   // Return the string after removing the even numbers
    }
}