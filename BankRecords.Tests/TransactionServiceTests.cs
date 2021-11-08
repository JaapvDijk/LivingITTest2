using Xunit;
using BankRecords.Models;
using BankRecords.Services;

namespace BankRecords.Tests
{
    [Collection("TransactionCollection")]
    public class TransactionServiceTests
    {
        private readonly TransactionService _transactions;

        public TransactionServiceTests(TransactionFixture transactionFixture)
        {
            _transactions = transactionFixture.Transactions;
        }

        [Fact]
        public void ReferenceIsUnique_ShouldReturnTrue()
        {
            Transaction transaction = _transactions.Transactions[0];
            int reference = (transaction.Reference) + 1232;

            Assert.True(_transactions.AddIfRefenceUnique(transaction));
        }

        [Fact]
        public void ReferenceIsUnique_ShouldReturnFalse()
        {
            Transaction transaction = _transactions.Transactions[0];

            Assert.False(_transactions.AddIfRefenceUnique(transaction));
        }
    }
}