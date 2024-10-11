/*

Approach:
1) Initialize the row and triangle lists
2) Add the first row to the triangle list
3) Iterate through the rows
4) Add 1 to the row list
5) Iterate through the columns
6) Add the sum of the previous row's jth and (j-1)th elements to the row list
7) Add 1 to the row list
8) Add the row list to the triangle list
9) Return the triangle list

Time complexity: O(n^2)
Space complexity: O(n^2)


*/

public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        List<int> row = new List<int>();
            List<IList<int>> triangle = new List<IList<int>>();
            triangle.Add(new List<int>{1});

            for(int i=1; i<numRows; i++) {
                row.Add(1);
                for(int j=1; j<i; j++) {
                    row.Add( triangle[i-1][j-1] + triangle[i-1][j] );
                }
                row.Add(1);
                triangle.Add(row);
                row = new List<int>();
            }

            return triangle;
    }
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////
///
public class Solution {
    public IList<IList<int>> Generate(int numRows) {

        IList<IList<int>> triangle = new List<IList<int>>();
        IList<int> firstRow = new List<int>();
        firstRow.Add(1);
        triangle.Add(firstRow);


        for(int i = 1; i < numRows; i++) {

                IList<int> row = new List<int>();
                row.Add(1);
                IList<int> prevRow = triangle[i-1];

               for(int j = 1;j < i; j++) {

                 row.Add(prevRow[j-1] + prevRow[j]);

                }

                row.Add(1);
                triangle.Add(row);
        }

        return triangle;

    }
}
