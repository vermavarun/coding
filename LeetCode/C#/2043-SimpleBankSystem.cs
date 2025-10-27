/*
Solution: Simple Bank System Implementation
Approach: Object-Oriented Design with Balance Management
Tags: Design, Array, Simulation, OOP
1) Store account balances in a list for easy access and modification.
2) Implement transfer operation with validation for both accounts and sufficient funds.
3) Implement deposit operation with account validation.
4) Implement withdrawal operation with account validation and sufficient funds check.
5) Use helper method to validate account numbers (1-indexed to n).

Time Complexity: O(1) for all operations
Space Complexity: O(n) where n is number of accounts
*/
public class Bank
{
    private readonly List<long> _balances;                      // Store account balances (0-indexed internally)

    public Bank(long[] balance)
    {
        _balances = new List<long>(balance);                    // Initialize balances from input array
    }

    public bool Transfer(int account1, int account2, long money)
    {
        if (IsValidAccount(account1) && IsValidAccount(account2) && _balances[account1 - 1] >= money)  // Validate accounts and sufficient funds
        {
            _balances[account1 - 1] -= money;                   // Deduct money from source account
            _balances[account2 - 1] += money;                   // Add money to destination account
            return true;                                        // Transfer successful
        }

        return false;                                           // Transfer failed due to invalid account or insufficient funds
    }

    public bool Deposit(int account, long money)
    {
        if (IsValidAccount(account))                            // Validate account number
        {
            _balances[account - 1] += money;                    // Add money to account (convert to 0-indexed)
            return true;                                        // Deposit successful
        }

        return false;                                           // Deposit failed due to invalid account
    }

    public bool Withdraw(int account, long money)
    {
        if (IsValidAccount(account) && _balances[account - 1] >= money)  // Validate account and sufficient funds
        {
            _balances[account - 1] -= money;                    // Deduct money from account (convert to 0-indexed)
            return true;                                        // Withdrawal successful
        }

        return false;                                           // Withdrawal failed due to invalid account or insufficient funds
    }

    private bool IsValidAccount(int account)
    {
        return account > 0 && account <= _balances.Count;       // Check if account number is within valid range (1 to n)
    }
}
