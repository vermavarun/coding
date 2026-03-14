/*
Title: 2977. Minimum Cost to Convert String II
Solution: https://leetcode.com/problems/minimum-cost-to-convert-string-ii/solutions/7536324/simplest-solution-c-time-on2-m3-space-om-wa14/
Difficulty: Hard
Approach: Trie + Floyd-Warshall + Dynamic Programming
Tags: String, Trie, Dynamic Programming, Graph, Floyd-Warshall
1) Create a Trie to store all original and changed substrings.
2) Map each unique substring to a unique integer ID.
3) Build a cost matrix to store transformation costs between substring IDs.
4) Use Floyd-Warshall algorithm to find shortest paths between all substring pairs.
5) Apply dynamic programming where dp[i] represents minimum cost to transform source[0..i-1].
6) For each position, check if characters match (0 cost) or find matching substrings in Trie.
7) Try all valid substring transformations and update DP array accordingly.
8) Return dp[n] if valid transformation exists, otherwise return -1.

Time Complexity: O(n² + m³) where n = length of strings, m = number of unique substrings
Space Complexity: O(m² + n) for cost matrix, DP array, and Trie structure
Tip: The key insight is combining Trie for efficient substring matching with Floyd-Warshall to precompute all shortest transformation paths, then using DP to find the optimal sequence of transformations. The Trie allows O(1) substring lookup instead of O(n) string comparison.
Similar Problems: 72. Edit Distance, 433. Minimum Genetic Mutation, 2976. Minimum Cost to Convert String I, 208. Implement Trie
*/
public class Solution {
    // Trie node structure for efficient substring pattern matching
    class TrieNode {
        public TrieNode[] children = new TrieNode[26];      // 26 lowercase English letters
        public int identifier = -1;                         // Unique ID for complete substring, -1 if not end
    }

