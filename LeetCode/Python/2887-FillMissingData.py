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
Using the pandas library, create a function that takes a DataFrame of products and fills any missing values with 0.
fillna is a pandas function that fills missing values in a DataFrame with a specified value.
'''
def fillMissingValues(products: pd.DataFrame) -> pd.DataFrame:
    products['quantity'] = products['quantity'].fillna(0)   # fillna fills missing values in a DataFrame with a specified value
