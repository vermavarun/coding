/*
Approach:
1. Find the length of the list.
2. Find the new head of the list.
3. Break the list at the new head.
4. Connect the end of the list to the original head.
5. Return the new head.

Time complexity: O(n)
Space complexity: O(1)

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
    public ListNode RotateRight(ListNode head, int k) {

        if (head == null || head.next == null || k == 0)            // if list is empty or has only one node or k is zero
            return head;                                            // return null

        // Find Length of the list
        ListNode ptr , prev, newHead;                               // pointers for finding the length of the list
        int lengthList = 0;                                         // length of the list
        ptr = head;                                                 // starting from the head of the list
        prev = null;                                                // previous node of the current node
        while(ptr != null) {                                        // until the end of the list
            prev = ptr;                                             // updating the previous node
            ptr = ptr.next;                                         // moving to the next node
            lengthList++;                                           // updating the length of the list
        }
        k = k % lengthList;                                         // finding the actual value of k
        if (k==0)                                                   // if k is zero
            return head;                                            // return the original list

        int newHeadPosition = lengthList - k - 1;                   // position of the new head
        ptr = head;                                                 // starting from the head of the list
        while(newHeadPosition > 0) {                                // until the new head position
            ptr = ptr.next;                                         // moving to the next node
            newHeadPosition--;                                      // updating the new head position
        }

        newHead = ptr.next;                                         // new head of the list
        ptr.next = null;                                            // breaking the list at the new head
        prev.next = head;                                           // connecting the end of the list to the original head

        return newHead;                                             // return the new head


    }
}