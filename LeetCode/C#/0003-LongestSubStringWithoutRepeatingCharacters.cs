/*
Solution:
Difficulty: Medium
Approach: Sliding Window with HashMap
Tags: Hash Table, String, Sliding Window
1) Use a sliding window approach with left and right pointers.
2) Maintain a dictionary to store characters and their indices.
3) Expand window by moving right pointer, adding characters to dictionary.
4) When duplicate found, shrink window from left until duplicate removed.
5) Track maximum window size seen so far.
6) Return the maximum length found.

Time Complexity: O(n) where n = s.length
Space Complexity: O(min(n, m)) where m is the charset size
*/
// Animation https://www.interviewbit.com/blog/wp-content/uploads/2021/10/Image-1-7-768x633.png
// Test Cases
// "abcabcbb"
// "bbbbb"
// "pwwkew"
// "dvdf"
// "xxzqi"


// Solution only one loop
public class Solution {
    public int LengthOfLongestSubstring(string s) {

        if(s.Length==0)
            return 0;
        int currentMax = 0;
        int max = 0;
        int startSlidingWindow = 0;
        int endSlidingWindow = 0;
        int charIndex = 0;
        Dictionary<char,int> uniqueCharacters = new Dictionary<char,int>();
        while(endSlidingWindow >= startSlidingWindow && charIndex < s.Length) {
            if(!uniqueCharacters.ContainsKey(s[charIndex])) {
                uniqueCharacters.TryAdd(s[charIndex],1);
                endSlidingWindow++;
                currentMax++;
            }
            else {
                startSlidingWindow++;
                endSlidingWindow = startSlidingWindow;
                uniqueCharacters.Clear();
                if(max < currentMax) {
                    max = currentMax;
                }
                currentMax = 0;
                charIndex = startSlidingWindow -1;
            }
            charIndex++;
        }

        return max > currentMax ? max : currentMax; // special case to handle " "
    }
}

// public class Solution
// {
//     public int LengthOfLongestSubstring(string s)
//     {
//         if (s.Length == 0) {
//             return 0;
//         }

//          if (s.Length == 1) {
//             return 1;
//         }

//         int startWindow = 0;
//         int endWindow = 0;
//         int max = 0 ;
//         Dictionary<char,int> map = new Dictionary<char,int>();

//         while(endWindow < s.Length) {

//             if(!map.ContainsKey(s[endWindow])) {
//                 map.Add(s[endWindow],1);
//             }
//             else{
//                 int valueKey = map[s[endWindow]];
//                 map[s[endWindow]] = valueKey + 1;
//             }

//             while(map.ContainsKey(s[endWindow]) && map[s[endWindow]] > 1 ) {

//                 int valueKey = map[s[startWindow]];
//                 map[s[startWindow]] = valueKey - 1;

//                 startWindow++;
//             }

//              max = Math.Max(max,endWindow - startWindow + 1);
//              endWindow++;
//         }
//         return max;
//     }
// }


// Better Space InterviewBit Solution.
// public class Solution
// {
//     public int LengthOfLongestSubstring(string s)
//     {
//         int[] chars = new int[128];

//         int left = 0;
//         int right = 0;

//         int res = 0;
//         while (right < s.Length) {
//             char r = s[right];
//             chars[r]++;

//             while (chars[r] > 1) {
//                 char l = s[left];
//                 chars[l]--;
//                 left++;
//             }

//             res = Math.Max(res, right - left + 1);

//             right++;
//         }
//         return res;
//     }
// }
