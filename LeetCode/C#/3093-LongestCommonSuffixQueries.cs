/*
Title: 3093. Longest Common Suffix Queries
Solution: https://leetcode.com/problems/longest-common-suffix-queries/solutions/8299279/simplest-solution-c-time-ol-space-ol-ple-laeq/
Difficulty: Hard
Approach: Trie (Suffix Trie) for efficient suffix matching
Tags: Trie, String, Suffix, Query
1) Build a Trie where each word is inserted in reverse (to match suffixes).
2) Each Trie node tracks the best (shortest, then smallest index) word ending at or below it.
3) For each query, traverse the Trie in reverse order of the query string to find the deepest matching suffix.
4) Return the index of the best matching word for each query.

Time Complexity: O(L) per insert/query, where L is the total length of all words/queries
Space Complexity: O(L) for the Trie
Tip: Insert words in reverse to turn suffix queries into prefix queries on the Trie. Track best index/length at each node for fast lookup.
Similar Problems: 208. Implement Trie, 211. Design Add and Search Words Data Structure, 1032. Stream of Characters
*/
public class Solution
{
    // Trie node definition for lowercase English letters
    class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26]; // Children nodes for each character
        public int BestIndex = -1;                     // Index of the best matching word
        public int BestLength = int.MaxValue;          // Length of the best matching word
    }

    private TrieNode root = new TrieNode(); // Root of the Trie

    // Update the best index/length at this node if the new word is better
    private void Update(TrieNode node, int index, int length)
    {
        if (length < node.BestLength ||
           (length == node.BestLength && index < node.BestIndex))
        {
            node.BestLength = length;
            node.BestIndex = index;
        }
    }

    // Insert a word into the Trie in reverse order
    private void Insert(string word, int index)
    {
        TrieNode node = root;

        Update(node, index, word.Length); // Update root with this word

        for (int i = word.Length - 1; i >= 0; i--)
        {
            int c = word[i] - 'a'; // Map character to index

            if (node.Children[c] == null)
                node.Children[c] = new TrieNode(); // Create child if missing

            node = node.Children[c];

            Update(node, index, word.Length); // Update best at this node
        }
    }

    // Query the Trie for the best matching suffix for the given word
    private int Query(string word)
    {
        TrieNode node = root;

        for (int i = word.Length - 1; i >= 0; i--)
        {
            int c = word[i] - 'a';

            if (node.Children[c] == null)
                break; // No further match

            node = node.Children[c];
        }

        return node.BestIndex; // Return best index found
    }

    // Main function: for each query, return the index of the best matching word
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        // Build Trie with all words
        for (int i = 0; i < wordsContainer.Length; i++)
        {
            Insert(wordsContainer[i], i); // Insert each word into the Trie
        }

        int[] result = new int[wordsQuery.Length]; // Result array

        // Process each query
        for (int i = 0; i < wordsQuery.Length; i++)
        {
            result[i] = Query(wordsQuery[i]); // Query for best matching suffix
        }

        return result;
    }
}