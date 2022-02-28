using CrudDapper.Data.IRepositories;
using CrudDapper.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDapper.Data.Repositories
{
    public class UniversityRepository : GenericRepository<University>, IUniversityRepository
    {
        public async Task<IEnumerable<University>> GetAllAsync(Func<University, bool> predicate = null)
        {

            var universities = await _db.QueryAsync<University, Group, University>(
                $"SELECT un.*, gr.* FROM Universities as un " +
                $"INNER JOIN Groups as gr on un.id = gr.UniversityId " +
                $"INNER JOIN Students as st on st.GroupId = gr.id;", (un, gr) =>
                {
                    University university = un;

                    university.Groups.Add(gr);

                    return university;
                });
            return predicate == null ? universities : universities.Where(predicate);
        }

        public async Task<University> GetAsync(int id)
        {

            var university = await _db.QueryAsync<University, Group, University>(
                $"SELECT un.*, gr.* FROM Universities as un " +
                $"INNER JOIN Groups as gr on un.id = gr.UniversityId " +
                $"WHERE un.id = {id};", (un, gr) =>
                    {
                        University university = un;
                        university.Groups.Add(gr);

                        return university;
                    });

            return university.FirstOrDefault(p => p.Id == id);
        }
    }
}
