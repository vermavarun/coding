/*

Approach:
1. Create a dictionary to store the frequency of each character in the words array.
2. Iterate through the words array and calculate the frequency of each character.
3. If the frequency of any character is not divisible by the length of the words array, return false.
4. If all characters have a frequency divisible by the length of the words array, return true.

Time complexity: O(n*m)
Space complexity: O(n)
where n is the number of words in the array and m is the average length of the words.


*/
public class Solution {
    public bool MakeEqual(string[] words) {
        Dictionary<char,int> dict = new Dictionary<char, int>();

            foreach (string word in words) {

                foreach(char ch in word) {

                    if (dict.ContainsKey(ch)) {
                        dict[ch] = dict[ch] + 1;
                    }
                    else {
                        dict.Add(ch,1);
                    }
                }
            }

            foreach(var kv in dict) {
                if (kv.Value % words.Length  !=  0)
                    return false;
            }

            return true;
    }
}