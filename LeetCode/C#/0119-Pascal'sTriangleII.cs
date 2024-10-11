/*

Approach:
1) Initialize the lastRow and currentRow lists
2) Add 1 to the currentRow list
3) Iterate through the rows
4) Add 1 to the currentRow list
5) Iterate through the columns
6) Add the sum of the lastRow's jth and (j-1)th elements to the currentRow list
7) Add 1 to the currentRow list
8) Set the lastRow to the currentRow
9) Return the currentRow

Time complexity: O(n^2)
Space complexity: O(n)

*/


public class Solution {
    public IList<int> GetRow(int rowIndex) {
        List<int> lastRow = new List<int>();
        List<int> currentRow = new List<int>();
        currentRow.Add(1);
        lastRow = currentRow;

        for(int i=1; i<=rowIndex; i++) {

            currentRow = new List<int>();
            currentRow.Add(1);
            for(int j=1; j<i; j++) {
                currentRow.Add( lastRow[j-1] + lastRow[j] );
            }
            currentRow.Add(1);
            lastRow = currentRow;
        }

        return currentRow;

    }
}