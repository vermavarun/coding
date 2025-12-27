/*
Solution: 
Difficulty: Medium
Approach:
Tags: String
1. Create a hashset to store the visited points.
2. Initially, add the starting point (0,0) to the hashset.
3. Traverse the path string and for each character, update the x and y coordinates.
4. If the current point is already visited, return true.
5. Otherwise, add the current point to the hashset.
6. If the loop completes, return false.

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public bool IsPathCrossing(string path) {
        HashSet<(int,int)> set = new HashSet<(int,int)>();
            int x,y;
            x = y = 0;
            set.Add((0,0));

            foreach(char c in path) {
                switch (c) {

                    case 'N':
                        y=y+1;
                        break;
                    case 'E':
                        x=x+1;
                        break;
                    case 'S':
                        y=y-1;
                        break;
                    case 'W':
                        x=x-1;
                        break;
                }

                if (set.Contains((x,y)))
                    return true;
                set.Add((x,y));

            }

            return false;
    }
}