/*
Title: 67. Add Binary
Solution: https://leetcode.com/problems/add-binary/solutions/7580649/simplest-solution-c-time-omaxn-m-space-o-4a2k/
Difficulty: Easy
Approach: Two Pointers from Right to Left with Carry
Tags: String, Math, Bit Manipulation, Two Pointers
1) Initialize two pointers at the end of both strings (rightmost digits).
2) Use a carry flag to track if we need to carry 1 to the next position.
3) Traverse both strings from right to left simultaneously.
4) For each position, get the digit from both strings (use '0' if pointer is out of bounds).
5) Calculate the sum based on three cases: both 1s, both 0s, or one 1 and one 0.
6) Append the result digit to StringBuilder and update carry flag.
7) After traversal, if carry is true, append '1' to result.
8) Reverse the result since we built it from right to left.

Time Complexity: O(max(n, m)) where n = length of a, m = length of b
Space Complexity: O(max(n, m)) for the result string
Tip: Binary addition follows simple rules: 0+0=0, 0+1=1, 1+0=1, 1+1=10 (carry 1). Handle the carry like you would in decimal addition. Process from right to left and use StringBuilder for efficient string building. Don't forget to handle the final carry after the loop.
Similar Problems: 2. Add Two Numbers, 43. Multiply Strings, 66. Plus One, 989. Add to Array-Form of Integer
*/

public class Solution {
    public string AddBinary(string a, string b) {

        bool carry = false;                                    // Track carry bit for addition
        int i = a.Length - 1;                                  // Pointer for string a (starts at rightmost)
        int j = b.Length - 1;                                  // Pointer for string b (starts at rightmost)

        StringBuilder result = new StringBuilder();            // Build result string efficiently

        while (i >= 0 || j >= 0) {                             // Continue until both strings are fully processed

            char aChar = (i >= 0) ? a[i] : '0';                // Get current digit from a, or '0' if out of bounds
            char bChar = (j >= 0) ? b[j] : '0';                // Get current digit from b, or '0' if out of bounds

            char abChar = '\0';                                // Result digit for current position

            if (aChar == '1' && bChar == '1') {                // Case 1: 1 + 1 = 0 or 1 (with carry)
                abChar = carry ? '1' : '0';                    // If carry: 1+1+1=11 (result='1'), else 1+1=10 (result='0')
                carry = true;                                  // Always carry 1 forward
            }
            else if (aChar == '0' && bChar == '0') {           // Case 2: 0 + 0 = 0 or 1 (depends on carry)
                abChar = carry ? '1' : '0';                    // If carry: 0+0+1=1, else 0+0=0
                carry = false;                                 // No carry forward
            }
            else {                                             // Case 3: one is '1' and other is '0'
                if (carry) {                                   // If carry: 1+0+1=10 or 0+1+1=10
                    abChar = '0';                              // Result is '0'
                    carry = true;                              // Carry 1 forward
                }
                else {                                         // No carry: 1+0=1 or 0+1=1
                    abChar = '1';                              // Result is '1'
                    carry = false;                             // No carry forward
                }
            }

            result.Append(abChar);                             // Append current digit to result
            i--;                                               // Move left in string a
            j--;                                               // Move left in string b
        }

        if (carry)                                             // If final carry exists
            result.Append('1');                                // Append it to result

        // reverse since we appended from right to left
        char[] arr = result.ToString().ToCharArray();          // Convert to character array
        Array.Reverse(arr);                                    // Reverse to get correct order

        return new string(arr);                                // Return final binary sum as string
    }
}