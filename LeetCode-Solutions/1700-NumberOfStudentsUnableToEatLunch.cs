/*

Approach:

1. Create a dictionary to store the count of students with each preference.
2. Iterate through the students array and store the count of students with each preference in the dictionary.
3. Iterate through the sandwiches array and check if the sandwich preference is available in the dictionary and the count is greater than 0.
4. If the sandwich preference is available and the count is greater than 0, decrement the count and decrement the result.
5. If the sandwich preference is not available or the count is 0, return the result.

Time complexity: O(n)
Space complexity: O(n)

*/
public class Solution {
    public int CountStudents(int[] students, int[] sandwiches) {
        int result = students.Length;
        Dictionary<int,int> dict = new Dictionary<int,int>();

        foreach(int student in students) {
            if(!dict.ContainsKey(student)) {
                dict[student] = 1;
            }
            else {
                dict[student] = dict[student] + 1;
            }
        }

        foreach(int sandwich in sandwiches) {
            if(dict.ContainsKey(sandwich) && dict[sandwich] > 0) {
                dict[sandwich] = dict[sandwich] - 1;
                result = result - 1;
            }
            else {
                return result;
            }
        }

        return result;
    }
}