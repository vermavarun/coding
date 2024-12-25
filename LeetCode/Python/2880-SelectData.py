# https://leetcode.com/problems/select-data/post-solution/?submissionId=1487712581
import pandas as pd
'''
Using the pandas library, select the name and age of the student with student_id 101 from the given DataFrame students.
Return a DataFrame containing the name and age of the student with student_id 101.

The query method is used to select rows from a DataFrame based on a condition.
The query method takes a string as an argument that specifies the condition for selecting rows.
The query method returns a DataFrame containing the rows that satisfy the condition.
'''
def selectData(students: pd.DataFrame) -> pd.DataFrame:
    # dt = students.loc[students['student_id']==101,['name','age']] # Alternative solution using the loc method
    # dt = students[students['student_id']==101][['name','age']] # Alternative solution using boolean indexing
    # dt = students[students['student_id']==101].loc[:,['name','age']] # Alternative solution using boolean indexing and the loc method
    # dt = students[students['student_id']==101].iloc[:,[1,2]] # Alternative solution using boolean indexing and the iloc method
    # dt = students[students['student_id']==101].iloc[:,1:3] # Alternative solution using boolean indexing and the iloc method
    # dt = students.loc[students["student_id"] == 101, "name" :] # Alternative solution using the loc method
    dt = students.query('student_id == 101')[['name','age']] # Select the name and age of the student with student_id 101 from the DataFrame students
    return dt
