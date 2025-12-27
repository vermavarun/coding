/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        HashSet<int> hs1 = new HashSet<int>();
        HashSet<int> hs2 = new HashSet<int>();
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> list = new List<int>();

        foreach(int num in nums1) {
            hs1.Add(num);
        }

        foreach(int num in nums2) {
            hs2.Add(num);
        }

        foreach(int num in hs1) {
            if(!hs2.Contains(num))
                list.Add(num);
        }

        result.Add(list);
        list = new List<int>();

        foreach(int num in hs2) {
            if(!hs1.Contains(num))
                list.Add(num);
        }

        result.Add(list);
        return result;
    }
}