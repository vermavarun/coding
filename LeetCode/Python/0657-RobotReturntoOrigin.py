'''
Title: 657. Robot Return to Origin
Solution: https://leetcode.com/problems/robot-return-to-origin/solutions/7784245/simplest-solution-c-time-on-space-on-ple-kh8r/
Difficulty: Easy
Approach: Coordinate tracking simulation
Tags: String, Simulation
1) Initialize x and y coordinates to 0 (starting at origin).
2) Iterate through each character in the moves string.
3) For 'R' (right), increment x by 1.
4) For 'L' (left), decrement x by 1.
5) For 'U' (up), increment y by 1.
6) For 'D' (down), decrement y by 1.
7) After all moves, check if both x and y are 0.
8) Return True if robot is at origin, False otherwise.

Time Complexity: O(n) where n = len(moves)
Space Complexity: O(1) constant space for x and y coordinates
Tip: The robot returns to origin only if the number of 'R' moves equals 'L' moves AND the number of 'U' moves equals 'D' moves. You can also use Counter from collections to count moves: Counter(moves)['R'] == Counter(moves)['L'] and Counter(moves)['U'] == Counter(moves)['D'].
Similar Problems: 1041. Robot Bounded In Circle, 1266. Minimum Time Visiting All Points, 2120. Execution of All Suffix Instructions Staying in a Grid
'''
class Solution:
    def judgeCircle(self, moves: str) -> bool:
        x = 0                                           # Initialize x-coordinate at origin
        y = 0                                           # Initialize y-coordinate at origin
        for direction in moves:                         # Iterate through each move command
            if direction == 'R':                        # If move is right
                x+=1                                    # Move right (increment x)
            elif direction == 'L':                      # If move is left
                x-=1                                    # Move left (decrement x)
            elif direction == 'U':                      # If move is up
                y+=1                                    # Move up (increment y)
            elif direction == 'D':                      # If move is down
                y-=1                                    # Move down (decrement y)
        return x == 0 and y == 0                        # Return True if robot is back at origin (0,0)