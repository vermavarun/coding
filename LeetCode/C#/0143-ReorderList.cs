/*
Solution: 
Difficulty: Medium
Approach:
Tags: Array, Linked List
1. Find the middle of the list using slow and fast pointers.
2. Reverse the second half of the list.
3. Merge the two lists.
Space complexity: O(1)

Time Complexity: O(?)
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
    public void ReorderList(ListNode head) {

        // Finding middle of the list
        ListNode slow, fast;                            // slow and fast pointers
        slow = fast = head;                             // both pointers at the start of the list
        while(fast != null && fast.next != null) {      // until fast reaches the end of the list
            slow = slow.next;                           // slow moves one step
            fast = fast.next.next;                      // fast moves two steps
        }

        // Reversing the second half of the list
        ListNode head2 = slow.next;                     // head of the second half
        slow.next = null;                               // breaking the list into two halves
        ListNode curr, prev, temp;                      // pointers for reversing the second half
        curr = head2;                                   // starting from the head of the second half
        prev = null;                                    // previous node of the current node
        while(curr != null) {                           // until the end of the list
            temp = curr.next;                           // storing the next node of the current node
            curr.next = prev;                           // reversing the current node
            prev = curr;                                // updating the previous node
            curr = temp;                                // moving to the next node
        }

        // Merging the two lists
        ListNode list1, list2, temp1, temp2;            // pointers for merging the two lists
        list1 = head;                                   // starting from the head of the first half
        list2 = prev;                                   // starting from the head of the reversed second half

        while(list2 != null) {                          // until the end of the second half
            temp1 = list1.next;                         // storing the next node of the first half
            temp2 = list2.next;                         // storing the next node of the second half
            list1.next = list2;                         // connecting the first half to the second half
            list2.next = temp1;                         // connecting the second half to the first half
            list1 = temp1;                              // moving to the next node of the first half
            list2 = temp2;                              // moving to the next node of the second half
        }
    }
}