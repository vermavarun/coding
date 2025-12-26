/*
Solution: 
Difficulty: Medium
Approach:
Tags: Hash Table, String, Math
1. Create a dictionary to store the index of the first occurrence of a character.
2. Iterate through the string and check if the character is already present in the dictionary.
3. If it is present, calculate the difference between the current index and the index of the first occurrence of the character.
4. Update the result with the maximum difference.
5. Return the result.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public int MaxLengthBetweenEqualCharacters(string s) {
        Dictionary<char,int> dict = new Dictionary<char, int>();

            int index, result;
            index = 0;
            result = -1;

            while(index < s.Length) {

                if(!dict.ContainsKey(s[index])) {
                    dict[s[index]] = index;
                }
                else {
                    result = Math.Max(index - dict[s[index]] - 1,result);
                }
                index++;
            }
            return result;
    }
}