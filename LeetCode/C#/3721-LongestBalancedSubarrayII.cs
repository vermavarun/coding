/*
Title: 3721. Longest Balanced Subarray II
Solution: https://leetcode.com/problems/longest-balanced-subarray-ii/solutions/7570663/simplest-solution-c-time-on-long-space-o-hxs0/
Difficulty: Hard
Approach: Segment Tree with Balance Tracking and Lazy Propagation
Tags: Array, Hash Table, Segment Tree, Prefix Sum, Lazy Propagation
1) Build next occurrence map to track when each value reappears.
2) Calculate balance prefix sums (increment for odd, decrement for even distinct values).
3) Use segment tree to efficiently track and update balance ranges.
4) Find rightmost position where balance equals zero (balanced subarray).
5) For each starting position, adjust balance by removing previous element's contribution.
6) Update segment tree range when element no longer affects distinct count.
7) Query for rightmost zero balance and update maximum length.

Time Complexity: O(n log n) where n = nums.length, segment tree operations
Space Complexity: O(n) for segment tree and auxiliary data structures
Tip: The key insight is transforming distinct even/odd counting into a balance tracking problem. By treating distinct evens as -1 and odds as +1, a balanced subarray has sum=0. Using lazy propagation in segment tree allows efficient range updates when an element's contribution ends (at next occurrence). Finding the rightmost zero efficiently determines the longest balanced subarray from each starting position.
Similar Problems: 525. Contiguous Array, 3719. Longest Balanced Subarray I, 1124. Longest Well-Performing Interval, 327. Count of Range Sum
*/


public class SegmentTreeNode
{
    public int MinimumValue;                                        // Minimum value in range
    public int MaximumValue;                                        // Maximum value in range
    public int LazyValue;                                           // Lazy propagation value for delayed updates

    public SegmentTreeNode()                                        // Constructor to initialize node
    {
        MinimumValue = int.MaxValue;                                // Initialize min to maximum possible value
        MaximumValue = int.MinValue;                                // Initialize max to minimum possible value
        LazyValue = 0;                                              // No pending updates initially
    }
}

public class SegmentTree
{
    public SegmentTreeNode[] TreeNodes;                             // Array storing segment tree nodes
    public int ItemCount;                                           // Number of elements in original array

    public SegmentTree(int[] initialValues)                         // Constructor to build segment tree
    {
        ItemCount = initialValues.Length;                           // Store array length
        TreeNodes = new SegmentTreeNode[4 * ItemCount];             // Allocate 4n space for tree nodes
        for (int Index = 0; Index < TreeNodes.Length; Index++)      // Initialize all nodes
            TreeNodes[Index] = new SegmentTreeNode();               // Create new node object

        BuildTree(0, 0, ItemCount - 1, initialValues);              // Build tree recursively from root
    }

    public void BuildTree(int NodeIndex, int RangeStart, int RangeEnd, int[] InitialValues)  // Recursive tree builder
    {
        if (RangeStart == RangeEnd)                                 // Base case: leaf node
        {
            TreeNodes[NodeIndex].MinimumValue = TreeNodes[NodeIndex].MaximumValue = InitialValues[RangeStart];  // Set min and max to element value
            return;
        }

        int MiddleIndex = (RangeStart + RangeEnd) / 2;              // Calculate midpoint of range
        BuildTree(2 * NodeIndex + 1, RangeStart, MiddleIndex, InitialValues);      // Build left subtree
        BuildTree(2 * NodeIndex + 2, MiddleIndex + 1, RangeEnd, InitialValues);    // Build right subtree

        TreeNodes[NodeIndex].MinimumValue = Math.Min(TreeNodes[2 * NodeIndex + 1].MinimumValue, TreeNodes[2 * NodeIndex + 2].MinimumValue);  // Parent min is min of children
        TreeNodes[NodeIndex].MaximumValue = Math.Max(TreeNodes[2 * NodeIndex + 1].MaximumValue, TreeNodes[2 * NodeIndex + 2].MaximumValue);  // Parent max is max of children
    }

    public void PushDown(int NodeIndex, int RangeStart, int RangeEnd)  // Apply lazy updates to node
    {
        if (TreeNodes[NodeIndex].LazyValue == 0) return;            // No pending update, return

        TreeNodes[NodeIndex].MinimumValue += TreeNodes[NodeIndex].LazyValue;  // Apply lazy value to minimum
        TreeNodes[NodeIndex].MaximumValue += TreeNodes[NodeIndex].LazyValue;  // Apply lazy value to maximum

        if (RangeStart != RangeEnd)                                 // If not a leaf node
        {
            TreeNodes[2 * NodeIndex + 1].LazyValue += TreeNodes[NodeIndex].LazyValue;  // Propagate to left child
            TreeNodes[2 * NodeIndex + 2].LazyValue += TreeNodes[NodeIndex].LazyValue;  // Propagate to right child
        }

        TreeNodes[NodeIndex].LazyValue = 0;                         // Clear lazy value after applying
    }

