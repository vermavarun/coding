/*
Approach: Brute Force
1. For each word in the array, check if it is prefix and suffix of any other word in the array.
2. If it is, increment the result.
3. Return the result.

Time complexity: O(n^2)
Space complexity: O(1)
*/
public class Solution {
    public int CountPrefixSuffixPairs(string[] words) {
        int result = 0;                                                             // declare result and initialize it to 0
        for(int i=0; i<words.Length; i++) {                                         // iterate through the words array
            for(int j=0; j<words.Length; j++) {                                     // iterate through the words array
                if(i==j || i>j ) continue;                                          // if i is equal to j or i is greater than j, continue
                if(words[j].StartsWith(words[i]) && words[j].EndsWith(words[i])) {  // check if the word at index j is prefix and suffix of the word at index i
                    result++;                                                       // increment the result
                }
            }
        }
        return result;                                                              // return the result
    }
}