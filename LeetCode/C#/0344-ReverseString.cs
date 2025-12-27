/*
Solution: 
Difficulty: Easy
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public void ReverseString(char[] s) {

        int left = 0;
        int right = s.Length-1;
        char temp;

        while ( left <= right ) {

            temp = s[left];
            s[left] = s[right];
            s[right] = temp;

            left++;
            right--;
        }

    }
}