    // Insert substring into Trie with unique identifier for later lookup
    private void BuildTrie(TrieNode root, string word, int identifier) {
        TrieNode current = root;                            // Start from root node
        foreach (char ch in word) {                         // Traverse each character in word
            int pos = ch - 'a';                             // Convert char to index (0-25)
            if (current.children[pos] == null) {            // If child node doesn't exist
                current.children[pos] = new TrieNode();     // Create new Trie node
            }
            current = current.children[pos];                // Move to child node
        }
        current.identifier = identifier;                    // Mark end of substring with unique ID
    }

    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost) {
        int len = source.Length;                            // Get length of source/target strings

        Dictionary<string, int> wordMapping = new Dictionary<string, int>();    // Map substring -> unique ID
        TrieNode trieRoot = new TrieNode();                 // Initialize Trie root
        int indexCounter = 0;                               // Counter for assigning unique IDs

        // Process all original substrings and assign unique IDs
        foreach (string word in original) {                 // Iterate through original array
            if (!wordMapping.ContainsKey(word)) {           // If substring not seen before
                wordMapping[word] = indexCounter;           // Assign new unique ID
                BuildTrie(trieRoot, word, indexCounter);    // Insert into Trie with ID
                indexCounter++;                             // Increment counter for next unique ID
            }
        }

        // Process all changed substrings and assign unique IDs
        foreach (string word in changed) {                  // Iterate through changed array
            if (!wordMapping.ContainsKey(word)) {           // If substring not seen before
                wordMapping[word] = indexCounter;           // Assign new unique ID
                BuildTrie(trieRoot, word, indexCounter);    // Insert into Trie with ID
                indexCounter++;                             // Increment counter for next unique ID
            }
        }

        // Initialize cost matrix with infinity for all pairs
        long[][] costMatrix = new long[indexCounter][];     // 2D array for transformation costs
        long INFINITY = long.MaxValue;                      // Define infinity value
        for (int i = 0; i < indexCounter; i++) {            // Initialize each row
            costMatrix[i] = new long[indexCounter];         // Create new row array
            Array.Fill(costMatrix[i], INFINITY);            // Fill row with infinity
            costMatrix[i][i] = 0;                           // Cost to transform substring to itself is 0
        }

        // Populate direct transformation costs from input arrays
        for (int i = 0; i < original.Length; i++) {         // Iterate through all transformations
            int from = wordMapping[original[i]];            // Get source substring ID
            int to = wordMapping[changed[i]];               // Get target substring ID
            costMatrix[from][to] = Math.Min(costMatrix[from][to], cost[i]);    // Store minimum cost
        }

        // Apply Floyd-Warshall algorithm to compute shortest paths between all substring pairs
        for (int mid = 0; mid < indexCounter; mid++) {      // Iterate through intermediate nodes
            for (int from = 0; from < indexCounter; from++) {   // Iterate through source nodes
                if (costMatrix[from][mid] == INFINITY) continue;    // Skip if path from->mid is infinity
                for (int to = 0; to < indexCounter; to++) {     // Iterate through destination nodes
                    if (costMatrix[mid][to] == INFINITY) continue;  // Skip if path mid->to is infinity
                    costMatrix[from][to] = Math.Min(costMatrix[from][to],   // Update minimum cost
                                                     costMatrix[from][mid] + costMatrix[mid][to]);  // Via intermediate
                }
            }
        }

        // Initialize DP array where dp[i] = minimum cost to transform source[0..i-1] to target[0..i-1]
        long[] memo = new long[len + 1];                    // DP array of size n+1
        Array.Fill(memo, INFINITY);                         // Initialize all positions with infinity
        memo[0] = 0;                                        // Base case: empty string has 0 cost

        char[] srcChars = source.ToCharArray();             // Convert source to char array for O(1) access
        char[] tgtChars = target.ToCharArray();             // Convert target to char array for O(1) access

        // Process each position in strings using dynamic programming
        for (int i = 0; i < len; i++) {                     // Iterate through each position
            if (memo[i] == INFINITY) continue;              // Skip unreachable positions

            // Handle single character match with no transformation cost
            if (srcChars[i] == tgtChars[i]) {               // If characters at position i match
                memo[i + 1] = Math.Min(memo[i + 1], memo[i]);   // No cost, just advance position
            }

            // Find all valid target substrings starting at current position using Trie
            TrieNode targetNode = trieRoot;                 // Start from Trie root for target
            Dictionary<int, int> matchedTargetIds = new Dictionary<int, int>();     // Map length -> target ID

            for (int j = i; j < len; j++) {                 // Extend substring from position i
                int charPos = tgtChars[j] - 'a';            // Get character index
                if (targetNode.children[charPos] == null) break;    // No more valid substrings
                targetNode = targetNode.children[charPos];  // Move to child node
                if (targetNode.identifier != -1) {          // If valid substring found
                    int substringLen = j - i + 1;           // Calculate substring length
                    matchedTargetIds[substringLen] = targetNode.identifier; // Store length -> ID mapping
                }
            }

            // Find all valid source substrings and try transformations
            TrieNode sourceNode = trieRoot;                 // Start from Trie root for source
            for (int j = i; j < len; j++) {                 // Extend substring from position i
                int charPos = srcChars[j] - 'a';            // Get character index
                if (sourceNode.children[charPos] == null) break;    // No more valid substrings
                sourceNode = sourceNode.children[charPos];  // Move to child node

                if (sourceNode.identifier != -1) {          // If valid source substring found
                    int substringLen = j - i + 1;           // Calculate substring length
                    if (matchedTargetIds.ContainsKey(substringLen)) {   // If target substring with same length exists
                        int srcId = sourceNode.identifier;  // Get source substring ID
                        int tgtId = matchedTargetIds[substringLen]; // Get target substring ID

                        // Update DP with transformation cost if path exists
                        if (costMatrix[srcId][tgtId] != INFINITY) { // If transformation possible
                            memo[i + substringLen] = Math.Min(memo[i + substringLen],   // Update minimum cost
                                                               memo[i] + costMatrix[srcId][tgtId]); // Current + transform
                        }
                    }
                }
            }
        }

        return memo[len] == INFINITY ? -1 : memo[len];      // Return -1 if impossible, else minimum cost
    }
}