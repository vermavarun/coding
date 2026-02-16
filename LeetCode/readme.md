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
            <td id="cs">265</td>
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
            <td id="js">18</td>
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

## Line Sweep
<details>
 <summary>Click to expand</summary>

**Line Sweep** is a technique for solving interval and range problems by processing events in sorted order. Commonly used for:
- Meeting rooms / Overlapping intervals
- Skyline problems
- Range coverage
- Activity scheduling

**Key Concepts:**
1. Convert intervals to events (start/end points)
2. Sort events by time (and by type if needed)
3. Process events sequentially, maintaining state
4. Track active intervals using a counter or data structure

**Template (Meeting Rooms II - Min rooms needed):**
```csharp
int MinMeetingRooms(int[][] intervals) {
    List<(int time, int type)> events = new();

    // Create events: +1 for start, -1 for end
    foreach(var interval in intervals) {
        events.Add((interval[0], 1));   // Start event
        events.Add((interval[1], -1));  // End event
    }

    // Sort by time, if tied, process end before start
    events.Sort((a, b) => {
        if(a.time != b.time) return a.time.CompareTo(b.time);
        return a.type.CompareTo(b.type); // -1 before +1
    });

    int activeRooms = 0, maxRooms = 0;
    foreach(var (time, type) in events) {
        activeRooms += type;
        maxRooms = Math.Max(maxRooms, activeRooms);
    }
    return maxRooms;
}
```

**Template (Merge Intervals):**
```csharp
int[][] MergeIntervals(int[][] intervals) {
    if(intervals.Length == 0) return intervals;

    // Sort by start time
    Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

    List<int[]> merged = new();
    int[] current = intervals[0];

    for(int i = 1; i < intervals.Length; i++) {
        if(intervals[i][0] <= current[1]) {
            // Overlapping - merge
            current[1] = Math.Max(current[1], intervals[i][1]);
        } else {
            // Non-overlapping - add previous and start new
            merged.Add(current);
            current = intervals[i];
        }
    }
    merged.Add(current);
    return merged.ToArray();
}
```

**Template (Range Coverage - Min intervals to cover range):**
```csharp
int MinIntervalsToCover(int[][] intervals, int target) {
    Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

    int count = 0, currentEnd = 0, i = 0;

    while(currentEnd < target) {
        int maxReach = currentEnd;

        // Find the interval that extends furthest from current position
        while(i < intervals.Length && intervals[i][0] <= currentEnd) {
            maxReach = Math.Max(maxReach, intervals[i][1]);
            i++;
        }

        if(maxReach == currentEnd) return -1; // Can't extend further

        count++;
        currentEnd = maxReach;
    }
    return count;
}
```

**Common Problems:**
- Meeting Rooms I & II
- Merge Intervals
- Insert Interval
- The Skyline Problem
- My Calendar I/II/III
- Car Pooling
- Minimum Number of Arrows to Burst Balloons
- Non-overlapping Intervals
- Employee Free Time

**Time Complexity:** O(n log n) for sorting + O(n) for processing = **O(n log n)**

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

## Dictionary

<details>
    <summary>Click to expand</summary>

    Dictionary<int, string> dict = new Dictionary<int, string>();
    dict.Add(1, "One");
    dict[2] = "Two";  // Add or update
    dict.Remove(1);
    dict.ContainsKey(1);
    dict.ContainsValue("One");
    dict.TryGetValue(1, out string value);
    dict.Count;
    dict.Clear();

    // Iteration
    foreach(var kvp in dict) {
        int key = kvp.Key;
        string value = kvp.Value;
    }

    // Get or create pattern
    if(!dict.ContainsKey(key)) {
        dict[key] = new List<int>();
    }
    dict[key].Add(value);

    // Or use GetValueOrDefault (C# 6+)
    dict.TryAdd(key, value);  // Adds only if key doesn't exist

</details>

## String

