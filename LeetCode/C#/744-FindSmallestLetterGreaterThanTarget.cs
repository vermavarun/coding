/*
Title: 744. Find Smallest Letter Greater Than Target
Solution: https://leetcode.com/problems/find-smallest-letter-greater-than-target/solutions/7538741/simplest-solution-c-time-olog-n-space-o1-zfg9/
Difficulty: Easy
Approach: Binary Search
Tags: Array, Binary Search
1) Initialize left pointer to 0 and right pointer to last index.
2) Use binary search to find the smallest letter greater than target.
3) Calculate mid index to avoid overflow.
4) If letter at mid is less than or equal to target, move left pointer right.
5) If letter at mid is greater than target, move right pointer left.
6) After loop, left pointer points to the smallest letter greater than target.
7) Use modulo to wrap around if left goes out of bounds.

Time Complexity: O(log n) where n = letters.length
Space Complexity: O(1) constant space
Tip: The key insight is using binary search on a sorted array. When letters[mid] <= target, we move left to mid+1 because we need strictly greater. The modulo operation handles the wrap-around case when no letter is greater than target.
Similar Problems: 35. Search Insert Position, 278. First Bad Version, 374. Guess Number Higher or Lower
*/
public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        int left = 0;                                       // Initialize left pointer to start
        int right = letters.Length - 1;                     // Initialize right pointer to end

        while (left <= right) {                             // Continue until pointers cross
            int mid = left + (right - left) / 2;            // Calculate mid to avoid overflow

            if (letters[mid] <= target) {                   // If mid letter is not greater than target
                left = mid + 1;                             // Search in right half
            } else {                                        // If mid letter is greater than target
                right = mid - 1;                            // Search in left half for smaller candidate
            }
        }

        // left may go out of bounds → wrap around
        return letters[left % letters.Length];              // Return smallest greater letter, wrap if needed
    }
}
