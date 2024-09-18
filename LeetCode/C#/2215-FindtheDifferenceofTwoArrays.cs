/*

Approach:
- Create two hashsets to store the unique elements of the two arrays.
- Create a list to store the difference of the two arrays.
- Iterate through the first array and add the elements to the first hashset.
- Iterate through the second array and add the elements to the second hashset.
- Iterate through the first hashset and check if the element is not present in the second hashset, then add it to the list.
- Add the list to the result.
- Create a new list to store the difference of the second array.
- Iterate through the second hashset and check if the element is not present in the first hashset, then add it to the list.
- Add the list to the result.
- Return the result.

Time complexity: O(n)
Space complexity: O(n)

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