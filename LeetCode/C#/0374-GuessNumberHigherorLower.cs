/*
Approach: Binary Search
1) Initialize the left and right pointers
2) Iterate through the array
3) Calculate the mid
4) If the mid element is equal to the target, return the mid
5) If the mid element is less than the target, increment the left pointer
6) If the mid element is greater than the target, decrement the right pointer
7) Return the left pointer

Time complexity: O(log n)
Space complexity: O(1)

*/
/**
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        int left = 0;                               // Initialize left pointer
        int right = n;                              // Initialize right pointer

        while(left<=right) {                        // Iterate through the array

            int mid = left+(right-left)/2;          // Calculate the mid    // Prevent overflow by using this formula (**Important)
            int output = guess(mid);                // Call the guess API
            if (output == 0) {                      // If the mid element is equal to the target, return the mid
                return mid;                         // Return the mid
            }
            else if (output == 1) {                 // If the mid element is less than the target, increment the left pointer
                left = mid + 1;                     // Increment the left pointer
            }
            else {                                  // If the mid element is greater than the target, decrement the right pointer
                right = mid - 1;                    // Decrement the right pointer
            }
        }

        return -1;                                  // Should never be reached in a valid game
    }
}