<details>
    <summary>Click to expand</summary>

    // Creation and manipulation
    string s = "Hello";
    s.Length;
    s[0];  // 'H' (indexer)
    s.ToCharArray();  // Convert to char[]
    new string(charArray);  // Create from char[]

    // StringBuilder for efficient concatenation
    StringBuilder sb = new StringBuilder();
    sb.Append("Hello");
    sb.AppendLine("World");
    sb.Insert(0, "Start ");
    sb.Remove(0, 5);
    sb.Replace("old", "new");
    string result = sb.ToString();

    // Common operations
    s.Split('@');
    s.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
    s.Replace(".", "");
    s.Substring(0, 5);  // Extract substring
    s.Contains("ell");
    s.StartsWith("He");
    s.EndsWith("lo");
    s.IndexOf('e');  // Find first occurrence
    s.LastIndexOf('l');  // Find last occurrence
    s.Trim();  // Remove whitespace
    s.ToLower();
    s.ToUpper();
    String.Join(",", array);  // Join array elements

    // Char to Int
    (int)ch - '0';  // '5' -> 5

    // Case conversion
    char lower = 'a';
    char upper = (char)(lower - 32);  // 'A'
    char upper2 = char.ToUpper(lower);

    // Letter to index (0-25)
    'a' -> 0: (int)(ch - 'a')
    'A' -> 0: (int)(ch - 'A')

    // Index to letter
    0 -> 'a': (char)('a' + 0)
    0 -> 'A': (char)('A' + 0)

    // Character checks
    Char.IsDigit(ch);
    Char.IsLetter(ch);
    Char.IsLetterOrDigit(ch);
    Char.IsUpper(ch);
    Char.IsLower(ch);
    Char.IsWhiteSpace(ch);

    // Conversions
    Convert.ToString(n, 2);  // int to binary string
    Convert.ToInt32("1101", 2);  // binary string to int
    int.Parse("123");  // string to int
    int.TryParse("123", out int result);  // Safe parsing

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

## Backtracking

<details>
    <summary>Click to expand</summary>

Technique for finding all (or some) solutions by incrementally building candidates and abandoning them if they fail.

**Template:**
```csharp
void Backtrack(List<List<int>> result, List<int> current, int[] nums, int start) {
    // Base case: solution found
    result.Add(new List<int>(current));  // Make a copy!

    // Try all choices
    for(int i = start; i < nums.Length; i++) {
        // Make choice
        current.Add(nums[i]);

        // Explore with choice
        Backtrack(result, current, nums, i + 1);

        // Undo choice (backtrack)
        current.RemoveAt(current.Count - 1);
    }
}
```

**Common Problems:**
- Subsets / Power Set
- Permutations
- Combinations
- N-Queens
- Sudoku Solver
- Word Search
- Generate Parentheses

</details>

## Dynamic Programming

<details>
    <summary>Click to expand</summary>

Optimization technique using overlapping subproblems and optimal substructure.

**Approaches:**
1. **Top-Down (Memoization)**: Recursion + cache
2. **Bottom-Up (Tabulation)**: Iterative + DP array

**Template (Top-Down):**
```csharp
Dictionary<string, int> memo = new();

int DP(int n) {
    if(n <= 1) return n;  // Base case

    string key = n.ToString();
    if(memo.ContainsKey(key)) return memo[key];

    int result = DP(n - 1) + DP(n - 2);  // Recurrence relation
    memo[key] = result;
    return result;
}
```

**Template (Bottom-Up):**
```csharp
int DP(int n) {
    if(n <= 1) return n;

    int[] dp = new int[n + 1];
    dp[0] = 0;  // Base case
    dp[1] = 1;  // Base case

    for(int i = 2; i <= n; i++) {
        dp[i] = dp[i - 1] + dp[i - 2];  // Recurrence relation
    }
    return dp[n];
}
```

**Common Patterns:**
- Fibonacci / Climbing Stairs: `dp[i] = dp[i-1] + dp[i-2]`
- Coin Change: `dp[i] = min(dp[i], dp[i-coin] + 1)`
- Longest Increasing Subsequence: `dp[i] = max(dp[j] + 1)` where `nums[j] < nums[i]`
- Edit Distance: `dp[i][j] = min(insert, delete, replace)`
- Knapsack: `dp[i][w] = max(include, exclude)`

**Common Problems:**
- Climbing Stairs
- House Robber
- Longest Common Subsequence
- Longest Increasing Subsequence
- Edit Distance
- Coin Change
- Maximum Subarray (Kadane's)
- Partition Equal Subset Sum

</details>

## STEPS TO SOLVE:

<details>
    <summary>Click to expand</summary>

1) **Understand the problem**: Clarify inputs, outputs, edge cases, and constraints.
2) **Choose approach**:
   - Brute Force → Optimize
   - Can it be sorted?
   - Is there a pattern (Two Pointer, Sliding Window, etc.)?
3) **Data Structure Selection**:
   - Counting → Dictionary
   - Membership checking → HashSet
   - Order matters → Stack/Queue
   - Priority/Min-Max → PriorityQueue (Heap)
   - Range queries → Prefix Sum
   - Relationships → Graph/Tree
