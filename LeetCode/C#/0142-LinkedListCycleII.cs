/*
Approach:
1. We will use Floyd's Tortoise and Hare algorithm to detect the cycle.
2. We will initialize two pointers slow and fast to head.
3. We will iterate through the linked list until fast is not null and fast.next is not null.
4. If cycle is found, we will set cycleFound to true and will set slow to head.
5. If cycle is found, we will iterate through the linked list until slow is not equal to fast.
6. If slow is equal to fast, we will return slow.
7. If cycle is not found, we will return null.

Time Complexity: O(n)
Space Complexity: O(1)

*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        ListNode slow, fast;                        // Declare slow and fast pointers
        slow = fast = head;                         // Initialize slow and fast pointers to head
        bool cycleFound = false;                    // Initialize cycleFound to false
        while(fast != null && fast.next != null) {  // Iterate through the linked list until fast is not null and fast.next is not null
            if(cycleFound && slow == fast) {        // If cycle is found, return slow
                return slow;                        // Return slow
            }
            if(cycleFound) {
                slow = slow.next;                   // Move slow pointer by one step
                fast = fast.next;                   // Move fast pointer by one step
            }
            else {
                slow = slow.next;                   // Move slow pointer by one step
                fast = fast.next.next;              // Move fast pointer by two steps
                if(slow == fast) {                  // If cycle is found, set cycleFound to true and set slow to head
                    cycleFound = true;              // Set cycleFound to true
                    slow = head;                    // Set slow to head
                }

            }
        }
        return null;                                // If cycle is not found, return null
    }
}