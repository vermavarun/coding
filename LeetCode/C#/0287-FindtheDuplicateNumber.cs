/*
Approach: Floyd's Tortoise and Hare (Cycle Detection)
1. Create two pointers slow and fast and assign them to 0.
2. Move the slow pointer by one step and the fast pointer by two steps.
3. If the slow and fast pointers meet, break the loop.
4. Move the slow pointer to 0.
5. Move both the slow and fast pointers by one step until they meet.
6. Return the slow pointer.

Time complexity: O(n)
Space complexity: O(1)

*/
public class Solution {
    public int FindDuplicate(int[] nums) {
        int slow, fast;                     // Create two pointers slow and fast.
        slow = fast = 0;                    // Assign both the pointers to 0.
        while(true) {                       // Move the slow pointer by one step and the fast pointer by two steps.
            slow = nums[slow];              // Move the slow pointer.
            fast = nums[nums[fast]];        // Move the fast pointer.
            if(nums[slow]==nums[fast]) {    // If the slow and fast pointers meet, break the loop.
                break;                      // Break the loop.
            }
        }
        slow = 0;                           // Move the slow pointer to 0.
        while(slow != fast) {               // Move both the slow and fast pointers by one step until they meet.
            slow = nums[slow];              // Move the slow pointer.
            fast = nums[fast];              // Move the fast pointer.
        }
        return slow;                        // Return the slow pointer.
    }
}