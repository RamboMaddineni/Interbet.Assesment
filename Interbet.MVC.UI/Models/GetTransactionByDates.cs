using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interbet.MVC.UI.Models
{
    public class GetTransactionByDates
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
