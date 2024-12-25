-- https://leetcode.com/problems/recyclable-and-low-fat-products/solutions/6186285/simplest-solution-sql-please-upvote-by-v-ksgl/
-- Query all columns of the products table that have low_fats and recyclable.
-- Return the result table in any order.
select product_id from products where low_fats='y' and recyclable='y'
