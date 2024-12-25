# https://leetcode.com/problems/change-data-type/solutions/6184629/simplest-solution-python-please-upvote-b-ouv7/
import pandas as pd
'''
Using the pandas library, create a function that takes a DataFrame of students and changes the datatype of the "grade" column to int.
astype is a pandas function that changes the datatype of a column in a DataFrame.
'''
def changeDatatype(students: pd.DataFrame) -> pd.DataFrame:
    students['grade'] = students['grade'].astype(int) # change the datatype of the "grade" column to int
    return students