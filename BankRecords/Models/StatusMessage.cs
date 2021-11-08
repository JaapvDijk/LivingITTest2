namespace BankRecords.Models
{
    public static class StatusMessage
    {
        public static readonly string SUCCESSFUL = "SUCCESSFUL";
        public static readonly string DUPLICATE_REFERENCE = "DUPLICATE_REFERENCE";
        public static readonly string INTERNAL_SERVER_ERROR = "INTERNAL_SERVER_ERROR";
        public static readonly string BAD_REQUEST = "BAD_REQUEST"; 
        public static readonly string INCORRECT_END_BALANCE = "INCORRECT_END_BALANCE";
        public static readonly string DUPLICATE_REFERENCE_INCORRECT_END_BALANCE = "DUPLICATE_REFERENCE_INCORRECT_END_BALANCE";
    }
}
