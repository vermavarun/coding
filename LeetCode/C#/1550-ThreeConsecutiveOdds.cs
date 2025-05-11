/*
Solution: https://leetcode.com/problems/three-consecutive-odds/post-solution/?submissionId=1630962333
Approach: Iterate array
1. Check if the current element and the next two elements are odd.
2. If they are, return true.
3. If no such triplet is found, return false.
Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int size = arr.Length;                                                  // Get the size of the array
        if (size <=2)                                                           // If the size of the array is less than 3, return false
            return false;                                                       // return false
        for (int i=0; i<size-2; i++) {                                          // Iterate through the array
            if (arr[i] % 2 != 0 && arr[i+1] % 2 != 0 && arr[i+2] % 2 != 0)      // Check if the current element and the next two elements are odd
                return true;                                                    // If they are, return true
        }
        return false;                                                            // If no such triplet is found, return false
    }
}