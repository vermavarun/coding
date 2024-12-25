import pandas as pd
'''
Using the pandas library, create a function that takes a DataFrame of students and removes any rows where the "name" column is missing.
dropna is a pandas function that removes rows with missing data from a DataFrame.
'''
def dropMissingData(students: pd.DataFrame) -> pd.DataFrame:
    dropped_students = students.dropna(subset=["name"]) # dropna removes rows with missing data from a DataFrame
    return dropped_students                             # return the DataFrame with rows where the "name" column is missing removed
