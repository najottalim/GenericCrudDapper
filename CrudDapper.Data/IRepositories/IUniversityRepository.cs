using CrudDapper.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudDapper.Data.IRepositories
{
    public interface IUniversityRepository : IGenericRepository<University>, IDisposable
    {
        Task<IEnumerable<University>> GetAllAsync(Func<University, bool> predicate = null);

        Task<University> GetAsync(int id);
    }
}
