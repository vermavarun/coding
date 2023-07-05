public class Solution {
    public bool IsAnagram(string s, string t) {

        if (s.Length != t.Length)
            return false;
        
        int[] set = new int[256] ;
        
        foreach(char c in s) {
            set[c]++;  
        }

        foreach(char c in t) {
            set[c]--;  
        }

        int index = 0;
        while(index < set.Length) {
            if(set[index]!=0)
                return false;
            index++;
        }

        return true;
    }
}
