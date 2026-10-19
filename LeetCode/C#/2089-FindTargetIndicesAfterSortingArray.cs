/*
Title: 2089. Find Target Indices After Sorting Array
Solution: https://leetcode.com/problems/find-target-indices-after-sorting-array/solutions/8579078/simplest-solution-c-time-on-spacek-pleas-svgv/
Difficulty: Easy
Approach: Count values less than the target and occurrences of the target
Tags: Array, Binary Search, Sorting
1) Count the elements that are less than the target.
2) Count how many times the target appears.
3) The count of smaller elements gives the first target index after sorting.
4) Add one index for each occurrence of the target.
5) Return the list of target indices.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(k) for the result, where k is the number of target occurrences
Tip: Sorting is not necessary. In the sorted array, all values smaller than the target come first, followed by all occurrences of the target.
*/
public class Solution {
    public IList<int> TargetIndices(int[] nums, int target) {
       
      int countOfTarget = nums.Where(x=>x==target).Count(); // Count how many times the target appears
      int countOfLessThanTarget = nums.Where(x=>x<target).Count(); // Count values that come before the target after sorting

      List<int> result = new List<int>(); // Store every sorted index where the target appears

       for (int i=0; i<countOfTarget; i++) {
          result.Add(i+countOfLessThanTarget); // Add the next consecutive target index
       }

      return result.ToArray(); // Return all target indices
    
    }
}