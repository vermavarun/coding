# https://leetcode.com/problems/modify-columns/solutions/6184583/simplest-solution-python-please-upvote-b-29ha/
import pandas as pd
'''
Using the pandas library, create a function that takes a DataFrame of employees and modifies the "Salary" column to be twice its original value.
'''
def modifySalaryColumn(employees: pd.DataFrame) -> pd.DataFrame:
    employees['salary'] = employees['salary'] * 2   # modify the "salary" column to be twice its original value
    # or employees.salary *= 2
    return employees                                # return the DataFrame with the "salary" column modified