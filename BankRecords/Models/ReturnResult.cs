using System.Collections.Generic;

namespace BankRecords.Models
{
    public class ReturnResult
    {
        public string Result { get; set; }
        public List<IErrorRecord> ErrorRecords { get; set; } = new List<IErrorRecord>();

        //Service..
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
