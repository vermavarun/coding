/*
Solution: 
Difficulty: Medium
Approach:
Tags: String
1. Start from the beginning of the string and check if 'b' is found for the first time.
2. If 'b' is found for the first time, set the flag to true.
3. If once 'b' is found, check if all the characters are 'b'. If not, return false.
4. return true if all 'b's are found after the first 'b'.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public bool CheckString(string s) {
        bool bFound = false;                                    // Flag to check if 'b' is found
        foreach(char ch in s) {                                 // Iterate through the string
            if(ch == 'b' && bFound == false) {                  // If 'b' is found for the first time
                bFound = true;                                  // Set the flag to true
                continue;                                       // Continue to the next character
            }
            if(bFound && ch !='b')                              // If 'b' is found and a character other than 'b' is found
                return false;                                   // Return false
        }
        return true;                                            // Return true if all 'b's are found after the first 'b'
    }
}