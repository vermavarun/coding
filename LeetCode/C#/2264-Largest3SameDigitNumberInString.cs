/*

Approach:
1. Traverse the string and check if there are 3 consecutive same digits.
2. If yes, return the maximum digit.
3. If no, return empty string.

Time Complexity: O(n)
Space Complexity: O(1)

*/
public class Solution {
    public string LargestGoodInteger(string num) {
        int currPtr = 0;
        int maxChar = -1;
        while (currPtr < num.Length - 2) {
            if(num[currPtr] == num[currPtr+1] && num[currPtr] == num[currPtr+2]) {
                maxChar = Math.Max(maxChar,num[currPtr] - '0');
            }
            currPtr++;
        }
        return maxChar > -1 ? maxChar.ToString() + maxChar.ToString() + maxChar.ToString() : "";
    }
}