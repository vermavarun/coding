/*
Title: 690. Employee Importance
Solution: https://leetcode.com/problems/employee-importance/solutions/7474900/simplest-solution-c-time-on-spacen-pleas-2g0i/
Difficulty: Medium
Approach: DFS with Hash Map for Employee Lookup
Tags: Hash Table, Depth-First Search, Breadth-First Search
1) Build a hash map to store employee id -> Employee object mapping for O(1) lookup.
2) Use DFS to traverse the employee hierarchy starting from the given employee id.
3) For each employee, add their importance value to the total.
4) Recursively process all subordinates and sum their importance values.
5) Return the total importance value.

Time Complexity: O(n) where n = number of employees
Space Complexity: O(n) for the hash map and recursion stack
*/
/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

class Solution {
    public int GetImportance(IList<Employee> employees, int id) {

        // Step 1: Build lookup map
        Dictionary<int, Employee> map = new Dictionary<int, Employee>();    // Create hash map for O(1) employee lookup by id
        foreach (var emp in employees) {                                    // Iterate through all employees
            map[emp.id] = emp;                                              // Store employee object with id as key
        }

        // Step 2: DFS
        return DFS(id, map);                                                // Start DFS from target employee and return total importance
    }

    private int DFS(int id, Dictionary<int, Employee> map) {
        Employee emp = map[id];                                             // Get employee object using id from hash map

        int total = emp.importance;                                         // Initialize total with current employee's importance
        foreach (int subId in emp.subordinates) {                           // Iterate through all subordinates
            total += DFS(subId, map);                                       // Recursively add subordinate's total importance (DFS)
        }

        return total;                                                       // Return total importance of employee and all subordinates
    }
}
