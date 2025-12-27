/*
Solution: 
Difficulty: Medium
Approach: [Algorithm approach to be determined]
Tags: [Relevant tags]
1) [Step 1 description]
2) [Step 2 description]
3) [Step 3 description]

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public string MergeAlternately(string word1, string word2) {

        int lsb = word1.Length > word2.Length ? word1.Length : word2.Length;
        int index = 0;
        StringBuilder sb = new StringBuilder();

        while(index < lsb) {

            if (index < word1.Length) sb.Append(word1[index]);
            if (index < word2.Length) sb.Append(word2[index]);

            index++;
        }

        return sb.ToString();

    }
}

