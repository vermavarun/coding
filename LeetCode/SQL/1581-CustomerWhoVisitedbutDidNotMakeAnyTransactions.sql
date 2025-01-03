-- Approach: Left Join
-- 1. We need to join the visits and transactions tables on the basis of the visit_id column.
-- 2. We can achieve this by using the left join keyword to join the two tables.
-- 3. We need to specify the columns that we want to select from the tables.
-- 4. We need to specify the condition on which we want to join the tables.
-- 5. We need to filter out the rows where the transaction_id is null.
-- 6. Group the results by the customer_id column.
-- 7. Return the customer_id and the count of the number of transactions.

select v.customer_id, count(v.customer_id) as count_no_trans
from visits as v
left join transactions as t
on v.visit_id = t.visit_id
where transaction_id is null
group by v.customer_id