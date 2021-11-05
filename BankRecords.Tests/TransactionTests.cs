using Xunit;

namespace BankRecords.Tests
{
    [Collection("TransactionCollection")]
    public class TransactionTests
    {
        private readonly TransactionList _transactions;

        public TransactionTests(TransactionFixture transactionFixture)
        {
            _transactions = transactionFixture.Transactions;
        }

        [Fact]
        public void IsCorrectEndBalance_ShouldReturnTrue()
        {
            Transaction transaction = _transactions.Transactions[0];
            Assert.True(transaction.IsCorrectEndBalance());
        }

        [Fact]
        public void IsCorrectEndBalance_ShouldReturnFalse()
        {
            Transaction transaction = _transactions.Transactions[1];
            Assert.False(transaction.IsCorrectEndBalance());
        }
    }
}