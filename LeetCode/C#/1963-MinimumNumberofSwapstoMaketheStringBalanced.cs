/*

Approach:
1. Initialize maxNumberOfClosingBrackets, currentNumberOfClosingBrackets to 0.
2. Iterate through the string.
3. If the current character is ']', increment currentNumberOfClosingBrackets.
4. Else, decrement currentNumberOfClosingBrackets.
5. Update maxNumberOfClosingBrackets to the maximum of maxNumberOfClosingBrackets and currentNumberOfClosingBrackets.
6. Return (maxNumberOfClosingBrackets+1)/2.
7. The reason for adding 1 to maxNumberOfClosingBrackets is that we need to consider the extra closing bracket that will close the brackets.

Time complexity: O(n)
Space complexity: O(1)
where n is the length of the string.


*/
public class Solution {
    public int MinSwaps(string s) {
        int maxNumberOfClosingBrackets = 0;
        int currentNumberOfClosingBrackets = 0;
        foreach(char c in s) {
            if(c==']') {
                currentNumberOfClosingBrackets++;
            }
            else {
                currentNumberOfClosingBrackets--;
            }
            maxNumberOfClosingBrackets = Math.Max(maxNumberOfClosingBrackets,currentNumberOfClosingBrackets);
        }
        return (maxNumberOfClosingBrackets+1)/2;                                                                // div by 2 bcoz 1 extra bracket will close 2 brackets.
    }
}