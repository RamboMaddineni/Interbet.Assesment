using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interbet.MVC.UI.Contracts;
using Interbet.MVC.UI.Models;
using Interbet.MVC.UI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interbet.MVC.UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionsService _transactionService;
        public TransactionController(ITransactionsService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ResponseModel>> GetTransactionByDates(string FromDate, string Todate)
        {

            var modal = new GetTransactionByDates
            {
                FromDate = Convert.ToDateTime(FromDate),
                ToDate = Convert.ToDateTime(Todate)
            };

            IList<GetTransactions> result = await _transactionService.GetTransactions(modal);
            return ResponseUtility.CreateResponse(result);
        }

    }
}