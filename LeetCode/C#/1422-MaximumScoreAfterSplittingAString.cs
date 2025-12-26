/*
Solution: 
Difficulty: Medium
Approach:
Tags: String
1. Count the number of 1's in the right part of the string.
2. Traverse the string from left to right and count the number of 0's in the left part of the string.
3. Calculate the score by adding the number of 0's in the left part and the number of 1's in the right part.
4. Update the maxScore if the current score is greater than the maxScore.
5. Return the maxScore.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/
public class Solution {
    public int MaxScore(string s) {
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
}