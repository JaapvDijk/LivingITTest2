using System.Collections.Generic;
using System.Linq;
using BankRecords.Models;
using BankRecords.Repositories;

namespace BankRecords.Services
{
    public class TransactionService
    {
        public List<Transaction> Transactions { get; set; }
        private CustomerStatementRepo _customerStatementRepo { get; set; }

        public TransactionService()
        {
            Transactions = new List<Transaction>();
            _customerStatementRepo = new CustomerStatementRepo(this);
        }

        public bool AddIfRefenceUnique(Transaction transaction)
        {
            bool isUnique = !Transactions.Any(p => p.Reference == transaction.Reference);

            if (isUnique) _customerStatementRepo.AddTransaction(transaction);

            return isUnique;
        }

        public (int, string) GetStatusCodeAndMessage(bool CorrectBalance, bool uniqueRefence)
        {
            switch ((CorrectBalance, uniqueRefence))
            {
                case (true, true):
                    return (200, StatusMessage.SUCCESSFUL);

                case (true, false):
                    return (409, StatusMessage.DUPLICATE_REFERENCE);

                case (false, true):
                    return (400, StatusMessage.INCORRECT_END_BALANCE);

                case (false, false):
                    return (400, StatusMessage.DUPLICATE_REFERENCE_INCORRECT_END_BALANCE);
            }
        }
    }
}