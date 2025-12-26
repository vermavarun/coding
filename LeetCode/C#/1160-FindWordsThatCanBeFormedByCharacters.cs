/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Hash Table, String
1. Create a dictionary of characters and their count in chars string.
2. For each word in words, create a dictionary of characters and their count.
3. Check if the word can be formed from chars string.
4. Return the result.

Time Complexity: O(n*m) where n is the length of words and m is the length of chars.
Space Complexity: O(n) where n is the length of chars.
*/
public class Solution {
    public int CountCharacters(string[] words, string chars) {
        Dictionary<char,int> dict = new Dictionary<char,int>();
        Dictionary<char,int> temp = new Dictionary<char,int>();
        int result = 0;
        foreach(char ch in chars) {
            if(!dict.ContainsKey(ch)) {
                dict[ch] = 1;
            }
            else {
                dict[ch] = dict[ch] + 1;
            }
        }

        foreach(string word in words) {

            foreach(char ch in word) {
               if(!temp.ContainsKey(ch)) {
                    temp[ch] = 1;
                }
                else {
                    temp[ch] = temp[ch] + 1;
                }
            }

            int index = 0;
            foreach(var kv in temp) {
                if (dict.ContainsKey(kv.Key) && dict[kv.Key] >= temp[kv.Key])  {
                    index++;
                    continue;
                }
                else {
                    break;
                }
            }
            if (index == temp.Count())
                result = result + word.Length;
            temp.Clear();
        }
        return result;

    }
}