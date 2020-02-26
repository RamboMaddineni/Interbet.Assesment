using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Interbet.Transactions.Forms.Models;
using Interbet.Transactions.Forms.DAL;
using System.Globalization;

namespace Interbet.Transactions.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string folderPath = "C:\\xmlTest";

                foreach (string file in Directory.EnumerateFiles(folderPath, "*.txt"))
                {
                    string contents = File.ReadAllText(file);
                    var transaction = LoadFromXMLString(contents);

                    var effectiveDate = Convert.ToDateTime(DateTime.ParseExact(transaction.EffectiveDate, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                    var transactionDate = Convert.ToDateTime(DateTime.ParseExact(transaction.TransactionDate, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

                    CorporatePaymentsDto modal = new CorporatePaymentsDto
                    {
                        EffectiveDate = effectiveDate,
                        TransactionDate = transactionDate,
                        UniqueInstanceID = transaction.UniqueInstanceID,
                        TransactionCode = transaction.TransactionCode,
                        TransactionAmount = transaction.TransactionAmount,
                        TransactionTime = transaction.TransactionTime,
                        ChequeNumber = transaction.ChequeNumber,
                        DrCrIndicator = transaction.DrCrIndicator,
                        BankName = transaction.BankName,
                        BranchCode = transaction.BranchCode,
                        ReferenceNumber = transaction.ReferenceNumber,
                        AccountNumber = transaction.AccountNumber,
                        Identifier = transaction.Identifier
                    };

                    TransactionService.InsertTransactions(modal);

                    label1.Text = "Succesfully exported";

                }
            }
            catch (Exception ex)
            {

                label1.Text = ex.Message.ToString();
            }

        }

        public static CorporatePayments LoadFromXMLString(string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(CorporatePayments));


            return serializer.Deserialize(stringReader) as CorporatePayments;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
