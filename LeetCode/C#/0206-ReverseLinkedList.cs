/*

Approach:
1. We will use three pointers, prev, curr and temp.
2. We will iterate through the linked list and reverse the pointers.
3. We will return the prev pointer as the head of the reversed linked list.

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
    public ListNode ReverseList(ListNode head) {

        ListNode prev, curr, temp;  // prev is the previous node, curr is the current node and temp is the temporary node.
        curr = head;                // curr is the head of the linked list.
        prev = null;                // prev is null initially.
        while(curr != null) {       // iterate through the linked list.
            temp = curr.next;       // store the next node in temp.
            curr.next = prev;       // reverse the pointer.
            prev = curr;            // move the prev pointer to the current node.
            curr = temp;            //  move the current pointer to the next node.
        }
        return prev;                //  return the prev pointer as the head of the reversed linked list.
    }
}