    public void UpdateRange(int UpdateStart, int UpdateEnd, int NodeIndex, int RangeStart, int RangeEnd, int AdjustmentValue)  // Update range [UpdateStart, UpdateEnd]
    {
        PushDown(NodeIndex, RangeStart, RangeEnd);                  // Apply any pending lazy updates

        if (RangeStart > UpdateEnd || RangeEnd < UpdateStart || RangeStart > RangeEnd)  // No overlap with update range
            return;                                                 // Nothing to update

        if (RangeStart >= UpdateStart && RangeEnd <= UpdateEnd)     // Current range completely within update range
        {
            TreeNodes[NodeIndex].LazyValue += AdjustmentValue;      // Add adjustment to lazy value
            PushDown(NodeIndex, RangeStart, RangeEnd);              // Apply immediately
            return;
        }

        int MiddleIndex = (RangeStart + RangeEnd) / 2;              // Calculate midpoint
        UpdateRange(UpdateStart, UpdateEnd, 2 * NodeIndex + 1, RangeStart, MiddleIndex, AdjustmentValue);      // Update left subtree
        UpdateRange(UpdateStart, UpdateEnd, 2 * NodeIndex + 2, MiddleIndex + 1, RangeEnd, AdjustmentValue);    // Update right subtree

        TreeNodes[NodeIndex].MinimumValue = Math.Min(TreeNodes[2 * NodeIndex + 1].MinimumValue, TreeNodes[2 * NodeIndex + 2].MinimumValue);  // Recalculate parent min
        TreeNodes[NodeIndex].MaximumValue = Math.Max(TreeNodes[2 * NodeIndex + 1].MaximumValue, TreeNodes[2 * NodeIndex + 2].MaximumValue);  // Recalculate parent max
    }

    public int FindRightMostZero(int NodeIndex, int RangeStart, int RangeEnd)  // Find rightmost index where value is 0
    {
        PushDown(NodeIndex, RangeStart, RangeEnd);                  // Apply pending updates
        int CurrentMinimum = TreeNodes[NodeIndex].MinimumValue;     // Get minimum in current range
        int CurrentMaximum = TreeNodes[NodeIndex].MaximumValue;     // Get maximum in current range

        if (CurrentMinimum > 0 || CurrentMaximum < 0)               // Range doesn't contain 0
            return -1;                                              // No zero found

        if (RangeStart == RangeEnd)                                 // Leaf node contains zero
            return RangeStart;                                      // Return this index

        int MiddleIndex = (RangeStart + RangeEnd) / 2;              // Calculate midpoint
        int RightResult = FindRightMostZero(2 * NodeIndex + 2, MiddleIndex + 1, RangeEnd);  // Check right subtree first
        if (RightResult != -1)                                      // Found zero in right subtree
            return RightResult;                                     // Return rightmost from right

        return FindRightMostZero(2 * NodeIndex + 1, RangeStart, MiddleIndex);  // Check left subtree
    }
}

public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int ArrayLength = nums.Length;                              // Store input array length
        Dictionary<int, int> ValueToIndexMap = new Dictionary<int, int>();  // Map value to its last occurrence index
        int[] NextOccurrenceIndices = new int[ArrayLength];         // Array to store next occurrence of each element

        for (int Index = 0; Index < ArrayLength; Index++)           // Initialize all next occurrences to array length
            NextOccurrenceIndices[Index] = ArrayLength;             // Default: no next occurrence

        for (int Index = ArrayLength - 1; Index >= 0; Index--)      // Traverse array backwards
        {
            if (ValueToIndexMap.ContainsKey(nums[Index]))           // If value seen before (to the right)
                NextOccurrenceIndices[Index] = ValueToIndexMap[nums[Index]];  // Store next occurrence index

            ValueToIndexMap[nums[Index]] = Index;                   // Update last seen index for this value
        }

        int[] BalancePrefixSums = new int[ArrayLength];             // Store balance values (even=-1, odd=+1)
        HashSet<int> EncounteredValues = new HashSet<int>();        // Track distinct values seen so far

        for (int Index = 0; Index < ArrayLength; Index++)           // Calculate balance prefix sums
        {
            if (Index > 0)                                          // Copy previous balance
                BalancePrefixSums[Index] = BalancePrefixSums[Index - 1];  // Carry forward balance

            if (EncounteredValues.Contains(nums[Index]))            // If value already encountered
                continue;                                           // Don't change balance (not distinct)

            if (nums[Index] % 2 == 0)                               // If even number
                BalancePrefixSums[Index]--;                         // Decrement balance
            else                                                    // If odd number
                BalancePrefixSums[Index]++;                         // Increment balance

            EncounteredValues.Add(nums[Index]);                     // Mark value as encountered
        }

        SegmentTree BalanceTree = new SegmentTree(BalancePrefixSums);  // Build segment tree from balance array
        int MaxBalancedLength = BalanceTree.FindRightMostZero(0, 0, ArrayLength - 1) + 1;  // Find initial longest balanced subarray

        for (int Index = 1; Index < ArrayLength; Index++)           // Try each starting position
        {
            int UpdateEndRange = NextOccurrenceIndices[Index - 1] - 1;  // Range where previous element affects distinct count
            int AdjustmentValue = ((nums[Index - 1] % 2 == 0) ? 1 : -1);  // Adjustment when removing element (opposite of original)

            BalanceTree.UpdateRange(Index, UpdateEndRange, 0, 0, ArrayLength - 1, AdjustmentValue);  // Update range where element no longer counts
            int RightMostZeroIndex = BalanceTree.FindRightMostZero(0, 0, ArrayLength - 1);  // Find rightmost zero balance

            if (RightMostZeroIndex != -1)                           // If balanced subarray found
                MaxBalancedLength = Math.Max(MaxBalancedLength, RightMostZeroIndex - Index + 1);  // Update maximum length
        }

        return MaxBalancedLength;                                   // Return longest balanced subarray length
    }
}
