using CrudDapper.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudDapper.Data.IRepositories
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<IEnumerable<Teacher>> GetAllAsync(Func<Teacher, bool> predicate = null);

        Task<Teacher> GetAsync(int id);
    }
}
