"""
Solution: 
Difficulty: Medium
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
"""
import pandas as pd
'''
Using the pandas library, create a function that takes a DataFrame of animals and returns only the rows where the "weight" column is greater than 100, sorted in descending order by weight, and only including the "name" column.
query is a pandas function that filters a DataFrame based on a query string.
'''
def findHeavyAnimals(animals: pd.DataFrame) -> pd.DataFrame:
    return animals.query('weight > 100').sort_values(by='weight',ascending=False)[['name']] # query filters the DataFrame to only include rows where the weight column is greater than 100, sort_values sorts the DataFrame by the weight column in descending order, and [['name']] returns a DataFrame with only the name column
