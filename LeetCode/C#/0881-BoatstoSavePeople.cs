/*
Title: 881. Boats to Save People
Solution: https://leetcode.com/problems/boats-to-save-people/solutions/7526039/simplest-solution-c-time-on-log-n-space-ax00j/
Difficulty: Medium
Approach: Two Pointers with Greedy Strategy
Tags: Array, Two Pointers, Greedy, Sorting
1) Sort the people array in ascending order.
2) Initialize two pointers: left at start, right at end.
3) Initialize boat counter to 0.
4) While left pointer is less than or equal to right pointer:
5) Check if lightest person (left) and heaviest person (right) can share a boat.
6) If their combined weight fits, move left pointer right (both board together).
7) Always move right pointer left (heaviest person always boards).
8) Increment boat counter for each iteration.
9) Return total number of boats needed.

Time Complexity: O(n log n) where n = people.length (due to sorting)
Space Complexity: O(1) or O(log n) depending on sorting algorithm
Tip: Greedy approach works here because each boat can hold at most 2 people. Always try to pair the lightest with the heaviest person. If they can't fit together, the heaviest person must go alone. This maximizes boat utilization.
Similar Problems: 11. Container With Most Water, 167. Two Sum II - Input Array Is Sorted, 455. Assign Cookies
*/
public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        Array.Sort(people);                                         // Sort people by weight to enable greedy pairing

        int left = 0;                                               // Pointer to lightest person
        int right = people.Length - 1;                              // Pointer to heaviest person
        int boats = 0;                                              // Counter for number of boats needed

        while (left <= right) {                                     // Process until all people are assigned
            if (people[left] + people[right] <= limit) {            // Check if lightest and heaviest can share boat
                left++;                                             // Pair lightest with heaviest, move left pointer
            }
            right--;                                                // Heaviest always boards (alone or paired)
            boats++;                                                // Increment boat count for this iteration
        }

        return boats;                                               // Return total number of boats needed
    }
}
