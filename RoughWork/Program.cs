




using System;
using System.Linq;
using System.Collections.Generic;
namespace Practice
{

    class Practice
    {
        public static void Main(string[] args)
        {
            // GroupAnagrams
            // string[] arr = new string[]{"eat","tea","tan","ate","nat","bat"};
            // var output = GroupAnagrams(arr);
            // foreach(var item in output) {
            //     Console.WriteLine(string.Join(",", item));
            // }

            // IsIsomorphic
            // string s = "egg";
            // string t = "add";
            // Console.WriteLine(IsIsomorphic(s, t));

            // FindPivot
            // int[] nums = new int[]{1, 7, 3, 6, 5, 6};
            // Console.WriteLine(FindPivot(nums));

            // FindDisappearedNumbers
            //int[] nums = new int[]{4,3,2,7,8,2,3,1};
            // int[] nums = new int[]{1,1};
            // var output = FindDisappearedNumbers(nums);
            // foreach(var item in output) {
            //     Console.WriteLine(item);
            // }

            // MaxNumberOfBalloons
            // int result = MaxNumberOfBalloons("loonbalxballpoon");
            // System.Console.WriteLine(result);

            // WordPattern
            // bool result = WordPattern("abba", "dog cat cat fish");
            // bool result = WordPattern("abba","dog cat cat dog");
            //  bool result = WordPattern("abba","dog dog dog dog");
            // System.Console.WriteLine(result);

            // IsMonoTonic
            // int[] nums = new int[]{1,2,2,3};
            // bool result = IsMonotonic(nums);
            // System.Console.WriteLine(result);

            // MaxProductDifference
            // int[] nums = new int[]{5,6,2,7,4}; // 34
            // int[] nums = new int[]{4,2,5,9,7,4,8}; // 64
            // int result = MaxProductDifference(nums);
            // System.Console.WriteLine(result);

            // MaxScore
            // string s = "011101"; // 5
            // string s = "1111";  //  3
            // string s = "00" // 1
            // int result = MaxScore(s);
            // System.Console.WriteLine(result);

            // IsPathCrossing
            // string path = "NES"; // false
            // string path = "NESWW"; // true
            // bool result = IsPathCrossing(path);
            //System.Console.WriteLine(result);

            // MinOperations
            // string s = "0100"; // 1
            // string s = "10" ;  // 0
            // string s = "1111" ;// 2
            // string s = "10010100" ;//3
            // int result = MinOperations(s);
            // System.Console.WriteLine(result);

            // MakeEqual
            // string[] words = ["abc","aabc","bc"]; // true
            // string[] words = ["ab","a"]; // false
            // bool result = MakeEqual(words);
            // System.Console.WriteLine(result);

            // MaxLengthBetweenEqualCharacters
            // string s = "aa";     // 0
            // string s = "abca";   // 2
             string s = "cbzxy";  // -1
            int result = MaxLengthBetweenEqualCharacters(s);
            System.Console.WriteLine(result);

        }

        static int MaxLengthBetweenEqualCharacters(string s) {
            Dictionary<char,int> dict = new Dictionary<char, int>();

            int index, result;
            index = 0;
            result = -1;

            while(index < s.Length) {

                if(!dict.ContainsKey(s[index])) {
                    dict[s[index]] = index;
                }
                else {
                    result = Math.Max(index - dict[s[index]] - 1,result);
                }
                index++;
            }
            return result;
        }

