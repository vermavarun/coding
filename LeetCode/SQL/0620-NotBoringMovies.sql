-- Difficulty: Medium
-- Tags: Algorithm
-- 1) [Step 1]
-- Time Complexity: O(?)
-- Space Complexity: O(?)
-- Approach: Select the movies which are not boring and have odd id
-- 1. We need to select the id, movie, description, and rating from the cinema table.
-- 2. We need to select the movies which are not boring and have an odd id.
-- 3. We need to order the result by rating in descending order.
-- 4. Return the id, movie, description, and rating.
select id, movie, description, rating
from cinema
where description != 'boring' and id % 2 != 0
order by rating desc;