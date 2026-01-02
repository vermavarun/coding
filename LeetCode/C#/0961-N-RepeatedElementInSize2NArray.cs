/*
Solution: https://leetcode.com/problems/n-repeated-element-in-size-2n-array/solutions/7457721/simplest-solution-c-time-on-spacen-pleas-dy2a
Difficulty: Easy
Approach: Hash Set for duplicate detection
Tags: Array, Hash Table
1) Create a hash set to track seen numbers.
2) Iterate through each number in the array.
3) For each number, check if it already exists in the hash set.
4) If found in hash set, return it as the repeated element.
5) If not found, add the number to the hash set.
6) Continue until the repeated element is found.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the hash set
*/
public class Solution {
    public int RepeatedNTimes(int[] nums) {
        HashSet<int> hs = new HashSet<int>();                       // Hash set to track seen numbers
        foreach(int num in nums) {                                  // Iterate through each number
            if (hs.Contains(num)) {                                 // If number already seen
                return num;                                         // Return as the repeated element
            }
            else {                                                  // If number not seen before
                hs.Add(num);                                        // Add to hash set
            }
        }
        return -1;                                                  // Return -1 if no repeat found (shouldn't happen per problem)
    }
}