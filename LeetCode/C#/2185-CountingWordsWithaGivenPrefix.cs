/*
Solution: 
Difficulty: Medium
Approach: Brute Force
Tags: Array, String
1. Initialize the result to 0.
2. Iterate through the words array.
3. For each word in the array, check if it starts with the given prefix.
4. If it does, increment the result.
5. Return the result.
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
1. Create a Trie data structure.
2. Insert all the words in the Trie.
3. Search for the prefix in the Trie.
4. Return the count of the prefix.
Time complexity: O(n)
Space complexity: O(n)
*/
public class Trie {
    public Trie[] Child = new Trie[26];     // create an array of Trie nodes
    public bool WordEnd = false;            // create a boolean variable WordEnd
    public int Count;                       // create an integer variable Count

  }
public class Solution {
    public int PrefixCount(string[] words, string pref) {
        Trie root = new Trie();             // create a new Trie node root
        int result = 0;                     // declare result and initialize it to 0
        foreach(string word in words) {     // iterate through the words array
            InsertWordInTrie(root, word);   // insert the word in the Trie
        }
        result = SearchPrefix(root, pref);  // search for the prefix in the Trie
        return result;                      // return the result
    }

    public static void InsertWordInTrie(Trie root, string word) {
        Trie curr;                                  // declare a Trie node curr
        curr = root;                                // initialize curr to root
        foreach (char ch in word) {                 // iterate through the word
            if(curr.Child[ch - 'a'] == null) {      // check if the child of curr is null
                curr.Child[ch - 'a'] = new Trie();  // create a new Trie node
            }
            curr = curr.Child[ch - 'a'];            // move curr to the child
            curr.Count++;                           // increment the count
        }
        curr.WordEnd = true;                        // mark the end of the word
    }

    public static int SearchPrefix(Trie root, string pref) {
        Trie curr;                              // declare a Trie node curr
        curr = root;                            // initialize curr to root
        foreach(char ch in pref) {              // iterate through the prefix
            if(curr.Child[ch - 'a'] == null) {  // check if the child of curr is null
                return 0;                       // return 0
            }
            curr = curr.Child[ch - 'a'];        // move curr to the child
        }
        return curr.Count;                      // return the count of the prefix
    }
}