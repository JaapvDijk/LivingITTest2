using Microsoft.AspNetCore.Mvc;
using BankRecords.Models;
using BankRecords.Services;
using System;

namespace BankRecords.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerStatementController : ControllerBase
    {
        private TransactionService _transactionsService;

        public CustomerStatementController(TransactionService transactionsService) 
        {
            _transactionsService = transactionsService;
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
                bool isUniqueRefence = _transactionsService.AddIfRefenceUnique(transaction);

                (int statusCode, string statusMessage) = 
                    _transactionsService.GetStatusCodeAndMessage(isCorrectBalance,
                                                         isUniqueRefence);

                if (statusCode > 200)
                    returnResult.ErrorRecords.Add(transaction);

                returnResult.Result = statusMessage;

                return StatusCode(statusCode, returnResult);
            }
            catch(Exception e)
            {
                returnResult.Result = StatusMessage.INTERNAL_SERVER_ERROR;
                return StatusCode(500, returnResult);
            }
        }
    }
}
