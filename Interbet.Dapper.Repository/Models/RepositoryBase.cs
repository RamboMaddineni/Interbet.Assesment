using Interbet.Dapper.Repository.Contracts;
using Interbet.Dapper.Repository.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interbet.Dapper.Repository.Models
{
   public class RepositoryBase
    {
        public IDapperRepository _dapperRepository;
        public DbConnection _dbconnection { get; set; } = new DbConnection();

        public RepositoryBase(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }
    }
}
