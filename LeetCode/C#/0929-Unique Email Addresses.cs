// Approach 1
public class Solution {
    public int NumUniqueEmails(string[] emails) {

        HashSet<String> hs = new HashSet<String>();
        foreach(string email in emails) {
            string localName = email.Split('@')[0];
            string domain = email.Split('@')[1];
            localName = localName.Split('+')[0];
            localName = localName.Replace(".","");
            hs.Add(localName+"@"+domain);
        }
        return hs.Count();
    }
}