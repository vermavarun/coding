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

        ListNode head, prev, temp;
        int sumNode = 0;
        bool carry = false;
        head = new ListNode();
        prev = head;
        int num1, num2;


        while (l1 != null || l2 != null)
        {
            num1 = l1 != null ? l1.val : 0;
            num2 = l2 != null ? l2.val : 0;
                        
            if (!carry)
            {
                sumNode = num1 + num2;               
            }
            else
            {
                sumNode = num1 + num2 + 1;
                carry = false;
            }

            if (sumNode >= 10)
            {
                carry = true;
                sumNode = sumNode % 10;
            }
            else if (carry)
            {
                sumNode = sumNode + 1;
                carry = false;
            }
           
            temp = new ListNode();
            temp.val = sumNode;
            temp.next = null;
            prev.next = temp;
            prev = temp;

            l1 = l1 == null ? l1 : l1.next;
            l2 = l2 == null ? l2 : l2.next;           
           
        }
        
         if(carry) {
                temp = new ListNode();
                temp.val = 1;
                temp.next = null;
                prev.next = temp;
                prev = temp;
        }
        return head.next;

    }

}
