/*
Solution: 
Difficulty: Medium
Approach:
Tags: Hash Table, String
1. Create a dictionary to store the longUrl and the corresponding shortUrl.
2. Create a variable to store the base address.
3. If the longUrl is not present in the dictionary, then add it to the dictionary.
4. Return the base address concatenated with the shortUrl.
5. To decode, extract the shortUrl from the input.
6. Extract the number from the shortUrl.
7. Iterate through the dictionary and find the longUrl corresponding to the number.
8. Return the longUrl.
Time complexity: O(1)

Space Complexity: O(?)
*/
public class Codec {
    Dictionary<string,int> dict  = new Dictionary<string,int>();
    string baseAddress = "http://tinyurl.com/";

    // Encodes a URL to a shortened URL
    public string encode(string longUrl) {
       if(!dict.ContainsKey(longUrl)) {
        int surl = dict.Count()+1;
        dict.Add(longUrl,surl);
       }
       return baseAddress + dict[longUrl].ToString();
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {

        int surl = Convert.ToInt16(shortUrl.Split(".com/")[1]);
        string longUrl = string.Empty;
        foreach(var kv in dict) {
            if(kv.Value == surl)
                longUrl = kv.Key;
        }
        return longUrl;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));