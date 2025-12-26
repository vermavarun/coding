/*
Solution:
Difficulty: Medium
Approach: [To be documented]
Tags: Array, Sorting
1. We need to find the number of content children.
2. We have to assign cookies to children such that each child gets at most one cookie.
3. We need to find the maximum number of content children.
4. We can sort the children and cookies in ascending order.
5. Then, we can iterate through the children and cookies.
Space Complexity: O(1)

Time Complexity: O(nlogn)
Space Complexity: O(1)
*/

public class Solution {
    public int FindContentChildren(int[] g, int[] s) {
        Array.Sort(g);                                  // Sort the children
        Array.Sort(s);                                  // Sort the cookies
        int i, j;                                       // Initialize two pointers
        i = j = 0;                                      // Initialize the pointers to 0
        while(j < s.Length && i < g.Length) {           // Iterate through the children and cookies
            if(s[j] >= g[i]) {                          // If the cookie is greater than or equal to the greed factor of the child
                i++;                                    // Move to the next child
            }
            j++;                                        // Move to the next cookie
        }
        return i;                                       // Return the number of content children
    }
}