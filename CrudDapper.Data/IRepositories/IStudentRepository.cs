using CrudDapper.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudDapper.Data.IRepositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllAsync(Func<Student, bool> predicate = null);

        Task<Student> GetAsync(int id);
    }
}