4) **Algorithm patterns**:
   - Search/Path → BFS/DFS
   - Optimization → DP/Greedy
   - Multiple solutions → Backtracking
   - Sorted data → Binary Search
5) **Write pseudocode** before implementation
6) **Consider edge cases**: Empty input, single element, duplicates
7) **Analyze complexity**: Time and Space
8) **Test with examples**: Include edge cases

**Quick Decision Tree:**
- Array sorted? → Binary Search
- Subarray/Substring? → Sliding Window or Prefix Sum
- All combinations? → Backtracking
- Optimization? → DP or Greedy
- Shortest path? → BFS
- Connected components? → DFS or Union-Find
- Range queries? → Segment Tree or Fenwick Tree
- String matching? → KMP or Rabin-Karp

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

### Knapsack (0/1 and Unbounded)
<details>
    <summary>Click to expand</summary>

A dynamic programming technique to solve optimization problems where items have weights and values.

**0/1 Knapsack:** Each item can be taken once or not at all.
```csharp
int Knapsack(int[] weights, int[] values, int W) {
    int n = weights.Length;
    int[,] dp = new int[n + 1, W + 1];

    for(int i = 1; i <= n; i++) {
        for(int w = 0; w <= W; w++) {
            if(weights[i-1] <= w) {
                dp[i,w] = Math.Max(values[i-1] + dp[i-1, w-weights[i-1]], dp[i-1,w]);
            } else {
                dp[i,w] = dp[i-1,w];
            }
        }
    }
    return dp[n,W];
}
```

**Unbounded Knapsack:** Each item can be taken multiple times.
```csharp
int UnboundedKnapsack(int[] weights, int[] values, int W) {
    int[] dp = new int[W + 1];

    for(int w = 0; w <= W; w++) {
        for(int i = 0; i < weights.Length; i++) {
            if(weights[i] <= w) {
                dp[w] = Math.Max(dp[w], values[i] + dp[w - weights[i]]);
            }
        }
    }
    return dp[W];
}
```

</details>

### Boyer-Moore Voting:
<details>
    <summary>Click to expand</summary>

Used to find the majority element among the given elements that have more than N/2 occurrences. Time: O(n), Space: O(1).

```csharp
int FindMajorityElement(int[] nums) {
    int candidate = 0;
    int count = 0;

    // Find candidate
    foreach(int num in nums) {
        if(count == 0) {
            candidate = num;
        }
        count += (num == candidate) ? 1 : -1;
    }

    // Verify candidate (if not guaranteed to exist)
    count = 0;
    foreach(int num in nums) {
        if(num == candidate) count++;
    }

    return count > nums.Length / 2 ? candidate : -1;
}
```

</details>

### KMP (Knuth-Morris-Pratt) Algorithm:
<details>
    <summary>Click to expand</summary>

String pattern matching algorithm that avoids re-checking previously matched characters. Time: O(n + m), Space: O(m).

```csharp
int[] BuildLPS(string pattern) {
    int[] lps = new int[pattern.Length];
    int len = 0;
    int i = 1;

    while(i < pattern.Length) {
        if(pattern[i] == pattern[len]) {
            len++;
            lps[i] = len;
            i++;
        } else {
            if(len != 0) {
                len = lps[len - 1];
            } else {
                lps[i] = 0;
                i++;
            }
        }
    }
    return lps;
}

int KMPSearch(string text, string pattern) {
    int[] lps = BuildLPS(pattern);
    int i = 0; // index for text
    int j = 0; // index for pattern

    while(i < text.Length) {
        if(pattern[j] == text[i]) {
            i++;
            j++;
        }

        if(j == pattern.Length) {
            return i - j; // Pattern found at index i-j
        } else if(i < text.Length && pattern[j] != text[i]) {
            if(j != 0) {
                j = lps[j - 1];
            } else {
                i++;
            }
        }
    }
    return -1; // Pattern not found
}
```

</details>

### Rabin Karp
<details>
    <summary>Click to expand</summary>

Rolling hash algorithm for pattern matching. Useful for multiple pattern search. Time: O(n + m) average, O(nm) worst case.

