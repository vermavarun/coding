/*
Approach:
1. If the array is valid, then the XOR of all the elements in the array should be 0.
2. So, we can iterate through the array and XOR all the elements.
3. If the result is 0, then the array is valid.
4. Else, the array is invalid.

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public bool DoesValidArrayExist(int[] derived) {
        int result = 0;                 // Initialize the result to 0
        foreach (int num in derived) {  // Iterate through the array
            result = result ^ num;      // XOR all the elements
        }
        return result == 0;             // Return true if the result is 0, else return false
    }
}