




using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice
{

    class Practice
    {
        public class Trie {
            public Trie[] Child = new Trie[26];
            public bool WordEnd = false;
            public int Count;

        }
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
            //  string s = "cbzxy";  // -1
            // int result = MaxLengthBetweenEqualCharacters(s);
            // System.Console.WriteLine(result);

            // SpecialArray
            // int[] nums = new int[]{3,5}; // 2
            // // int[] nums = new int[]{0,0}; // -1
            // // int[] nums = new int[]{0,4,3,0,4}; // 3
            // int result = SpecialArray(nums);
            // System.Console.WriteLine(result);
            // char[][] board =
            // [['5','3','.',   '.','7','.',   '.','.','.']
            // ,['6','.','.',   '1','9','5',   '.','.','.']
            // ,['.','9','8',   '.','.','.',   '.','6','.']

            // ,['8','.','.',   '.','6','.',   '.','.','3']
            // ,['4','.','.',   '8','.','3',   '.','.','1']
            // ,['7','.','.',   '.','2','.',   '.','.','6']

            // ,['.','6','.',   '.','.','.',   '2','8','.']
            // ,['.','.','.',   '4','1','9',   '.','.','5']
            // ,['.','.','.',   '.','8','.',   '.','7','9']];

            // char[][] board=
            // [['.','.','.',      '.','5','.',        '.','1','.'],
            // ['.','4','.'        ,'3','.','.',       '.','.','.'],
            // ['.','.','.'        ,'.','.','3',       '.','.','1'],

            // ['8','.','.',       '.','.','.',        '.','2','.'],
            // ['.','.','2',       '.','7','.',        '.','.','.'],
            // ['.','1','5',       '.','.','.',        '.','.','.'],

            // ['.','.','.',       '.','.','2',        '.','.','.'],
            // ['.','2','.',       '9','.','.',        '.','.','.'],
            // ['.','.','4',       '.','.','.',        '.','.','.']];
            // IsValidSudoku(board);

            // int result = CountCharacters(new string[] { "cat", "bt", "hat", "tree" }, "atach");
            // System.Console.WriteLine(result);

            // string result = LargestOddNumber("52");
            // string result = LargestOddNumber("4206");
            // System.Console.WriteLine(result);

            // int[] nums = new int[] { -1, 0, 1, 2, -1, -4 }; // {-4,-1,-1,0,1,2}       [[-1,-1,2],[-1,0,1]]
            // int[] nums = new int[] { 0, 0, 0, 0 }; // {0,0,0,0}       [[0,0,0]]
            // int[] nums = new int[] {-2,0,1,1,2}; // {[-2,0,1,1,2]}       [[-2,0,2],[-2,1,1]]
            // int[] nums = new int[] {-4,-2,1,-5,-4,-4,4,-2,0,4,0,-2,3,1,-5,0}     // {[-5,-4,-4,-4,-2,-2,-2,0,0,0,1,1,3,4,4]}       [[-5,1,4],[-4,0,4],[-4,1,3],[-2,-2,4],[-2,1,1],[0,0,0]]
            // var result = ThreeSum(nums);
            // foreach (var item in result)
            // {
            //     System.Console.WriteLine(string.Join(",", item));
            // }

            // MinStackII obj = new MinStackII();
            // obj.Push(-2);
            // obj.Push(0);
            // obj.Push(-3);
            // int param_4 = obj.GetMin();

            // obj.Pop();
            // obj.Top();
            // int param_5 = obj.GetMin();

            //var result = PrefixCount(new string[] { "dog", "cat", "bat", "rat", "cat" }, "ca");
            // var result = PrefixCount(new string[] { "pay","attention","practice","attend" }, "at");
            // System.Console.WriteLine(result);  // 2

            // var result = SearchInsert(new int[] { 1,3,5,6 }, 2); // 1
            // System.Console.WriteLine(result);

            var result = MinWindow("ADOBECODEBANC", "ABC"); // "BANC"
            Console.WriteLine(result);

        }

        public static string MinWindow(string s, string t) {

            if (t.Length == 0 || s.Length == 0 || t.Length > s.Length)
                return string.Empty;

            Dictionary<char,int> dict = new Dictionary<char,int>();

            int l = 0;
            int r = 0;
            int minL = 0;
            int need = t.Length;
            int minWindowSize = int.MaxValue;

            // Count chars in t
            foreach(char c in t) {
                if (!dict.ContainsKey(c)) {
                    dict.Add(c,1);
                }
                else {
                    dict[c]++;
                }
            }

            // start sliding
            while(r < s.Length) {

                if (dict.ContainsKey(s[r]) && s[r] > 0) {
                    dict[s[r]]--;
                    need--;
                }
                else if (dict.ContainsKey(s[r]) && s[r] <= 0) {
                    dict[s[r]]--;
                }
                else if (!dict.ContainsKey(s[r])) {
                    dict.Add(s[r],-1);
                }

                // If no more chars are required
                while(need == 0) {
                    minL = Math.Max(minL, l);
                    minWindowSize = Math.Min(minWindowSize, r - l + 1);

                    char ch = s[l];
                    if (dict.ContainsKey(ch)) {
                        dict[ch]++;
                        if (dict[ch] > 0)
                            need++;

                    }
                    l++;
                }
                r++;
            }

        return s.Substring(minL,minWindowSize);

    }
        public static int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = (right + left) / 2;

            while (left <= right)
            {
                mid = (right + left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        public static int PrefixCount(string[] words, string pref) {
            Trie root = new Trie();
            int result = 0;
            foreach(string word in words) {
                InsertWordInTrie(root, word);
            }
            result = SearchPrefix(root, pref);
            return result;
        }

        public static void InsertWordInTrie(Trie root, string word) {
            Trie curr;
            curr = root;
            foreach (char ch in word) {
                if(curr.Child[ch - 'a'] == null) {
                    curr.Child[ch - 'a'] = new Trie();
                }
                curr = curr.Child[ch - 'a'];
                curr.Count++;
            }
            curr.WordEnd = true;
        }

        public static int SearchPrefix(Trie root, string pref) {
            Trie curr;
            curr = root;
            foreach(char ch in pref) {
                if(curr.Child[ch - 'a'] == null) {
                    return 0;
                }
                curr = curr.Child[ch - 'a'];
            }
            return curr.Count;
        }

        static IList<IList<int>> ThreeSum(int[] nums)
        {

            IList<IList<int>> result = new List<IList<int>>();                                              // List to store the result
            int  left, right;                                                                               // Pointers to find the other two elements
            Array.Sort(nums);                                                                               // Sort the array

            for(int i=0; i< nums.Length; i++) {                                                             // Iterate through the array
                if(i > 0 && nums[i] == nums[i-1])                                                           // Skip the duplicate elements. num1
                    continue;
                left = i+1;                                                                                 // Initialize the left pointer
                right = nums.Length - 1;                                                                    // Initialize the right pointer

                while(left< right) {                                                                        // Iterate through the array
                    if( (nums[i] + nums[left] + nums[right]) > 0) {                                         // If the sum of the three elements is greater than 0, decrement the right pointer
                        right--;
                    }
                    else if( (nums[i] + nums[left] + nums[right]) < 0) {                                    // If the sum of the three elements is less than 0, increment the left pointer
                        left++;
                    }
                    else {                                                                                  // If the sum of the three elements is equal to 0, add the elements to the result
                        result.Add(new List<int>{nums[i],nums[left],nums[right]});
                        left++;                                                                             // Increment the left pointer

                        while(nums[left] == nums[left-1] && left < right) {                                 // Skip the duplicate elements. left num. No need to skip right num as it will be decremented next iteration
                            left++;
                        }
                    }
                }
            }

            return result;
        }

        static string LargestOddNumber(string num)
        {

            int index = num.Length - 1;
            int removals = 0;
            while (index >= 0)
            {
                if ((num[index] - '0') % 2 == 0 || (num[index] - '0' == 0))
                {
                    removals++;
                    index--;
                }
                else
                {
                    break;
                }
            }
            return num.Substring(0, num.Length - removals);
        }

        static int CountCharacters(string[] words, string chars)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            Dictionary<char, int> temp = new Dictionary<char, int>();
            int result = 0;
            foreach (char ch in chars)
            {
                if (!dict.ContainsKey(ch))
                {
                    dict[ch] = 1;
                }
                else
                {
                    dict[ch] = dict[ch] + 1;
                }
            }

            foreach (string word in words)
            {

                foreach (char ch in word)
                {
                    if (!temp.ContainsKey(ch))
                    {
                        temp[ch] = 1;
                    }
                    else
                    {
                        temp[ch] = temp[ch] + 1;
                    }
                }

                int index = 0;
                foreach (var kv in temp)
                {
                    if (dict.ContainsKey(kv.Key) && dict[kv.Key] >= temp[kv.Key])
                    {
                        index++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (index == temp.Count())
                    result = result + temp.Count();
                temp.Clear();
            }
            return result;

        }

        static bool IsValidSudoku(char[][] board)
        {
            return CheckRows(board) && CheckColumns(board) && CheckBoxes(board);
        }

        static bool CheckBoxes(char[][] board)
        {
            int startRow = 0;
            int startColumn = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bool isCompliant = CheckBox(board, startRow, startColumn);
                    if (!isCompliant) return false;
                    startColumn = startColumn + 3;
                }
                startColumn = 0;
                startRow = startRow + 3;
            }
            return true;
        }

        static bool CheckBox(char[][] board, int startRow, int startColumn)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startColumn; j < startColumn + 3; j++)
                {
                    if (board[i][j] == '.') continue;

                    if (set.Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        set.Add(board[i][j]);
                    }
                }
            }
            return true;
        }

        static bool CheckColumns(char[][] board)
        {
            HashSet<char> set = new HashSet<char>();

            for (int column = 0; column < board.Length; column++)
            {
                for (int row = 0; row < board[column].Length; row++)
                {
                    if (board[row][column] == '.') continue;

                    if (set.Contains(board[row][column]))
                    {
                        return false;
                    }
                    else
                    {
                        set.Add(board[row][column]);
                    }
                }
                set.Clear();
            }
            return true;
        }

        static bool CheckRows(char[][] board)
        {
            HashSet<char> set = new HashSet<char>();
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    if (board[row][column] == '.') continue;

                    if (set.Contains(board[row][column]))
                    {
                        return false;
                    }
                    else
                    {
                        set.Add(board[row][column]);
                    }
                }
                set.Clear();
            }
            return true;
        }

        static int SpecialArray(int[] nums)
        {

            int index = 0;
            int[] count = new int[nums.Length];

            while (index < nums.Length)
            {

                count[nums[index]] = count[nums[index]] + 1;
                index++;
                Console.WriteLine(count);
            }

            Console.WriteLine(count);
            return -1;
        }

        static int MaxLengthBetweenEqualCharacters(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int index, result;
            index = 0;
            result = -1;

            while (index < s.Length)
            {

                if (!dict.ContainsKey(s[index]))
                {
                    dict[s[index]] = index;
                }
                else
                {
                    result = Math.Max(index - dict[s[index]] - 1, result);
                }
                index++;
            }
            return result;
        }

        static bool MakeEqual(string[] words)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (string word in words)
            {

                foreach (char ch in word)
                {

                    if (dict.ContainsKey(ch))
                    {
                        dict[ch] = dict[ch] + 1;
                    }
                    else
                    {
                        dict.Add(ch, 1);
                    }
                }
            }

            foreach (var kv in dict)
            {
                if (kv.Value % words.Length != 0)
                    return false;
            }

            return true;

        }
        static int MinOperations(string s)
        {

            char nextExpectedChar = '1';
            char currentChar = '\0';
            int index = 1;
            int result = 0;

            if (s[0] != '0')
            {
                nextExpectedChar = '0';
            }

            while (index < s.Length)
            {

                currentChar = s[index];

                if (currentChar != nextExpectedChar)
                {
                    result++;
                    currentChar = nextExpectedChar;
                }

                nextExpectedChar = currentChar == '0' ? '1' : '0';
                index++;
            }

            // As alternative string can start from 0 or 1, we will take minimum of two strings
            // if result is for 0. s.Length - result will be for 1.
            return Math.Min(s.Length - result, result);

        }
        static bool IsPathCrossing(string path)
        {
            HashSet<(int, int)> set = new HashSet<(int, int)>();
            int x, y;
            x = y = 0;
            set.Add((0, 0));

            foreach (char c in path)
            {
                switch (c)
                {

                    case 'N':
                        y = y + 1;
                        break;
                    case 'E':
                        x = x + 1;
                        break;
                    case 'S':
                        y = y - 1;
                        break;
                    case 'W':
                        x = x - 1;
                        break;
                }

                if (set.Contains((x, y)))
                    return true;
                set.Add((x, y));

            }

            return false;
        }
        static int MaxScore(string s)
        {

            int currentIndex, numOfZerosInLeftPart, numOfOnesInRightPart, score, maxScore;
            currentIndex = numOfZerosInLeftPart = numOfOnesInRightPart = score = maxScore = 0;

            while (currentIndex < s.Length)
            {

                if (s[currentIndex] == '1') numOfOnesInRightPart++;
                currentIndex++;

            }

            currentIndex = 0;

            while (currentIndex < s.Length - 1)
            {

                if (s[currentIndex] == '0')
                {
                    numOfZerosInLeftPart++;
                }
                else
                {
                    numOfOnesInRightPart--;
                }

                score = numOfZerosInLeftPart + numOfOnesInRightPart;
                if (score > maxScore) maxScore = score;
                currentIndex++;

            }

            return maxScore;

        }
        static int MaxProductDifference(int[] nums)
        {

            int max1, max2, min1, min2, index, currentNumber;
            max1 = max2 = int.MinValue;
            min1 = min2 = int.MaxValue;
            index = 0;

            while (index < nums.Length)
            {

                currentNumber = nums[index];

                if (currentNumber > max2)
                {
                    max2 = currentNumber;
                }

                if (currentNumber > max1)
                {
                    max2 = max1;
                    max1 = currentNumber;
                }

                if (currentNumber < min2)
                {
                    min2 = currentNumber;
                }

                if (currentNumber < min1)
                {
                    min2 = min1;
                    min1 = currentNumber;
                }

                index++;

            }

            return (max1 * max2) - (min1 * min2);
        }
        static bool IsMonotonic(int[] nums)
        {

            return IsIncreasingMonotonic(nums) || IsDecreasingMonotonic(nums);

        }
        static bool IsIncreasingMonotonic(int[] nums)
        {
            int index = 0;
            while (index < nums.Length - 1)
            {
                if (nums[index] > nums[index + 1]) return false;
                index++;
            }

            return true;
        }
        static bool IsDecreasingMonotonic(int[] nums)
        {
            int index = 0;
            while (index < nums.Length - 1)
            {
                if (nums[index] < nums[index + 1]) return false;
                index++;
            }

            return true;
        }
        static List<List<string>> GroupAnagrams(string[] arr)
        {
            return arr.GroupBy(x => new string(x.OrderBy(c => c).ToArray())).Select(x => x.ToList()).ToList();
        }
        static List<List<string>> GroupAnagrams_1(string[] arr)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (var item in arr)
            {
                var key = new string(item.OrderBy(c => c).ToArray());
                if (dict.ContainsKey(key))
                {
                    dict[key].Add(item);
                }
                else
                {
                    dict.Add(key, new List<string>() { item });
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
        static int FindPivot(int[] nums)
        {
            // {1, 7, 3, 6, 5, 6}
            // [1,2,3]
            // [2,1,-1]
            // [0]

            int currentIndex = 0;
            int sumLeft = 0;
            int sumRight = 0;
            int totalSum = nums.Sum();

            while (currentIndex < nums.Length)
            {
                sumRight = totalSum - sumLeft - nums[currentIndex];

                if (sumLeft == sumRight)
                {
                    return currentIndex;
                }
                sumLeft = sumLeft + nums[currentIndex];
                currentIndex++;
            }

            return -1;

        }
        static IList<int> FindDisappearedNumbers(int[] nums)
        {


            // int[] nums = new int[]{4,3,2,7,8,2,3,1};

            int[] check = new int[nums.Length];
            IList<int> result = new List<int>();
            int i = 0;

            while (i < nums.Length)
            {
                check[i] = i + 1;
                i++;
            }

            i = 0;
            while (i < nums.Length)
            {
                check[nums[i] - 1] = -1;
                i++;
            }

            i = 0;
            while (i < check.Length)
            {
                if (check[i] != -1)
                {
                    result.Add(check[i]);
                }
                i++;
            }

            return result;
        }
        static int MaxNumberOfBalloons(string text)
        {
            // text = loonbalxballpoon
            string balloon = "balloon";

            Dictionary<char, int> text_dict = new Dictionary<char, int>();
            Dictionary<char, int> balloon_dict = new Dictionary<char, int>();
            IList<int> count = new List<int>();

            int numOfTextChar = 0;
            int numOfBalloonsChar = 0;

            foreach (char c in balloon)
            {
                if (balloon_dict.ContainsKey(c))
                {
                    balloon_dict[c] = balloon_dict[c] + 1;
                }
                else
                {
                    balloon_dict.Add(c, 1);
                }
            }

            foreach (char c in text)
            {
                if (text_dict.ContainsKey(c))
                {
                    text_dict[c] = text_dict[c] + 1;
                }
                else
                {
                    text_dict.Add(c, 1);
                }
            }

            foreach (var kv in balloon_dict)
            {

                numOfBalloonsChar = kv.Value;

                if (text_dict.ContainsKey(kv.Key))
                {
                    numOfTextChar = text_dict[kv.Key];
                    count.Add(numOfTextChar / numOfBalloonsChar);
                }
                else
                {
                    return 0;
                }

            }

            return count.Min();
        }
        static bool WordPattern(string pattern, string s)
        {

            // Input: pattern = "abba", s = "dog cat cat fish"
            // Input: pattern = "aaaa", s = "dog cat cat dog"
            // Input: pattern = "abba", s = "dog cat cat dog"
            // Input: pattern = "abba", s = "dog dog dog dog"

            Dictionary<string, char> dictWordToPattern = new Dictionary<string, char>();
            Dictionary<char, string> dictPatternToWord = new Dictionary<char, string>();

            var words = s.Split(' ');
            var patternChars = pattern.ToCharArray();

            if (words.Length != patternChars.Length) return false;

            int wordsPointer = 0;
            int patternPointer = 0;

            while (patternPointer < pattern.Length)
            {

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