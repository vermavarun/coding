/*
Title: 1415. The k-th Lexicographical String of All Happy Strings of Length n
Solution:
Difficulty: Medium
Approach: Backtracking with DFS to generate strings in lexicographical order
Tags: String, Backtracking, DFS
1) Use DFS to generate all valid happy strings in lexicographical order.
2) A happy string has no adjacent characters that are the same.
3) Only use characters 'a', 'b', 'c' in order to ensure lexicographical ordering.
4) Track the count of generated strings and stop when we reach the k-th string.
5) Return the k-th happy string if it exists, otherwise return empty string.

Time Complexity: O(3^n) in worst case as we may generate all possible strings
Space Complexity: O(n) for the recursion stack depth
Tip: By iterating through characters in sorted order ('a', 'b', 'c'), we naturally generate strings in lexicographical order. This avoids the need to sort after generation.
Similar Problems: 1079. Letter Tile Possibilities, 320. Generalized Abbreviation, 1087. Brace Expansion
*/
public class Solution {

    // Tracks how many happy strings we have generated so far
    int count = 0;

    // Stores the k-th happy string once found
    string ans = "";

    public string GetHappyString(int n, int k) {

        // Start DFS with an empty string to build up to length n
        DFS("", n, k);

        // If we never reached k strings, ans remains empty string ""
        return ans;
    }

    void DFS(string cur, int n, int k) {

        // If answer already found, stop exploring further branches (pruning)
        if (ans != "") 
            return;

        /*
        If current string length reached n,
        we formed one valid happy string that meets all constraints
        */
        if (cur.Length == n) {

            // Increase the count of happy strings generated so far
            count++;

            // If this is the k-th string, store it as the answer
            if (count == k)
                ans = cur;

            return;
        }

        /*
        Try adding characters in lexicographical order ('a', 'b', 'c')
        This ensures generated strings are automatically sorted, so we find the k-th lexicographically
        */
        foreach (char c in "abc") {

            /*
            Happy string condition:
            Adjacent characters must NOT be the same
            Check if current string is empty OR last character is different from c
            */
            if (cur.Length == 0 || cur[cur.Length - 1] != c) {

                // Character is valid - add it and continue building the string recursively
                DFS(cur + c, n, k);
            }
        }
    }
}