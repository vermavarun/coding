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
