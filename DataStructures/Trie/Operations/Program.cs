using System;
using System.Collections.Generic;

class TrieNode
{
    // Array to store children nodes (one for each letter 'a' to 'z')
    public TrieNode[] Child = new TrieNode[26];

    // Boolean to mark the end of the word
    public bool WordEnd = false;
}

class Trie
{
    // Method to insert a key into the Trie
    static void InsertKey(TrieNode root, string key)
    {
        // Initialize the curr pointer with the root node
        TrieNode curr = root;

        // Iterate across the length of the string
        foreach (char c in key)
        {
            // Check if the node exists for the current character in the Trie
            if (curr.Child[c - 'a'] == null)
            {
                // If node for current character does not exist, create a new node
                TrieNode newNode = new TrieNode();
                curr.Child[c - 'a'] = newNode;
            }

            // Move the curr pointer to the newly created node
            curr = curr.Child[c - 'a'];
        }

        // Mark the end of the word
        curr.WordEnd = true;
    }

    // Method to search a key in the Trie
    static bool SearchKey(TrieNode root, string key)
    {
        // Initialize the curr pointer with the root node
        TrieNode curr = root;

        // Iterate across the length of the string
        foreach (char c in key)
        {
            // Check if the node exists for the current character in the Trie
            if (curr.Child[c - 'a'] == null)
                return false;

            // Move the curr pointer to the already existing node for the current character
            curr = curr.Child[c - 'a'];
        }

        // Return true if the word exists and is marked as ending
        return curr.WordEnd;
    }

    // Main function to test the Trie functionality
    public static void Main()
    {
        // Create an example Trie
        TrieNode root = new TrieNode();
        List<string> arr = new List<string> { "and", "ant", "do", "geek", "dad", "ball" };

        // Insert words into the Trie
        foreach (var s in arr)
        {
            InsertKey(root, s);
        }

        // One by one search strings
        List<string> searchKeys = new List<string> { "do", "gee", "bat" };
        foreach (var s in searchKeys)
        {
            Console.WriteLine("Key : " + s);
            if (SearchKey(root, s))
                Console.WriteLine("Present");
            else
                Console.WriteLine("Not Present");
        }
    }
}