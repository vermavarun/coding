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

