
// Approach 1
// Use Dictionary to insert array sorted element as key and all elements as values.
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string,IList<string>> dict = new Dictionary<string,IList<string>>();
        foreach(string s in strs) {
            var key = new string(s.OrderBy(c=>c).ToArray());
            if(dict.ContainsKey(key)) {
                dict[key].Add(s);
            }
            else{
                dict.Add(key,new List<string>(){s});
            }
        }
        return dict.Values.ToList();
    }
}