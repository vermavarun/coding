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
Using the pandas library, create a function that takes a DataFrame of customers and removes any duplicate rows based on the "email" column.
drop_duplicates is a pandas function that removes duplicate rows from a DataFrame.
'''
def dropDuplicateEmails(customers: pd.DataFrame) -> pd.DataFrame:
    dup_customers_removed = customers.drop_duplicates(subset=['email']) # drop_duplicates removes duplicate rows from a DataFrame
    return dup_customers_removed                                        # return the DataFrame with duplicate rows removed