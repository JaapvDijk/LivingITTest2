using Xunit;

namespace BankRecords.Tests
{
    [Collection("TransactionCollection")]
    public class TransactionListTests
    {
        private readonly TransactionList _transactions;

        public TransactionListTests(TransactionFixture transactionFixture)
        {
            _transactions = transactionFixture.Transactions;
        }

        [Fact]
        public void ReferenceIsUnique_ShouldReturnTrue()
        {
            Transaction transaction = _transactions.Transactions[0];
            int reference = transaction.Reference + 123;

            Assert.True(_transactions.ReferenceIsUnique(reference));
        }

        [Fact]
        public void ReferenceIsUnique_ShouldReturnFalse()
        {
            Transaction transaction = _transactions.Transactions[0];

            Assert.False(_transactions.ReferenceIsUnique(transaction.Reference));
        }
    }
}