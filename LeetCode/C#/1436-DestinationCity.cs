/*
Solution: 
Difficulty: Medium
Approach: HashSet
Tags: Array, String
1. Create a HashSet to store all the destination cities.
2. Add all the destination cities to the HashSet.
3. Remove all the source cities from the HashSet.
4. The remaining city in the HashSet is the destination city.
5. Return the destination city.

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public string DestCity(IList<IList<string>> paths) {

        HashSet<string> hashSet = new HashSet<string>();

        foreach(var item in paths) {
            hashSet.Add(item[1]);
        }

        foreach(var item in paths) {
            hashSet.Remove(item[0]);
        }

        return hashSet.Single();
    }
}