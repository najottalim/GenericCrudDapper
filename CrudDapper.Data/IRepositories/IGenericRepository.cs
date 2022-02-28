using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace CrudDapper.Data.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(string query, DynamicParameters parameters, CommandType cmdType = CommandType.StoredProcedure);

        Task DeleteAsync(string query, DynamicParameters parameters, CommandType cmdType = CommandType.StoredProcedure);

        Task UpdateAsync(string query, DynamicParameters parameters, CommandType cmdType = CommandType.StoredProcedure);

    }
}
