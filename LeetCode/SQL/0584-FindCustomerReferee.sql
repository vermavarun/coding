-- Solution: 
-- Difficulty: Medium
-- Approach: [To be documented]
-- Tags: Algorithm
-- 1) [Step 1]
-- 2) [Step 2]
-- Time Complexity: O(?)
-- Space Complexity: O(?)
/*
https://leetcode.com/problems/find-customer-referee/solutions/6189169/simplest-solution-sql-please-upvote-by-v-3s7j/

This query retrieves the name of customers from the customer table where the referee_id is either not equal to 2 or is null.

select name from customer: This part specifies that we want to select the name column from the customer table.
where referee_id != 2: This condition filters out customers whose referee_id is 2.
or referee_id is null: This condition includes customers whose referee_id is null.
Combining these conditions with or means that the query will return the names of customers who either do not have a referee_id of 2 or do not have a referee_id at all (i.e., it is null).
*/
select name from customer where referee_id != 2 or referee_id is null