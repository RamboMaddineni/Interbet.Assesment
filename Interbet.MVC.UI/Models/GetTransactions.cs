using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interbet.MVC.UI.Models
{
    public class GetTransactions
    {
        public string UniqueInstanceID { get; set; }
       
        public string EffectiveDate { get; set; }
        
        public int TransactionCode { get; set; }
        
        public string TransactionAmount { get; set; }
        
        public string TransactionDate { get; set; }
        
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
