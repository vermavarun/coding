/*
Title: 3296. Minimum Number of Seconds to Make Mountain Height Zero
Solution: https://leetcode.com/problems/minimum-number-of-seconds-to-make-mountain-height-zero/solutions/7645701/simplest-solution-c-time-on-log1018-spac-1mjh/
Difficulty: Medium
Approach: Binary Search + Mathematical Formula
Tags: Binary Search, Array, Math, Greedy
1) Use binary search on the answer (time in seconds) from 0 to 10^18.
2) For each candidate time, check if workers can reduce the mountain to 0.
3) Each worker takes progressively more time: 1st unit takes w seconds, 2nd takes 2w, 3rd takes 3w, etc.
4) Total time for k units = w * (1 + 2 + 3 + ... + k) = w * k(k+1)/2.
5) To find max k units a worker can remove in time T: solve w * k(k+1)/2 <= T.
6) Using quadratic formula: k = floor((sqrt(1 + 8T/w) - 1) / 2).
7) Sum all workers' contributions; if >= mountainHeight, time is sufficient.
8) Narrow the search range based on whether current time works.

Time Complexity: O(n * log(10^18)) where n = workerTimes.length
Space Complexity: O(1) - only using constant extra space
Tip: The key insight is that this problem fits binary search on the answer pattern. Since checking if a given time works is monotonic (if time T works, T+1 also works), we can binary search for the minimum valid time. The mathematical formula k = (sqrt(1 + 8T/w) - 1) / 2 comes from solving the quadratic inequality k(k+1) <= 2T/w.
Similar Problems: 875. Koko Eating Bananas, 1482. Minimum Number of Days to Make m Bouquets, 1870. Minimum Speed to Arrive on Time, 2064. Minimized Maximum of Products Distributed to Any Store
*/
public class Solution {
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes) {

        // Initialize left boundary of binary search to 0 (minimum possible time)
        long left = 0;
        // Initialize right boundary to very large value (maximum possible time)
        long right = (long)1e18; // Upper bound ensures we cover all possible scenarios

        /*
        Example walkthrough:
        mountainHeight = 4
        workerTimes = [2,3]

        Worker 1 (w=2) progression:
        remove 1 unit -> 2 * 1 = 2 seconds total
        remove 2 units -> 2 * (1+2) = 2 + 4 = 6 seconds total
        remove 3 units -> 2 * (1+2+3) = 2 + 4 + 6 = 12 seconds total

        Worker 2 (w=3) progression:
        remove 1 unit -> 3 * 1 = 3 seconds total
        remove 2 units -> 3 * (1+2) = 3 + 6 = 9 seconds total
        remove 3 units -> 3 * (1+2+3) = 3 + 6 + 9 = 18 seconds total
        */

        while (left < right) {                                      // Continue binary search until range converges

            // Calculate middle point to avoid overflow (safe mid calculation)
            long mid = left + (right - left) / 2;                   // Current candidate time to test

            // Check if mountain can be completely removed within mid seconds
            if (Can(mid, mountainHeight, workerTimes))              // If mid seconds is sufficient
                right = mid;                                        // Try smaller time (search left half)
            else                                                    // If mid seconds is not enough
                left = mid + 1;                                     // Need more time (search right half)
        }

        // Binary search converges to minimum sufficient time
        return left;                                                // Return the minimum seconds required
    }

    private bool Can(long time, int height, int[] workers) {        // Helper function to check if given time is sufficient

        long removed = 0;                                           // Track total height units removed by all workers

        /*
        Mathematical derivation:
        Worker removes k units in time = w * (1 + 2 + ... + k) = w * k(k+1)/2

        To find max k for given time T:
        w * k(k+1)/2 <= T
        k(k+1) <= 2T/w
        k^2 + k - 2T/w <= 0

        Using quadratic formula: k = (-1 ± sqrt(1 + 8T/w)) / 2
        Taking positive root and flooring: k = floor((sqrt(1 + 8T/w) - 1) / 2)
        */

        foreach (int w in workers) {                                // Iterate through each worker's time multiplier

            // Calculate right-hand side of the inequality: 2 * time / worker_time
            double val = (double)2 * time / w;                      // This represents 2T/w in our formula

            /*
            Solve quadratic equation to find maximum k:
            k^2 + k - val <= 0
            k = (sqrt(1 + 4*val) - 1) / 2

            Note: 4*val = 4*(2T/w) = 8T/w, so sqrt(1 + 4*val) = sqrt(1 + 8T/w)
            */

            // Calculate maximum units this worker can remove in given time
            long k = (long)((Math.Sqrt(1 + 4 * val) - 1) / 2);     // Apply quadratic formula and floor the result

            removed += k;                                           // Add this worker's contribution to total

            /*
            Example calculation when time = 9 seconds, worker = 2:

            val = 2*9/2 = 9
            k = floor((sqrt(1+36)-1)/2)
              = floor((sqrt(37)-1)/2)
              = floor((6.08-1)/2)
              = floor(2.54)
              = 2

            Verification: Worker removes 2 units in 2*(1+2) = 6 seconds (fits within 9)
                         Worker cannot remove 3 units in time (would need 2*(1+2+3) = 12 seconds)
            */

            if (removed >= height)                                  // Early exit: if enough height removed
                return true;                                        // Mountain can be fully removed in this time
        }

        return false;                                               // Total removed height insufficient
    }
}