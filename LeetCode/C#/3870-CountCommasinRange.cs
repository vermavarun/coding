/*
Title: 3870. Count Commas in Range
Solution:
Difficulty: Easy
Approach: Count all numbers from 1,000 through n, because each contains exactly one comma.
1) Numbers below 1,000 contain no commas.
2) Every number from 1,000 through n contains one comma.
3) Subtract 999 from n to count those numbers, and return zero when n is below 1,000.

Time Complexity: O(1)
Space Complexity: O(1)
Tip: The answer is the size of the inclusive range [1,000, n].
*/
public class Solution {
    public int CountCommas(int n) {
        return n > 999 ? n-999: 0; // Count numbers that contain one comma.
    }
}