        static bool MakeEqual(string[] words) {

            Dictionary<char,int> dict = new Dictionary<char, int>();

            foreach (string word in words) {

                foreach(char ch in word) {

                    if (dict.ContainsKey(ch)) {
                        dict[ch] = dict[ch] + 1;
                    }
                    else {
                        dict.Add(ch,1);
                    }
                }
            }

            foreach(var kv in dict) {
                if (kv.Value % words.Length  !=  0)
                    return false;
            }

            return true;

        }
        static int MinOperations(string s) {

            char nextExpectedChar = '1';
            char currentChar = '\0';
            int index = 1;
            int result = 0;

            if (s[0] != '0') {
                nextExpectedChar = '0';
            }

            while(index < s.Length) {

                currentChar = s[index];

                if(currentChar != nextExpectedChar) {
                    result++;
                    currentChar = nextExpectedChar;
                }

                nextExpectedChar = currentChar == '0' ? '1' : '0';
                index++;
            }

            // As alternative string can start from 0 or 1, we will take minimum of two strings
            // if result is for 0. s.Length - result will be for 1.
            return Math.Min(s.Length - result ,result);

        }
        static bool IsPathCrossing(string path) {
            HashSet<(int,int)> set = new HashSet<(int,int)>();
            int x,y;
            x = y = 0;
            set.Add((0,0));

            foreach(char c in path) {
                switch (c) {

                    case 'N':
                        y=y+1;
                        break;
                    case 'E':
                        x=x+1;
                        break;
                    case 'S':
                        y=y-1;
                        break;
                    case 'W':
                        x=x-1;
                        break;
                }

                if (set.Contains((x,y)))
                    return true;
                set.Add((x,y));

            }

            return false;
        }
        static int MaxScore(string s) {

            int currentIndex, numOfZerosInLeftPart, numOfOnesInRightPart, score, maxScore;
            currentIndex = numOfZerosInLeftPart = numOfOnesInRightPart = score = maxScore = 0;

            while(currentIndex < s.Length) {

                if(s[currentIndex] == '1') numOfOnesInRightPart++;
                currentIndex++;

            }

            currentIndex = 0;

            while(currentIndex < s.Length - 1) {

                if (s[currentIndex] == '0') {
                    numOfZerosInLeftPart++;
                }
                else {
                    numOfOnesInRightPart--;
                }

                score = numOfZerosInLeftPart + numOfOnesInRightPart;
                if (score > maxScore) maxScore = score;
                currentIndex++;

            }

            return maxScore;

        }
        static int MaxProductDifference(int[] nums) {

            int max1, max2, min1, min2, index,currentNumber;
            max1 = max2 = int.MinValue;
            min1 = min2 = int.MaxValue;
            index = 0;

            while (index < nums.Length) {

                currentNumber = nums[index];

                if (currentNumber > max2) {
                    max2 = currentNumber;
                }

                if(currentNumber > max1) {
                    max2 = max1;
                    max1 = currentNumber;
                }

                if(currentNumber < min2) {
                    min2 = currentNumber;
                }

                if(currentNumber < min1) {
                    min2 = min1;
                    min1 = currentNumber;
                }

                index++;

            }

            return (max1 * max2) - (min1 * min2);
        }
        static bool IsMonotonic(int[] nums) {

            return IsIncreasingMonotonic(nums) || IsDecreasingMonotonic(nums);

        }
        static bool IsIncreasingMonotonic(int[] nums) {
            int index = 0;
            while(index < nums.Length - 1) {
                if (nums[index] > nums [index + 1])  return false;
                index++;
            }

            return true;
        }
        static bool IsDecreasingMonotonic(int[] nums) {
            int index = 0;
            while(index < nums.Length - 1) {
                if (nums[index] < nums [index + 1])  return false;
                index++;
            }

            return true;
        }
        static List<List<string>> GroupAnagrams(string[] arr) {
            return arr.GroupBy(x => new string(x.OrderBy(c => c).ToArray())).Select(x => x.ToList()).ToList();
        }
        static List<List<string>> GroupAnagrams_1(string[] arr) {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach(var item in arr) {
                var key = new string(item.OrderBy(c => c).ToArray());
                if(dict.ContainsKey(key)) {
                    dict[key].Add(item);
                }
                else {
                    dict.Add(key, new List<string>(){item});
                }
            }
            return dict.Values.ToList();
        }
        static bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, char> map = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                char sChar = s[i];
                char tChar = t[i];

                if (map.ContainsKey(sChar))
                {
                    if (map[sChar] != tChar)
                    {
                        return false;
                    }
                }
                else
                {
                    if (map.ContainsValue(tChar))
                    {
                        return false;
                    }
                    map.Add(sChar, tChar);
                }
            }

            return true;
        }
        static int FindPivot(int[] nums) {
            // {1, 7, 3, 6, 5, 6}
            // [1,2,3]
            // [2,1,-1]
            // [0]

            int currentIndex = 0;
            int sumLeft = 0;
            int sumRight = 0;
            int totalSum = nums.Sum();

            while(currentIndex < nums.Length) {
                sumRight = totalSum - sumLeft - nums[currentIndex];

                if(sumLeft == sumRight) {
                    return currentIndex;
                }
                sumLeft = sumLeft + nums[currentIndex];
                currentIndex++;
            }

            return -1;

        }
        static IList<int> FindDisappearedNumbers(int[] nums) {


            // int[] nums = new int[]{4,3,2,7,8,2,3,1};

            int[] check = new int[nums.Length];
            IList<int> result = new List<int>();
            int i=0;

            while(i < nums.Length) {
                check[i] = i+1;
                i++;
            }

            i=0;
            while(i < nums.Length) {
                check[nums[i] - 1] = -1;
                i++;
            }

            i=0;
            while(i < check.Length) {
                if (check[i] != -1) {
                    result.Add(check[i]);
                }
                i++;
            }

            return result;
        }
        static int MaxNumberOfBalloons(string text) {
            // text = loonbalxballpoon
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
        static bool WordPattern(string pattern, string s) {

            // Input: pattern = "abba", s = "dog cat cat fish"
            // Input: pattern = "aaaa", s = "dog cat cat dog"
            // Input: pattern = "abba", s = "dog cat cat dog"
            // Input: pattern = "abba", s = "dog dog dog dog"

            Dictionary<string,char> dictWordToPattern = new Dictionary<string, char>();
            Dictionary<char,string> dictPatternToWord = new Dictionary<char, string>();

            var words = s.Split(' ');
            var patternChars = pattern.ToCharArray();

            if (words.Length != patternChars.Length) return false;

            int wordsPointer = 0;
            int patternPointer = 0;

            while(patternPointer < pattern.Length) {

                var currentPattern = pattern[patternPointer];
                var currentWord = words[wordsPointer];

                if (dictPatternToWord.ContainsKey(currentPattern) && dictPatternToWord[currentPattern] != currentWord) return false;

                if (dictWordToPattern.ContainsKey(currentWord) && dictWordToPattern[currentWord] != currentPattern) return false;


                dictPatternToWord[currentPattern] = currentWord;
                dictWordToPattern[currentWord] = currentPattern;

                // if (!dictPatternToWord.ContainsKey(currentPattern)) {

                //     dictPatternToWord.Add(currentPattern,currentWord);  // a->dog
                //     dictWordToPattern.Add(currentWord,currentPattern);  // dog->a
                // }
                // else {

                //     var wordToMatch = dictPatternToWord[currentPattern];
                //     if(!wordToMatch.Equals(currentWord)) return false;

                // }

                wordsPointer++;
                patternPointer++;

            }

            return true;



        }

    }
}