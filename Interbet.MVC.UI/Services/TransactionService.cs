using Interbet.Dapper.Repository.Contracts;
using Interbet.Dapper.Repository.Models;
using Interbet.MVC.UI.Contracts;
using Interbet.MVC.UI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Interbet.MVC.UI.Services
{
    public class TransactionService : RepositoryBase, ITransactionsService
    {
        private IConfiguration _configuration;
        public TransactionService(IDapperRepository _dapperRepository, IConfiguration configuration) : base(_dapperRepository)
        {
            _configuration = configuration;
            _dbconnection.ConnectionString = configuration.GetSection("InterbetConnectionString").Value;
        }
        public async Task<IList<GetTransactions>> GetTransactions(GetTransactionByDates modal)
        {

            try
            {
                _dbconnection.StoredProcedure = "spGetTransactionsByDateRange";
                _dbconnection.Parameters = modal;
                return await _dapperRepository.QueryList<GetTransactions>(_dbconnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
