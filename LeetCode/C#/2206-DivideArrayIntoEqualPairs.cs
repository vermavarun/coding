/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array
1. Create a boolean array of size 1000 and fill it with true.
2. Iterate through the array and toggle the value of the index in the boolean array.
3. If the value is false, return false.
4. If all the values are true, return true.
Space complexity is O(1)

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public bool DivideArray(int[] nums) {
        bool[] pair = new bool[1000];   // Create a boolean array of size 1000 and fill it with true.
        Array.Fill(pair,true);          // Fill the array with true.
        foreach(int num in nums) {      // Iterate through the array and toggle the value of the index in the boolean array.
            pair[num] = !pair[num];     // Toggle the value of the index in the boolean array.
        }
        foreach(bool value in pair) {   // If the value is false, return false.
            if (value == false)         // If the value is false, return false.
                return false;           // Return false.
        }
        return true;                    // If all the values are true, return true.
    }
}