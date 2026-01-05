# Solution Metadata Format Guide

This guide explains how to format solution files so they are properly parsed by the build scripts.

## Overview

The build scripts (`generate-solutions.js`, `generate-pages.js`, `generate-pages-grouped.js`) automatically scan all solution files in the `LeetCode/` directory and extract metadata from comment blocks at the beginning of each file.

## Comment Block Format by Language

### C#, JavaScript, Java, Go
Use multi-line block comments:
```csharp
/*
Title: 1. Two Sum
Solution: https://leetcode.com/problems/two-sum/
Difficulty: Easy
Approach: Hash Table for O(n) lookup
Tags: Array, Hash Table
1) Create a dictionary to store numbers and their indices.
2) Iterate through the array with index tracking.
3) For each number, check if (target - number) exists in the dictionary.
4) If complement found, return current index and complement's index.
5) If not found, add current number and its index to the dictionary.
6) Continue until pair is found.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the hash table
*/
```

### Python
Use triple-quoted strings (docstrings):
```python
"""
Title: 1. Two Sum
Solution: https://leetcode.com/problems/two-sum/
Difficulty: Easy
Approach: Hash Table for O(n) lookup
Tags: Array, Hash Table
1) Create a dictionary to store numbers and their indices.
2) Iterate through the array with index tracking.
3) For each number, check if (target - number) exists in the dictionary.
4) If complement found, return current index and complement's index.
5) If not found, add current number and its index to the dictionary.
6) Continue until pair is found.

Time Complexity: O(n) where n = nums.length
Space Complexity: O(n) for the hash table
"""
```

You can also use single quotes:
```python
'''
Title: 1. Two Sum
...
'''
```

### SQL
Use line comments (each line starts with `--`):
```sql
-- Title: 175. Combine Two Tables
-- Solution: https://leetcode.com/problems/combine-two-tables/
-- Difficulty: Easy
-- Approach: LEFT JOIN to include all persons
-- Tags: Database, JOIN
-- 1) Use LEFT JOIN to ensure all persons are included.
-- 2) Join Person and Address tables on personId.
-- 3) Select required columns.
--
-- Time Complexity: O(n + m) where n = persons, m = addresses
-- Space Complexity: O(1)
```

### Bash
Use hash comments (each line starts with `#`):
```bash
# Title: 193. Valid Phone Numbers
# Solution: https://leetcode.com/problems/valid-phone-numbers/
# Difficulty: Easy
# Approach: grep with regex pattern matching
# Tags: Bash, Regex
# 1) Use grep to filter lines matching phone number pattern.
# 2) Pattern matches XXX-XXX-XXXX or (XXX) XXX-XXXX format.
#
# Time Complexity: O(n) where n = number of lines
# Space Complexity: O(1)
```

## Metadata Fields

### Required Fields

#### `Title`
**Format**: `Title: <problem-number>. <problem-name>`

**Examples**:
- `Title: 1. Two Sum`
- `Title: 121. Best Time to Buy and Sell Stock`
- `Title: 1234. Replace the Substring for Balanced String`

**Important Notes**:
- Must start with the problem number followed by a period
- The title is extracted and used for:
  - Display in the website
  - Generating page slugs
  - SEO meta tags
  - Problem grouping
- If `Title` is not provided, the script will fall back to parsing the filename

### Recommended Fields

#### `Solution`
**Format**: `Solution: <leetcode-url>`

**Example**: `Solution: https://leetcode.com/problems/two-sum/`

Used to create a "View on LeetCode" link on the solution page.

#### `Difficulty`
**Format**: `Difficulty: <Easy|Medium|Hard>`

**Values**: Must be one of:
- `Easy`
- `Medium`
- `Hard`

Case-insensitive, but will be standardized to title case.

#### `Approach`
**Format**: `Approach: <brief-description>`

**Example**: `Approach: Hash Table for O(n) lookup`

A one-line description of the solution approach. Should be concise and descriptive.

#### `Tags`
**Format**: `Tags: <tag1>, <tag2>, <tag3>, ...`

**Examples**:
- `Tags: Array, Hash Table`
- `Tags: Dynamic Programming, String`
- `Tags: Tree, Depth-First Search, Binary Tree`

**Important Notes**:
- Comma-separated list
- Can include any relevant tags
- Used for filtering and categorization
- Common tags: Array, String, Hash Table, Tree, Graph, Dynamic Programming, etc.

#### Algorithm Steps
**Format**: Numbered list starting with `1)`, `2)`, `3)`, etc.

**Example**:
```
1) Initialize variables for tracking.
2) Iterate through the input array.
3) For each element, perform calculation.
4) Update result based on conditions.
5) Return the final result.
```

**Important Notes**:
- Each step must start with a number followed by `)`
- Steps are displayed as an ordered list on the website
- Should describe the algorithm in clear, sequential steps

#### `Time Complexity`
**Format**: `Time Complexity: <complexity-description>`

