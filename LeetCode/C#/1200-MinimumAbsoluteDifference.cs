/*
Title: 1200. Minimum Absolute Difference
Solution: https://leetcode.com/problems/minimum-absolute-difference/solutions/7525787/simplest-solution-c-time-on-log-n-space-e6z0l/
Difficulty: Easy
Approach: Sorting and One Pass
Tags: Array, Sorting
1) Sort the array in ascending order.
2) Initialize result list and minimum difference to max value.
3) Iterate through adjacent pairs in sorted array.
4) Calculate difference between each adjacent pair.
5) If difference is smaller than current minimum, reset result list and update minimum.
6) If difference equals current minimum, add pair to result list.
7) Return all pairs with minimum absolute difference.

Time Complexity: O(n log n) where n = arr.length (due to sorting)
Space Complexity: O(1) or O(log n) depending on sorting algorithm (excluding output space)
Tip: After sorting, the minimum absolute difference can only exist between adjacent elements. This eliminates the need to check all possible pairs (O(n²)) and reduces the problem to checking only adjacent pairs in one pass (O(n)).
Similar Problems: 532. K-diff Pairs in an Array, 1984. Minimum Difference Between Highest and Lowest of K Scores, 2200. Find All K-Distant Indices in an Array
*/
public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        Array.Sort(arr);                                            // Sort array to group similar values together
        List<IList<int>> result = new List<IList<int>>();           // List to store result pairs
        int minDiff = int.MaxValue;                                 // Track minimum difference found so far

        for (int i = 0; i < arr.Length - 1; i++) {                  // Iterate through adjacent pairs
            int diff = arr[i + 1] - arr[i];                         // Calculate difference between adjacent elements

            if (diff < minDiff) {                                   // If new minimum difference found
                minDiff = diff;                                     // Update minimum difference
                result.Clear();                                     // Clear previous results (they have larger difference)
                result.Add(new List<int> { arr[i], arr[i + 1] });   // Add new pair with minimum difference
            }
            else if (diff == minDiff) {                             // If difference equals current minimum
                result.Add(new List<int> { arr[i], arr[i + 1] });   // Add pair to result list
            }
        }

        return result;                                              // Return all pairs with minimum absolute difference
    }
}
