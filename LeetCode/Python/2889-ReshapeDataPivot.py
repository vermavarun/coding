import pandas as pd
'''
Using the pandas library, create a function that takes a DataFrame of weather data and reshapes it into a pivot table.
pivot is a pandas function that reshapes a DataFrame into a pivot table.
index is the column to use as the index of the pivot table. The column that we need to keep
columns is the column to use as the columns of the pivot table. The column that we need to spread
values is the column to use as the values of the pivot table. The column that we need to spread
'''
def pivotTable(weather: pd.DataFrame) -> pd.DataFrame:
    return weather.pivot(index="month", columns="city", values="temperature")
