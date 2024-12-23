/*
Solution: https://leetcode.com/problems/remove-duplicates-from-sorted-list/solutions/6177565/simplest-solution-c-time-on-space1-pleas-y9vp/
Approach:
1. Traverse the linked list from the head node.
2. If the current node and the next node have the same value, update the next pointer of the current node to the node next to the next node.
3. Repeat the process until the current node is the last node of the linked list.
4. Return the head node.

Time complexity: O(n), where n is the number of nodes in the linked list.
Space complexity: O(1).
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
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode curr = head;                           // Declare the current node to head
        while (curr != null && curr.next != null) {     // Traverse the linked list
            if(curr.val == curr.next.val) {             // If the current node and the next node have the same value
                curr.next = curr.next.next;             // Update the next pointer of the current node to the node next to the next node
            }
            else {
                curr = curr.next;                       // Move to the next node
            }
        }
        return head;                                    // Return the head node
    }
}