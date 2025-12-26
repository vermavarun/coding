-- Difficulty: Medium
-- Tags: Database
-- 1) [Step 1]
-- Time Complexity: O(?)
-- Space Complexity: O(?)
-- Approach: Join the two tables on the basis of id
-- 1. We need to join the Employees and EmployeeUNI tables on the basis of the id column.
-- 2. We can achieve this by using the join keyword to join the two tables.
-- 3. We need to specify the columns that we want to select from the tables.
-- 4. We need to specify the condition on which we want to join the tables.
-- 5. Return the unique_id and name columns.

select
eu.unique_id as unique_id, e.name as name
from Employees e
left join EmployeeUNI eu
on e.id = eu.id

-- or

-- SELECT
--   EmployeeUNI.unique_id,
--   Employees.name
-- FROM Employees
-- LEFT JOIN EmployeeUNI
--   USING (id);