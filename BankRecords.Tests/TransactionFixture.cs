using System;
using System.IO;
using System.Security.Cryptography;
using BankRecords;
using Newtonsoft.Json.Linq;
using Xunit;

namespace BankRecords.Tests
{
    [CollectionDefinition("TransactionCollection")]
    public class TransactionCollection : ICollectionFixture<TransactionFixture> { }
    
    public class TransactionFixture
    {
        public readonly TransactionList Transactions;

        public TransactionFixture()
        {
            var path = Path.Combine(Environment.CurrentDirectory, @"../../../files/transactions.json");
            var json = JObject.Parse(File.ReadAllText(path));
            Transactions = json.ToObject<TransactionList>();
        }

    }

    
}
