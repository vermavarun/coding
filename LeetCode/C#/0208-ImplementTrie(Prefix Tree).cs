/*
Solution: 
Difficulty: Easy
Approach:
Tags: Array, Binary Tree, String
1. Create a TrieNode class with 26 children and a boolean variable to check if it is the end of the word.
2. Create a Trie class with Insert, Search, and StartsWith methods.
3. In the Insert method, iterate through the word and check if the current character's child is null. If it is null, create a new TrieNode and assign it to the current character's child.
4. In the Search method, iterate through the word and check if the current character's child is null. If it is null, return false. If the iteration is completed, return the value of the EndOfWord variable.
5. In the StartsWith method, iterate through the prefix and check if the current character's child is null. If it is null, return false. If the iteration is completed, return true.

Time Complexity: Insert: O(n), Search: O(n), StartsWith: O(n)
Space Complexity: O(n)
*/
public class TrieNode {                                         // TrieNode class
    public TrieNode[] Children = new TrieNode[26];              // Array to store children nodes (one for each letter 'a' to 'z')
    public bool EndOfWord = false;                              // Boolean to mark the end of the word
}
public class Trie {                                             // Trie class

    private TrieNode _trie;                                     // TrieNode object
    public Trie() {
        _trie = new TrieNode();                                 // Initialize the TrieNode object
    }

    public void Insert(string word) {                           // Method to insert a key into the Trie
        var _curr = _trie;                                      // Initialize the curr pointer with the root node
        foreach (char c in word) {                              // Iterate across the length of the string
            if(_curr.Children[c - 'a'] == null) {               // Check if the node exists for the current character in the Trie
                _curr.Children[c - 'a'] = new TrieNode();       // If node for current character does not exist, create a new node
            }
            _curr = _curr.Children[c - 'a'];                    // Move the curr pointer to the newly created node
        }
        _curr.EndOfWord = true;                                 // Mark the end of the word
    }

    public bool Search(string word) {                           // Method to search a key in the Trie
        var _curr = _trie;                                      // Initialize the curr pointer with the root node
        foreach (char c in word) {                              // Iterate across the length of the string
            if (_curr.Children[c - 'a'] == null)                // Check if the node exists for the current character in the Trie
                return false;                                   // Return false if the node does not exist
            _curr = _curr.Children[c - 'a'];                    // Move the curr pointer to the already existing node for the current character
        }
        return _curr.EndOfWord;                                 // Return true if the word exists and is marked as ending
    }

    public bool StartsWith(string prefix) {                     // Method to search a prefix in the Trie
        var _curr = _trie;                                      // Initialize the curr pointer with the root node
        foreach (char c in prefix) {                            // Iterate across the length of the string
            if (_curr.Children[c - 'a'] == null)                // Check if the node exists for the current character in the Trie
                return false;                                   // Return false if the node does not exist
            _curr = _curr.Children[c - 'a'];                    // Move the curr pointer to the already existing node for the current character
        }
        return true;                                            // Return true if the prefix exists
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */