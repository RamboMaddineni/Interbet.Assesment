using Interbet.Dapper.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interbet.Dapper.Repository.Contracts
{ 
    public interface IDapperRepository
    {
        Task<T> QueryOne<T>(DbConnection connection) where T : new();
        Task<IList<T>> QueryList<T>(DbConnection connection) where T : new();
        Task<int> Execute(DbConnection connection);
    }
}
