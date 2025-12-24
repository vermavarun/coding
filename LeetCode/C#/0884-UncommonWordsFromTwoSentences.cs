/*
Solution: https://leetcode.com/problems/uncommon-words-from-two-sentences/solutions/7435091/simplest-solution-c-time-onm-spacenm-ple-d23q/
Difficulty: Easy
Approach: Hash Table for word frequency counting
Tags: Hash Table, String, Counting
1) Create a dictionary to count word occurrences across both sentences.
2) Split both sentences into individual words.
3) Process first sentence: mark words as 1 if new, 2 if already seen.
4) Process second sentence: mark words as 2 if seen, 1 if new.
5) Iterate through dictionary and collect words with count exactly 1.
6) Return the list of uncommon words (appearing exactly once total).

Time Complexity: O(n + m) where n = words in s1, m = words in s2
Space Complexity: O(n + m) for the dictionary and result list
*/
public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        Dictionary<string,int> map = new Dictionary<string,int>();      // Store word frequencies (1=unique, 2=duplicate)
        List<string> result = new List<string>();                       // List to collect uncommon words
        var words1 = s1.Split(' ').ToArray();                           // Split first sentence into words
        var words2 = s2.Split(' ').ToArray();                           // Split second sentence into words

        foreach(string word1 in words1) {                               // Process words from first sentence
            if (!map.ContainsKey(word1))                                // If word is new
                map[word1]=1;                                           // Mark as appearing once
            else                                                        // If word already exists
                map[word1]=2;                                           // Mark as duplicate (2+ occurrences)
        }

        foreach(string word2 in words2) {                               // Process words from second sentence
            if (map.ContainsKey(word2))                                 // If word exists (from s1 or earlier in s2)
                map[word2]=2;                                           // Mark as duplicate
            else                                                        // If word is new
                map[word2]=1;                                           // Mark as appearing once
        }

        foreach(var kv in map) {                                        // Iterate through all unique words
            if (kv.Value == 1) {                                        // If word appears exactly once total
                result.Add(kv.Key);                                     // Add to result list
            }
        }

        return result.ToArray();                                        // Convert list to array and return
    }
}