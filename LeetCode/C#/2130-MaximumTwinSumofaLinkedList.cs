/*
Title: 2130. Maximum Twin Sum of a Linked List
Solution: https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/solutions/8333937/simplest-solution-c-time-on-space-o1-ple-lj29/
Difficulty: Medium
Approach: Slow/Fast Pointers + Reverse Second Half
Tags: Linked List, Two Pointers, Stack
1) Use slow/fast pointers to find the middle of the linked list.
2) Reverse the second half of the list starting from the middle.
3) Traverse both halves simultaneously, computing twin sums.
4) Track and return the maximum twin sum found.

Time Complexity: O(n) where n = number of nodes
Space Complexity: O(1) - in-place reversal, no extra data structures
Tip: The key insight is that twin nodes are symmetric - node i pairs with node (n-1-i). By reversing the second half, you can align twins with a two-pointer traversal without needing extra space.
Similar Problems: 206. Reverse Linked List, 234. Palindrome Linked List, 876. Middle of the Linked List
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

    public int PairSum(ListNode head) {
        int ans = 0;
        ListNode slow = head;                                       // Slow pointer moves one step at a time
        ListNode fast = head;                                       // Fast pointer moves two steps at a time

        while (fast != null && fast.next != null) {                 // Advance until fast reaches the end
            slow = slow.next;
            fast = fast.next.next;
        }
        // slow now points to the start of the second half

        ListNode tail = Reverse(slow);                              // Reverse second half in-place

        ListNode curr = head;                                       // Pointer starting from the beginning
        while (tail != null) {                                      // Traverse both halves simultaneously
            ans = Math.Max(ans, curr.val + tail.val);               // Update max twin sum
            curr = curr.next;
            tail = tail.next;
        }

        return ans;
    }


    private ListNode Reverse(ListNode head) {

       ListNode prev, curr, temp;
       curr = head;
       prev = null;

       while (curr != null) {
            temp = curr.next;                                       // Save next node
            curr.next = prev;                                       // Reverse the link
            prev = curr;                                            // Move prev forward
            curr = temp;                                            // Move curr forward
       }
        return prev;                                                // prev is now the new head
    }
}