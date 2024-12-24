# https://leetcode.com/problems/create-a-dataframe-from-list/solutions/6181300/simplest-solution-python-please-upvote-b-0sq6/

import pandas as pd
'''
Use the pandas library to create a DataFrame from the given list of lists student_data.
The DataFrame should have two columns: student_id and age.
Return the DataFrame.
'''
def createDataframe(student_data: List[List[int]]) -> pd.DataFrame:
    df = pd.DataFrame(student_data, columns=["student_id","age"])   # Create a DataFrame from the given list of lists student_data
    return df                                                       # Return the DataFrame
