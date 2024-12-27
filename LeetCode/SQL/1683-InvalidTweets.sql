-- Approach: Select the tweet_id from the table where the length of the content is greater than 15
-- 1. We need to select the tweet_id from the tweets table where the length of the content is greater than 15.
-- 2. We can achieve this by using the select statement to select the tweet_id from the tweets table.
-- 3. We need to filter the tweets based on the length of the content using the where clause.
-- 4. We need to specify the condition where the length of the content is greater than 15.
-- 5. Return the tweet_id.
select tweet_id from tweets where LENGTH(content) > 15