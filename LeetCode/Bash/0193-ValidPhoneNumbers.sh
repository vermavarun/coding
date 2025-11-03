#!/bin/bash
# Solution: Valid Phone Numbers
# Approach: Regular Expression Pattern Matching with grep
# Tags: Bash, Regular Expression, Text Processing
# 1) Use grep to filter lines matching valid phone number patterns.
# 2) Valid formats: "xxx-xxx-xxxx" or "(xxx) xxx-xxxx" where x is a digit.
# 3) Use -e flag for multiple patterns or -E for extended regex.
# 4) ^ ensures pattern starts at beginning, $ ensures it ends at end of line.

# Method 1: Basic regex with -e flag for multiple patterns
grep -e "^[0-9]\{3\}\-[0-9]\{3\}\-[0-9]\{4\}$" -e "^([0-9]\{3\}) [0-9]\{3\}\-[0-9]\{4\}$" file.txt

# Method 2: Extended regex with -E flag (alternation with |)
# grep -E "^([0-9]{3}-[0-9]{3}-[0-9]{4}|\([0-9]{3}\) [0-9]{3}-[0-9]{4})$" file.txt