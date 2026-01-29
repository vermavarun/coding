<table border="0">
    <tr>
        <td>

![LeetCode Stats](https://leetcard.jacoblin.cool/varunve?theme=dark&font=Stylish&border=0&radius=20)

</td>
<td valign="middle">
<table id="stats">
    <caption><center>LeetCode Statistics</center></caption>
    <thead>
        <tr>
            <th>Language</th>
            <th>Problems Solved</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>C#</td>
            <td id="cs">244</td>
        </tr>
        <tr>
            <td>Go</td>
            <td id="go">2</td>
        </tr>
        <tr>
            <td>Java</td>
            <td id="java">3</td>
        </tr>
        <tr>
            <td>JavaScript</td>
            <td id="js">17</td>
        </tr>
        <tr>
            <td>Python</td>
            <td id="py">20</td>
        </tr>
        <tr>
            <td>SQL</td>
            <td id="sql">10</td>
        </tr>
        <tr>
            <td>Bash</td>
            <td id="sh">2</td>
        </tr>
    </tbody>
</table>
</td>
</tr>
</table>

# Tags

Sliding-Window, Hash-Table

## Binary Search
<details>
 <summary>Click to expand</summary>

- condition `while(left <= right)`
- `mid = left + (right - left) / 2`

</details>

## Two Pointer
<details>
 <summary>Click to expand</summary>

- condition `while(indexS < s.Length && indexT < t.Length) `

</details>

## Sliding Window
<details>
 <summary>Click to expand</summary>

- condition `while(right < s.Length)`

</details>


## Reverse array Iterate
<details>
 <summary>Click to expand</summary>

- condition should be && for short circuit like `while (index >= 0 && s[index] != ' ' )`

</details>

## Intervals
<details>
 <summary>Click to expand</summary>

 - Try if you can sort the intervals first.

</details>


## Bitwise
<details>
    <summary>Click to expand</summary>

    XOR -> if both same then 0. If different then 1.

    a ^ 0 = a
    a ^ a = 0
    a ^ b = 1

</details>

## PriorityQueue

<details>
    <summary>Click to expand</summary>

    // Less value more priority.
    // Min Heap
    PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>(); // where <int,int> means <element,priority>

    // More value more priority.
    // Max Heap
    PriorityQueue<int,int> pq = new PriorityQueue<int,int>(Comparer<int>.Create((x, y) => y - x));

    pq.Enqueue(1, 1);
    pq.Dequeue();
    pq.Peek();

</details>

## Queue

<details>
    <summary>Click to expand</summary>

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Dequeue();
        queue.Peek();
        queue.Count;  // To check if empty

</details>


## LinkedList

<details>
    <summary>Click to expand</summary>

        Fast and Slow Pointer
        while(fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }
</details>

## HashSet

<details>

    <summary>Click to expand</summary>

    HashSet<String> hs = new HashSet<String>();
    hs.Add();
    hs.Remove();
    hs.Count();
    hs.Contains();
    hs.Single(); // To return the only element
    hs1.ExceptWith(hs2); // This method is used to remove all elements in the specified collection from the current HashSet object.
    hs1.UnionWith(hs2) //  This method is used to modify the current HashSet object to contain all elements that are present in itself, the specified collection, or both.
    hs1.IntersectWith(hs2) // This method is used to modify the current HashSet object to contain only elements that are present in that object and in the specified collection.

</details>

## String

<details>
    <summary>Click to expand</summary>

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

    Convert.ToString(n, 2) // To convert int to binary
    Convert.ToInt32("1101", 2) // To convert binary to int

</details>

## Stacks

<details>
    <summary>Click to expand</summary>

    // Use when there is increasing decreasing order
    Stack<char> pstack = new Stack<char>();

    pstack.Push(c);
    pstack.Count()
    pstack.Peek()

    Stack myStack = new Stack();
    myStack.Push("Hello");
    Peek()
    Pop()
    Count() == 0 // to check if empty

</details>

## Arrays:

<details>
    <summary>Click to expand</summary>

    int[] age = new int[5];
    age[0] = 12;

    or

    int [] numbers = {1, 2, 3, 4, 5};

    Array.Sort(numbers);
    Array.Reverse(numbers);
    Arrays.Fill(dp,-1); // To fill the array with -1

    Multi Dimensional Array

    int[,] matrix = new int[2,3];
    matrix[0,0] = 1;
    int[][] matrix = new int[2][] { new int[] {1,2,3}, new int[] {4,5,6} };
    Array.Sort(matrix, (a, b) => a[0] - b[0]); // To sort the matrix based on first element of each row in ascending order.
    Array.Sort(matrix, (a, b) => a[1] - b[1]); // To sort the matrix based on second element of each row in ascending order.
    Array.Sort(matrix, (a, b) => b[0] - a[0]); // To sort the matrix based on first element of each row in descending order.

</details>

## Trees:
<details>
 <summary>Click to expand</summary>

   ### Traversal Techniques:
      1) Inorder - (Left, Root, Right)
      2) Preorder - (Root, Left, Right)
      3) Postorder - (Left, Right, Root)
      4) Level Order - (Level by Level)
