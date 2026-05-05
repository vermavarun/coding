/*
Title: 61. Rotate List
Solution: https://leetcode.com/problems/rotate-list/solutions/8145814/simplest-solution-c-time-on-space-o1-ple-995z/
Difficulty: Medium
Approach: Find length, make circular, break at new tail
Tags: Linked List, Two Pointers
1) Handle edge cases: null head, single node, or k == 0.
2) Traverse the list to find the last node and the total length.
3) Connect the last node back to the head to form a circular list.
4) Compute effective rotation: rotate = k % length.
5) Walk (length - rotate - 1) steps from head to reach the new tail.
6) Set new head to new tail's next, then break the circle by setting new tail's next to null.

Time Complexity: O(n) where n = number of nodes
Space Complexity: O(1) — only pointers used
Tip: The key insight is that rotating right by k is equivalent to moving the last (k % length) nodes to the front. Making the list circular first lets you find the new head without re-traversing.
Similar Problems: 189. Rotate Array, 24. Swap Nodes in Pairs, 25. Reverse Nodes in k-Group
*/
public class Solution {
    public ListNode RotateRight(ListNode head, int k) {

        if (head == null || head.next == null || k == 0)    // Edge case: nothing to rotate
            return head;

        int length = 1;
        ListNode curr = head;

        // find last node + length
        while (curr.next != null) {
            curr = curr.next;                               // Advance to next node
            length++;                                       // Count each node
        }

        ListNode last = curr;                               // last now points to the tail node

        // make circular
        last.next = head;                                   // Connect tail to head to form a cycle

        int rotate = k % length;                            // Effective rotations needed (k may exceed length)
        int stepsToNewTail = length - rotate - 1;           // Steps from head to reach the new tail

        curr = head;
        for (int i = 0; i < stepsToNewTail; i++) {
            curr = curr.next;                               // Walk to the new tail position
        }

        ListNode newHead = curr.next;                       // Node after new tail becomes the new head
        curr.next = null;                                   // Break the circle at the new tail

        return newHead;                                     // Return the new head of the rotated list
    }
}