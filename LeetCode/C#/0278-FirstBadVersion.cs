/*
    Solution: https://leetcode.com/problems/first-bad-version/solutions/7380676/simplest-solution-c-time-olog-n-space1-p-lck4/
Difficulty: Medium
    Approach: Binary Search to Find First Occurrence
    Tags: Binary Search, Interactive Problem
    1) Use binary search with left starting at 1 and right at n.
    2) While left < right, calculate mid point to avoid overflow.
    3) If mid version is bad, the first bad version is at mid or before it.
    4) If mid version is good, the first bad version must be after mid.
    5) Continue until left equals right, which points to the first bad version.
    Space Complexity: O(1)

    Time Complexity: O(log n)
    Space Complexity: O(1)
*/

    /* The isBadVersion API is defined in the parent class VersionControl.
        bool IsBadVersion(int version); */

    public class Solution : VersionControl {
        public int FirstBadVersion(int n) {
            int left = 1;                                           // Start from version 1
            int right = n;                                          // End at version n
            while (left < right) {                                  // Continue until pointers converge
                int mid = left + (right - left) / 2;                // Calculate mid to avoid overflow
                if (IsBadVersion(mid)) {                            // If mid version is bad
                    right = mid;                                    // First bad version is at mid or before it
                }
                else {                                              // If mid version is good
                    left = mid + 1;                                 // First bad version must be after mid
                }
            }

            return left;                                            // Return first bad version (left == right)
        }
    }