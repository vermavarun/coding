/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Two Pointers, String
1. Create a diff array of size s.Length
2. Create a chars array of size s.Length
3. Create a StringBuilder
4. Iterate through the string and populate the chars array
5. Iterate through the shifts array and populate the diff array
6. Iterate through the diff array and calculate the cumulative sum
7. Iterate through the chars array and calculate the new position of the character
8. Append the new character to the StringBuilder
9. Return the StringBuilder as string

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public string ShiftingLetters(string s, int[][] shifts) {
        int[] diff = new int[s.Length];                             // declare an array of size s.Length
        int[] chars = new int[s.Length];                            // declare an array of size s.Length
        int index = 0;                                              // declare an index variable
        int modFactor = 26;                                         // declare a modFactor variable
        StringBuilder sb = new StringBuilder();                     // declare a StringBuilder

        // Populate the chars array
        foreach(char c in s) {                                      // iterate through the string and populate the chars array
            chars[index] = c - 'a';                                 // populate the chars array
            index++;                                                // increment the index
        }

        // Populate the diff array
        foreach(var shift in shifts) {                              // iterate through the shifts array
            int left = shift[0];                                    // declare a left variable
            int right = shift[1];                                   // declare a right variable
            int factor = shift[2] == 0 ? -1 : 1;                    // declare a factor variable

            diff[left] = (diff[left] + factor) ;                    // populate the diff array
            if ((right+1) < diff.Length) {                          // check if right+1 is less than diff.Length
                diff[right + 1] = (diff[right + 1] - factor);       // populate the diff array
            }

        }

        // Calculate the cumulative sum
        index = 0;                                                  // reset the index
        int cumSum = 0;                                             // declare a cumSum variable
        while (index < s.Length) {                                  // iterate through the diff array
            diff[index] = diff[index] + cumSum;                     // calculate the cumulative sum
            cumSum = diff[index];                                   // update the cumSum
            index++;                                                // increment the index
        }

        // Calculate the new position of the character
        index=0;                                                    // reset the index
        while (index < s.Length) {                                  // iterate through the chars array
            int newPos = chars[index] + diff[index];                // calculate the new position of the character
            newPos = newPos % modFactor;                            // calculate the new position of the character
            if(newPos < 0) {                                        // check if newPos is less than 0
                newPos = newPos + modFactor;                        // calculate the new position of the character
            }
            char newChar = (char)(newPos + 'a');                    // calculate the new character
            sb.Append(newChar);                                     // append the new character to the StringBuilder
            index++;                                                // increment the index
        }

        return sb.ToString();                                       // return the StringBuilder as string
    }
}