```csharp
const int PRIME = 101;
const int BASE = 256;

int RabinKarp(string text, string pattern) {
    int m = pattern.Length;
    int n = text.Length;
    int patternHash = 0;
    int textHash = 0;
    int h = 1;

    // Calculate h = pow(BASE, m-1) % PRIME
    for(int i = 0; i < m - 1; i++) {
        h = (h * BASE) % PRIME;
    }

    // Calculate initial hash values
    for(int i = 0; i < m; i++) {
        patternHash = (BASE * patternHash + pattern[i]) % PRIME;
        textHash = (BASE * textHash + text[i]) % PRIME;
    }

    // Slide the pattern over text
    for(int i = 0; i <= n - m; i++) {
        if(patternHash == textHash) {
            // Check for characters one by one
            bool match = true;
            for(int j = 0; j < m; j++) {
                if(text[i + j] != pattern[j]) {
                    match = false;
                    break;
                }
            }
            if(match) return i;
        }

        // Calculate hash for next window
        if(i < n - m) {
            textHash = (BASE * (textHash - text[i] * h) + text[i + m]) % PRIME;
            if(textHash < 0) textHash += PRIME;
        }
    }
    return -1;
}
```

</details>

### Dijkstra's Algorithm:
<details>
    <summary>Click to expand</summary>

Finds shortest path from a source vertex to all other vertices in a weighted graph with non-negative weights. Time: O((V + E) log V) with priority queue.

```csharp
int[] Dijkstra(List<List<(int node, int weight)>> graph, int source) {
    int n = graph.Count;
    int[] dist = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[source] = 0;

    PriorityQueue<(int node, int dist), int> pq = new();
    pq.Enqueue((source, 0), 0);

    while(pq.Count > 0) {
        var (node, d) = pq.Dequeue();

        if(d > dist[node]) continue;

        foreach(var (neighbor, weight) in graph[node]) {
            int newDist = dist[node] + weight;
            if(newDist < dist[neighbor]) {
                dist[neighbor] = newDist;
                pq.Enqueue((neighbor, newDist), newDist);
            }
        }
    }
    return dist;
}
```

</details>

### Bellman-Ford Algorithm:
<details>
    <summary>Click to expand</summary>

Finds shortest path from source to all vertices. Can handle negative weights and detect negative cycles. Time: O(VE).

```csharp
int[] BellmanFord(int n, List<(int from, int to, int weight)> edges, int source) {
    int[] dist = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[source] = 0;

    // Relax all edges n-1 times
    for(int i = 0; i < n - 1; i++) {
        foreach(var (from, to, weight) in edges) {
            if(dist[from] != int.MaxValue && dist[from] + weight < dist[to]) {
                dist[to] = dist[from] + weight;
            }
        }
    }

    // Check for negative cycles
    foreach(var (from, to, weight) in edges) {
        if(dist[from] != int.MaxValue && dist[from] + weight < dist[to]) {
            throw new Exception("Graph contains negative cycle");
        }
    }

    return dist;
}
```

</details>

### Floyd Warshall Algorithm:
<details>
    <summary>Click to expand</summary>

Finds shortest path between all pairs of vertices in a weighted graph. Can handle negative weights but not negative cycles. Time: O(V³).

Pseudo Code:
```
1) Initialize the distance matrix with the given weights. If there is no edge between two vertices, set the distance to infinity.
2) For each vertex k, for each vertex i, for each vertex j:
    a) If distance[i][j] > distance[i][k] + distance[k][j], then update distance[i][j] = distance[i][k] + distance[k][j].
3) After all iterations, the distance matrix will contain the shortest distances between all pairs of vertices.
```

```csharp
int[,] FloydWarshall(int[,] graph) {
    int n = graph.GetLength(0);
    int[,] dist = (int[,])graph.Clone();

    for(int k = 0; k < n; k++) {
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                if(dist[i,k] != int.MaxValue && dist[k,j] != int.MaxValue) {
                    dist[i,j] = Math.Min(dist[i,j], dist[i,k] + dist[k,j]);
                }
            }
        }
    }
    return dist;
}
```

</details>

### Union Find (Disjoint Set):
<details>
    <summary>Click to expand</summary>

Efficient data structure for tracking disjoint sets and checking connectivity. Time: O(α(n)) ≈ O(1) with path compression and union by rank.

```csharp
class UnionFind {
    private int[] parent;
    private int[] rank;

    public UnionFind(int n) {
        parent = new int[n];
        rank = new int[n];
        for(int i = 0; i < n; i++) {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    public int Find(int x) {
        if(parent[x] != x) {
            parent[x] = Find(parent[x]); // Path compression
        }
        return parent[x];
    }

    public bool Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);

        if(rootX == rootY) return false; // Already in same set

        // Union by rank
        if(rank[rootX] < rank[rootY]) {
            parent[rootX] = rootY;
        } else if(rank[rootX] > rank[rootY]) {
            parent[rootY] = rootX;
        } else {
            parent[rootY] = rootX;
            rank[rootX]++;
        }
        return true;
    }

    public bool Connected(int x, int y) {
        return Find(x) == Find(y);
    }
}
```

