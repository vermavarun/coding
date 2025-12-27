/*
Solution: Keep Multiplying Found Values by Two
Difficulty: Medium
Approach: HashSet Lookup with Iterative Multiplication
Tags: Array, Hash Table, Simulation
1) Create a HashSet from the array for O(1) lookup operations.
2) While the current value exists in the HashSet, multiply it by 2.
3) Continue until the value is not found in the HashSet.
4) Return the final value that doesn't exist in the array.

Time Complexity: O(n + k) where n = nums.length, k = number of multiplications
Space Complexity: O(n)
*/
public class Solution {
    public int FindFinalValue(int[] nums, int original) {
        HashSet<int> hs = new HashSet<int>();                   // HashSet for O(1) lookup
        foreach(int num in nums) {                              // Add all elements to HashSet
            hs.Add(num);
        }
        while (hs.Contains(original)) {                         // While current value exists in array
            original = original * 2;                            // Multiply by 2
        }
        return original;                                        // Return final value not found in array
    }
}