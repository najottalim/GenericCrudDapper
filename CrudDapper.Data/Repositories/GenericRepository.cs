using CrudDapper.Data.IRepositories;
using CrudDapper.Domain.Customs;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CrudDapper.Data.Repositories
{
#pragma warning disable
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal IDbConnection _db;
        public GenericRepository()
        {
            _db = new SqlConnection(Constants.CONNECTION_DB);
        }
        public async Task CreateAsync(string query, DynamicParameters parameters, CommandType cmdType = CommandType.StoredProcedure)
        {
            await _db.QueryFirstOrDefaultAsync<T>(query, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(string query, DynamicParameters parameters, CommandType cmdType = CommandType.StoredProcedure)
        {
            await _db.QueryFirstOrDefaultAsync<T>(query, parameters, commandType: cmdType);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task UpdateAsync(string query, DynamicParameters parameters, CommandType cmdType = CommandType.StoredProcedure)
        {
            await _db.QueryAsync<T>(query, parameters, commandType: cmdType);
        }
    }
}
