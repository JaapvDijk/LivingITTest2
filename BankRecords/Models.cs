using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Linq;

namespace BankRecords
{
    public static class StatusMessage
    {
        public static string SUCCESSFUL { get { return "SUCCESSFUL"; } }
        public static string DUPLICATE_REFERENCE { get { return "DUPLICATE_REFERENCE"; } }
        public static string INTERNAL_SERVER_ERROR { get { return "INTERNAL_SERVER_ERROR"; } }
        public static string BAD_REQUEST { get { return "BAD_REQUEST"; } }
        public static string INCORRECT_END_BALANCE { get { return "INCORRECT_END_BALANCE"; } }
        public static string DUPLICATE_REFERENCE_INCORRECT_END_BALANCE { get { return "DUPLICATE_REFERENCE_INCORRECT_END_BALANCE"; } }
    }

    public class ReturnResult
    {
        public string Result { get; set; }
        public List<IErrorRecord> ErrorRecords { get; set; } = new List<IErrorRecord>();

        public (int, string) GetStatusCodeAndMessage(bool CorrectBalance, bool uniqueRefence)
        {
            switch ((CorrectBalance, uniqueRefence))
            {
                case (true, true):
                    return (200, StatusMessage.SUCCESSFUL);

                case (false, true):
                    return (400, StatusMessage.INCORRECT_END_BALANCE);

                case (true, false):
                    return (409, StatusMessage.DUPLICATE_REFERENCE);

                case (false, false):
                    return (400, StatusMessage.DUPLICATE_REFERENCE_INCORRECT_END_BALANCE);
            }
        }
    }

    public interface IErrorRecord
    {
        int Reference { get; set; }
        string AccountNumber { get; set; }
    }

    public class ErrorRecord : IErrorRecord
    {
        public int Reference { get; set; }
        public string AccountNumber { get; set; }
    }

    public class TransactionList
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public bool ReferenceIsUnique(int reference)
        {
            return !Transactions.Any(p => p.Reference == reference);
        }
    }

    public class Transaction : IErrorRecord
    {
        [Required]
        [RegularExpression("^[0-9]{8,10}$")]
        public int Reference { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]{2}[0-9]{2}[a-zA-Z0-9]{4}[0-9]{10}$")]
        public string AccountNumber { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [Range(-9000000, 9000000)]
        [DataType(DataType.Currency)]
        public decimal StartBalance { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(-18000000, 18000000)]
        public decimal Mutation { get; set; }

        [Required]
        [Range(-9000000, 9000000)]
        [DataType(DataType.Currency)]
        public decimal EndBalance { get; set; }

        public bool IsCorrectEndBalance()
        {
            return StartBalance + Mutation == EndBalance;
        }
    }
}
