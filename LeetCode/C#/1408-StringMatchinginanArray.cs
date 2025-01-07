/*
Approach: Brute Force
1. Create a list of strings to store the result
2. Iterate through the words array
3. Iterate through the words array again
4. Check if the word is not the same as the current word and the current word is a substring of the word
5. If the condition is true, add the current word to the result list and break the inner loop
6. Return the result list

Note: Use KMP, trie, Rabin-Karp, or other string matching algorithms for better performance
Time complexity: O(n^2)
Space complexity: O(n)
*/
public class Solution {
    public IList<string> StringMatching(string[] words) {
        IList<string> result = new List<string>();      // declare a list of strings to store the result
        for (int i=0; i<words.Length; i++) {            // iterate through the words array
            for (int j=0; j<words.Length; j++) {        // iterate through the words array again
                if (i==j) continue;                     // check if the word is not the same as the current word
                if(words[j].Contains(words[i])) {       // check if the current word is a substring of the word
                    result.Add(words[i]);               // add the current word to the result list
                    break;                              // break the inner loop if the word is found to avoid duplicates
                }
            }
        }
        return result;
    }
}