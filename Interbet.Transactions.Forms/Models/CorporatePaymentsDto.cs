using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interbet.Transactions.Forms.Models
{
    public class CorporatePaymentsDto
    {

        public string UniqueInstanceID { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int TransactionCode { get; set; }

        public string TransactionAmount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TransactionTime { get; set; }

        public string ChequeNumber { get; set; }

        public string DrCrIndicator { get; set; }

        public string BankName { get; set; }

        public int BranchCode { get; set; }

        public string ReferenceNumber { get; set; }

        public string AccountNumber { get; set; }

        public string Identifier { get; set; }
    }
}

