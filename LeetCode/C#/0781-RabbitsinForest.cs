/*
Solution: 
Difficulty: Easy
Approach:
Tags: Array, Hash Table, Math
1) We will use a Dictionary to store the number of rabbits that have the same answer.
2) For each answer, we will check if it is already in the Dictionary.
3) If it is, we will increment the count of rabbits with that answer.
4) If it is not, we will add it to the Dictionary with a count of 1.
5) After processing all the answers, we will iterate through the Dictionary and calculate the total number of rabbits.
6) For each answer, we will calculate the number of groups of rabbits with that answer.
7) The number of groups is equal to the number of rabbits with that answer divided by the size of the group (answer + 1).
8) We will multiply the number of groups by the size of the group to get the total number of rabbits with that answer.
9) Finally, we will return the total number of rabbits.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public int NumRabbits(int[] answers) {
        Dictionary<int, int> groups = new Dictionary<int, int>();                           // Dictionary to store the number of rabbits with the same answer
        int sum = 0;                                                                        // Variable to store the total number of rabbits
        foreach (int num in answers) {                                                      // Iterate through the answers
            if (groups.ContainsKey(num)) {                                                  // If the answer is already in the Dictionary
                groups[num]++;                                                              // Increment the count of rabbits with that answer
            } else {                                                                        // If the answer is not in the Dictionary
                groups.Add(num, 1);                                                         // Add it to the Dictionary with a count of 1
            }
        }

        foreach (var group in groups) {                                                     // Iterate through the Dictionary
            int groupSize = group.Key + 1;                                                  // Calculate the size of the group
            int numberOfGroups = (int)Math.Ceiling((double)group.Value / groupSize);        // Calculate the number of groups of rabbits with that answer
            sum += numberOfGroups * groupSize;                                              // Multiply the number of groups by the size of the group to get the total number of rabbits with that answer
        }

        return sum;                                                                         // Return the total number of rabbits
    }
}
