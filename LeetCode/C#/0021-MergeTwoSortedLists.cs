/*
Approach:
1. Create a dummy node and a node to keep track of the current node.
2. Traverse through both the lists and compare the values of the nodes.
3. If the value of the first list is less than the value of the second list, then add the first list node to the current node and move the first list node to the next node.
4. If the value of the first list is greater than the value of the second list, then add the second list node to the current node and move the second list node to the next node.
5. Move the current node to the next node.
6. If the first list is not null, then add the remaining nodes of the first list to the current node.
7. If the second list is not null, then add the remaining nodes of the second list to the current node.
8. Return the next node of the dummy node.

Time Complexity: O(n + m) where n is the number of nodes in the first list and m is the number of nodes in the second list.
Space Complexity: O(1) as we are not using any extra space.

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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode dummy = new ListNode(0);           // Create a dummy node
        ListNode node = dummy;                      // Create a node to keep track of the current node

        while(list1 != null && list2 != null) {     // Traverse through both the lists
            if(list1.val < list2.val) {             // Compare the values of the nodes
                node.next = list1;                  // If the value of the first list is less than the value of the second list, then add the first list node to the current node
                list1 = list1.next;                 // Move the first list node to the next node
            }
            else {
                node.next = list2;                  // If the value of the first list is greater than the value of the second list, then add the second list node to the current node
                list2 = list2.next;                 // Move the second list node to the next node
            }
            node = node.next;                       // Move the current node to the next node
        }
        if(list1 != null) {                         // If the first list is not null, then add the remaining nodes of the first list to the current node
            node.next = list1;                      // Add the remaining nodes of the first list to the current node
        }
        else {                                      // If the second list is not null, then add the remaining nodes of the second list to the current node
            node.next = list2;                      // Add the remaining nodes of the second list to the current node
        }
        return dummy.next;                          // Return the next node of the dummy node
    }
}