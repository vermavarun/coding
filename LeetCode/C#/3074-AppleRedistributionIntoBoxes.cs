/*
Solution: https://leetcode.com/problems/apple-redistribution-into-boxes/solutions/7434819/simplest-solution-c-time-on-log-n-space1-cncn/
Difficulty: Easy
Approach: Greedy with sorting
Tags: Array, Greedy, Sorting
1) Calculate the total number of apples across all packs.
2) Sort the capacity array in descending order (largest boxes first).
3) Iterate through sorted boxes, accumulating capacity.
4) For each box, check if current capacity meets or exceeds total apples.
5) Return the number of boxes used when capacity is sufficient.
6) Use greedy approach: always pick largest available boxes first.

Time Complexity: O(n log n) where n = capacity.length (due to sorting)
Space Complexity: O(1) excluding sorting space
*/
public class Solution {
    public int MinimumBoxes(int[] apple, int[] capacity) {
        int totalApples = 0;                                    // Store total number of apples
        int currentCapacity = 0;                                // Track accumulated capacity
        int boxesRequired = 0;                                  // Count boxes needed

        foreach (int aple in apple) {                           // Iterate through apple packs
            totalApples+=aple;                                  // Sum all apples
        }

        Array.Sort(capacity);                                   // Sort capacity array (ascending)
        Array.Reverse(capacity);                                // Reverse to descending (largest first)

        foreach (int cap in capacity) {                         // Iterate through boxes by capacity

            if (currentCapacity >= totalApples) {               // If current capacity is sufficient
                return boxesRequired;                           // Return number of boxes used
            }
            currentCapacity += cap;                             // Add current box capacity
            boxesRequired++;                                    // Increment box count
        }
        return boxesRequired;                                   // Return total boxes used
    }
}