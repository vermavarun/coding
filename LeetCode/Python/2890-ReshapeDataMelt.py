# https://leetcode.com/problems/reshape-data-melt/submissions/1488842410/?envType=study-plan-v2&envId=introduction-to-pandas&lang=pythondata
import pandas as pd
'''
Using the pandas library, create a function that takes a DataFrame of quarterly sales data and reshapes it into a long format.
melt is a pandas function that reshapes a DataFrame into a long format.
id_vars is the column to use as identifier variables.
var_name is the name of the column that will contain the variable names.
value_name is the name of the column that will contain the values.
'''
def meltTable(report: pd.DataFrame) -> pd.DataFrame:
    return pd.melt(report, id_vars=['product'], var_name='quarter', value_name='sales')
