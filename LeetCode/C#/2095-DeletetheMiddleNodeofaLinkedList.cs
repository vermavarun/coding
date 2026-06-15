    /*
    Title: 2095. Delete the Middle Node of a Linked List
    Solution: https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/solutions/8334721/simplest-solution-c-time-on-space-o1-ple-xar4/
    Difficulty: Medium
    Approach: Slow/Fast Pointers with Dummy Node
    Tags: Linked List, Two Pointers
    1) Create a dummy node pointing to head so slow starts one step before the list.
    2) Use slow/fast pointers both starting from dummy.
    3) Advance slow by one and fast by two each iteration.
    4) When fast can no longer move two steps, slow is just before the middle node.
    5) Skip the middle node by linking slow.next to slow.next.next.

    Time Complexity: O(n) where n = number of nodes
    Space Complexity: O(1) - only a constant number of pointers used
    Tip: The dummy node trick shifts the slow pointer so it stops one node before the middle, making the deletion a simple pointer reassignment without needing a separate "prev" tracking variable.
    Similar Problems: 876. Middle of the Linked List, 2130. Maximum Twin Sum of a Linked List, 19. Remove Nth Node From End of List
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
        public ListNode DeleteMiddle(ListNode head) {
            ListNode dummy = new ListNode(0);           // Dummy node to handle edge cases and simplify deletion
            dummy.next = head;

            ListNode slow = dummy;                      // Slow pointer starts at dummy (one step behind)
            ListNode fast = dummy;                      // Fast pointer starts at dummy

            while (fast.next != null && fast.next.next != null) {  // Advance until fast can't move two steps
                slow = slow.next;
                fast = fast.next.next;
            }
            // slow is now just before the middle node

            slow.next = slow.next.next;                 // Skip the middle node to delete it

            return head;
        }
    }