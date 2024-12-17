/*
Approach 1:
1. We will use HashSet to store the nodes of the first linked list.
2. We will iterate through the first linked list and add the nodes to the HashSet.
3. We will iterate through the second linked list and check if the node is present in the HashSet.
4. If the node is present in the HashSet, we will return the node.
5. If the node is not present in the HashSet, we will move to the next node.
6. If no intersection is found, we will return null.

Time Complexity: O(n + m) where n is the number of nodes in the first linked list and m is the number of nodes in the second linked list.
Space Complexity: O(n) where n is the number of nodes in the first linked list.

*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        HashSet<ListNode> hs = new HashSet<ListNode>(); // Declare HashSet to store list nodes
        ListNode a = headA;                             // Declare a pointer to the head of the first linked list
        ListNode b = headB;                             // Declare a pointer to the head of the second linked list
        while(a!=null)                                  // Iterate through the first linked list and add the nodes to the HashSet
        {
            hs.Add(a);                                  // Add the node to the HashSet
            a = a.next;                                 // Move to the next node
        }
        while(b!= null) {                               // Iterate through the second linked list and check if the node is present in the HashSet
            if(!hs.Contains(b)) {                       // If the node is not present in the HashSet, move to the next node
                b = b.next;                             // Move to the next node
            }
            else {                                      // If the node is present in the HashSet, return the node
                return b;                               // Return the node
            }
        }
        return null;                                    // If no intersection is found, return null
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////

/*
Approach 2 (Efficient):
1. We will use two pointers to traverse the linked lists.
2. We will initialize two pointers a and b to the heads of the linked lists.
3. We will iterate through the linked lists until a is not equal to b.
4. If a is null, we will set a to the head of the second linked list.
5. If b is null, we will set b to the head of the first linked list.
6. If a is not null, we will move a to the next node.
7. If b is not null, we will move b to the next node.
8. If a is equal to b, we will return a.
9. If no intersection is found, we will return null.

Time Complexity: O(n + m) where n is the number of nodes in the first linked list and m is the number of nodes in the second linked list.
Space Complexity: O(1)
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        ListNode a = headA;                     // Declare a pointer to the head of the first linked list
        ListNode b = headB;                     // Declare a pointer to the head of the second linked list

        while(a != b) {                         // Iterate through the linked lists until a is not equal to b
            a = a == null ? headB : a.next;     // If a is null, set a to the head of the second linked list
            b = b == null ? headA : b.next;     // If b is null, set b to the head of the first linked list
        }

        return a;                               // Return the intersection node or null
    }
}