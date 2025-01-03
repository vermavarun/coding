/*
Approach:
1. Create a bag array of size words.Length.
2. Create a HashSet of vowels.
3. Iterate through the words array and check if the first and last character of the word is a vowel.
4. If it is a vowel, increment the currentSum by 1 and store it in the bag array.
5. If it is not a vowel, store the currentSum in the bag array.
6. Iterate through the queries array and calculate the number of vowel strings between the given range.
7. Return the result array.

Time Complexity: O(n + m) where n is the length of the words array and m is the length of the queries array.
Space Complexity: O(n) where n is the length of the words array.
*/
public class Solution {
    public int[] VowelStrings(string[] words, int[][] queries) {
        int[] bag = new int[words.Length];                                      // bag array to store the number of vowel strings
        int index = 0;                                                          // index to iterate through the bag array
        int currentSum = 0;                                                     // currentSum to store the number of vowel strings
        int[] result = new int[queries.Length];                                 // result array to store the number of vowel strings between the given range
        HashSet<int> hs = new HashSet<int>();                                   // HashSet to store the vowels
        hs.Add('a');                                                            // Add vowels to the HashSet
        hs.Add('e');                                                            // Add vowels to the HashSet
        hs.Add('i');                                                            // Add vowels to the HashSet
        hs.Add('o');                                                            // Add vowels to the HashSet
        hs.Add('u');                                                            // Add vowels to the HashSet

        foreach(string word in words) {                                         // Iterate through the words array
            if (IfVowelString(word,hs)) {                                       // Check if the first and last character of the word is a vowel
                bag[index] = currentSum + 1;                                    // Increment the currentSum by 1 and store it in the bag array
                currentSum = bag[index];                                        // Update the currentSum
            }
            else {
                bag[index] = currentSum;                                        // Store the currentSum in the bag array
            }

            index++;                                                            // Increment the index
        }

        index=0;                                                                // Reset the index

        foreach(var arr in queries) {                                           // Iterate through the queries array
            int numStart = arr[0];                                              // Get the start index of the range
            int numEnd = arr[1];                                                // Get the end index of the range
            if(numStart > 0) {                                                  // Check if the start index is greater than 0
                result[index] = bag[numEnd] - bag[numStart - 1];                // Calculate the number of vowel strings between the given range
            }
            else {
                result[index] = bag[numEnd];                                    // Calculate the number of vowel strings between the given range
            }
            index++;                                                            // Increment the index
        }
        return result;                                                          // Return the result array
    }

    public bool IfVowelString(string word, HashSet<int> hs) {                   // Function to check if the first and last character of the word is a vowel
        bool result = false;                                                    // Initialize the result to false
        char firstChar = word[0];                                               // Get the first character of the word
        char lastChar = word[word.Length - 1];                                  // Get the last character of the word
        if(hs.Contains(firstChar) && hs.Contains(lastChar)) {                   // Check if the first and last character of the word is a vowel
            result = true;                                                      // Update the result
        }
        return result;                                                          // Return the result
    }
}