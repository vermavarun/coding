-- Difficulty: Medium
-- Tags: Algorithm
-- 1) [Step 1]
-- Time Complexity: O(?)
-- Space Complexity: O(?)
-- Approach: Self Join
-- 1. We need to find the author_id who viewed their own article.
-- 2. We can achieve this by joining the views table with itself on author_id = viewer_id.
-- 3. We need to select the distinct author_id as id from views where author_id = viewer_id.
-- 4. We need to order the result by author_id.
-- 5. Return the id.
select distinct author_id as id from views
    where author_id = viewer_id
    order by author_id