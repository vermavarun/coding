/*
Solution:
Difficulty: Medium
Approach: Hash Map with sorted string as key
Tags: Array, Hash Table, String, Sorting
1) Create a dictionary with sorted string as key and list of anagrams as value.
2) Iterate through each string in the input array.
3) Sort each string to create a key.
4) If key exists in dictionary, add string to existing list.
5) Otherwise, create new entry with key and string as first element.
6) Return all values from dictionary as result.

Time Complexity: O(n * k log k) where n = strs.length, k = max string length
Space Complexity: O(n * k) for storing all strings
*/

// Approach 1
// Use Dictionary to insert array sorted element as key and all elements as values.
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string,IList<string>> dict = new Dictionary<string,IList<string>>();
        foreach(string s in strs) {
            var key = new string(s.OrderBy(c=>c).ToArray());
            if(dict.ContainsKey(key)) {
                dict[key].Add(s);
            }
            else{
                dict.Add(key,new List<string>(){s});
            }
        }
        return dict.Values.ToList();
    }
}