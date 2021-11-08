using System.Collections.Generic;

namespace BankRecords.Models
{
    public class ReturnResult
    {
        public string Result { get; set; }
        public List<IErrorRecord> ErrorRecords { get; set; } = new List<IErrorRecord>();
    }
}