</details>

### Trie (Prefix Tree):
<details>
    <summary>Click to expand</summary>

Tree-based data structure for efficient string storage and prefix search. Time: O(m) for insert/search where m is word length.

```csharp
class TrieNode {
    public Dictionary<char, TrieNode> Children = new();
    public bool IsEndOfWord = false;
}

class Trie {
    private TrieNode root = new();

    public void Insert(string word) {
        TrieNode node = root;
        foreach(char c in word) {
            if(!node.Children.ContainsKey(c)) {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        node.IsEndOfWord = true;
    }

    public bool Search(string word) {
        TrieNode node = SearchPrefix(word);
        return node != null && node.IsEndOfWord;
    }

    public bool StartsWith(string prefix) {
        return SearchPrefix(prefix) != null;
    }

    private TrieNode SearchPrefix(string prefix) {
        TrieNode node = root;
        foreach(char c in prefix) {
            if(!node.Children.ContainsKey(c)) return null;
            node = node.Children[c];
        }
        return node;
    }
}
```

</details>

### LRU Cache:
<details>
    <summary>Click to expand</summary>

Cache with Least Recently Used eviction policy. Time: O(1) for get and put operations.

```csharp
class LRUCache {
    private class Node {
        public int Key, Value;
        public Node Prev, Next;
        public Node(int key, int value) {
            Key = key;
            Value = value;
        }
    }

    private Dictionary<int, Node> cache = new();
    private Node head = new(0, 0);
    private Node tail = new(0, 0);
    private int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        head.Next = tail;
        tail.Prev = head;
    }

    public int Get(int key) {
        if(!cache.ContainsKey(key)) return -1;
        Node node = cache[key];
        Remove(node);
        Add(node);
        return node.Value;
    }

    public void Put(int key, int value) {
        if(cache.ContainsKey(key)) {
            Remove(cache[key]);
        }
        Node node = new Node(key, value);
        cache[key] = node;
        Add(node);

        if(cache.Count > capacity) {
            Node lru = head.Next;
            Remove(lru);
            cache.Remove(lru.Key);
        }
    }

    private void Add(Node node) {
        Node prev = tail.Prev;
        prev.Next = node;
        node.Prev = prev;
        node.Next = tail;
        tail.Prev = node;
    }

    private void Remove(Node node) {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
}
```

</details>
<hr/>

# Sorting
<details>
    <summary>Click to expand</summary>

### Comparison Sorts:
- **Merge Sort**: O(n log n) - Stable, divide and conquer
- **Quick Sort**: O(n log n) average, O(n²) worst - In-place, not stable
- **Heap Sort**: O(n log n) - In-place, not stable
- **Insertion Sort**: O(n²) - Good for small/nearly sorted arrays
- **Selection Sort**: O(n²) - Simple but inefficient
- **Bubble Sort**: O(n²) - Simple but inefficient
- **Shell Sort**: O(n log² n) - Improved insertion sort

### Non-Comparison Sorts:
- **Counting Sort**: O(n + k) - Good when range k is small
- **Radix Sort**: O(d * (n + k)) - Sorts integers digit by digit
- **Bucket Sort**: O(n + k) average - Good for uniform distribution

### C# Built-in Sorting:
```csharp
// Array
Array.Sort(arr);  // O(n log n) - IntroSort (QuickSort + HeapSort + InsertionSort)
Array.Sort(arr, (a, b) => b - a);  // Custom comparator (descending)

// List
list.Sort();  // O(n log n)
list.Sort((a, b) => a.CompareTo(b));

// LINQ (creates new collection)
var sorted = arr.OrderBy(x => x).ToArray();
var descending = arr.OrderByDescending(x => x).ToList();
```

### Quick Select (Find Kth element):
```csharp
int QuickSelect(int[] nums, int k) {
    int left = 0, right = nums.Length - 1;
    while(left <= right) {
        int pivot = Partition(nums, left, right);
        if(pivot == k) return nums[k];
        else if(pivot < k) left = pivot + 1;
        else right = pivot - 1;
    }
    return nums[k];
}

int Partition(int[] nums, int left, int right) {
    int pivot = nums[right];
    int i = left;
    for(int j = left; j < right; j++) {
        if(nums[j] <= pivot) {
            Swap(nums, i++, j);
        }
    }
    Swap(nums, i, right);
    return i;
}
```

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
