/*
Solution: https://leetcode.com/problems/sort-the-people/solutions/6888177/simplest-solution-c-time-on-log-n-spacen-qcoc/
Approach: Using Dictionary and Sorting
1. Create a dictionary to map heights to names.
2. Sort the heights in descending order.
3. Iterate through the sorted heights and build the result list using the dictionary.
4. Convert the result list to an array and return it.

Time Complexity: O(n log n) due to sorting.
Space Complexity: O(n) for the dictionary and result list.
*/
public class Solution
{
    public string[] SortPeople(string[] names, int[] heights)
    {

        Dictionary<int, string> dict = new Dictionary<int, string>();   // Dictionary to map heights to names
        List<string> result = new List<string>();                       // Result list to store sorted names

        for (int i = 0; i < heights.Length; i++)                        // Populate the dictionary with heights as keys and names as values
        {
            dict.Add(heights[i], names[i]);                             // Add height and corresponding name to the dictionary
        }

        Array.Sort(heights);                                             // Sort the heights in ascending order
        Array.Reverse(heights);                                          // Reverse the sorted heights to get them in descending order

        foreach (int height in heights)                                  // Iterate through the sorted heights
        {
            result.Add(dict[height]);                                    // For each height, find the corresponding name in the dictionary and add it to the result list
        }
        return result.ToArray();                                         // Convert the result list to an array and return it
    }
}