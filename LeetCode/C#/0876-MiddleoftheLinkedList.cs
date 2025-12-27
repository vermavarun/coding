/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Linked List
1) Initialize two pointers, slow and fast, and point them to the head of the linked list.
2) Traverse the linked list until the fast pointer reaches the end.
3) Move the slow pointer by one step and the fast pointer by two steps.
4) If the slow and fast pointers meet, then there is a cycle in the linked list.
5) If the fast pointer reaches the end of the linked list, then there is no cycle.
6) Return true if there is a cycle, else return false.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MiddleNode(ListNode head) {
        ListNode fast, slow;                            // Initialize two pointers
        slow = fast = head;                             // Point both the pointers to the head of the linked list
        while(fast != null && fast.next != null) {      // Traverse the linked list until the fast pointer reaches the end
            slow = slow.next;                           // Move the slow pointer by one step
            fast = fast.next.next;                      // Move the fast pointer by two steps
        }
        return slow;                                    // Return the slow pointer
    }
}