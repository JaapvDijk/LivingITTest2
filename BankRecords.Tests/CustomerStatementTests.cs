using Xunit;
using BankRecords.Controllers;
using BankRecords.Services;

namespace BankRecords.Tests
{
    [Collection("TransactionCollection")]
    public class CustomerStatementTests
    {   
        private readonly TransactionService _transactions;
        private readonly CustomerStatementController _controller;

        public CustomerStatementTests(TransactionFixture transactionFixture)
        {
            _transactions = transactionFixture.Transactions;
            _controller = new CustomerStatementController(new TransactionService());
        }

        [Fact]
        public void CheckTransactions_ShouldReturnSomething()
        {
            var result = _controller.CheckTransaction(_transactions.Transactions[0]);
      
            Assert.NotNull(result);
        }

        // [Fact]
        // public void CheckTransactions_ShouldReturnSucces()
        // {
        //     var result = _controller.CheckTransaction(_transactions.Transactions[0]);

        //     Assert.Equal(StatusMessage.SUCCESSFUL, result.Value.Result);
        // }

        // [Fact]
        // public void CheckTransactions_ShouldReturnDuplicate()
        // {
        //     var result = _controller.CheckTransaction(_transactions.Transactions[0]);

        //     Assert.Equal(StatusMessage.DUPLICATE_REFERENCE, result.Value.Result);
        // }

        // [Fact]
        // public void CheckTransactions_ShouldReturnIncorrectBalance()
        // {
        //     var result = _controller.CheckTransaction(_transactions.Transactions[1]);

        //     Assert.Equal(StatusMessage.INCORRECT_END_BALANCE, result.Value.Result);
        // }

        // [Fact]
        // public void CheckTransactions_ShouldReturnDuplicateIncorrectBalance()
        // {
        //     var result = _controller.CheckTransaction(_transactions.Transactions[1]);

        //     Assert.Equal(StatusMessage.DUPLICATE_REFERENCE_INCORRECT_END_BALANCE, result.Value.Result);
        // }
    }
}
