/*
Solution: 
Difficulty: Easy
Approach:
Tags: Array, Linked List, String
1. We will use three pointers, prev, curr and temp.
2. We will iterate through the linked list and reverse the pointers.
3. We will return the prev pointer as the head of the reversed linked list.
Space Complexity: O(1)

Time Complexity: O(n)
Space Complexity: O(1)
*/

/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
 func reverseList(head *ListNode) *ListNode {
    var curr *ListNode;		// Declare the current node
    var prev *ListNode;		// Declare the previous node
    var temp *ListNode;		// Declare the temporary node

    curr= head				// Initialize the current node
    prev= nil				// Initialize the previous node
    for curr != nil {		// Iterate through the linked list
        temp= curr.Next		// Store the next node
        curr.Next=prev		// Reverse the current node
        prev = curr			// Move the previous node
        curr= temp			// Move the current node
    }
    return prev;			// Return the reversed linked list
}