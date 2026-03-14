/*
Title: 401. Binary Watch
Solution: https://leetcode.com/problems/binary-watch/solutions/7586053/simplest-solution-c-time-o1-space-o1-ple-xn0p/
Difficulty: Easy
Approach: Brute Force with Bit Counting
Tags: Bit Manipulation, Backtracking, Brute Force
1) Binary watch has 4 LED bits for hours (0-11) and 6 LED bits for minutes (0-59).
2) Given turnedOn LEDs, find all possible times the watch could represent.
3) Iterate through all valid hour values (0-11).
4) For each hour, iterate through all valid minute values (0-59).
5) Count total number of 1-bits in both hour and minute representations.
6) If total bit count equals turnedOn, add the time to result.
7) Format minutes with leading zero if less than 10 (e.g., "0:05").
8) Return all valid times as strings in "H:MM" format.

Time Complexity: O(1) - fixed iterations (12 * 60 = 720)
Space Complexity: O(1) - excluding output space
Tip: This is a brute force problem made elegant by recognizing that there are only 720 possible times (12 hours × 60 minutes). Simply check each valid time and count the number of set bits (1s) in the binary representation of both hours and minutes. The key insight: use bit counting to determine how many LEDs are lit. In C#, convert to binary string and count '1' characters.
Similar Problems: 191. Number of 1 Bits, 338. Counting Bits, 461. Hamming Distance
*/

public class Solution {
    public IList<string> ReadBinaryWatch(int turnedOn) {
        List<string> result = new List<string>();              // Store all valid times

        for (int hh = 0; hh <= 11; hh++) {                     // Iterate through all valid hours (0-11)
            for (int mm = 0; mm <= 59; mm++) {                 // Iterate through all valid minutes (0-59)

                // Count total number of 1-bits in hour and minute
                if (BitCount(hh) + BitCount(mm) == turnedOn) { // If total lit LEDs equals turnedOn
                    string hour = hh.ToString();               // Convert hour to string
                    string minute = (mm < 10 ? "0" : "") + mm; // Format minute with leading zero if needed
                    result.Add(hour + ":" + minute);           // Add formatted time to result
                }

            }
        }

        return result;                                         // Return all valid times
    }

    private int BitCount(int n) {                              // Helper method to count 1-bits
        return Convert.ToString(n, 2).Count(c => c == '1');    // Convert to binary string and count '1's
    }
}