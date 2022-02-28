using CrudDapper.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudDapper.Data.IRepositories
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        Task<IEnumerable<Subject>> GetAllAsync(Func<Subject, bool> predicate = null);

        Task<Subject> GetAsync(int id);
    }
}
