/*
Approach:
1. Create a hashset to store the unique elements.
2. Calculate the sum of all the elements in the grid.
3. Calculate the sum of the first n natural numbers.
4. The difference between the sum of the first n natural numbers and the sum of the elements in the grid will give the missing element.
5. The repeated element is the element that is repeated in the grid.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        HashSet<int> hs = new HashSet<int>();       // Declare a hashset to store the unique elements.
        int sum = 0;                                // Declare a variable to store the sum of all the elements in the grid.    
        int[] result = new int[2];                  // Declare an array to store the missing and repeated elements.
        int n = grid[0].Length * grid[0].Length;    // Calculate the number of elements in the grid.

        foreach(int[] arr in grid) {                // Iterate through the grid.
            foreach(int num in arr) {               // Iterate through the elements in the grid.
                if(!hs.Contains(num)) {             // Check if the element is not present in the hashset.
                    hs.Add(num);                    // Add the element to the hashset.
                }
                else {
                    result[0] = num;                // Store the repeated element in the result array.
                }
                sum+=num;                           // Calculate the sum of all the elements in the grid.
            }
        }
        sum -= result[0];                           // Subtract the repeated element from the sum.
        result[1] = (n*(n+1)/2) - sum;              // Calculate the missing element.
        return result;                              // Return the result array.
    }
}