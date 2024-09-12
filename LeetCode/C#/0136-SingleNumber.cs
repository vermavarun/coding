// Approach 1
// You hashset to identify if the umber is already there.

// Approach 2
// XOR operation x XOR x will be 0. X XOR y will be 1
// n XOR 0 is n
// so get XOR of all elements in the array and you will get the number.

public class Solution {
    public int SingleNumber(int[] nums) {
        int ans = 0;
        foreach(int num in nums) {
            ans = ans ^ num;
        }
        return ans;
    }
}