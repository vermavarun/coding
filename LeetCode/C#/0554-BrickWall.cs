/*
Solution:
Difficulty: Medium
Approach: [To be documented]
Tags: Array, Hash Table, Math
1. We need to find the least number of bricks that can be cut to make a straight line.
2. We need to find the maximum number of bricks that can be cut at the same place.
3. We can ignore the last brick as we cannot cut it.
4. We can use a dictionary to store the number of bricks that can be cut at a particular place.
5. We can iterate through the wall and calculate the current cut.
6. We can store the current cut in the dictionary.
7. We can find the maximum number of bricks that can be cut at the same place.
8. We can return the least number of bricks that can be cut to make a straight line.

Time Complexity: O(n) where n is the number of bricks in the wall.
Space Complexity: O(n) where n is the number of bricks in the wall.
*/

public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        int currentCut = 0;
        int maxCut = 0;
        Dictionary<int,int> dict = new Dictionary<int,int>();
        int i=0;
        foreach(var w in wall) {
            int j=0;
            currentCut = 0;
            foreach(var brick in w) {
                if(j == w.Count()-1) break;                     // If this is the last brick ignore
                currentCut = currentCut + wall[i][j];
                if(!dict.ContainsKey(currentCut)) {
                    dict[currentCut] = 1;
                }
                else {
                    dict[currentCut] = dict[currentCut] + 1;
                }
                j++;
            }
            i++;
        }

        foreach(var kv in dict) {
            maxCut = Math.Max(maxCut,kv.Value);
        }
        return i - maxCut;
    }
}