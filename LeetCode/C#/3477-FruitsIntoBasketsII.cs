/*
Solution: https://leetcode.com/problems/fruits-into-baskets-ii/solutions/7047747/simplest-solution-c-time-onm-space1-plea-gfdo/
Difficulty: Medium
Approach: Iteration with Greedy Matching
Tags: Array, Greedy, Simulation
1) Initialize counter for placed fruits.
2) Iterate through each fruit in the fruits array.
3) For each fruit, find the first basket that can accommodate it (fruit <= basket capacity).
4) If a suitable basket is found, place the fruit and mark basket as used (-1).
5) Count total placed fruits during the process.
6) Return the number of unplaced fruits (total fruits - placed fruits).

Time Complexity: O(n * m) where n = fruits.length, m = baskets.length
Space Complexity: O(1)
*/
public class Solution {
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {

        int placedFruits = 0;                                       // Counter for successfully placed fruits

        foreach(int fruit in fruits) {                              // Iterate through each fruit

            for(int i=0; i<baskets.Length; i++) {                   // Check each basket for placement
                if (fruit <= baskets[i]) {                          // If fruit fits in current basket
                    placedFruits++;                                 // Increment placed fruits counter
                    baskets[i] = -1;                                // Mark basket as used (set to -1)
                    break;                                          // Move to next fruit
                }
            }
        }

        return fruits.Length - placedFruits;                        // Return number of unplaced fruits
    }
}