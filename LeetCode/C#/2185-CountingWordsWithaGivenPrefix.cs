/*
Approach: Brute Force
1. Initialize the result to 0.
2. Iterate through the words array.
3. For each word in the array, check if it starts with the given prefix.
4. If it does, increment the result.
5. Return the result.
Time complexity: O(n)
Space complexity: O(1)
*/
public class Solution {
    public int PrefixCount(string[] words, string pref) {
        int result=0;                       // declare result and initialize it to 0
        foreach(string word in words) {     // iterate through the words array
            if(word.StartsWith(pref)) {     // check if the word starts with the given prefix
                result++;                   // increment the result
            }
        }
        return result;                      // return the result
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
Approach: Trie
TODO
*/