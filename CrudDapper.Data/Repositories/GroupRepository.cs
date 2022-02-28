using CrudDapper.Data.IRepositories;
using CrudDapper.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDapper.Data.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public async Task<IEnumerable<Group>> GetAllAsync(Func<Group, bool> predicate = null)
        {
            var groups = await _db.QueryAsync<Group, Student, Teacher, Group>(
                $"SELECT gr.*, tch.*, st.* FROM GroupTeacher as grtch " +
                $"INNER JOIN Groups as gr on gr.id = grtch.GroupId " +
                $"INNER JOIN Teachers as tch on tch.id = grtch.TeacherId " +
                $"INNER JOIN Students as st on st.GroupId = gr.id;", (gr, st, tch) =>
                {
                    Group group = gr;

                    group.Teachers.Add(tch);
                    group.Students.Add(st);

                    return group;
                });
            return predicate == null ? groups : groups.Where(predicate);
        }

        public async Task<Group> GetAsync(int id)
        {
            var groups = await _db.QueryAsync<Group, Student, Teacher, Group>(
                $"SELECT gr.*, tch.*, st.* FROM GroupTeacher as grtch " +
                $"INNER JOIN Groups as gr on gr.id = grtch.GroupId " +
                $"INNER JOIN Teachers as tch on tch.id = grtch.TeacherId " +
                $"INNER JOIN Students as st on st.GroupId = gr.id;", (gr, st, tch) =>
                {
                    Group group = gr;

                    group.Teachers.Add(tch);
                    group.Students.Add(st);

                    return group;
                });
            return groups.FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
