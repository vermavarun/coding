/*
Solution: https://leetcode.com/problems/count-largest-group/submissions/1615589789/?envType=daily-question&envId=2025-04-23
Approach: Using Dictionary
1) We will use a Dictionary to store the number of groups with the same sum of digits.
2) For each number from 1 to n, we will calculate the sum of its digits.
3) We will check if the sum of digits is already in the Dictionary.
4) If it is, we will increment the count of groups with that sum of digits.
5) If it is not, we will add it to the Dictionary with a count of 1.
6) After processing all the numbers, we will find the largest group size.
7) We will iterate through the Dictionary and count the number of groups with the largest size.
8) Finally, we will return the count of groups with the largest size.
Time Complexity: O(n * log(n))
Space Complexity: O(n)

*/
public class Solution {
    public int CountLargestGroup(int n) {
        Dictionary<int, int> dict = new Dictionary<int,int>();          // Dictionary to store the number of groups with the same sum of digits
        int largestGroup = 0;                                           // Variable to store the largest group size
        for (int i=1; i<=n; i++) {                                      // Iterate through numbers from 1 to n
            int sumOfDigits = SumOfDigits(i);                           // Calculate the sum of digits of the number
            if (dict.ContainsKey(sumOfDigits)) {                        // If the sum of digits is already in the Dictionary
                dict[sumOfDigits]++;                                    // Increment the count of groups with that sum of digits
            }
            else {                                                      // If the sum of digits is not in the Dictionary
                dict.Add(sumOfDigits, 1);                               // Add it to the Dictionary with a count of 1
            }
            largestGroup = Math.Max(largestGroup, dict[sumOfDigits]);   // Update the largest group size
        }

        int noOfGroupsWithLargestSize = 0;                              // Variable to store the count of groups with the largest size
        foreach(var group in dict.Values) {                             // Iterate through the Dictionary
            if (group == largestGroup) {                                // If the group size is equal to the largest group size
                noOfGroupsWithLargestSize++;                            // Increment the count of groups with the largest size
            }
        }

        return noOfGroupsWithLargestSize;                               // Return the count of groups with the largest size
    }

    private int SumOfDigits(int n) {                                    // Helper function to calculate the sum of digits of a number
        int sum = 0;                                                    // Variable to store the sum of digits
        while (n>0) {                                                   // While there are still digits left in the number
            sum+= n%10;                                                 // Add the last digit to the sum
            n=n/10;                                                     // Remove the last digit from the number
        }
        return sum;                                                     // Return the sum of digits
    }
}