/*
Solution: https://leetcode.com/problems/distribute-candies/solutions/7404538/simplest-solution-c-time-on-spacen-pleas-r1os/
Difficulty: Medium
Approach: Hash Table (Dictionary) + Greedy
Tags: Hash Table, Greedy, Array
1) Create a dictionary to count unique candy types.
2) Iterate through candyType array and populate the frequency map.
3) Alice can eat at most n/2 candies (where n is total candies).
4) To maximize variety, return min(unique types, n/2).
5) If unique types >= n/2, she can get n/2 different types.
6) If unique types < n/2, she can only get all available unique types.

Time Complexity: O(n) - single pass through the array
Space Complexity: O(n) - dictionary stores up to n unique types
*/
public class Solution {
    public int DistributeCandies(int[] candyType) {
        Dictionary<int,int> dict = new Dictionary<int,int>();       // Dictionary to store candy types and their counts
        foreach (int num in candyType) {                            // Count each candy type
            if (!dict.ContainsKey(num)) {                           // Add new candy type to dictionary
                dict[num] = 1;                                      // Initialize count to 1
            }
            else {                                                  // Increment count for existing candy type
                dict[num]++;                                        // Increase frequency
            }
        }
        // Alice can eat n/2 candies, so return minimum of n/2 or unique types
        // This maximizes variety - if there are more unique types than n/2,
        // she can get n/2 different types; otherwise she gets all unique types
        return Math.Min(candyType.Length / 2, dict.Keys.Count);     // Return maximum variety Alice can achieve
    }
}