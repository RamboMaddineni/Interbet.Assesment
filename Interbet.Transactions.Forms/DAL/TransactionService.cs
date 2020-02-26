using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Interbet.Transactions.Forms.Models;
using System.Configuration;

namespace Interbet.Transactions.Forms.DAL
{
   public static class TransactionService
    {
        public static void InsertTransactions(CorporatePaymentsDto modal)
        {
            using(SqlConnection conn= new SqlConnection(ConfigurationManager.ConnectionStrings["InterbetConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertTransactions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountNumber", modal.AccountNumber);
                    cmd.Parameters.AddWithValue("@BankName", modal.BankName);
                    cmd.Parameters.AddWithValue("@BranchCode", modal.BranchCode);
                    cmd.Parameters.AddWithValue("@ChequeNumber", modal.ChequeNumber);
                    cmd.Parameters.AddWithValue("@DrCrIndicator", modal.DrCrIndicator);
                    cmd.Parameters.AddWithValue("@EffectiveDate", modal.EffectiveDate);
                    cmd.Parameters.AddWithValue("@Identifier", modal.Identifier);
                    cmd.Parameters.AddWithValue("@ReferenceNumber", modal.ReferenceNumber);
                    cmd.Parameters.AddWithValue("@TransactionAmount", modal.TransactionAmount);
                    cmd.Parameters.AddWithValue("@TransactionCode", modal.TransactionCode);
                    cmd.Parameters.AddWithValue("@TransactionDate", modal.TransactionDate);
                    cmd.Parameters.AddWithValue("@TransactionTime", modal.TransactionTime);
                    cmd.Parameters.AddWithValue("@UniqueInstanceID", modal.UniqueInstanceID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
