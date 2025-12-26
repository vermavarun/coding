/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Hash Table, String
1. Create two dictionaries, one to store the mapping of word to pattern and another to store the mapping of pattern to word.
2. Split the string s into words and convert the pattern into a char array.
3. Iterate through the pattern and for each pattern, check if the word is already mapped to the pattern and if the pattern is already mapped to the word.
4. If the mapping is not present, add the mapping to the dictionaries.
5. If the mapping is present, check if the mapping is correct.
6. If the mapping is not correct, return false.
7. If the loop completes, return true.

Time Complexity: O(?)
Space Complexity: O(?)
*/
public class Solution {
    public bool WordPattern(string pattern, string s) {
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


                wordsPointer++;
                patternPointer++;

            }

            return true;
    }
}