"""
Solution: 
Difficulty: Easy
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
"""
'''
Approach:
1. Create a dictionary mapping where the key is the source city and the value is the destination city.
2. Start from the first source city and keep on updating the source city to the destination city.
3. If the source city is not in the mapping, then it is the destination city.

Time complexity: O(n)
Space complexity: O(n)

'''
class Solution:
    def destCity(self, paths: List[List[str]]) -> str:
        mapping = {}
        for path in paths:
            mapping[path[0]] = path[1]
        dest = paths[0][0]
        while(dest is not None):
            if dest in mapping:
                dest = mapping[dest]
            else:
                return dest
