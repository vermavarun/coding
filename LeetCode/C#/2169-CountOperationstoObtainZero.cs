/*
Solution: Count Operations to Obtain Zero
Difficulty: Medium
Approach: Simulation with Repeated Subtraction
Tags: Math, Simulation
1) Initialize a counter to track the number of operations.
2) While both numbers are non-zero, subtract the smaller from the larger.
3) Increment the operation counter after each subtraction.
4) Continue until one of the numbers becomes zero.
5) Return the total count of operations performed.
Time Complexity: O(max(num1, num2)) - worst case when numbers differ by 1
Space Complexity: O(1)

Time Complexity: O(max(num1, num2)) - worst case when numbers differ by 1
Space Complexity: O(1)
*/
public class Solution {
    public int CountOperations(int num1, int num2) {
        int result = 0;                                         // Counter for number of operations
        while (num1 != 0 && num2 != 0) {                       // Continue while both numbers are non-zero
            if (num1 >= num2)                                   // If num1 is greater or equal
                num1 = num1 - num2;                             // Subtract num2 from num1
            else                                                // If num2 is greater
                num2 = num2 - num1;                             // Subtract num1 from num2
            result++;                                           // Increment operation counter
        }
        return result;                                          // Return total operations count
    }
}