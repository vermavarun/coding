/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array
1. We will keep on buying tickets from the first shop till we have enough tickets from the kth shop.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/

public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {

        int index = 0;
        int result = 0 ;
        while (tickets[k] != 0) {
            if (tickets[index] != 0) {
                tickets[index] = tickets[index] - 1;
                result++;
            }
            if(index == tickets.Length - 1)
                index = 0;
            else
                index++;
        }

        return result;
    }
}

/*

Approach:
1. Loop through the tickets array and check if the number of tickets in the current shop is less than the number of tickets in the kth shop.
2. If yes, then buy all the tickets from the current shop.
3. If no, then buy all the tickets from the kth shop.
4. If the current shop is after the kth shop, then buy all the tickets from the kth shop - 1.
5. If the current shop is before the kth shop, then buy all the tickets from the kth shop.
6. Return the total number of tickets bought.

Time Complexity: O(n)
Space Complexity: O(1)

*/

public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {

        int index = 0;
        int result = 0;

        while (index < tickets.Length) {
            if(tickets[index] < tickets[k]) {
                result = result + tickets[index];
            }
            else {
                if(index > k) {
                    result = result + tickets[k] - 1;
                }
                else {
                    result = result + tickets[k];
                }
            }

            index++;
        }

        return result;
    }
}
