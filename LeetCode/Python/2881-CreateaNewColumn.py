# https://leetcode.com/problems/create-a-new-column/solutions/6184192/simplest-solution-python-time-on-space1-onoy2/
import pandas as pd
'''
Using the pandas library, create a function that takes a DataFrame of employees and adds a new column called "Bonus" that is twice the value of the "Salary" column.
'''
def createBonusColumn(employees: pd.DataFrame) -> pd.DataFrame:
    employees['bonus'] = employees['salary'] * 2
    return employees