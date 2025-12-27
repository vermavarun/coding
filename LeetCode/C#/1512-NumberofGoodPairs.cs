/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Hash Table
1. Create a dictionary to store the frequency of each number.
2. Iterate through the array and store the frequency of each number in the dictionary.
3. Iterate through the dictionary and calculate the number of good pairs for each number.
4. Return the sum of all the good pairs.

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public int NumIdenticalPairs(int[] nums) {
        Dictionary<int,int> dict = new Dictionary<int,int>();           // To store the frequency of each number
        int result = 0;                                                 // To store the number of good pairs

        foreach(int num in nums) {                                      // Storing the frequency of each number in the dictionary
            if(!dict.ContainsKey(num)) {                                // If the number is not present in the dictionary
                dict[num] = 1;                                          // Add the number to the dictionary with frequency 1
            }
            else {
                dict[num] = dict[num] + 1;                              // If the number is already present in the dictionary, increment the frequency
            }
        }

        foreach(var kv in dict) {                                       // Calculating the number of good pairs for each number
            result = result + (((kv.Value)*(kv.Value -1)) / 2);         // Number of good pairs for a number n is nC2 = n*(n-1)/2
        }
        return result;                                                  // Return the total number of good pairs
    }
}
