/*
Solution: 
Difficulty: Medium
Approach:
Tags: Hash Table, String
1. Create a dictionary to store the count of each character in the string.
2. Iterate through the string and update the count of each character in the dictionary.
3. Iterate through the string again and check if the count of the character is 1.
4. If the count is 1, return the index of the character.
5. If no such character is found, return -1.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public int FirstUniqChar(string s) {
        Dictionary<char,int> dict = new Dictionary<char,int>();
        int index = 0;

        foreach(var c in s) {
            if(!dict.ContainsKey(c)) {
                dict.Add(c,1);
            }
            else {
                dict[c] = dict[c] + 1;
            }
            index++;
        }

        index=0;

        foreach(var c in s) {
            if(dict.ContainsKey(c) && dict[c] == 1) {
                return index;
            }
            index++;
        }
        return -1;
    }
}