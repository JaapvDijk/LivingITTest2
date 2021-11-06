using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace BankRecords.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerStatementController : ControllerBase
    {
        private TransactionList transactions;

        public CustomerStatementController(TransactionList transactions) 
        {
            this.transactions = transactions;
        }

        [HttpPost]
        public ActionResult<ReturnResult> CheckTransaction([FromBody] Transaction transaction)
        {
            ReturnResult returnResult = new ReturnResult();

            try
            {
                if (!ModelState.IsValid)
                {
                    returnResult.Result = StatusMessage.BAD_REQUEST;
                    return StatusCode(400, returnResult);
                }

                bool isCorrectBalance = transaction.IsCorrectEndBalance();
                bool isUniqueRefence = transactions.AddIfRefenceUnique(transaction);

                (int statusCode, string statusMessage) = 
                    returnResult.GetStatusCodeAndMessage(isCorrectBalance,
                                                         isUniqueRefence);

                if (statusCode > 200)
                    returnResult.ErrorRecords.Add(transaction);

                returnResult.Result = statusMessage;
                
                return StatusCode(statusCode, returnResult);
            }
            catch
            {
                returnResult.Result = StatusMessage.INTERNAL_SERVER_ERROR;
                return StatusCode(500, returnResult);
            }
        }
    }
}
