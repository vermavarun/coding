/*
Solution:
Difficulty: Medium
Approach: Linked List Traversal with Carry
Tags: Linked List, Math, Recursion
1) Initialize carry to 0 and create a dummy head node.
2) Traverse both linked lists simultaneously.
3) At each position, add corresponding digits from both lists plus carry.
4) Create new node with sum % 10 and update carry = sum / 10.
5) Move to next nodes in both lists.
6) Continue until both lists exhausted and carry is 0.
7) Return dummy head's next node.

Time Complexity: O(max(m,n)) where m, n are lengths of the two lists
Space Complexity: O(max(m,n)) for the result list
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
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // corner case

        ListNode head, temp, prev;
        int num1,num2,carry =0,sum;

        head = new ListNode();
        prev =  head;
        while(l1 != null || l2 != null) {

            num1 = l1 != null ? l1.val : 0;
            num2 = l2 != null ? l2.val : 0;

            sum = num1 + num2 + carry;

            if (sum >= 10) {
                sum = sum % 10;
                carry = 1;
            }
            else {
                carry = 0;
            }

            temp = new ListNode();
            temp.val = sum;
            temp.next = null;
            prev.next = temp;
            prev = temp;



            l1 = l1 == null ? l1 : l1.next;
            l2 = l2 == null ? l2 : l2.next;

        }
        if(carry > 0) {
            temp = new ListNode();
            temp.val = 1;
            temp.next = null;
            prev.next = temp;
            prev = temp;
        }
        return head.next;
    }

}
