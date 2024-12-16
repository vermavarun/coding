/*

Approach:
1) Create a dummy node and point it to the head of the linked list.
2) Create two pointers, prev and curr, and point them to the dummy node.
3) Traverse the linked list and check if the value of the current node is equal to the given value.
4) If the value is equal, then point the next of the previous node to the next of the current node.
5) If the value is not equal, then move the previous pointer to the current pointer.
6) Finally, return the next of the dummy node.

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
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode prev, curr, dummy;         // Create three pointers
        curr = head;                        // Point the current pointer to the head of the linked list
        prev = null;                        // Point the previous pointer to null
        dummy = new ListNode(0);            // Create a dummy node and point it to the head of the linked list
        dummy.next = head;                  // Point the next of the dummy node to the head of the linked list
        prev = dummy;                       // Point the previous pointer to the dummy node
        while(curr != null) {               // Traverse the linked list
            if(curr.val == val) {           // Check if the value of the current node is equal to the given value
                prev.next = curr.next;      // Point the next of the previous node to the next of the current node
            }
            else {
                prev = curr;                // Move the previous pointer to the current pointer
            }
            curr = curr.next;               // Move the current pointer to the next node
        }
        return dummy.next;                  // Return the next of the dummy node
    }
}