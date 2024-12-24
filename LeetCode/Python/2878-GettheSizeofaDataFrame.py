# https://leetcode.com/problems/get-the-size-of-a-dataframe/solutions/6181317/simplest-solution-python-please-upvote-b-pu21/

import pandas as pd
'''
Using the pandas library, get the number of rows and columns in the given DataFrame players.
Return a list containing the number of rows and columns in the DataFrame.

The shape property returns a tuple containing the shape of the DataFrame.
The shape is the number of rows and columns of the DataFrame in the form (rows, columns).

'''
def getDataframeSize(players: pd.DataFrame) -> List[int]:
    rows = players.shape[0]     # Get the number of rows in the DataFrame players
    columns = players.shape[1]  # Get the number of columns in the DataFrame players
    return [rows,columns]       # Return a list containing the number of rows and columns in the DataFrame
