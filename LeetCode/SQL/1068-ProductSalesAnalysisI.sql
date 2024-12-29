-- Approach: Join the tables on product_id
-- 1. We need to join the sales and product tables on the basis of the product_id column.
-- 2. We can achieve this by using the left join keyword to join the two tables.
-- 3. We need to specify the columns that we want to select from the tables.
-- 4. We need to specify the condition on which we want to join the tables.
-- 5. Return the product_name, year, and price columns.

select p.product_name, s.year, s.price from sales as s
left join product as p
on s.product_id = p.product_id