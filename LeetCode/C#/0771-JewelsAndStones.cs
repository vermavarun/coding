/*
Solution: https://leetcode.com/problems/jewels-and-stones/solutions/7419143/simplest-solution-c-time-ojs-spacej-plea-y8ff/
Difficulty: Easy
Approach: HashSet for O(1) lookup
Tags: Hash Table, String
1) Create a HashSet to store all jewel characters.
2) Iterate through jewels string and add each character to the HashSet.
3) Initialize a counter to track the number of jewels found.
4) Iterate through stones string.
5) For each stone, check if it exists in the HashSet.
6) If found, increment the counter.
7) Return the total count.

Time Complexity: O(j + s) where j = jewels.length, s = stones.length
Space Complexity: O(j) for the HashSet storing unique jewel characters
*/

public class Solution {
    public int NumJewelsInStones(string jewels, string stones) {
        HashSet<char> hs = new HashSet<char>();         // HashSet to store jewel characters
        int result = 0;                                 // Counter for jewels found in stones
        foreach (char jewel in jewels) {                // Add all jewel characters to HashSet
            hs.Add(jewel);
        }
        foreach (char stone in stones) {                // Iterate through each stone
            if (hs.Contains(stone)) {                   // Check if stone is a jewel
                result++;                               // Increment counter if jewel found
            }
        }
        return result;                                  // Return total count of jewels
    }
}