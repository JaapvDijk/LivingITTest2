namespace BankRecords.Models
{
    public interface IErrorRecord
    {
        int Reference { get; set; }
        string AccountNumber { get; set; }
    }
}