</details>

## Graphs:

<details>
 <summary>Click to expand</summary>

   ### Types:
      1) Directed
      2) Undirected
      3) Weighted
      4) Unweighted
   ### Code:
      1) Adjacency List

            List<List<int>> graph = new List<List<int>>();
            for(int i = 0; i < n; i++) {
                graph.Add(new List<int>());
            }
            graph[0].Add(1);

      2) Adjacency Matrix
         1) int[,] graph = new int[n,n];
         2) graph[0,1] = 1;
         3) graph[1,0] = 1;
         4) graph[0,1] = 1;

   ### Traversal Techniques:
      3) BFS
         1) Used for shortest path
      4) DFS
         1) For undirected: To detect cycle check if visited node is already visited and is not parent.
         2) For directed: To detect cycle check if visited node is already visited and is in the stack (current recursion).
   ### Representation:
      5) Adjacency List
      6) Adjacency Matrix
   ### Sorting:
      7)  Topological Sort: Used for Directed Acyclic Graphs (DAG) only. Multiple answers possible.
      8)  Kahn's Algorithm: Used for Directed Acyclic Graphs (DAG) only. Single answer possible. It uses BFS.
      9)  Tarjan's Algorithm: Used for Directed Acyclic Graphs (DAG) only. Single answer possible.
      10) Kosaraju's Algorithm: Used for Directed Acyclic Graphs (DAG) only. Single answer possible.
   ### Miscellaneous:
      11) InDegree: Number of incoming edges to a node.
      12) OutDegree: Number of outgoing edges from a node.
      13) Strongly Connected Components (SCC) - Kosaraju's Algorithm
      14) Articulation Points - Tarjan's Algorithm
      15) Bridges - Tarjan's Algorithm
      16) Bipartite Graph - It means that the graph can be colored using two colors such that no two adjacent nodes have the same color. It can be solved using BFS or DFS.
          1)  if odd cycle is present then it is not bipartite.
          2)  if even cycle is present then it is bipartite.
      17) Eulerian Path - A path that visits every edge exactly once.
      18) Disjoint Set - Used to find if two nodes are connected or not. It is used to find the cycle in the graph.
            1) Union: To merge two sets.
            2) Find: To find the parent of the set.
            3) Path Compression: To reduce the height of the tree.
            4) Union by Rank: To merge the smaller tree to the bigger tree.
            5) It has two operations: Union and Find.
            6) To detect cycle in the graph. If parent of both nodes is same then there is a cycle else union them.


</details>

## STEPS TO SOLVE:

<details>
    <summary>Click to expand</summary>

1) Identity the problem. Clear the doubts.
2) Write Pseudo Code first
3) Try Brute Force
4) Try Sorting
5) Use Stacks
   1) if there is increasing or decreasing order.
6) Use Dictionary
   1) if you want to count.
7) Use HashSet
   1) if you want to check if already present.
8) Trees
   1) In order traversal of BST gives sorted list.

</details>

<hr/>

# Algorithms

### Kahn's Algorithm
<details>
    <summary>Click to expand</summary>

Used to find the topological sort of a Directed Acyclic Graph (DAG). It uses BFS. It is used when there is a single answer possible. It is used when there is a single source.
Pseudo Code:
```
1) Calculate the in-degree of each node.
2) Add all the nodes with in-degree 0 to the queue.
3) While the queue is not empty:
    a) Pop the element from the queue.
    b) Add it to the result.
    c) For all the adjacent nodes of the popped element, reduce the in-degree by 1.
    d) If the in-degree becomes 0, add it to the queue.
4) If the result size is not equal to the number of nodes, then there is a cycle. If you have visited all the nodes, then return the result. if not, that means there is a cycle.
```

</details>

### Knacksack
<details>
    <summary>Click to expand</summary>

TBU

</details>

### Boyer-Moore Voting:
<details>
    <summary>Click to expand</summary>

Used to Calculate the majority element among the given elements that have more than N/ 2 occurrences.

</details>

### KMP
<details>
    <summary>Click to expand</summary>
TBU

</details>

### Rabin Karp
<details>
    <summary>Click to expand</summary>
TBU

</details>


### KMP Algorithm:
<details>
    <summary>Click to expand</summary>
TBU

</details>

<hr/>

# Sorting
<details>
    <summary>Click to expand</summary>

- Merge Sort
- Selection Sort
- Quick Sort
- Bubble Sort
- Bucket Sort
- Insertion Sort
- Radix Sort
- Lazy Sort

</details>

# Data Structures

<details>
    <summary>Click to expand</summary>

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

</details>


# Techniques

<details>
    <summary>Click to expand</summary>

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

</details>


# Appendix
- [LeetCode](https://leetcode.com/)
- [Animated Solutions](https://www.hellointerview.com/learn/code)
- [Constraints]<img width="1272" alt="image" src="https://github.com/user-attachments/assets/3acbf39a-0198-4ac8-977d-436ec3552cd4" />
