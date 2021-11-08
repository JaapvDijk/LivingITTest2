namespace BankRecords.Models
{
    public class ErrorRecord : IErrorRecord
    {
        public int Reference { get; set; }
        public string AccountNumber { get; set; }
    }
}