// Approach 1 : Brute Force

public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();
        int[] result = new int[nums1.Length];
        for(int i = 0; i < nums2.Length; i++) {
            while(stack.Count > 0 && nums2[i] > stack.Peek()) {
                dict.Add(stack.Pop(), nums2[i]);
            }
            stack.Push(nums2[i]);
        }

        return nums1.Select(x => dict.ContainsKey(x) ? dict[x] : -1).ToArray();

    }
}