/*

Approach:
1. Check if the rows are valid.
2. Check if the columns are valid.
3. Check if the boxes are valid.
4. If all the above conditions are satisfied, return true.
5. Otherwise, return false.

Time complexity: O(n)
Space complexity: O(n)

*/
public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        return CheckRows(board) && CheckColumns(board) && CheckBoxes(board);
    }

    static bool CheckBoxes(char[][] board)
    {
        int startRow = 0;
        int startColumn = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                bool isCompliant = CheckBox(board, startRow, startColumn);
                if (!isCompliant) return false;
                startColumn = startColumn + 3;
            }
            startColumn = 0;
            startRow = startRow + 3;
        }
        return true;
    }

    static bool CheckBox(char[][] board, int startRow, int startColumn)
    {
        HashSet<char> set = new HashSet<char>();
        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startColumn; j < startColumn + 3; j++)
            {
                if (board[i][j] == '.') continue;

                if (set.Contains(board[i][j]))
                {
                    return false;
                }
                else
                {
                    set.Add(board[i][j]);
                }
            }
        }
        return true;
    }

    static bool CheckColumns(char[][] board)
    {
        HashSet<char> set = new HashSet<char>();

        for (int column = 0; column < board.Length; column++)
        {
            for (int row = 0; row < board[column].Length; row++)
            {
                if (board[row][column] == '.') continue;

                if (set.Contains(board[row][column]))
                {
                    return false;
                }
                else
                {
                    set.Add(board[row][column]);
                }
            }
            set.Clear();
        }
        return true;
    }

    static bool CheckRows(char[][] board)
    {
        HashSet<char> set = new HashSet<char>();
        for (int row = 0; row < board.Length; row++)
        {
            for (int column = 0; column < board[row].Length; column++)
            {
                if (board[row][column] == '.') continue;

                if (set.Contains(board[row][column]))
                {
                    return false;
                }
                else
                {
                    set.Add(board[row][column]);
                }
            }
            set.Clear();
        }
        return true;
    }

}