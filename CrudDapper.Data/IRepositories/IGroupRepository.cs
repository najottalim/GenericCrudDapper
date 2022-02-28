using CrudDapper.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudDapper.Data.IRepositories
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<IEnumerable<Group>> GetAllAsync(Func<Group, bool> predicate = null);

        Task<Group> GetAsync(int id);
    }
}
