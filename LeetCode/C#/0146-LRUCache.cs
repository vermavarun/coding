/*
Solution: https://leetcode.com/problems/lru-cache/solutions/7432188/simplest-solution-c-time-o1-spacecapacit-0ymk/
Difficulty: Medium
Approach: Hash Table + Doubly Linked List
Tags: Design, Hash Table, Linked List, Doubly-Linked List
1) Use a doubly linked list to maintain order of access (most recent at front).
2) Use a hash table to store key -> node mapping for O(1) lookup.
3) Create dummy head and tail nodes to simplify edge cases.
4) For Get: Return -1 if key doesn't exist, otherwise move node to front and return value.
5) For Put: If key exists, update value and move to front.
6) For Put: If key is new and cache is full, remove LRU node (before tail) from both list and map.
7) For Put: Add new node to front and update map.

Time Complexity: O(1) for both Get and Put operations
Space Complexity: O(capacity) for the hash table and linked list
*/
public class LRUCache
{
    // Doubly linked list node to maintain order
    private class Node
    {
        public int key;                                             // Store key for removal from map
        public int value;                                           // Store value for retrieval
        public Node prev;                                           // Pointer to previous node
        public Node next;                                           // Pointer to next node

        public Node(int k, int v)                                   // Constructor to initialize node
        {
            key = k;
            value = v;
        }
    }

    private int capacity;                                           // Maximum capacity of cache
    private Dictionary<int, Node> map;                              // Hash table for O(1) access
    private Node head;                                              // Dummy head (most recently used side)
    private Node tail;                                              // Dummy tail (least recently used side)

    public LRUCache(int capacity)                                   // Constructor to initialize LRU cache
    {
        this.capacity = capacity;                                   // Set cache capacity
        map = new Dictionary<int, Node>();                          // Initialize hash table

        // Dummy head and tail to simplify edge cases
        head = new Node(0, 0);                                      // Create dummy head node
        tail = new Node(0, 0);                                      // Create dummy tail node
        head.next = tail;                                           // Connect head to tail
        tail.prev = head;                                           // Connect tail to head
    }

    public int Get(int key)                                         // Retrieve value by key
    {
        if (!map.ContainsKey(key))                                  // If key doesn't exist
            return -1;                                              // Return -1

        Node node = map[key];                                       // Get node from map
        Remove(node);                                               // Remove from current position
        AddToFront(node);                                           // Move to front (most recently used)
        return node.value;                                          // Return value
    }

    public void Put(int key, int value)                             // Insert or update key-value pair
    {
        if (map.ContainsKey(key))                                   // If key already exists
        {
            Node node = map[key];                                   // Get existing node
            node.value = value;                                     // Update value
            Remove(node);                                           // Remove from current position
            AddToFront(node);                                       // Move to front (most recently used)
        }
        else                                                        // If key is new
        {
            if (map.Count == capacity)                              // If cache is at full capacity
            {
                // Remove LRU (least recently used)
                Node lru = tail.prev;                               // Get node before tail (LRU)
                Remove(lru);                                        // Remove from linked list
                map.Remove(lru.key);                                // Remove from hash table
            }

            Node newNode = new Node(key, value);                    // Create new node
            map[key] = newNode;                                     // Add to hash table
            AddToFront(newNode);                                    // Add to front of list
        }
    }

    private void Remove(Node node)                                  // Remove node from linked list
    {
        node.prev.next = node.next;                                 // Link previous node to next node
        node.next.prev = node.prev;                                 // Link next node to previous node
    }

    private void AddToFront(Node node)                              // Add node to front (after head)
    {
        node.next = head.next;                                      // Point node's next to current first node
        node.prev = head;                                           // Point node's prev to head
        head.next.prev = node;                                      // Update current first node's prev to new node
        head.next = node;                                           // Update head's next to new node
    }
}
