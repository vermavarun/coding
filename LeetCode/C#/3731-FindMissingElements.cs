/*
Title: 3731. Find Missing Elements
Solution: https://leetcode.com/problems/find-missing-elements/solutions/8441126/simplest-solution-c-time-on-space-on-ple-y1f7/
Difficulty: Easy
Approach: HashSet for O(1) lookups
Tags: Array, Hash Table
1) Find the min and max of the array.
2) Store all elements in a HashSet for O(1) lookup.
3) Iterate from min+1 to max-1.
4) Any number in that range not in the HashSet is missing.
5) Return the missing numbers as an array.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the HashSet
Tip: Use a HashSet to mark present elements, then scan the range [min+1, max-1] to find gaps in O(n) time.
Similar Problems: 268. Missing Number, 448. Find All Numbers Disappeared in an Array
*/
public class Solution {
    public IList<int> FindMissingElements(int[] nums) {
        HashSet<int> hs = new HashSet<int>();                       // HashSet for O(1) presence checks
        List<int> result = new List<int>();
        int min = nums.Min();
        int max = nums.Max();

        foreach (int num in nums) {
            hs.Add(num);                                            // Populate set with all elements
        }

        for (int i=min+1; i<max; i++) {
            if (!hs.Contains(i)) {                                  // Number in range but not in array
                result.Add(i);
            }
        }

        return result.ToArray();
    }
}