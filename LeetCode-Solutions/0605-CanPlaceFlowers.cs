// Problem: Can Place Flowers
// Source: https://leetcode.com/problems/can-place-flowers/
// Approach 1: Greedy
// Time complexity : O(n). We traverse the entire flowerbed once.
// Space complexity : O(1). Constant extra space is used.
// If the current position is empty, and the next position is empty, and the previous position is empty, then we can plant a flower at the current position.

public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int numberOfPlantedFlowers = 0;
        if(flowerbed.Length == 1 && flowerbed[0]==0) return true;
        for(int i=0; i<flowerbed.Length; i++) {
            if(i == 0) //[0,0,1]
            {
                if (flowerbed[i]==0 && flowerbed[i+1]==0)
                {
                    numberOfPlantedFlowers++;
                    flower  bed[i]=1;
                    Console.WriteLine(i);
                }
            }
            else if(i == flowerbed.Length-1) //[1,0,0]
            {
               if (flowerbed[i]==0 && flowerbed[i-1]==0)
                {
                    numberOfPlantedFlowers++;
                    flowerbed[i]=1;
                    Console.WriteLine(i);
                }
            }
            else
            {
                 if (flowerbed[i]==0 && flowerbed[i-1]==0 && flowerbed[i+1]==0) // [0,0,0]
                {
                    numberOfPlantedFlowers++;
                    flowerbed[i]=1;
                    Console.WriteLine(i);
                }
            }
        }
        return numberOfPlantedFlowers >= n ? true: false;
    }
}