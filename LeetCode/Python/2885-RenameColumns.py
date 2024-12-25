import pandas as pd
'''
Using the pandas library, create a function that takes a DataFrame of students and renames the columns to "student_id", "first_name", "last_name", and "age_in_years".
.columns is a pandas attribute that allows you to rename the columns of a DataFrame.
'''
def renameColumns(students: pd.DataFrame) -> pd.DataFrame:
    students.columns = ['student_id', 'first_name', 'last_name', 'age_in_years']    # rename the columns of the DataFrame
    return students                                                                 # return the DataFrame with the columns renamed