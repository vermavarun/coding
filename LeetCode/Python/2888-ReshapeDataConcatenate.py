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
Using the pandas library, create a function that takes two DataFrames and concatenates them into a single DataFrame.
pd.concat is a pandas function that concatenates two DataFrames into a single DataFrame.
or
pd._append is a pandas function that concatenates two DataFrames into a single DataFrame.
'''
def concatenateTables(df1: pd.DataFrame, df2: pd.DataFrame) -> pd.DataFrame:
    df1 = df1._append(df2)
    return df1

    # or return pd.concat([df1,df2])