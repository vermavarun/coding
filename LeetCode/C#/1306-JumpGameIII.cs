/*
Title: 1306. Jump Game III
Solution: https://leetcode.com/problems/jump-game-iii/solutions/8256089/simplest-solution-c-time-on-space-on-ple-zwyg/
Difficulty: Medium
Approach: DFS with In-Place Visited Marking
Tags: Array, Depth-First Search, Breadth-First Search
1) Start at the given index and recursively explore both jump directions.
2) Base case: return false if index is out of bounds or already visited.
3) Success case: return true if the current cell's value is 0.
4) Mark the current cell as visited by negating its value (since values are non-negative).
5) Recurse to (index + arr[index]) and (index - arr[index]).
6) Return true if either branch reaches a zero cell.

Time Complexity: O(n) where n = arr.Length — each cell is visited at most once
Space Complexity: O(n) for the recursion stack in the worst case
Tip: Negating the value is a clean trick to mark visited cells without an extra visited array, since the problem guarantees non-negative inputs. Remember to check arr[start] < 0 before recursing to prevent infinite loops.
Similar Problems: 55. Jump Game, 45. Jump Game II, 1345. Jump Game IV, 1340. Jump Game V
*/
public class Solution {
    public bool CanReach(int[] arr, int start) {
        if (start < 0 || start >= arr.Length || arr[start] < 0)    // Out of bounds or already visited
            return false;

        if (arr[start] == 0)                                       // Reached a zero cell — success
            return true;

        int jump = arr[start];                                     // Store jump distance before marking
        arr[start] = -arr[start];                                  // Mark current cell as visited via negation

        return CanReach(arr, start + jump) ||                      // Try jumping forward
               CanReach(arr, start - jump);                        // Try jumping backward
    }
}