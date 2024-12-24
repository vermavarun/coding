# https://leetcode.com/problems/display-the-first-three-rows/solutions/6181343/simplest-solution-python-please-upvote-b-2cxy/

import pandas as pd
'''
Using the head() method, we can select the first n rows of a DataFrame.
or
Using the iloc[] method, we can select the first n rows of a DataFrame.
or
Using the slicing operator, we can select the first n rows of a DataFrame.
'''
def selectFirstRows(employees: pd.DataFrame) -> pd.DataFrame:
    return employees.head(3) # or return employees[:3] or return employees.iloc[:3]