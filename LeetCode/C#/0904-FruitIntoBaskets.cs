/*
Solution: https://leetcode.com/problems/fruit-into-baskets/solutions/7043440/simplest-solution-c-time-on-spacen-pleas-9kr1/
Approach: Two Pointers (Sliding Window)
Tags: Array, Hash Table, Sliding Window, Two Pointers
1) Use a sliding window approach with left and right pointers.
2) Use a dictionary to track fruit types and their counts in current window.
3) Expand the window by moving right pointer and adding fruits to dictionary.
4) If more than 2 fruit types exist, shrink window from left until only 2 types remain.
5) Track the maximum window size (maximum fruits collected) throughout the process.
6) Return the maximum number of fruits that can be collected.

Time Complexity: O(n)
Space Complexity: O(1) - at most 3 fruit types in dictionary
*/
public class Solution {
    public int TotalFruit(int[] fruits) {
        int left = 0;                                               // Left pointer for sliding window
        int maxFruits = 0;                                          // Maximum fruits collected so far
        Dictionary<int, int> dict = new Dictionary<int, int>();     // Dictionary to track fruit types and counts

        for (int right = 0; right < fruits.Length; right++) {      // Expand window by moving right pointer
            int fruitType = fruits[right];                          // Get current fruit type

            if (!dict.ContainsKey(fruitType)) {                     // If fruit type not in dictionary
                dict[fruitType] = 0;                                // Initialize count to 0
            }
            dict[fruitType]++;                                      // Increment count of current fruit type

            while (dict.Count > 2) {                                // While we have more than 2 fruit types
                int leftFruit = fruits[left];                       // Get fruit type at left pointer
                dict[leftFruit]--;                                  // Decrease count of left fruit
                if (dict[leftFruit] == 0) {                         // If count becomes 0
                    dict.Remove(leftFruit);                         // Remove fruit type from dictionary
                }
                left++;                                             // Move left pointer to shrink window
            }

            maxFruits = Math.Max(maxFruits, right - left + 1);      // Update maximum fruits with current window size
        }

        return maxFruits;                                           // Return maximum fruits collected
    }
}