**Examples**:
- `Time Complexity: O(n) where n = nums.length`
- `Time Complexity: O(n²) for nested loops`
- `Time Complexity: O(log n) for binary search`

#### `Space Complexity`
**Format**: `Space Complexity: <complexity-description>`

**Examples**:
- `Space Complexity: O(1) - constant space`
- `Space Complexity: O(n) for the hash table`
- `Space Complexity: O(h) where h = height of the tree`

## Complete Examples

### C# Example
```csharp
/*
Title: 66. Plus One
Solution: https://leetcode.com/problems/plus-one/
Difficulty: Easy
Approach: Reverse iteration with carry handling
Tags: Array, Math
1) Start from the rightmost digit (least significant).
2) If digit is not 9, simply increment it and return (no carry needed).
3) If digit is 9, set it to 0 and continue to next position (carry forward).
4) Repeat step 2-3 until either we increment a non-9 digit or reach the start.
5) If all digits were 9, create a new array with length+1, set first digit to 1.
6) Return the result array.

Time Complexity: O(n) where n = digits.length
Space Complexity: O(1) or O(n) only when all digits are 9
*/
public class Solution {
    public int[] PlusOne(int[] digits) {
        // implementation...
    }
}
```

### Python Example
```python
"""
Title: 1. Two Sum
Solution: https://leetcode.com/problems/two-sum/
Difficulty: Easy
Approach: Hash Table for O(n) lookup
Tags: Array, Hash Table
1) Create a dictionary to store numbers and their indices.
2) Iterate through the array with index tracking.
3) For each number, check if (target - number) exists in the dictionary.
4) If complement found, return current index and complement's index.
5) If not found, add current number and its index to the dictionary.
6) Continue until pair is found.

Time Complexity: O(n) where n = len(nums)
Space Complexity: O(n) for the hash table
"""
class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        # implementation...
```

## How the Scripts Use This Data

### 1. `generate-solutions.js`
- Scans all files in `LeetCode/` directory
- Extracts metadata from comment blocks
- Creates `solutions.json` with all solution data
- Groups solutions by problem number
- Generates statistics (total solutions, languages, tags)

### 2. `generate-pages.js`
- Reads `solutions.json`
- Creates individual HTML pages for each solution
- Uses metadata for page title, description, and SEO
- Generates syntax-highlighted code blocks

### 3. `generate-pages-grouped.js`
- Groups solutions by problem number
- Creates one page per problem with tabs for different languages
- Shows all language implementations on a single page

### 4. `generate-sitemap.js`
- Generates `sitemap.xml` for SEO
- Uses problem numbers and titles to create URLs

## Best Practices

1. **Always include Title**: This is the most important field
   ```
   Title: 1. Two Sum
   ```

2. **Keep approach concise**: One line is ideal
   ```
   Approach: Hash Table for O(n) lookup
   ```

3. **Use descriptive tags**: Include all relevant topics
   ```
   Tags: Array, Hash Table, Two Pointers
   ```

4. **Write clear algorithm steps**: Each step should be actionable
   ```
   1) Initialize hash table to store seen numbers.
   2) For each number, check if complement exists.
   3) Return indices when complement is found.
   ```

5. **Specify complexity clearly**: Include variable definitions
   ```
   Time Complexity: O(n) where n = nums.length
   Space Complexity: O(n) for the hash table
   ```

6. **Add inline comments**: Explain the code logic within the implementation
   ```csharp
   Dictionary<int,int> seen = new Dictionary<int,int>();  // Store number -> index mapping
   ```

## Troubleshooting

### Title not appearing correctly
- Ensure `Title:` field exists in the comment block
- Check that format is: `Title: <number>. <name>`
- Verify comment block is at the very beginning of the file

### Tags not showing up
- Make sure tags are comma-separated
- Check that there's no typo in `Tags:`
- Ensure tags line is before numbered steps

### Complexity not displaying
- Verify exact spelling: `Time Complexity:` and `Space Complexity:`
- Check that there's a space after the colon
- Ensure these lines are in the comment block

### Solution link not working
- Format must be: `Solution: <full-url>`
- URL must start with `https://`
- No extra spaces or characters

## Validation

After adding metadata, you can validate it works correctly:

```bash
# Generate solutions.json
node scripts/generate-solutions.js

# Check the generated JSON for your solution
cat docs/solutions.json | grep -A 20 "problemNumber.*: \"<your-problem-number>\""
```

Look for:
- Correct title extraction
- All tags present
- Complexity strings captured
- Steps formatted as array

## Migration Guide

If you have existing solutions without the `Title:` field, add it to the comment block:

**Before:**
```csharp
/*
Solution: https://leetcode.com/problems/two-sum/
Difficulty: Easy
...
*/
```

**After:**
```csharp
/*
Title: 1. Two Sum
Solution: https://leetcode.com/problems/two-sum/
Difficulty: Easy
...
*/
```

The script will still work without `Title:` (falling back to filename parsing), but including it ensures consistent and accurate display across all platforms.
