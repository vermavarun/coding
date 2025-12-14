# Adding Difficulty Levels to LeetCode Solutions

## How to Add Difficulty

Add a `Difficulty:` line in the comment block at the top of your solution file, right after the `Solution:` link and before the `Approach:` line.

### Supported Values
- `Easy`
- `Medium`
- `Hard`

## Format Examples

### C#, Java, JavaScript, Go
```csharp
/*
Solution: https://leetcode.com/problems/two-sum/
Difficulty: Easy
Approach: Hash Map for O(n) lookup
Tags: Array, Hash Table
1) Create a hash map to store numbers and their indices.
2) For each number, check if target - number exists in map.
3) If found, return the indices. If not, add current number to map.

Time Complexity: O(n)
Space Complexity: O(n)
*/
```

### Python
```python
"""
Solution: https://leetcode.com/problems/two-sum/
Difficulty: Easy
Approach: Hash Map for O(n) lookup
Tags: Array, Hash Table
1) Create a hash map to store numbers and their indices.
2) For each number, check if target - number exists in map.
3) If found, return the indices. If not, add current number to map.

Time Complexity: O(n)
Space Complexity: O(n)
"""
```

### SQL
```sql
-- Solution: https://leetcode.com/problems/...
-- Difficulty: Medium
-- Approach: Window Function with LAG
-- Tags: SQL, Window Function
-- 1) Use LAG to get previous row value.
-- 2) Calculate difference between current and previous.
-- 3) Filter results based on condition.
--
-- Time Complexity: O(n)
-- Space Complexity: O(1)
```

### Bash
```bash
# Solution: https://leetcode.com/problems/...
# Difficulty: Easy
# Approach: AWK for text processing
# Tags: Bash, Text Processing
# 1) Read input file line by line.
# 2) Process each line with AWK.
# 3) Output formatted result.
#
# Time Complexity: O(n)
# Space Complexity: O(1)
```

## Field Order (Recommended)

1. `Solution:` - LeetCode solution link (optional)
2. **`Difficulty:` - Easy/Medium/Hard** ⭐ **NEW**
3. `Approach:` - Brief description
4. `Tags:` - Comma-separated list
5. Algorithm steps (numbered with `1)`, `2)`, etc.)
6. `Time Complexity:`
7. `Space Complexity:`

## Example: Complete Solution File

```csharp
/*
Solution: https://leetcode.com/problems/search-in-rotated-sorted-array/
Difficulty: Medium
Approach: Modified Binary Search
Tags: Array, Binary Search, Divide and Conquer
1) Use binary search with left and right pointers.
2) Check if mid element equals target, return index if found.
3) Determine which half of the array is sorted (left or right).
4) Check if target lies within the sorted half's range.
5) If target is in sorted half, search that half; otherwise search the other half.
6) Return -1 if target is not found after exhausting search space.

Time Complexity: O(log n)
Space Complexity: O(1)
*/
public class Solution {
    public int Search(int[] nums, int target) {
        // Your code here
    }
}
```

## What Happens

### When You Add Difficulty
1. The script parses the `Difficulty:` line
2. Difficulty badge appears on the solution card (color-coded: Easy=Green, Medium=Orange, Hard=Red)
3. The difficulty filter in the UI will work correctly
4. Solutions can be filtered by Easy/Medium/Hard

### When You Don't Add Difficulty
- The solution gets `difficulty: "Unknown"`
- No difficulty badge is shown
- The solution won't appear when filtering by Easy/Medium/Hard
- Everything else still works normally

## Updating Existing Solutions

To add difficulty to existing solutions:

1. Open the solution file in your editor
2. Add `Difficulty: Easy/Medium/Hard` after the Solution link
3. Save the file
4. Commit and push to GitHub
5. The workflow will automatically regenerate everything with the new difficulty

## Batch Update Script (Optional)

If you want to add difficulty to multiple files at once, you can use this bash script:

```bash
#!/bin/bash
# Update difficulty for specific problem numbers

# Easy problems
sed -i '' 's|^/\*\nSolution:|/*\nSolution:|; s|^\(Solution:.*\)\n\(Approach:\)|\1\nDifficulty: Easy\n\2|' LeetCode/C#/0001-*.cs

# Medium problems
sed -i '' 's|^\(Solution:.*\)\n\(Approach:\)|\1\nDifficulty: Medium\n\2|' LeetCode/C#/0033-*.cs

# Hard problems
sed -i '' 's|^\(Solution:.*\)\n\(Approach:\)|\1\nDifficulty: Hard\n\2|' LeetCode/C#/0041-*.cs
```

**Note:** Be careful with batch updates. It's better to add difficulty manually when you remember the problem's difficulty.

## How to Find Difficulty Levels

If you don't remember a problem's difficulty:
1. Visit LeetCode: `https://leetcode.com/problems/{problem-name}/`
2. The difficulty is shown at the top of the problem description
3. Or check the LeetCode problem list/explore page

## Result

After adding difficulty and pushing to GitHub:
- 🟢 Easy solutions will show a green badge
- 🟠 Medium solutions will show an orange badge
- 🔴 Hard solutions will show a red badge
- ⚪ Unknown solutions will have no difficulty badge

The difficulty filter on your website will now work correctly!
