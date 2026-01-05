/*
Solution: https://leetcode.com/problems/four-divisors/solutions/7465846/simplest-solution-c-time-onsqrtm-space1-3ohu5/
Difficulty: Medium
Approach: Hash Set with Optimized Divisor Finding
Tags: Array, Hash Set, Math
1) For each number in the array, find all its divisors.
2) Optimize divisor search by only iterating up to sqrt(num).
3) For each divisor i found, also add its complement (num / i).
4) Use a HashSet to automatically handle duplicates and ensure unique divisors.
5) If a number has exactly 4 divisors, sum those divisors and add to total.
6) Return the total sum of all numbers that have exactly 4 divisors.

Time Complexity: O(n * sqrt(m)) where n = nums.length, m = max value in nums
Space Complexity: O(1) for the HashSet (max 4 divisors)
*/

public class Solution {
    public int SumFourDivisors(int[] nums) {
        int totalSum = 0;                                           // Variable to accumulate sum of all qualifying divisors

        foreach (int num in nums) {                                 // Iterate through each number in the input array
            // HashSet to store divisors (to avoid duplicates)
            HashSet<int> divisors = new HashSet<int>();            // HashSet automatically handles duplicate divisors

            // Find divisors up to sqrt(num)
            for (int i = 1; i * i <= num; i++) {                   // Iterate from 1 to sqrt(num) for efficiency
                if (num % i == 0) {                                 // If i is a divisor of num
                    divisors.Add(i);                                // Add the divisor i
                    if (i != num / i) {                             // Avoid adding the square root twice (when i^2 = num)
                        divisors.Add(num / i);                      // Add the complementary divisor
                    }
                }
            }

            // If the number has exactly 4 divisors
            if (divisors.Count == 4) {                              // Check if this number has exactly 4 divisors
                int sum = 0;                                        // Sum variable for this number's divisors
                foreach (int divisor in divisors) {                 // Iterate through all divisors
                    sum += divisor;                                 // Add each divisor to the sum
                }
                totalSum += sum;                                    // Add this number's divisor sum to total
            }
        }

        return totalSum;                                            // Return the total sum
    }
}
