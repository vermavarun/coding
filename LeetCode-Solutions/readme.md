## Two Pointer
- condition `while(indexS < s.Length && indexT < t.Length) `


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

    XOR

    a ^ 0 = a
    a ^ a = 0
    a ^ b = 1

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

## Stacks

    Stack myStack = new Stack();
    myStack.Push("Hello");
    Peek()
    Pop()

## Arrays:

    int[] age = new int[5];
    age[0] = 12;

    or

    int [] numbers = {1, 2, 3, 4, 5};


## STEPS TO SOLVE:

1) Try BruteForce
2) Try Sorting
3) Use Stacks if there is increasing or decreasing order.


<hr/>

# Algorithms

### Boyer-Moore Voting Algorithm:

Used to Calculate the majority element among the given elements that have more than N/ 2 occurrences.

<hr/>
