/*

Approach:
1. Create a HashSet to store the elements of the first array.
2. Create a List to store the common elements of the two arrays.
3. Iterate through the first array and add all the elements to the HashSet.
4. Iterate through the second array and check if the element is present in the HashSet.
5. If the element is present, remove it from the HashSet and add it to the List.
6. Convert the List to an array and return the result.

Time Complexity: O(n + m), where n is the length of the first array and m is the length of the second array.
Space Complexity: O(n), where n is the length of the first array.

*/
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> hs = new HashSet<int>();
        List<int> result = new List<int>();

        foreach(int num in nums1) {
            hs.Add(num);
        }

        foreach(int num in nums2) {
            if(hs.Contains(num)) {
                hs.Remove(num);
                result.Add(num);

            }
        }

        return result.ToArray();
    }
}