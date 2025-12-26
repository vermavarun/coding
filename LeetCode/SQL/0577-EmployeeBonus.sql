-- Difficulty: Medium
-- Tags: Algorithm
-- 1) [Step 1]
-- Time Complexity: O(?)
-- Space Complexity: O(?)
-- Approach: Left Join
-- 1. We need to find the employee name and bonus from the employee and bonus tables.
-- 2. We can achieve this by left joining the employee table with the bonus table on empId.
-- 3. We need to select the employee name and bonus where bonus is less than 1000 or bonus is null.
-- 4. Return the employee name and bonus.

select e.name, b.bonus from employee as e
left join bonus as b
on e.empId = b.empId
where b.Bonus < 1000 or b.Bonus is Null