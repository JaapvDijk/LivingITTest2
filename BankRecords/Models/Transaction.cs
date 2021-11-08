using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Linq;

namespace BankRecords.Models
{
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
