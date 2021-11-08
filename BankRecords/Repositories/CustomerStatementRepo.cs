using BankRecords.Services;
using BankRecords.Models;

namespace BankRecords.Repositories
{
    public class CustomerStatementRepo
    {
        private TransactionService transactionService;

        public CustomerStatementRepo(TransactionService transactionService) 
        {
            this.transactionService = transactionService;
        }

        public void AddTransaction(Transaction transaction)
        {
            transactionService.Transactions.Add(transaction);
        }
    }
}