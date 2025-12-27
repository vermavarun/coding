/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Hash Table, String, Math
1. Create a dictionary to store the count of each character in the word "balloon".
2. Create another dictionary to store the count of each character in the given text.
3. Create a list to store the count of each character in the given text divided by the count of each character in the word "balloon".
4. Return the minimum value from the list.

Time Complexity: O(n)
Space Complexity: O(n)
*/
public class Solution {
    public int MaxNumberOfBalloons(string text) {
        string balloon = "balloon";

            Dictionary<char,int> text_dict = new Dictionary<char, int>();
            Dictionary<char,int> balloon_dict = new Dictionary<char, int>();
            IList<int> count = new List<int>();

            int numOfTextChar = 0;
            int numOfBalloonsChar = 0;

            foreach(char c in balloon) {
                if(balloon_dict.ContainsKey(c)) {
                    balloon_dict[c] = balloon_dict[c] + 1;
                }
                else {
                    balloon_dict.Add(c,1);
                }
            }

            foreach(char c in text) {
                if(text_dict.ContainsKey(c)) {
                    text_dict[c] = text_dict[c] + 1;
                }
                else {
                    text_dict.Add(c,1);
                }
            }

            foreach(var kv in balloon_dict) {

                numOfBalloonsChar = kv.Value;

                if(text_dict.ContainsKey(kv.Key)) {
                    numOfTextChar = text_dict[kv.Key];
                    count.Add(numOfTextChar/numOfBalloonsChar);
                }
                else {
                    return 0;
                }

            }

            return count.Min();
    }
}

/*
Same approach smaller code
*/

public class Solution {
    public int MaxNumberOfBalloons(string text) {
        var charCounts = text.GroupBy(c => c)
                        .ToDictionary(g => g.Key, g => g.Count());
        var balloonCounts = "balloon".GroupBy(c => c)
                        .ToDictionary(g => g.Key, g => g.Count());

        int result = text.Length;
        foreach (var balloonCount in balloonCounts) {
            if (charCounts.ContainsKey(balloonCount.Key)) {
                result = Math.Min(result, charCounts[balloonCount.Key] / balloonCount.Value);
            } else {
                result = 0;
                break;
            }
        }
        return result;
    }
}