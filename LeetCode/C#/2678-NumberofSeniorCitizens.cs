/*
Approach:
1. Declare a variable result and initialize it to 0.
2. Iterate through the details array.
3. For each detail, get the age by converting the characters at index 11 and 12 to integers.
4. If the age is greater than 60, increment the result.
5. Return the result.
Time complexity: O(n)
Space complexity: O(1)
*/
public class Solution {
    public int CountSeniors(string[] details) {
        int result = 0;
        foreach (string detail in details) {            // iterate through the details array
            int numberAt11 = detail[11] - '0';          // get the integer value of the character at index 11
            int numberAt12 = detail[12] - '0';          // get the integer value of the character at index 12
            int age = (numberAt11*10) + numberAt12;     // calculate the age
            if (age > 60) result++;                     // check if the age is greater than 60
        }
        return result;                                  // return the result
    }
}