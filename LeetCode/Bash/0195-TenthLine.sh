# Difficulty: Easy
#!/bin/bash
# Solution: https://leetcode.com/problems/tenth-line/solutions/7413139/simplest-solution-c-time-on-space1-pleas-p83u/
# Approach: Line Number Filtering with AWK/SED
# Tags: Shell, Text Processing, AWK, SED
# 1) Use AWK to filter lines by number (NR == 10).
# 2) NR is AWK's built-in variable for current line number.
# 3) When NR equals 10, AWK prints that line automatically.
# 4) Alternative: Use sed with -n flag (quiet mode) and 10p (print line 10).
# 5) Both commands read file.txt and output only the tenth line.
#
# Time Complexity: O(n) - reads up to line 10
# Space Complexity: O(1) - constant space

# Read from the file file.txt and output the tenth line to stdout
awk 'NR == 10' file.txt                                             # AWK: Print when line number equals 10
# or
# sed -n '10p' file.txt                                             # SED: Print only the 10th line (quiet mode)