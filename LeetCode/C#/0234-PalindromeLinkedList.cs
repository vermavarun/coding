/*
Solution: 
Difficulty: Easy
Approach:
Tags: Array, Linked List
1. Find the length of the linked list.
2. Find the mid of the linked list.
3. Reverse the linked list from mid.
4. Compare the first half of the linked list with the reversed second half of the linked list.
5. If they are equal, return true. Else, return false.
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
    public bool IsPalindrome(ListNode head) {
        int lengthList, mid, count;                 // lengthList = length of the linked list, mid = mid of the linked list, count = counter variable
        lengthList = count = 0;                     // Initialize lengthList and count to 0

        ListNode i, j;                              // i = head of the linked list, j = head of the linked list
        lengthList = FindLengthOfLinkedList(head);  // Find the length of the linked list

        mid = lengthList/2;                         // Find the mid of the linked list
        i = j = head;                               // Initialize i and j to head of the linked list

        while (count != mid) {                      // Traverse the linked list till mid
            j = j.next;                             // Move j to next node
            count++;                                // Increment count
        }

        j = ReverseLinkedList(j);                   // Reverse the linked list from mid

        while(j != null) {                          // Compare the first half of the linked list with the reversed second half of the linked list
            if(i.val != j.val) {                    // If they are not equal, return false
                return false;                       // Return false
            }
            i = i.next;                             // Move i to next node
            j = j.next;                             // Move j to next node
        }

        return true;                                // Return true
    }

    public static int FindLengthOfLinkedList(ListNode head) {       // Function to find the length of the linked list
        ListNode i = head;                                          // Initialize i to head of the linked list
        int lengthList=0;                                           // Initialize lengthList to 0

        while (i != null) {                                         // Traverse the linked list
            i = i.next;                                             // Move i to next node
            lengthList++;                                           // Increment lengthList
        }

        return lengthList;                                          // Return length of the linked list
    }

    public static ListNode ReverseLinkedList(ListNode head) {       // Function to reverse the linked list
        ListNode curr, prev, temp;                                  // curr = current node, prev = previous node, temp = temporary node
        curr = head;                                                // Initialize curr to head of the linked list
        prev = null;                                                // Initialize prev to null
        while(curr != null) {                                       // Traverse the linked list
            temp = curr.next;                                       // Store the next node in temp
            curr.next = prev;                                       // Reverse the linked list
            prev = curr;                                            // Move prev to curr
            curr = temp;                                            // Move curr to temp
        }
        return prev;                                                // Return the head of the reversed linked list
    }
}