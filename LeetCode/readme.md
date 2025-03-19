![LeetCode Stats](https://leetcard.jacoblin.cool/varunve?theme=dark&font=Stylish&border=0&radius=20)


## Binary Search
- condition `while(left <= right)`
- `mid = left + (right - left) / 2`


## Two Pointer
- condition `while(indexS < s.Length && indexT < t.Length) `

## Sliding Window
- condition `while(right < s.Length)`

## Reverse array Iterate
- condition should be && for short circuit like `while (index >= 0 && s[index] != ' ' )`

## Declaration

    Stack
    // Use when there is increasing decreasing order
    Stack<char> pstack = new Stack<char>();

    pstack.Push(c);
    pstack.Count()
    pstack.Peek()

## Bitwise

    XOR -> if both same then 0. If different then 1.

    a ^ 0 = a
    a ^ a = 0
    a ^ b = 1

## PriorityQueue

    // Less value more priority.
    // Min Heap
    PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>(); // where <int,int> means <element,priority>

    // More value more priority.
    // Max Heap
    PriorityQueue<int,int> pq = new PriorityQueue<int,int>(Comparer<int>.Create((x, y) => y - x));

    pq.Enqueue(1, 1);
    pq.Dequeue();
    pq.Peek();

## Queue

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Dequeue();
        queue.Peek();
        queue.Count;  // To check if empty

## LinkedList

        Fast and Slow Pointer
        while(fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }


## HashSet

    HashSet<String> hs = new HashSet<String>();
    hs.Add();
    hs.Remove();
    hs.Count();
    hs.Contains();
    hs.Single(); // To return the only element
    hs1.ExceptWith(hs2); // This method is used to remove all elements in the specified collection from the current HashSet object.
    hs1.UnionWith(hs2) //  This method is used to modify the current HashSet object to contain all elements that are present in itself, the specified collection, or both.
    hs1.IntersectWith(hs2) // This method is used to modify the current HashSet object to contain only elements that are present in that object and in the specified collection.

## String

    Split('@')
    Replace("."."")

    Char to Int
    (int)ch - 0

    Small to Capital
    char a = 'a';
    char bigA = (char) (((int)a - '0') + 16);

    'a' -> 0
    'b' -> 1
    (int)ch - 'a'

    0 -> 'a'
    1 -> 'b'
    (char)('a' + 0)

    Char.IsDigit(ch) // To check if digit




## Stacks

    Stack myStack = new Stack();
    myStack.Push("Hello");
    Peek()
    Pop()
    Count() == 0 // to check if empty

## Arrays:

    int[] age = new int[5];
    age[0] = 12;

    or

    int [] numbers = {1, 2, 3, 4, 5};

    int[,] dp = new int[100001,2];

    Array.Sort(numbers);
    Array.Reverse(numbers);
    Arrays.Fill(dp,-1); // To fill the array with -1

## Trees:
   ### Traversal Techniques:
      1) Inorder - (Left, Root, Right)
      2) Preorder - (Root, Left, Right)
      3) Postorder - (Left, Right, Root)
      4) Level Order - (Level by Level)

## Graphs:
   ### Traversal Techniques:
      1) BFS
         1) Used for shortest path
      2) DFS
         1) For undirected: To detect cycle check if visited node is already visited and is not parent.
         2) For directed: To detect cycle check if visited node is already visited and is in the stack.

## STEPS TO SOLVE:

0) Write Pseudo Code first
1) Try Brute Force
2) Try Sorting
3) Use Stacks
   1) if there is increasing or decreasing order.
4) Use Dictionary
   1) if you want to count.
5) Use HashSet
   1) if you want to check if already present.
6) Trees
   1) In order traversal of BST gives sorted list.


<hr/>

# Algorithms

### Knacksack
TBU

### Boyer-Moore Voting:
Used to Calculate the majority element among the given elements that have more than N/ 2 occurrences.

### KMP
TBU

### Rabin Karp
TBU

<hr/>

### KMP Algorithm:

TBU

<hr/>

# Sorting

- Merge Sort
- Selection Sort
- Quick Sort
- Bubble Sort
- Bucket Sort
- Insertion Sort
- Radix Sort
- Lazy Sort

<hr/>

# Data Structures
- [x] Array
- [x] Linked List
- [x] Stack
- [x] Queue
- Deque
- [x] Priority Queue
- [x] Heap
- [x] Hash Table
- [x] Set
- [x] Map / Dictionary
- [x] Trie
- Graph
- [x] Tree
- [x] Binary Tree
- [x] Binary Search Tree
- AVL Tree
- Red Black Tree
- B Tree
- B+ Tree
- Segment Tree
- Fenwick Tree
- Suffix Tree
- Suffix Array
- Skip List
- Bloom Filter
- LRU Cache
- LFU Cache
- Union Find
- Disjoint Set
- [x] Min Heap
- [x] Max Heap
- Circular Queue
- Doubly Linked List
- Circular Linked List
- Difference Array
- [x] Prefix Sum Array
- Sparse Table
- Cartesian Tree
- Splay Tree
- Interval Tree
- KD Tree
- Quad Tree
- Octree
- Fenwick Tree

<hr/>

# Techniques

- [x] Sliding Window
- [x] Two Pointer
- [x] Fast and Slow Pointer
- [x] Reverse Iterate
- Backtracking
- Divide and Conquer
- [x] Dynamic Programming
- Greedy Algorithm
- [x] Recursion
- Iterative
- Binary Search
- BFS
- [x] DFS
- Bit Manipulation
- Difference Array Technique
- [x] Prefix Sum Technique
- Union Find
- Topological Sort
- Floyd Warshall
- Dijkstra
- Bellman Ford
- A* Algorithm
- Prim's Algorithm
- Kruskal's Algorithm
- Kahn's Algorithm
- Tarjan's Algorithm
- Kosaraju's Algorithm
- Ford Fulkerson Algorithm
- Edmonds Karp Algorithm
- Hopcroft Karp Algorithm
- Dinic's Algorithm
- Hungarian Algorithm
- Gale Shapley Algorithm
- Manacher's Algorithm
- KMP Algorithm
- Rabin Karp Algorithm
- Z Algorithm
- Suffix Array
- Suffix Tree
- Segment Tree
- Fenwick Tree
- AVL Tree
- Red Black Tree
- B Tree
- B+ Tree
- Trie
- Splay Tree
- Skip List
- Bloom Filter
- [x] Min Heap
- [x] Max Heap
- Priority Queue
- LRU Cache
- LFU Cache
- Circular Queue
- Deque
- [x] Stack
- [x] Queue
- [x] Linked List
- Doubly Linked List
- Circular Linked List
- [x] Array
- [x] Matrix
- Graph
- Directed Graph
- Undirected Graph
- Weighted Graph
- Unweighted Graph
- [x] Tree
- [x] Binary Tree
- [x] Binary Search Tree
- Balanced Binary Tree
- Complete Binary Tree
- Full Binary Tree
- Perfect Binary Tree
- N-ary Tree
- Ternary Tree
- Trie Tree
- A* Search
- Morris Traversal

<hr/>

# Appendix
- [LeetCode](https://leetcode.com/)
- [Animated Solutions](https://www.hellointerview.com/learn/code)
- [Constraints]<img width="1272" alt="image" src="https://github.com/user-attachments/assets/3acbf39a-0198-4ac8-977d-436ec3552cd4" />
