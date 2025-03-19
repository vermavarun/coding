/*
Solution: https://leetcode.com/problems/number-of-1-bits/solutions/6556147/simplest-solution-c-time-o1-space1-pleas-nilu/
Approach: String conversion
1. Convert the given number to binary string.
2. Count the number of 1's in the binary string.
3. Return the count.

Time complexity: O(1)
Space complexity: O(1)
*/
public class Solution {
    public int HammingWeight(int n) {
        string binaryString = Convert.ToString(n, 2);   // Convert the given number to binary string.
        int count = 0;                                  // Declare a variable to store the count of 1's.
        foreach(char ch in binaryString) {              // Iterate through the binary string.
            count += ch == '1' ? 1 : 0;                 // If the character is '1', increment the count.
        }
        return count;                                   // Return the count.
    }
}

/*
Approach: Bit Manipulation
TODO
*/