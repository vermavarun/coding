/*
Title: 3761. Minimum Absolute Distance Between Mirror Pairs
Solution: https://leetcode.com/problems/minimum-absolute-distance-between-mirror-pairs/solutions/7964111/simplest-solution-c-time-ond-space-on-pl-ti31/
Difficulty: Medium
Approach: Hash Table with Reversed Number Matching
Tags: Array, Hash Table, Math
1) Create a dictionary to store reversed numbers and their original indices.
2) Initialize minimum distance to maximum possible value.
3) Iterate through the array with index tracking.
4) For each number, check if it matches any previously stored reversed number.
5) If match found, calculate distance and update minimum.
6) Reverse the current number using helper function.
7) Store the reversed number with current index in dictionary.
8) Continue for all numbers in the array.
9) If no mirror pair found, return -1; otherwise return minimum distance.

Time Complexity: O(n * d) where n = nums.length, d = avg digits per number
Space Complexity: O(n) for the hash table storing reversed numbers
Tip: The key insight is that we need to find pairs where one number is the reverse of another. By storing reversed numbers as we iterate, we can check if the current number matches any previous reversed number in O(1) time. This avoids the O(n²) approach of comparing every pair.
Similar Problems: 7. Reverse Integer, 9. Palindrome Number, 1848. Minimum Distance to the Target Element
*/
public class Solution {

    public int MinMirrorPairDistance(int[] nums) {
        Dictionary<int,int> reversedToIndexMap = new Dictionary<int,int>();  // Dictionary to store reversed number -> original index mapping
        int minDistance = int.MaxValue;                         // Initialize minimum distance to max value

        for (int i = 0; i < nums.Length; i++) {                 // Iterate through entire array
            int currentNumber = nums[i];                        // Get current number

            // ✅ If current number matches any previously stored reversed number
            if (reversedToIndexMap.ContainsKey(currentNumber)) {  // Check if current matches any reversed number
                minDistance = Math.Min(minDistance, i - reversedToIndexMap[currentNumber]);  // Update minimum distance
            }

            // ✅ Store reversed version of current number
            int reversed = ReverseNumber(currentNumber);        // Reverse the current number
            reversedToIndexMap[reversed] = i;                   // Store reversed number with current index
        }

        return minDistance == int.MaxValue ? -1 : minDistance;  // Return -1 if no pair found, else minimum distance
    }

    private int ReverseNumber(int num) {
        int reversed = 0;                                       // Initialize reversed number to zero

        while (num > 0) {                                       // Loop until all digits are processed
            reversed = reversed * 10 + (num % 10);              // Build reversed number by extracting and adding digits
            num /= 10;                                          // Remove rightmost digit
        }

        return reversed;                                        // Return the reversed number
    }
}