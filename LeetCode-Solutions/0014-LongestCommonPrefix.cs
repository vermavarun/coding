// Check all strings char by char.
public class Solution {
    public string LongestCommonPrefix(string[] strs) {

        StringBuilder result = new StringBuilder();

        for (int i=0; i<strs[0].Length; i++) { // randomly first string taken, any string can be taken best would be smallest.

            foreach(string s in strs) {

                if(i == s.Length || strs[0][i] != s[i]) { //  First condition will check if any other string is less than first string.
                    return result.ToString();
                }
            }
            result.Append(strs[0][i]);
        }

        return result.ToString();        
    }
}
