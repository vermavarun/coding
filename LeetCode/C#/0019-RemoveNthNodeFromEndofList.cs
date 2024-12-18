/*
Approach:
1. Create a dummy node and assign it to the head of the list.
2. Create two pointers left and right and assign them to the dummy node.
3. Move the right pointer n times.
4. Move both the pointers until the right pointer reaches the end of the list.
5. The left pointer will be at the node before the node to be deleted.
6. Remove the node by assigning left.next to left.next.next.
7. Return the dummy node's next.

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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode left, right, temp;         // Create two pointers left and right and a temporary node.
        right = head;                       // Assign right to the head of the list.
        temp = new ListNode(-1, head);      // Create a dummy node and assign it to the head of the list.
        left = temp;                        // Assign left to the dummy node.
        while(n > 0) {                      // Move the right pointer n times.
            right = right.next;             // Move the right pointer.
            n--;                            // Decrement n.
        }
        while(right != null) {              // Move both the pointers until the right pointer reaches the end of the list.
            left = left.next;               // Move the left pointer.
            right = right.next;             // Move the right pointer.
        }
        left.next = left.next.next;         // Remove the node by assigning left.next to left.next.next.
        return temp.next;                   // Return the dummy node's next.
    }
}