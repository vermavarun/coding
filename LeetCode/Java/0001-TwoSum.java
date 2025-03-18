/**
 * Solution: https://leetcode.com/problems/two-sum/solutions/6550757/simplest-solution-java-time-on-spacen-pl-cxpv/
 * Approach: Using HashMap
 * 1. Create a HashMap to store the number and its index.
 * 2. Iterate through the array and check if the target - num is present in the HashMap.
 * 3. If it is present, return the index of the target - num and the current index.
 * 4. If it is not present, add the number and its index to the HashMap.
 * 5. If no such pair is found, return result.
 *
 * Time Complexity: O(n)
 * Space Complexity: O(n)
 */
class Solution {
    public int[] twoSum(int[] nums, int target) {
        HashMap<Integer,Integer> hmap = new HashMap<Integer,Integer>(); // Declare a HashMap
        int index = 0;                                                  // Declare a variable to store the index
        int[] result = new int[2];                                      // Declare a result array to store the indices
        for(int num : nums) {                                           // Iterate through the array
            if(!hmap.containsKey(target-num)) {                         // Check if the target - num is present in the HashMap
                hmap.put(num,index);                                    // If not present, add the number and its index to the HashMap
            }
            else {
                result[0]=hmap.get(target-num);                         // If present, return the index of the target - num
                result[1]= index;                                       // and the current index
                return result;                                          // Return the result
            }
            index++;                                                    // Increment the index
        }                                                               // End of loop
        return result;                                                  // Return the result if no such pair is found
    }
}