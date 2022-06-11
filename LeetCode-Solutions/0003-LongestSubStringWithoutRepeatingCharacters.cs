// Animation https://www.interviewbit.com/blog/wp-content/uploads/2021/10/Image-1-7-768x633.png
// Test Cases
// "abcabcbb"
// "bbbbb"
// "pwwkew"
// "dvdf"
// "xxzqi"

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0) {
            return 0;
        }
        
         if (s.Length == 1) {
            return 1;
        }
        
        int startWindow = 0;
        int endWindow = 0;
        int max = 0 ;
        Dictionary<char,int> map = new Dictionary<char,int>();

        while(endWindow < s.Length) {
            
            if(!map.ContainsKey(s[endWindow])) {
                map.Add(s[endWindow],1);                            
            }
            else{
                int valueKey = map[s[endWindow]];
                map[s[endWindow]] = valueKey + 1;
            }
            
            while(map.ContainsKey(s[endWindow]) && map[s[endWindow]] > 1 ) {

                int valueKey = map[s[startWindow]];
                map[s[startWindow]] = valueKey - 1;

                startWindow++;
            }            
                
             max = Math.Max(max,endWindow - startWindow + 1);
             endWindow++;     
        }
        return max;
    }               
}


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
