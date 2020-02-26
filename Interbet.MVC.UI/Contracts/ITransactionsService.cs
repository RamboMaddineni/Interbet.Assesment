using Interbet.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interbet.MVC.UI.Contracts
{
   public interface ITransactionsService
    {
        Task<IList<GetTransactions>> GetTransactions(GetTransactionByDates modal);
    }
}
