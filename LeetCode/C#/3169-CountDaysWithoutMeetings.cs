/*
Solution: https://leetcode.com/problems/count-days-without-meetings/solutions/6578015/simplest-solution-c-time-onlogn-space1-p-bvp4/
Approach: Greedy
1. Sort the meetings based on the start time.
2. Initialize freedays to 0 and prevEnd to 0.
3. Iterate through the meetings.
4. If the previous end time is less than the current meeting start time, add the difference between the start time and previous end time to freedays.
5. Update the previous end time to the maximum of the end time of the current meeting and the previous end time.
6. Return the sum of freedays and the difference between the days and the previous end time.

Time complexity: O(nlogn) where n is the number of meetings. Sorting the meetings takes O(nlogn) time.
Space complexity: O(1)

*/
public class Solution {
    public int CountDays(int days, int[][] meetings) {
        Array.Sort(meetings, (a,b) => a[0] - b[0]);         // Sort the meetings based on the start time
        int freedays = 0;                                   // Initialize freedays to 0
        int prevEnd = 0;                                    // Initialize prevEnd to 0
        foreach (int[] meeting in meetings) {               // Iterate through the meetings

            int meetingStart = meeting[0];                  // Get the start time of the meeting
            int meetingEnd = meeting[1];                    // Get the end time of the meeting

            if (prevEnd < meetingStart) {                   // If the previous end time is less than the current meeting start time
                freedays += meetingStart - prevEnd - 1;     // Add the difference between the start time and previous end time to freedays
            }
            prevEnd = Math.Max(meetingEnd, prevEnd);        // Update the previous end time to the maximum of the end time of the current meeting and the previous end time
        }

        return freedays + (days - prevEnd);                 // Return the sum of freedays and the difference between the days and the previous end time
    }
}